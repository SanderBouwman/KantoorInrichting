// created by: Robin
// on: 20-12-2015

#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using KantoorInrichting.Controllers.Algorithm;
using KantoorInrichting.Controllers.Algorithm.TestSetup;
using KantoorInrichting.Controllers.Placement.Handler;
using KantoorInrichting.Models.Algorithm;
using KantoorInrichting.Models.Grid;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Models.Space;
using KantoorInrichting.Views;
using KantoorInrichting.Views.Grid;
using KantoorInrichting.Views.Placement;

#endregion

namespace KantoorInrichting.Controllers.Placement
{
    public class ProductGridController : IController
    {
        private static readonly List<PlacedProduct> placedProducts = new List<PlacedProduct>();
        private readonly DatabaseController _dbc = DatabaseController.Instance;
        private readonly ICollisionHandler<PlacedProduct> collisionHandler;
        private readonly List<AlgorithmModel> comboBoxAlgorithms;
        private readonly Dictionary<string, SolidBrush> legendDictionary;
        private readonly ProductGridUtility utility;

        private readonly IView<ProductGrid.PropertyEnum> view;

        private readonly DatabaseController dbc = DatabaseController.Instance;

        private bool draggingProduct;
        private int lastCount;

        private float meterHeight;
        private float meterWidth;

        private ProductGrid productGrid;

        private PlacedProduct selectedProduct;
        private Space space;
        private float tileHeight;
        private float tileSize;
        private float tileWidth;
        private Bitmap viewContent, zoomContent;
        private Rectangle zoomArea;
        private bool zoomCheckboxChecked;
        private int zoomSize;
        private ZoomView zoomView;

        public ProductGridController(IView<ProductGrid.PropertyEnum> view,
            float meterWidth, float meterHeight, float tileSize)
        {
            utility = new ProductGridUtility();
            collisionHandler = new ProductGridCollisionHandler();
            // Set parameters to fields
            this.meterWidth = meterWidth;
            this.meterHeight = meterHeight;
            this.tileSize = tileSize;
            this.view = view;

            // set controller
            this.view.SetController(this);
            legendDictionary = ((Legend)view.Get(ProductGrid.PropertyEnum.Legend)).CategoryColors;

            // Init fields with default values
            zoomSize = 50;
            zoomArea = new Rectangle(0, 0, zoomSize, zoomSize);
            comboBoxAlgorithms = new List<AlgorithmModel>();
            draggingProduct = false;
            zoomContent = new Bitmap(zoomSize, zoomSize);
            // Init algorithm combobox
            PopulateAlgorithms();
        }

        public void Paint(object sender, PaintEventArgs e)
        {
            if (zoomCheckboxChecked)
                e.Graphics.DrawRectangle(Pens.Red, zoomArea);

            e.Graphics.DrawImage(PaintProducts(), Point.Empty);
        }

