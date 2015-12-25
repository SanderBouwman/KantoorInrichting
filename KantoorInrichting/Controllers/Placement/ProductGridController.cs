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
                {typeof (MouseEventArgs), () => HandleMouseEvent(sender, (MouseEventArgs) e)},
                {typeof (DragEventArgs), () =>  HandleDragEvents(sender, (DragEventArgs) e)}
            };
            Type typeToCheck = e.GetType();
            @switch[typeToCheck]();
        }

        public void Dispose(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #region Event methods

        public void HandleDragEvents(object sender, DragEventArgs e)
        {
            ProductModel model;
            if ((model = (ProductModel) e.Data.GetData(typeof (ProductModel))) != null) // if so, this is a new product
            {
                AddNewProduct(model, e.X, e.Y);
                view.Get(ProductGrid.PropertyEnum.Panel).Invalidate();
            }
            else // selected item is a PlacedProduct, and so is already in the field
            {
                PlacedProduct temp = (PlacedProduct) e.Data.GetData(typeof (PlacedProduct));
                Console.WriteLine(temp);
            }
        }

        public void AddNewProduct(ProductModel model, int x, int y)
        {
            float viewWidth = view.Get(ProductGrid.PropertyEnum.Panel).Width,
                viewHeight = view.Get(ProductGrid.PropertyEnum.Panel).Height;
            float newX = (x/viewWidth)*meterWidth,
                newY = (y/viewHeight)*meterHeight,
                newWidth = (float) model.Width/100,
                newHeight = (float) model.Height/100;
            PointF center = new PointF()
            {
                X = newX-(newWidth/2),
                Y = newY-(newHeight/2)
            };

            SizeF size = new SizeF(newWidth, newHeight);
            model.Size = size;
            this.placedProducts.Add(new PlacedProduct(model, center));
        }

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

                int people;
                float margin;

                using (AlgorithmDialog dialog = new AlgorithmDialog())
                {
                    dialog.ShowDialog();
                    people = (int) dialog.Result["People"];
                    margin = dialog.Result["Margin"];
                }

                ComboBox algorithmComboBox = (ComboBox) view.Get(ProductGrid.PropertyEnum.AlgorithmComboBox);
                Algorithm selectedAlgorithm = (Algorithm) algorithmComboBox.SelectedItem;
                // Example chair and table
                ProductModel chair = ProductFactory.CreateProduct("Ahrend", 1, 1, "Stoelen");
                ProductModel table = ProductFactory.CreateProduct("TableCompany", 2, 1, "Tafels");
                
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
            foreach (PlacedProduct product in placedProducts)
                PaintProduct(product, g);
        }


        private void PaintProduct(PlacedProduct product, Graphics g)
        {
            Rectangle rectangle = GetProductRectangle(product);
            SolidBrush brush = SelectBrush(product);

            g.FillRectangle(brush, rectangle);
        }

        public Rectangle GetProductRectangle(PlacedProduct product)
        {
            Rectangle rectangle;
            if( product.product.Size.IsEmpty ) {
                rectangle = new Rectangle {
                    Height = ( int ) ( ( product.product.Height / tileSize ) * tileHeight ),
                    Width = ( int ) ( ( product.product.Width / tileSize ) * tileWidth ),
                    X = ( int ) ( ( ( product.location.X - ( product.product.Width / 2 ) ) / tileSize ) * tileWidth ),
                    Y = ( int ) ( ( ( product.location.Y - ( product.product.Height / 2 ) ) / tileSize ) * tileHeight )
                };
            } else {
                rectangle = new Rectangle() {
                    Height = ( int ) ( ( product.product.Size.Height / tileSize ) * tileHeight ),
                    Width = ( int ) ( ( product.product.Size.Width / tileSize ) * tileWidth ),
                    X = ( int ) ( ( product.location.X / tileSize ) * tileWidth ),
                    Y = ( int ) ( ( product.location.Y / tileSize ) * tileHeight )
                };
            }
            return rectangle;
        }

        /// <summary>
        /// Selects the brush where the type matches from the Dictionary kept in the Legend.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public SolidBrush SelectBrush(PlacedProduct product)
        {
            Dictionary<string, SolidBrush> legendDictionary =
                ((Legend) view.Get(ProductGrid.PropertyEnum.Legend)).categoryColors;

            SolidBrush brush;
            try
            {
                brush = legendDictionary.Single(pair => pair.Key.Equals(product.product.Type)).Value;
            }
            catch (InvalidOperationException e)
            {
                // This means that the type is not found in the dictionary, and so I will set the brush to Black
                brush = new SolidBrush(Color.Black);
            }
            return brush;
        }

        /// <summary>
        /// Starts the selected algorithm.
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="model1"></param>
        /// <param name="model2"></param>
        /// <param name="people"></param>
        /// <param name="margin"></param>
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