// created by: Robin
// on: 20-12-2015

#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using KantoorInrichting.Controllers.Algorithm;
using KantoorInrichting.Controllers.Algorithm.TestSetup;
using KantoorInrichting.Models.Algorithm;
using KantoorInrichting.Models.Grid;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Views;
using KantoorInrichting.Views.Placement;

#endregion

namespace KantoorInrichting.Controllers.Placement
{
    public class ProductGridController : IController
    {
        private readonly List<AlgorithmModel> comboBoxAlgorithms;
        private readonly float meterHeight;
        private readonly float meterWidth;

        private readonly List<PlacedProduct> placedProducts;

        private readonly float tileSize;
        private readonly ProductGridUtility utility;

        private readonly IView<ProductGrid.PropertyEnum> view;
        private bool draggingProduct;
        private PlacedProduct selectedProduct;

        private float tileWidth, tileHeight;
        private Rectangle zoomArea;

        private bool zoomCheckboxChecked;
        private int zoomSize;

        private readonly Dictionary<string, SolidBrush> legendDictionary;


        public ProductGridController(IView<ProductGrid.PropertyEnum> view,
            float meterWidth, float meterHeight, float tileSize)
        {
            // set controller
            view.SetController(this);

            utility = new ProductGridUtility();
            // Set parameters to fields
            this.meterWidth = meterWidth;
            this.meterHeight = meterHeight;
            this.tileSize = tileSize;
            this.view = view;
            draggingProduct = false;

            // Init fields with default values
            zoomSize = 50;
            zoomArea = new Rectangle(0, 0, zoomSize, zoomSize);
            placedProducts = new List<PlacedProduct>();
            comboBoxAlgorithms = new List<AlgorithmModel>();
             legendDictionary = ( ( Legend ) view.Get(ProductGrid.PropertyEnum.Legend) ).CategoryColors;
            // Init algorithm combobox
            PopulateAlgorithms();
        }

        public void Paint(object sender, PaintEventArgs e)
        {
            if (zoomCheckboxChecked)
                e.Graphics.DrawRectangle(Pens.Red, zoomArea);

            PaintProducts(e.Graphics);
        }

        public void Notify(object sender, EventArgs e, string eventName)
        {
            // Made a switch using lambda expressions in a dictionary, since you can not do a switch on types
            var @switch = new Dictionary<Type, Action>
            {
                {typeof (EventArgs), () => HandleOtherEvent(sender, e)},
                {typeof (LayoutEventArgs), () => LayoutChanged(sender, (LayoutEventArgs) e)},
                {typeof (MouseEventArgs), () => HandleMouseEvent(sender, (MouseEventArgs) e, eventName)},
                {typeof (DragEventArgs), () => HandleDragEvents(sender, (DragEventArgs) e, eventName)}
            };
            Type typeToCheck = e.GetType();
            @switch[typeToCheck]();
        }