        public void Notify(object sender, EventArgs e, string eventName)
        {
            // Made a switch using lambda expressions in a dictionary, since you can not do a switch on types
            var @switch = new Dictionary<Type, Action>
            {
                {typeof (EventArgs), () => HandleOtherEvent(sender, e, eventName)},
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

        private Bitmap GetPanelImage()
        {
            if (viewContent != null)
            {
                if (zoomSize > zoomContent.Width)
                    zoomContent = new Bitmap(zoomSize, zoomSize);

                using (Graphics g = Graphics.FromImage(zoomContent))
                {
                    g.Clear(Color.Empty);
                    g.DrawImage(viewContent, 0, 0, zoomArea, GraphicsUnit.Pixel);
                    g.Dispose();
                }
            }
            return zoomContent;
        }

        public static int PlacementCount(ProductModel model)
        {
            int count = 0;
            foreach (PlacedProduct placedproduct in placedProducts)
            {
                if (placedproduct.Product.ProductId == model.ProductId)
                    count++;
            }
            return count;
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

        public void HandleMouseEvent(object sender, MouseEventArgs e, string eventName)
        {
            if (sender is Button)
                HandleButtonEvent(sender, e, eventName);
            if (sender is GridFieldPanel && e.Clicks > 0 && eventName == "PanelMouseDown")
                PanelMouseDown(sender, e);
            if (sender is GridFieldPanel && eventName == "PanelMouseMove" && e.Button == MouseButtons.Left)
                PanelMouseDrag(sender, e);
            if (sender is GridFieldPanel && eventName == "PanelMouseMove" && e.Button == MouseButtons.None)
                PanelMouseMove(sender, e);
            if (zoomCheckboxChecked)
            {
                UpdateRectangle(e.X, e.Y, view.Get(ProductGrid.PropertyEnum.Panel).Width,
                    view.Get(ProductGrid.PropertyEnum.Panel).Height);
            }
        }

        public void HandleOtherEvent(object sender, EventArgs e, string eventName)
        {
            if (sender is Button)
                HandleButtonEvent(sender, e, eventName);
            if (sender is CheckBox)
                HandleCheckBoxEvent(sender, e);
            if (sender is TrackBar)
                HandleTrackbarEvent(sender, e);
        }

        public void HandleButtonEvent(object sender, EventArgs e, string eventName)
        {
            switch (eventName)
            {
                case "AlgorithmClick":
                    AlgorithmClicked();
                    break;
                case "ButtonCW":
                    if (selectedProduct != null)
                        RotateSelectedItem(15);
                    break;
                case "ButtonCCW":
                    if (selectedProduct != null)
                        RotateSelectedItem(-15);
                    MessageBox.Show("test");
                    break;
                case "ButtonSave":
                    try
                    {
                        SaveRoom(space.Room);
                    }
                    catch (NullReferenceException ex)
                    {
                        MessageBox.Show("Vergeet niet uw lokaal op te geven");
                    }

                    break;
                case "ButtonDelete":
                    DeleteProduct(selectedProduct);
                    break;
                case "ButtonLock":
                    LockRoom();
                    break;
                case "ButtonCalculate":
                    CalculatePrice();
                    break;
            }
        }

        public void RotateSelectedItem(int degrees)
        {
            if (selectedProduct.CurrentAngle + degrees < 360 && selectedProduct.CurrentAngle + degrees > -360)
                selectedProduct.CurrentAngle += degrees;
            else
                selectedProduct.CurrentAngle = 0;
            view.Get(ProductGrid.PropertyEnum.Panel).Invalidate();
        }

        public void AlgorithmClicked()
        {
            int people;
            float margin;

            using (AlgorithmDialog dialog = new AlgorithmDialog())
            {
                dialog.ShowDialog();
                if (dialog.Result.Count > 0)
                {
                    people = (int)dialog.Result["People"];
                    margin = (dialog.Result["Margin"]/100); // Margin is given in centimeters (so we don't have trouble parsing
                }                                           // the result between OS').
                else
                {
                    people = 0;
                    margin = 0;
                }
            }

            ComboBox algorithmComboBox = (ComboBox)view.Get(ProductGrid.PropertyEnum.AlgorithmComboBox);
            AlgorithmModel selectedAlgorithm = (AlgorithmModel)algorithmComboBox.SelectedItem;
            // Example chair and table
            ProductModel chair = ProductFactory.CreateProduct("Ahrend", 1, 1, "Stoelen");
            ProductModel table = ProductFactory.CreateProduct("TableCompany", 2, 1, "Tafels");

            StartAlgorithm(selectedAlgorithm, chair, table, people, margin);

            view.Get(ProductGrid.PropertyEnum.Panel).Invalidate();
        }


        public void HandleCheckBoxEvent(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            zoomCheckboxChecked = checkBox.Checked;
            view.Get(ProductGrid.PropertyEnum.Trackbar).Enabled = zoomCheckboxChecked;
            if (zoomCheckboxChecked)
            {
                if (zoomView == null)
                    zoomView = new ZoomView();

                zoomView?.Show();
            }
            else if (!zoomCheckboxChecked)
            {
                zoomView?.Hide();
                view.Get(ProductGrid.PropertyEnum.Panel).Invalidate();
            }
        }

        public void HandleTrackbarEvent(object sender, EventArgs e)
        {
            TrackBar trackBar = (TrackBar)sender;
            zoomSize = trackBar.Value;
        }

        public void LayoutChanged(object sender, LayoutEventArgs e)
        {
            Control panel = view.Get(ProductGrid.PropertyEnum.Panel);
            panel.BackgroundImage = CreateBackground(panel.Size);
            UpdateTileSize(panel.Size);
            viewContent = null;
        }

        #endregion

        #region Helper methods

        private Image PaintProducts()
        {
            if (viewContent == null)
            {
                viewContent = new Bitmap(view.Get(ProductGrid.PropertyEnum.Panel).Width,
                    view.Get(ProductGrid.PropertyEnum.Panel).Height);
            }

            using (Graphics g = Graphics.FromImage(viewContent))
            {
                g.Clear(Color.Empty);
                foreach (PlacedProduct product in placedProducts)
                    PaintProduct(product, g);
            }

            return viewContent;
        }

        private void PaintProduct(PlacedProduct product, Graphics g)
        {
            Rectangle rectangle = utility.GetProductRectangle(product, tileWidth, tileHeight, tileSize);
            SolidBrush brush = utility.SelectBrush(product, legendDictionary);
            int angle = product.CurrentAngle;
            using (Matrix m = new Matrix())
            {
                m.RotateAt(angle, new PointF(rectangle.Left + rectangle.Width / 2, rectangle.Top + rectangle.Height / 2));
                g.Transform = m;
                if (product == selectedProduct)
                {
                    Rectangle selectionRectangle = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width,
                        rectangle.Height);
                    Pen pen = new Pen(Color.Red, 4);
                    g.DrawRectangle(pen, selectionRectangle);
                }
                g.FillRectangle(brush, rectangle);
                g.ResetTransform();
            }
        }

        public void LockRoom()
        {
            if (space.Final)
            {
                MessageBox.Show("Dit lokaal is al omgezet om alleen meubels te plaatsen.", "Lokaal: " + space.Room,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Weet je zeker dat je deze kamer wilt inrichten?\nJe kan dan niet meer muren, ramen, etc. plaatsen.\n\nKlik 'Ja' om dit lokaal om te zetten. Klik 'Nee' om dit niet te doen.",
                    "Pas op!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("EDITING");
                //Model
                space.Final = true;
                //Database
                var spaceRow = _dbc.DataSet.space.FindByspace_number(space.Room);
                spaceRow.final = true;
                _dbc.SpaceTableAdapter.Adapter.Update(_dbc.DataSet.space);

                //todo
                //Reload the placement screen so the user is now able to place non-static products, like chairs, sofas and lamps.

                return;
            }
            MessageBox.Show("NOT EDIT");
        }

        //Calculate the totalprice of a newly designed room.
        public void CalculatePrice()
        {
            decimal totalPrice = 0;
            int amountNeeded;

            //Create a distinct list with all placed products
            var distinctProducts = placedProducts
                .GroupBy(p => p.Product.ProductId)
                .Select(g => g.First())
                .ToList();

            //Loops through all placed products and calculate the price needed
            foreach (var product in distinctProducts)
            {
                var oldPlacement = dbc.DataSet.placement
                    .Where(p => p.space_number == space.Room && p.product_id == product.Product.ProductId)
                    .Select(c => c)
                    .ToList();

                int newPlacement = PlacementCount(product.Product) - oldPlacement.Count;

                amountNeeded = (product.Product.AmountPlaced + newPlacement) - product.Product.Amount;
                if (amountNeeded > 0)
                    totalPrice = totalPrice + product.Product.Price * amountNeeded;
            }

            if (totalPrice <= 0)
                MessageBox.Show("Er zijn genoeg producten op voorraad.");
            else
                MessageBox.Show("De totaalprijs van deze ruimte is €" + totalPrice);
        }

        public void DeleteProduct(PlacedProduct product)
        {
            if (product == null)
                return;

            placedProducts.Remove(product);
            view.Get(ProductGrid.PropertyEnum.Panel).Invalidate();
            ((ProductGrid)view).productList.fixInformation();
        }

        private void SaveRoom(string spacenumber)
        {
            string appFolderPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string resourcesFolderPath = Path.Combine(Directory.GetParent(appFolderPath).Parent.FullName, "Resources");

            string fileName = Path.Combine(resourcesFolderPath, "" + spacenumber + ".bmp");
            viewContent.Save(fileName);
            DeleteRows(spacenumber);
            SaveSpace(spacenumber);
            MessageBox.Show("Opgeslagen");
            view.Get(ProductGrid.PropertyEnum.Panel).Invalidate();
            ((ProductGrid)view).productList.fixInformation();
        }

        public void DeleteRows(string spacenumber)
        {
            var rows = dbc.DataSet.placement.Select("space_number = '" + spacenumber + "'");
            foreach (var row in rows)
            {
                row.Delete();
                dbc.PlacementTableAdapter.Update(dbc.DataSet.placement);
            }
        }

        public void SaveSpace(string spacenumber)
        {
            foreach (PlacedProduct product in placedProducts)
            {
                DataRow anyRow = dbc.DataSet.placement.NewRow();
                var hoi2 = dbc.DataSet.placement.Rows[dbc.DataSet.placement.Rows.Count - 1]["placement_id"];
                ;
                string hoi = hoi2.ToString();
                int x = int.Parse(hoi) + 1;
                float X = product.Location.X;
                float Y = product.Location.Y;
                int product_id = product.Product.ProductId;
                int angle = product.CurrentAngle;

                anyRow["placement_id"] = x;
                anyRow["space_number"] = spacenumber;
                anyRow["product_id"] = product_id;
                anyRow["x_position"] = X * 100;
                anyRow["y_position"] = Y * 100;
                anyRow["angle"] = angle;

                dbc.DataSet.placement.Rows.Add(anyRow);
                dbc.PlacementTableAdapter.Update(dbc.DataSet.placement);
                
                // count the new AmountPlaced for given product
                dbc.CountProductsAmountPlaced(product);
            }
        }

        public void OpenPanel(ProductGrid grid, Space spacenr)
        {
            placedProducts.Clear();
            space = spacenr;
            //this.SpaceNumberTitle.Text = space.Room;
            grid.spaceNumberTextbox.Text = space.Room;
            grid.spaceSizeTextbox.Text = space.Length + " + " + space.Width;

            meterWidth = (float)space.Width / 100;
            meterHeight = (float)space.Length / 100;
            tileSize = meterWidth / 10;

            LayoutChanged(this, null);

            //Update the data (size and colour of the PlacedProduct, information of the ProductList and ProductInfo)
            PlaceProducts();
            grid.Invalidate();
            grid.BringToFront();
        }

        public void PlaceProducts()
        {
            foreach (var placedProduct in dbc.DataSet.placement)
            {
                // check if placedproduct belongs to current space
                if (placedProduct.space_number == space.Room)
                {
                    foreach (ProductModel product in ProductModel.List)
                    {
                        // for each productmodel -> check if the id equals the placedproduct id

                        if (product.ProductId == placedProduct.product_id)
                        {
                            // create placedproducts with a point and product reference
                            Point point = new Point(placedProduct.x_position / 100, placedProduct.y_position / 100);
                            int angle = placedProduct.angle;
                            PlacedProduct p1 = new PlacedProduct(product, point, angle);

                            AddNewProduct(product, (float)placedProduct.x_position / 100,
                                (float)placedProduct.y_position / 100,
                                (float)product.Width / 100, (float)product.Height / 100, true, angle);
                        }
                    }
                }
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

                selectedProduct.OriginalLocation = selectedProduct.Location;
            }
            else
            {
                selectedProduct = null;
                draggingProduct = false;
            }
            view.Get(ProductGrid.PropertyEnum.Panel).Invalidate();
        }

        public void PanelMouseMove(object sender, MouseEventArgs e)
        {
            if (zoomCheckboxChecked)
            {
                zoomView?.SetArea(GetPanelImage());
                view.Get(ProductGrid.PropertyEnum.Panel).Invalidate();
            }
        }

        public void PanelMouseDrag(object sender, MouseEventArgs e)
        {
            bool xInField = e.X > 0 && e.X < view.Get(ProductGrid.PropertyEnum.Panel).Width,
                yInField = e.Y > 0 && e.Y < view.Get(ProductGrid.PropertyEnum.Panel).Height,
                validDrag = draggingProduct && selectedProduct != null;
            if (validDrag && xInField && yInField)
            {
                int maxWidth = view.Get(ProductGrid.PropertyEnum.Panel).Width,
                    maxHeight = view.Get(ProductGrid.PropertyEnum.Panel).Height;

                utility.MoveProduct(collisionHandler, selectedProduct, placedProducts,
                    maxWidth, maxHeight, meterWidth, meterHeight, e.X, e.Y);

                view.Get(ProductGrid.PropertyEnum.Panel).Invalidate();
            }
        }

        public void DragDrop(object sender, DragEventArgs e)
        {
            ProductModel model;
            if ((model = (ProductModel)e.Data.GetData(typeof(ProductModel))) != null) // if so, this is a new product
            {
                AddNewProduct(model, e.X, e.Y, (float)model.Width / 100, (float)model.Height / 100, false, 0);
                view.Get(ProductGrid.PropertyEnum.Panel).Invalidate();
            }
            else // selected item is a PlacedProduct, and so is already in the field
            {
                PlacedProduct temp = (PlacedProduct)e.Data.GetData(typeof(PlacedProduct));
                Console.WriteLine(temp);
            }
        }

        public void DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PlacedProduct)) || e.Data.GetDataPresent(typeof(ProductModel)))
                e.Effect = e.AllowedEffect;
            else
                e.Effect = DragDropEffects.None;
        }

