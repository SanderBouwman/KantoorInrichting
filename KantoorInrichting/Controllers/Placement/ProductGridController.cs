// created by: Robin
// on: 20-12-2015

#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using KantoorInrichting.Controllers.Algorithm;
using KantoorInrichting.Controllers.Algorithm.TestSetup;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Views;
using KantoorInrichting.Views.Placement;

#endregion

namespace KantoorInrichting.Controllers.Placement
{
    public class ProductGridController : IController
    {
        private readonly List<Algorithm> comboBoxAlgorithms;
        private readonly float meterHeight;
        private readonly float meterWidth;

        private readonly List<PlacedProduct> placedProducts;

        private readonly float tileSize;

        private readonly IView<ProductGrid.PropertyEnum> view;

        private float tileWidth, tileHeight;
        private Rectangle zoomArea;

        private bool zoomCheckboxChecked;
        private int zoomSize;


        public ProductGridController(IView<ProductGrid.PropertyEnum> view,
            float meterWidth, float meterHeight, float tileSize)
        {
            // set controller
            view.SetController(this);

            // Set parameters to fields
            this.meterWidth = meterWidth;
            this.meterHeight = meterHeight;
            this.tileSize = tileSize;
            this.view = view;

            // Init fields with default values
            zoomSize = 50;
            zoomArea = new Rectangle(0, 0, zoomSize, zoomSize);
            placedProducts = new List<PlacedProduct>();
            comboBoxAlgorithms = new List<Algorithm>();

            // Init algorithm combobox
            PopulateAlgorithms();
        }

        public void Paint(object sender, PaintEventArgs e)
        {
            if (zoomCheckboxChecked)
                e.Graphics.DrawRectangle(Pens.Red, zoomArea);

            PaintProducts(e.Graphics);
        }

        public void Notify(object sender, EventArgs e)
        {
            // Made a switch using lambda expressions in a dictionary, since you can not do a switch on types
            var @switch = new Dictionary<Type, Action>
            {
                {typeof (EventArgs), () => HandleOtherEvent(sender, e)},
                {typeof (LayoutEventArgs), () => LayoutChanged(sender, (LayoutEventArgs) e)},
                {typeof (MouseEventArgs), () => HandleMouseEvent(sender, (MouseEventArgs) e)}
            };
            Type typeToCheck = e.GetType();
            @switch[typeToCheck]();
        }

        public void Dispose(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #region Event methods

        public void HandleMouseEvent(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == typeof (Button))
                HandleButtonEvent(sender, e);
            if (zoomCheckboxChecked)
            {
                UpdateRectangle(e.X, e.Y, view.Get(ProductGrid.PropertyEnum.Panel).Width,
                    view.Get(ProductGrid.PropertyEnum.Panel).Height);

                view.Get(ProductGrid.PropertyEnum.Panel).Invalidate();
            }
        }

        public void HandleOtherEvent(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof (CheckBox))
                HandleCheckBoxEvent(sender, e);
            if (sender.GetType() == typeof (TrackBar))
            {
                TrackBar trackBar = (TrackBar) sender;
                zoomSize = trackBar.Value;
            }
        }

        public void HandleButtonEvent(object sender, MouseEventArgs e)
        {
            Button button = (Button) sender;
            if (button.Text == "Start")
            {
                ComboBox algorithmComboBox = (ComboBox) view.Get(ProductGrid.PropertyEnum.AlgorithmComboBox);
                Algorithm selectedAlgorithm = (Algorithm) algorithmComboBox.SelectedItem;
                // Example chair and table
                ProductModel chair = ProductFactory.CreateProduct("Ahrend", 1, 1, "Stoelen");
                ProductModel table = ProductFactory.CreateProduct("TableCompany", 2, 1, "Tafels");

                // TODO open dialog to ask for amount of people and the margin
                int people = 7;
                float margin = 0.5f;
                StartAlgorithm(selectedAlgorithm, chair, table, people, margin);

                view.Get(ProductGrid.PropertyEnum.Panel).Invalidate();
            }
        }