        public void Dispose(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #region Event methods

        public void HandleDragEvents(object sender, DragEventArgs e, string eventName)
        {
            switch (eventName)
            {
                case "PanelDragDrop":
                    DragDrop(sender, e);
                    break;
                case "PanelDragEnter":
                    DragEnter(sender, e);
                    break;
            }
        }

        public void DragDrop(object sender, DragEventArgs e)
        {
            ProductModel model;
            if ((model = (ProductModel) e.Data.GetData(typeof (ProductModel))) != null) // if so, this is a new product
            {
                AddNewProduct(model, e.X, e.Y, (float) model.Width/100, (float) model.Height/100, false);
                view.Get(ProductGrid.PropertyEnum.Panel).Invalidate();
            }
            else // selected item is a PlacedProduct, and so is already in the field
            {
                PlacedProduct temp = (PlacedProduct) e.Data.GetData(typeof (PlacedProduct));
                Console.WriteLine(temp);
            }
        }

        public void DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof (PlacedProduct)) || e.Data.GetDataPresent(typeof (ProductModel)))
                e.Effect = e.AllowedEffect;
            else
                e.Effect = DragDropEffects.None;
        }

        public void HandleMouseEvent(object sender, MouseEventArgs e, string eventName)
        {
            if (sender is Button)
                HandleButtonEvent(sender, e);
            if (sender is GridFieldPanel && e.Clicks > 0 && eventName == "PanelMouseDown")
                PanelMouseDown(sender, e);
            if (sender is GridFieldPanel && e.Button == MouseButtons.Left && eventName == "PanelMouseMove")
                PanelMouseMove(sender, e);
            if (zoomCheckboxChecked)
            {
                UpdateRectangle(e.X, e.Y, view.Get(ProductGrid.PropertyEnum.Panel).Width,
                    view.Get(ProductGrid.PropertyEnum.Panel).Height);

                view.Get(ProductGrid.PropertyEnum.Panel).Invalidate();
            }
        }

        public void PanelMouseDown(object sender, MouseEventArgs e)
        {
            PlacedProduct product = utility.GetProductFromField(e.Location, placedProducts, tileWidth, tileHeight,
                tileSize);
            
            if (product != null)
            {
                selectedProduct = product;
                draggingProduct = true;

                selectedProduct.OriginalLocation = selectedProduct.location;
            }
        }

        public void PanelMouseMove(object sender, MouseEventArgs e)
        {
            bool xInField = e.X > 0 && e.X < view.Get(ProductGrid.PropertyEnum.Panel).Width,
                yInField = e.Y > 0 && e.Y < view.Get(ProductGrid.PropertyEnum.Panel).Height,
                validDrag = draggingProduct && selectedProduct != null;
            if (validDrag && xInField && yInField)
                MoveSelectedProduct(e.X, e.Y);
        }

        public void MoveSelectedProduct(int x, int y)
        {
            float selectedWidth = selectedProduct.product.Size.Width,
                selectedHeight = selectedProduct.product.Size.Height;

            int panelWidth = view.Get(ProductGrid.PropertyEnum.Panel).Width,
                panelHeight = view.Get(ProductGrid.PropertyEnum.Panel).Height;

            float newX = x/(float) panelWidth*meterWidth
                         - selectedWidth/2,
                newY = y/(float) panelHeight*meterHeight
                       - selectedHeight/2;

            if (newX <= 0)
                newX = 0;
            if (newX + selectedWidth/2 >= meterWidth)
                newX = meterWidth - selectedWidth*2;
            if (newY <= 0)
                newY = selectedHeight/2;
            if (newY + selectedHeight/2 >= meterHeight)
                newY = meterHeight - selectedHeight;
            
            PointF newLocation = new PointF(newX, newY);
            selectedProduct.location = !utility.Collision(selectedProduct, placedProducts) 
                ? newLocation 
                : selectedProduct.OriginalLocation;
            view.Get(ProductGrid.PropertyEnum.Panel).Invalidate();
        }

        public void HandleOtherEvent(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof (CheckBox))
                HandleCheckBoxEvent(sender, e);
            if (sender.GetType() == typeof (TrackBar))
                HandleTrackbarEvent(sender, e);
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
                    if (dialog.Result.Count > 0)
                    {
                        people = (int) dialog.Result["People"];
                        margin = dialog.Result["Margin"];
                    }
                    else
                    {
                        people = 0;
                        margin = 0;
                    }
                }

                ComboBox algorithmComboBox = (ComboBox) view.Get(ProductGrid.PropertyEnum.AlgorithmComboBox);
                AlgorithmModel selectedAlgorithm = (AlgorithmModel) algorithmComboBox.SelectedItem;
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

        public void HandleTrackbarEvent(object sender, EventArgs e)
        {
            TrackBar trackBar = (TrackBar) sender;
            zoomSize = trackBar.Value;
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
            Rectangle rectangle = utility.GetProductRectangle(product, tileWidth, tileHeight, tileSize);
            SolidBrush brush = utility.SelectBrush(product, legendDictionary);
            g.FillRectangle(brush, rectangle);
        }

        public void AddNewProduct(ProductModel model, float x, float y, float width, float height, bool realDimensions)
        {
            float viewWidth = view.Get(ProductGrid.PropertyEnum.Panel).Width,
                viewHeight = view.Get(ProductGrid.PropertyEnum.Panel).Height;
            float newX = (realDimensions) ? x : x/viewWidth*meterWidth,
                newY = (realDimensions) ? y : y/viewHeight*meterHeight;
            PointF center;

            if(!realDimensions)
                center = new PointF {
                    X = newX - width / 2,
                    Y = newY - height / 2
                };
            else
                center = new PointF {
                    X = x + model.Width / 2,
                    Y = y + model.Height / 2
                };

            SizeF size = new SizeF(width, height);
            model.Size = size;
            PlacedProduct newProduct = new PlacedProduct(model, center);


            // Do not add product to field if it has collision
            if(!utility.Collision(newProduct, placedProducts))
                placedProducts.Add(newProduct);
        }

        /// <summary>
        /// Starts the selected algorithm.
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="model1"></param>
        /// <param name="model2"></param>
        /// <param name="people"></param>
        /// <param name="margin"></param>
        public void StartAlgorithm(AlgorithmModel algorithm, ProductModel model1, ProductModel model2, int people,
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
                AddNewProduct(model, model.location.X, model.location.Y, model.Width, model.Height, true);
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
            AddToComboBox(AlgorithmModel.CreateAlgorithm("Toets lokaal", typeof (TestSetupDesign)));
        }

        public void AddToComboBox(AlgorithmModel algorithm)
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
}