        public void AddNewProduct(ProductModel model, float x, float y, float width, float height, bool realDimensions,
            int angle)
        {
            float viewWidth = view.Get(ProductGrid.PropertyEnum.Panel).Width,
                viewHeight = view.Get(ProductGrid.PropertyEnum.Panel).Height;
            float newX = realDimensions ? x : x / viewWidth * meterWidth,
                newY = realDimensions ? y : y / viewHeight * meterHeight;
            PointF center;
            int currentangle = angle;

            if (!realDimensions)
            {
                center = new PointF
                {
                    X = newX - width / 2,
                    Y = newY - height / 2
                };
            }
            else
            {
                center = new PointF
                {
                    X = x,
                    Y = y
                };
            }

            SizeF size = new SizeF(width, height);
            model.Size = size;
            PlacedProduct newProduct = new PlacedProduct(model, center, currentangle);

            // Do not add product to field if it has collision
            if (!collisionHandler.Collision(newProduct, placedProducts))
            {
                placedProducts.Add(newProduct);
                ((ProductGrid)view).productList.fixInformation();
            }
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
            IDesignAlgorithm algoInstance = (IDesignAlgorithm)Activator.CreateInstance(selectedType);
            List<ProductModel> result = algoInstance.Design(model1, model2, people, meterWidth, meterHeight, margin);
            foreach (ProductModel model in result)
            {
                // flip width and height, because the algorithm gives relative [width, height] according to the orientation
                int width = model.Width;
                model.Width = model.Height;
                model.Height = width;
                AddNewProduct(model, model.Location.X, model.Location.Y, model.Width, model.Height, true, 0);
            }
        }