        public void HandleCheckBoxEvent(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox) sender;
            zoomCheckboxChecked = checkBox.Checked;
            view.Get(ProductGrid.PropertyEnum.Trackbar).Enabled = zoomCheckboxChecked;
            if (zoomCheckboxChecked)
            {
                // TODO open zoomview
            }
            else
                view.Get(ProductGrid.PropertyEnum.Panel).Invalidate();
        }

        public void LayoutChanged(object sender, LayoutEventArgs e)
        {
            Control panel = view.Get(ProductGrid.PropertyEnum.Panel);
            panel.BackgroundImage = CreateBackground(panel.Size);
        }

        #endregion

        #region Helper methods

        private void PaintProducts(Graphics g)
        {
            int x = 0,
                y = 0;
            foreach (PlacedProduct product in placedProducts)
                PaintProduct(product, g);
        }

        private void PaintProduct(PlacedProduct product, Graphics g)
        {
            Rectangle rectangle = new Rectangle
            {
                Height = (int) (product.product.Height/tileSize*tileHeight),
                Width = (int) (product.product.Width/tileSize*tileWidth),
                X = (int) ((product.location.X - product.product.Width/2)/tileSize*tileWidth),
                Y = (int) ((product.location.Y - product.product.Height/2)/tileSize*tileHeight)
            };

            SolidBrush brush = SelectBrush(product);

            if (brush != null)
                g.FillRectangle(brush, rectangle);
        }

        public SolidBrush SelectBrush(PlacedProduct product)
        {
            Dictionary<string, SolidBrush> legendDictionary =
                ((Legend) view.Get(ProductGrid.PropertyEnum.Legend)).categoryColors;
            SolidBrush brush = legendDictionary.Single(pair => pair.Key.Equals(product.product.Type)).Value;
            return brush;
        }

        public void StartAlgorithm(Algorithm algorithm, ProductModel model1, ProductModel model2, int people,
            float margin)
        {
            // clear current placed products
            placedProducts.Clear();
            Type selectedType = algorithm.Value;
            IDesignAlgorithm algoInstance = (IDesignAlgorithm) Activator.CreateInstance(selectedType);
            List<ProductModel> result = algoInstance.Design(model1, model2, people, meterWidth, meterHeight, margin);
            foreach (ProductModel model in result)
            {
                // flip width and height, because the algorithm gives relative [width, height] according to the orientation
                int width = model.Width;
                model.Width = model.Height;
                model.Height = width;
                PointF modelLocation = model.location;
                PointF center = new PointF
                {
                    X = modelLocation.X + model.Width/2,
                    Y = modelLocation.Y + model.Height/2
                };
                PlacedProduct product = new PlacedProduct(model, center);
                placedProducts.Add(product);
            }
        }

        public void UpdateRectangle(int x, int y, int? maxX, int? maxY)
        {
            if (maxX.HasValue && maxY.HasValue && zoomCheckboxChecked)
            {
                int boundX = (int) maxX;
                int boundY = (int) maxY;
                zoomArea.Width = zoomSize;
                zoomArea.Height = zoomSize;
                zoomArea.X = x - zoomArea.Width/2;
                zoomArea.Y = y - zoomArea.Height/2;
                if (zoomArea.Right > boundX)
                    zoomArea.X = boundX - zoomArea.Width;
                if (zoomArea.Bottom > boundY)
                    zoomArea.Y = boundY - zoomArea.Height;
                if (zoomArea.Top < 0)
                    zoomArea.Y = 0;
                if (zoomArea.Left < 0)
                    zoomArea.X = 0;
            }
        }

        /// <summary>
        /// Creates the background image used by the panel.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public Bitmap CreateBackground(Size size)
        {
            UpdateTileSize(size);
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            using (Graphics gfx = Graphics.FromImage(bitmap))
            {
                for (float x = 0; x < size.Width; x += tileWidth)
                    gfx.DrawLine(Pens.Black, x, 0, x, size.Height);
                for (float y = 0; y < size.Height; y += tileHeight)
                    gfx.DrawLine(Pens.Black, 0, y, size.Width, y);
            }
            return bitmap;
        }

        /// <summary>
        /// Updates the tileHeight and tileSize fields.
        /// </summary>
        /// <param name="size"></param>
        public void UpdateTileSize(Size size)
        {
            tileWidth = size.Width/meterWidth*tileSize;
            tileHeight = size.Height/meterHeight*tileSize;
        }

        #endregion

        #region Other methods

        // This method is here to populate the algorithms until
        // someone wants to update that process
        public void PopulateAlgorithms()
        {
            // Standard test setup algorithm
            AddToComboBox(Algorithm.CreateAlgorithm("Toets lokaal", typeof (TestSetupDesign)));
        }

        public void AddToComboBox(Algorithm algorithm)
        {
            comboBoxAlgorithms.Add(algorithm);
            ComboBox comboBox = (ComboBox) view.Get(ProductGrid.PropertyEnum.AlgorithmComboBox);
            comboBox.DataSource = comboBoxAlgorithms;
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "Value";
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        #endregion
    }

    public class Algorithm
    {
        public string Name { get; set; }
        public Type Value { get; set; }

        public static Algorithm CreateAlgorithm(string name, Type value)
        {
            return new Algorithm
            {
                Name = name,
                Value = value
            };
        }
    }
}