        public void UpdateRectangle(int x, int y, int? maxX, int? maxY)
        {
            if (maxX.HasValue && maxY.HasValue && zoomCheckboxChecked)
            {
                int boundX = (int)maxX,
                    boundY = (int)maxY,
                    tempWidth = zoomSize,
                    tempHeight = zoomSize,
                    tempX = x - zoomArea.Width / 2,
                    tempY = y - zoomArea.Height / 2;

                if (tempX + tempWidth > boundX)
                    tempX = boundX - tempWidth;
                if (tempY + tempHeight > boundY)
                    tempY = boundY - tempHeight;
                if (tempY < 0)
                    tempY = 0;
                if (tempX < 0)
                    tempX = 0;

                Rectangle rectangle = new Rectangle(tempX, tempY, tempWidth, tempHeight);

                zoomArea = rectangle;
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
            tileWidth = size.Width / meterWidth * tileSize;
            tileHeight = size.Height / meterHeight * tileSize;
        }

        #endregion

        #region Other methods

        // This method is here to populate the algorithms until
        // someone wants to update that process
        public void PopulateAlgorithms()
        {
            // Standard test setup algorithm
            AddToComboBox(AlgorithmModel.CreateAlgorithm("Toets lokaal", typeof(TestSetupDesign)));
        }

        public void AddToComboBox(AlgorithmModel algorithm)
        {
            comboBoxAlgorithms.Add(algorithm);
            ComboBox comboBox = (ComboBox)view.Get(ProductGrid.PropertyEnum.AlgorithmComboBox);
            comboBox.DataSource = comboBoxAlgorithms;
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "Value";
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        #endregion
    }
}