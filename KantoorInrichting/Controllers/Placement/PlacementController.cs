﻿using KantoorInrichting.Models.Placement;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Views.Placement;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantoorInrichting.Controllers.Placement
{
    public class PlacementController
    {
#region Variables
        public enum Direction
        {
            UP,
            DOWN,
            LEFT,
            RIGHT,
            CLOCKWISE,
            COUNTERCLOCKWISE
        }


        //List of all product currently placed on the screen.
        public static ObservableCollection<PlacedProduct> placedProductList = new ObservableCollection<PlacedProduct>();
        // above has to be static because it is used in alot of other classes, still needs to be fixed
        public ObservableCollection<PlacedProduct> placedProducts = new ObservableCollection<PlacedProduct>();
        public static List<PlacedProduct> staticlyPlacedObjectList;

        public MainFrame motherFrame;
        private ProductAdding productAdding;
        private PlacedProduct currentProduct;
        private Point clickLocation;
        private int MovementSpeed = 5;
        DatabaseController dbc = DatabaseController.Instance;

        private Bitmap drawImageGhostBitmap = new Bitmap(Properties.Resources.No_Image_Available, 50, 50);
        private Point drawImageGhostPoint = new Point(0,0);
        private bool draggingItem = false;
        #endregion Variables

        private void ppList_CollectionChanged(object sender, EventArgs e)
        {
            //The method to repaint the panel if the information stored inside the list has changed (ie. a product has moved).
            DoRepaint();
        }
        //
        public PlacementController(MainFrame motherFrame, ProductAdding pa)
        {
            this.motherFrame = motherFrame;
            productAdding = pa;
            clickLocation = new Point(0, 0);
            productAdding.productPanel.knowYourController(this);

            //Make an event when the selection of the ASSORTMENT or INVENTORY has changed
            productAdding.productList1.SelectionChanged += new ProductSelectionChanged(this.ChangeSelected);


            //Select the first product from the product list, and display it in the default info
            try
            {
                ProductInfo defaultInfo = new ProductInfo(ProductModel.List[0]);
                ChangeSelected(defaultInfo);
            }
            catch { }


            //Make an event that triggers when the list is changed, so that it automatically repaints the screen.
            placedProductList.CollectionChanged += ppList_CollectionChanged;




            //TEMP
            //Fill the staticlyplaced list with walls
            Vector pointTopLeft = new Vector(0, 0);
            Vector pointTopRight = new Vector(productAdding.productPanel.Width - 1, 0);
            Vector pointBottomLeft = new Vector(0, productAdding.productPanel.Height - 1);
            Vector pointBottomRight = new Vector(productAdding.productPanel.Width - 1, productAdding.productPanel.Height - 1);

            staticlyPlacedObjectList = new List<PlacedProduct>();

            int length = (int)(pointBottomRight.Y - pointTopRight.Y);
            int width = (int)(pointTopRight.X - pointTopLeft.X);

            staticlyPlacedObjectList.Add(   //Top
                new PlacedProduct(
                    new ProductModel(0, "", "", width, 1, 1, true),
                    new PointF(width / 2, 0)));

            staticlyPlacedObjectList.Add(   //Right
                new PlacedProduct(
                    new ProductModel(0, "", "", 1, 1, length, true),
                    new PointF(width, length / 2)));

            staticlyPlacedObjectList.Add(   //Bottom
                new PlacedProduct(
                    new ProductModel(0, "", "", width, 1, 1, true),
                    new PointF(width / 2, length)));

            staticlyPlacedObjectList.Add(   //Left
                new PlacedProduct(
                    new ProductModel(0, "", "", 1, 1, length, true),
                    new PointF(0, length / 2)));


        }
        //
        public void ChangeSelected(ProductInfo sender)
        {
            productAdding.productInfo1.setProduct(sender.product); //Sets a new product
            if(currentProduct.Product.Name != sender.product.Name) { currentProduct = null; }
            //Seing as name is an identifier in the database, this can be used to compare the two: Look if the names are the same, if not, then a different product is the currentProduct. Therefore the currentProduct needs to be set to null.
        }
        //
        public void FixUserData()
        {
            foreach (PlacedProduct placedP in placedProductList)
            {
                placedP.ResetImage();
            }
            productAdding.productList1.fixInformation();
            productAdding.productInfo1.setProduct(productAdding.productInfo1.product);
        }
        //
        public static Color GetMainCategoryColorIfNeeded(int CatId)
        {
            int? MainCategory = null;
            Color usedColor;

            // linq select category with the current id
            var selectedcategory = CategoryModel.List
                    .Where(c => c.CatId == CatId)
                    .Select(c => c)
                    .ToList();


            //check if the category is an subcategory
            if (selectedcategory[0].IsSubcategoryFrom > -1 || selectedcategory[0].IsSubcategoryFrom == null)
            {
                MainCategory = selectedcategory[0].IsSubcategoryFrom;


                // linq select category with the current id
                var selectedcategory2 = CategoryModel.List
                        .Where(c => c.CatId == MainCategory)
                        .Select(c => c)
                        .ToList();

                // use the main category color
                usedColor = selectedcategory2[0].Colour;
            }
            else
            {
                // else if no subcategory just use the current category color
                usedColor = selectedcategory[0].Colour;

            }
            return usedColor;
        }
        //
        private void DoRepaint()
        {
            draggingItem = false;
            productAdding.productPanel.Repaint();
        }
        //
        private void DoRepaintWithGhost()
        {
            draggingItem = true;
            productAdding.productPanel.Repaint();
        }
        //
        public void RedrawPanel(Graphics g)
        {
            Vector p1;
            Vector p2;

            /*

            Draw the walls

            EDIT

            */
            foreach(PlacedProduct spo in staticlyPlacedObjectList)
            {
                //Draw lines between every point
                if (spo.Product.Width == 1)
                {//Vertical Line (Left and Right)
                    g.DrawLine(new Pen(Color.Black), new PointF(spo.Location.X - spo.Product.Width - spo.Product.Length + 1,  0), new PointF(spo.Location.X + spo.Product.Width + spo.Product.Length - 1, 0));
                }
                else
                {//Horizontal Line (Top and Bottom)
                    g.DrawLine(new Pen(Color.Black), new PointF(0, spo.Location.Y - spo.Product.Width - spo.Product.Length + 1), new PointF(0, spo.Location.Y + spo.Product.Width + spo.Product.Length - 1));
                }
                
            }



            //Draw the products
            foreach (PlacedProduct pp in placedProductList)
            {
                //Draw the image
                g.DrawImage(pp.RotatedMap, pp.Location.X - (pp.RotatedMap.Width / 2), pp.Location.Y - (pp.RotatedMap.Height / 2));

                for (int i = 0; i < pp.Poly.Points.Count; i++)
                {
                    //Get the lines
                    p1 = pp.Poly.Points[i];
                    if (i + 1 >= pp.Poly.Points.Count)  { p2 = pp.Poly.Points[0]; }
                    else                                { p2 = pp.Poly.Points[i + 1]; }
                    //Draw lines between every point
                    g.DrawLine(new Pen(Color.Black), p1, p2);
                }
            }


            //Draw the Ghost when dragdropping
            if(draggingItem) { g.DrawImage(drawImageGhostBitmap, drawImageGhostPoint); draggingItem = false; }

            
        }
        //
        public void placeProducts()
        {
            foreach (var placedProduct in dbc.DataSet.placement)
            {
                if (placedProduct.space_number == productAdding.space.Room)
                {
                    // get placed productID product
                    foreach (ProductModel product in ProductModel.List)
                    {
                        if (product.ProductId == placedProduct.product_id)
                        {

                            Point point = new Point(placedProduct.x_position, placedProduct.y_position);
                            PlacedProduct p1 = new PlacedProduct(product, point,0);

                            placedProductList.Add(p1);
                        }
                    }
                }
            }
        }

        public static int PlacementCount(ProductModel model)
        {
            int count = 0;
            foreach (PlacedProduct placedproduct in placedProductList)
            {
                if (placedproduct.Product.ProductId == model.ProductId)
                {
                    count++;
                }
                    
            }
            return count;
        }
        

                    
                
               
            

        


        #region Button Events
        /// <summary>
        /// Turn a product
        /// </summary>
        /// <param name="d">Give a clockwise of counter clockwise direction for the product to turn to</param>
        public void button_Turn(Direction d)
        {
            if (currentProduct == null || (d != Direction.CLOCKWISE && d != Direction.COUNTERCLOCKWISE)) { return; }

            int angle = 15;

            if (d == Direction.COUNTERCLOCKWISE) { angle *= -1; }

            currentProduct.AddAngle(angle);

            DoRepaint();
        }

        /// <summary>
        /// Move a product
        /// </summary>
        /// <param name="d">Give a direction for the product to move</param>
        public void button_Move(Direction d)
        {
            if (currentProduct == null || (d != Direction.UP && d != Direction.DOWN && d != Direction.LEFT && d != Direction.RIGHT)) { return; }
            
            bool x_Axis = true;
            int speed = MovementSpeed;

            if(d == Direction.UP || d == Direction.LEFT){ speed *= -1; }
            if(d == Direction.UP || d == Direction.DOWN){ x_Axis = false; }

            currentProduct.GridSpace = speed;
            placement_Move(currentProduct, x_Axis);

            DoRepaint();
        }

        public void button_Delete()
        {
            try
            {
                placedProductList.Remove(currentProduct);
                productAdding.productList1.fixInformation();
                productAdding.productInfo1.ReloadInfo();
            }
            catch { }
        }

        public void button_Save(string spacenumber)
        {

            string appFolderPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string resourcesFolderPath = Path.Combine(Directory.GetParent(appFolderPath).Parent.FullName, "Resources");
            Bitmap bmp = new Bitmap(productAdding.productPanel.Width, productAdding.productPanel.Height);
            productAdding.productPanel.DrawToBitmap(bmp, productAdding.productPanel.Bounds);

            String fileName = Path.Combine(resourcesFolderPath, "" + spacenumber + ".bmp");
            bmp.Save(fileName);
            DeleteRows(spacenumber);
            SaveSpace(spacenumber);
            MessageBox.Show("Opgeslagen");

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

            foreach (PlacedProduct product in placedProductList)
            {
                DataRow anyRow = dbc.DataSet.placement.NewRow();
                var hoi2 = dbc.DataSet.placement.Rows[dbc.DataSet.placement.Rows.Count - 1]["placement_id"]; ;
                string hoi = hoi2.ToString();
                int x = Int32.Parse(hoi) + 1;
                string X = product.Location.X.ToString();
                string Y = product.Location.Y.ToString();
                int product_id = product.Product.ProductId;

                anyRow["placement_id"] = x;
                anyRow["space_number"] = spacenumber;
                anyRow["product_id"] = product_id;
                anyRow["x_position"] = X;
                anyRow["y_position"] = Y;
                anyRow["angle"] = 0;

                dbc.DataSet.placement.Rows.Add(anyRow);
                dbc.PlacementTableAdapter.Update(dbc.DataSet.placement);
              
            }

        }
        #endregion Button Events



        #region Event Handlers
        /// <summary>
        /// Event that allows the object to be dropped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void event_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PlacedProduct)) || e.Data.GetDataPresent(typeof(ProductModel)))
            {
                e.Effect = e.AllowedEffect; //Allows to drop (kinda validating the data)
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Event for when the object is dropped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void event_DragDrop(object sender, DragEventArgs e)
        {
            //Returns if the data isn't a PlacedProduct or a ProductModel
            if (e.Data.GetDataPresent(typeof(ProductModel)))
            {
                placement_NewProduct(sender, e);
            }
            
            if(e.Data.GetDataPresent(typeof(PlacedProduct)))
            {
                placement_MoveProduct(sender, e);
            }
            
            //Repaint so that the ghost image is removed
            DoRepaint();
            return;   
        }        

        /// <summary>
        /// Event that triggers when the dragdrop object is dragged  across the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void event_DragOver(object sender, DragEventArgs e)
        {
            //If not ProductModel or PlacedProduct, then exit out, because you can only get the location from them
            if (!(e.Data.GetDataPresent(typeof(ProductModel)) || e.Data.GetDataPresent((typeof(PlacedProduct)))))
            {
                draggingItem = false;
                return;
            }
            else
            {
                draggingItem = true;
            }

            
            //Gets the location of the mouse inside of the panel
            Point newLocation = new Point(e.X, e.Y);
            newLocation = motherFrame.PointToClient(newLocation);
            newLocation.X -= productAdding.productPanel.Left;
            newLocation.Y -= productAdding.productPanel.Top;
            newLocation.Y -= motherFrame.menuStrip1.Height;

            newLocation.X /= MovementSpeed; newLocation.X *= MovementSpeed; //Round down to the movement speed. (AKA: Fit into the grid)
            newLocation.Y /= MovementSpeed; newLocation.Y *= MovementSpeed; //Round down to the movement speed.
            
            
            Color drawImageColor;

            if (e.Data.GetDataPresent(typeof (ProductModel)))
            {
                //Make a new model, size and color
                ProductModel model = (ProductModel)e.Data.GetData(typeof (ProductModel));
                drawImageColor = GetMainCategoryColorIfNeeded(model.ProductCategory.CatId);

                //Colour in the bitmap and resize it.
                Graphics gfx = Graphics.FromImage(drawImageGhostBitmap);
                SolidBrush brush = new SolidBrush(Color.FromArgb(128, drawImageColor.R, drawImageColor.G, drawImageColor.B));
                gfx.FillRectangle(brush, new Rectangle(new Point(0, 0), new Size(1000,1000)));
                
                //Small dispose
                brush.Dispose();
                gfx.Dispose();
                
                //Set the Bitmap and new location
                drawImageGhostBitmap = new Bitmap(drawImageGhostBitmap, model.Width, model.Length);
                drawImageGhostPoint = new Point(newLocation.X - model.Width/2, newLocation.Y - model.Length/2); //Calculates the top left point for the Ghost.
            }
            else if (e.Data.GetDataPresent(typeof (PlacedProduct)))
            {
                //Get the rotated bitmap
                PlacedProduct placedP = (PlacedProduct)e.Data.GetData(typeof(PlacedProduct));
                drawImageGhostBitmap = placedP.RotatedMap;

                Vector clickOffsetVector = new Vector((clickLocation.X - placedP.Location.X), (clickLocation.Y - placedP.Location.Y)); //Get the click offset if the user clicked the bottom left of the image

                //Set the new location
                drawImageGhostPoint = new Point(
                    newLocation.X - drawImageGhostBitmap.Width/2 - (int) clickOffsetVector.X,
                    newLocation.Y - drawImageGhostBitmap.Height/2 - (int) clickOffsetVector.Y);
                    //Calculates the top left point for the Ghost.
            }

            //And then repaint the panel
            DoRepaintWithGhost();
        }

        /// <summary>
        /// When leave, repaint.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void event_DragLeave(object sender, EventArgs e)
        {
            DoRepaint();
        }

        public void event_DeleteEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PlacedProduct)))
            {
                e.Effect = e.AllowedEffect;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }        
        public void event_DeleteDrop(object sender, DragEventArgs e)
        {
            try
            { placedProductList.Remove((PlacedProduct)e.Data.GetData(typeof(PlacedProduct))); }
            catch { }
        }

        public void event_PanelMouseDown(object sender, MouseEventArgs e)
        {
            foreach (PlacedProduct PlacedP in PlacementController.placedProductList)
            {
                //Get the mouse location
                var MouseLocation = new Point(e.X, e.Y);
                Polygon P = new Polygon();
                P.Points.Add(new Vector(MouseLocation.X, MouseLocation.Y));
                P.BuildEdges();

                //And compare it to all possible polygons, so that when one collides, you know which one the user has clicked on.
                PolygonCollisionController.PolygonCollisionResult r = PolygonCollisionController.PolygonCollision(P, PlacedP.Poly, new Vector(0, 0));

                if (r.WillIntersect)
                {
                    //Do DragDrop
                    clickLocation = MouseLocation;
                    productAdding.DoDragDrop(PlacedP, DragDropEffects.Copy);
                    //Set as current product
                    productAdding.productInfo1.setProduct(PlacedP.Product);
                    currentProduct = PlacedP;
                    break;
                }
            }
        }
        public void event_PanelKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            { button_Move(Direction.UP); }
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            { button_Move(Direction.LEFT); }
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            { button_Move(Direction.DOWN); }
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            { button_Move(Direction.RIGHT); }

            if (e.KeyCode == Keys.Q)
            { button_Turn(Direction.COUNTERCLOCKWISE); }
            if (e.KeyCode == Keys.E)
            { button_Turn(Direction.CLOCKWISE); }
        }
        #endregion Event Handlers



#region Placement Handlers
        private void placement_NewProduct(object sender, DragEventArgs e)
        {
            ProductModel model = (ProductModel)e.Data.GetData(typeof(ProductModel));
            
            //Get the correct location
            Point newLocation = new Point(e.X, e.Y);
            newLocation = motherFrame.PointToClient(newLocation);
            newLocation.X -= productAdding.productPanel.Left;
            newLocation.Y -= productAdding.productPanel.Top;
            newLocation.Y -= motherFrame.menuStrip1.Height;

            newLocation.X /= MovementSpeed; newLocation.X *= MovementSpeed; //Round down to the movement speed.
            newLocation.Y /= MovementSpeed; newLocation.Y *= MovementSpeed; //Round down to the movement speed.

            PlacedProduct product = new PlacedProduct(model, newLocation);


            //Collision Loop
            foreach (Polygon placedP in product.PolyList)
            {
                PolygonCollisionController.PolygonCollisionResult r = PolygonCollisionController.PolygonCollision(product.Poly, placedP, new Vector(0, 0));

                if (r.WillIntersect)
                {
                    //At the collision, quit the method
                    DoRepaint();
                    return;
                }
            }

            //The adding of the product
            placedProductList.Add(product);
            //Set as current product
            currentProduct = product;
            productAdding.productList1.fixInformation();
            //Redraw
            DoRepaint();
        }
        private void placement_MoveProduct(object sender, DragEventArgs e)
        {
            PlacedProduct product = (PlacedProduct)e.Data.GetData(typeof(PlacedProduct));

            //Get the location of the mouse
            Point newLocation = new Point(e.X, e.Y);
            newLocation = motherFrame.PointToClient(newLocation);
            newLocation.X -= productAdding.productPanel.Left;
            newLocation.Y -= productAdding.productPanel.Top;
            newLocation.Y -= motherFrame.menuStrip1.Height;
            
            //Failsafe if user clicks the item and doesn't want to move it.
            if (Math.Abs(clickLocation.X - newLocation.X) == 0 || Math.Abs(clickLocation.Y - newLocation.Y) == 0)
            {
                DoRepaint();
                return;
            }

            
            int deltaX = newLocation.X - clickLocation.X;
            int deltaY = newLocation.Y - clickLocation.Y;

            //Round down to the closest spot on the grid (the movementspeed of an object)
            deltaX = ((deltaX / MovementSpeed) * MovementSpeed);
            deltaY = ((deltaY / MovementSpeed) * MovementSpeed);


            Point delta = new Point((int)(product.Location.X + deltaX), (int)(product.Location.Y + deltaY));
            Polygon movedProduct = product.GetVirtualPolygon(delta);


            foreach (Polygon placedP in product.PolyList)
            {
                //Looks to see if the current loop has itself
                if (placedP == product.Poly)
                {
                    continue;
                }

                PolygonCollisionController.PolygonCollisionResult r = PolygonCollisionController.PolygonCollision(movedProduct, placedP, new Vector(0, 0));
                
                if (r.WillIntersect)
                {
                    //At the collision, quit the method                    
                    DoRepaint();
                    return;
                }

            }

            //The moving of the product
            product.MoveTo(delta);
            DoRepaint();
        }
        #endregion Placement Handlers



#region Placement Methods
        /// <summary>
        /// Moves the product a certain amount to a certain direction
        /// </summary>
        /// <param name="X_Axis">Chooses the axis that the product moves on. True for X-axis. False for Y-axis</param>
        public static void placement_Move(PlacedProduct targetProduct, bool X_Axis)
        {
            int x = 0;
            int y = 0;
            if (X_Axis) { x += targetProduct.GridSpace; }
            else { y += targetProduct.GridSpace; }

            Vector velocity = new Vector(x, y);
            Vector playerTranslation1 = velocity;
            Vector playerTranslation2 = velocity;

            //Resets the speed, after the velocity has been assigned.
            if (targetProduct.GridSpace < 0) { targetProduct.GridSpace *= -1; }


            //Test all product polygons for a collision
            foreach (PlacedProduct placedP in placedProductList)
            {
                //Test if the selected polygon is himself
                if (placedP.Poly == targetProduct.Poly)
                {
                    continue;
                }

                //Test if the polygon collides with others
                PolygonCollisionController.PolygonCollisionResult r = PolygonCollisionController.PolygonCollision(targetProduct.Poly, placedP.Poly, velocity);

                //If it does, alter the speed
                if (r.WillIntersect)
                {
                    //
                    playerTranslation1 = velocity + r.MinimumTranslationVector;

                    if (X_Axis) //Moving the x-axis, so set the y-axis velocity to 0
                    {
                        playerTranslation1.Y = 0;
                    }
                    else //Moving the y-axis, so set the x-axis velocity to 0
                    {
                        playerTranslation1.X = 0;
                    }

                    //If there is any movement along the Y axis while moving along the X axis, then the polygon collision want to move around the other polygon. Can't let that happen. So set all movement to 0.
                    if (X_Axis && r.MinimumTranslationVector.Y != 0)
                    {
                        playerTranslation1.X = 0;
                        playerTranslation1.Y = 0;
                    }
                    if (!X_Axis && r.MinimumTranslationVector.X != 0)
                    {
                        playerTranslation1.X = 0;
                        playerTranslation1.Y = 0;
                    }

                    //Round down to the closest x pixels
                    playerTranslation1.X = ((int)playerTranslation1.X / targetProduct.GridSpace) * targetProduct.GridSpace;
                    playerTranslation1.Y = ((int)playerTranslation1.Y / targetProduct.GridSpace) * targetProduct.GridSpace;
                    //MessageBox.Show("then " + playerTranslation1.X.ToString() + " and " + playerTranslation1.Y.ToString());
                    break;
                }
            }


            //Test all product polygons for a collision
            foreach (PlacedProduct placedO in staticlyPlacedObjectList)
            {
                //Test if the selected polygon is himself
                if (placedO.Poly == targetProduct.Poly)
                {
                    continue;
                }

                //Test if the polygon collides with others
                PolygonCollisionController.PolygonCollisionResult r = PolygonCollisionController.PolygonCollision(targetProduct.Poly, placedO.Poly, velocity);

                //If it does, alter the speed
                if (r.WillIntersect)
                {
                    //
                    playerTranslation2 = velocity + r.MinimumTranslationVector;

                    if (X_Axis) //Moving the x-axis, so set the y-axis velocity to 0
                    {
                        playerTranslation2.Y = 0;
                    }
                    else //Moving the y-axis, so set the x-axis velocity to 0
                    {
                        playerTranslation2.X = 0;
                    }

                    //If there is any movement along the Y axis while moving along the X axis, then the polygon collision want to move around the other polygon. Can't let that happen. So set all movement to 0.
                    if (X_Axis && r.MinimumTranslationVector.Y != 0)
                    {
                        playerTranslation2.X = 0;
                        playerTranslation2.Y = 0;
                    }
                    if (!X_Axis && r.MinimumTranslationVector.X != 0)
                    {
                        playerTranslation2.X = 0;
                        playerTranslation2.Y = 0;
                    }

                    //Round down to the closest x pixels
                    playerTranslation2.X = ((int)playerTranslation2.X / targetProduct.GridSpace) * targetProduct.GridSpace;
                    playerTranslation2.Y = ((int)playerTranslation2.Y / targetProduct.GridSpace) * targetProduct.GridSpace;
                    //MessageBox.Show("then " + playerTranslation2.X.ToString() + " and " + playerTranslation2.Y.ToString());
                    break;
                }
            }

            //Compares the tanslations
            /*
            1. Makes a new vector
            2. compares the two, and chooses the highest for the X and the highest for the Y (it looks for the highest number, even when negative. ie. -10 is higher than 4)
            3. If one of the two is 0, then set that Axis to 0
            */
            //1
            Vector playerTranslation = new Vector();
            //2
            playerTranslation.X = Math.Abs(playerTranslation1.X) > Math.Abs(playerTranslation2.X)
                ? playerTranslation1.X
                : playerTranslation2.X;
            playerTranslation.Y = Math.Abs(playerTranslation1.Y) > Math.Abs(playerTranslation2.Y)
                ? playerTranslation1.Y
                : playerTranslation2.Y;
            //3
            if (playerTranslation1.X == 0 || playerTranslation2.X == 0)
            {
                playerTranslation.X = 0;
            }
            if (playerTranslation1.Y == 0 || playerTranslation2.Y == 0)
            {
                playerTranslation.Y = 0;
            }

            //Set the polygon points
            targetProduct.Poly.Offset(playerTranslation);

            //Update the corner points
            for (int index = 0; index < targetProduct.Poly.Points.Count; index++)
            {
                targetProduct.CornerPoints[index] = new PointF(targetProduct.Poly.Points[index].X, targetProduct.Poly.Points[index].Y);
            }

            //Update the center point
            targetProduct.Location = new PointF(targetProduct.Location.X + playerTranslation.X, targetProduct.Location.Y + playerTranslation.Y);

        }
        

        /// <summary>
        /// Issues the rotation of the product.
        /// </summary>
        /// <param name="fallbackAngle">The fallback angle to provide should the product not be able to rotate.</param>
        public static void placement_rotatePoints(PlacedProduct targetProduct, int fallbackAngle)
        {
            PointF[] fallbackPoints = new PointF[5];
            ProductModel product = targetProduct.Product;
            PointF location = targetProduct.Location;

            for (int index = 0; index < targetProduct.CornerPoints.Length; index++)
            {
                fallbackPoints[index] = targetProduct.CornerPoints[index];
            }

            double angle_Even = (double)targetProduct.CurrentAngle;
            double angle_Uneven = targetProduct.CurrentAngle;
            double radius = Math.Sqrt(Math.Pow(0.5 * product.Width, 2) + Math.Pow(0.5 * product.Length, 2));


            //Tan^-1 ( (1/2H) / (1/2W) )
            //This is to get the angle of the center of the rectangle relevant to the sides. (To get the angle inside the rectangle)
            angle_Even += (Math.Atan((0.5 * product.Length) / (0.5 * product.Width)) * 180 / Math.PI);
            angle_Uneven -= 90 - (Math.Atan((0.5 * product.Width) / (0.5 * product.Length)) * 180 / Math.PI);
            //If the angle is negative, add 360 to it to get the positive version
            while (angle_Uneven < 0)
            {
                angle_Uneven += 360;
            }
            while (angle_Even < 0)
            {
                angle_Even += 360;
            }
            //MessageBox.Show("Depth: " + product.depth + ". Width: " + product.width);
            //MessageBox.Show("Even angle: " + angle_Even.ToString() + ". Uneven angle: " + angle_Uneven.ToString());

            //Get the total angle to know what direction the item is facing. (To know where to apply the deltaX and deltaY)
            int directional_Even = Convert.ToInt32(angle_Even) % 360;
            int directional_Uneven = Convert.ToInt32(angle_Uneven) % 360;
            //Gets a 4 possible outcome to determine what deltaX and deltaY do.
            directional_Even = directional_Even / 90;
            directional_Uneven = directional_Uneven / 90;
            /*
            0-89 = 0 (360 degrees is 0 degrees)
            90-179 = 1
            180-269 = 2
            270-359 = 3
            */

            //Gets the angle nearest to 90, so that the Cos and Sin methods work.
            angle_Even = angle_Even % 90;
            angle_Uneven = angle_Uneven % 90;
            //MessageBox.Show("Even angle: " + angle_Even.ToString() + ". Uneven angle: " + angle_Uneven.ToString());


            //Get the difference in X and Y to be applied to the centre point so the corner points can be calculated
            float Cos_Even = (float)(Math.Cos(angle_Even * Math.PI / 180) * radius);
            float Sin_Even = (float)(Math.Sin(angle_Even * Math.PI / 180) * radius);

            float Cos_Uneven = (float)(Math.Cos(angle_Uneven * Math.PI / 180) * radius);
            float Sin_Uneven = (float)(Math.Sin(angle_Uneven * Math.PI / 180) * radius);



            //Determine what deltaX and deltaY do.
            switch (directional_Even)
            {
                case 0: //Total degree is between 0 and 89
                    targetProduct.CornerPoints[0] = new PointF(location.X - Cos_Even, location.Y - Sin_Even);
                    targetProduct.CornerPoints[2] = new PointF(location.X + Cos_Even, location.Y + Sin_Even);
                    break;


                case 1: //Total degree is between 90 and 179
                    targetProduct.CornerPoints[0] = new PointF(location.X + Sin_Even, location.Y - Cos_Even);
                    targetProduct.CornerPoints[2] = new PointF(location.X - Sin_Even, location.Y + Cos_Even);
                    break;


                case 2: //Total degree is between 180 and 269
                    targetProduct.CornerPoints[0] = new PointF(location.X + Cos_Even, location.Y + Sin_Even);
                    targetProduct.CornerPoints[2] = new PointF(location.X - Cos_Even, location.Y - Sin_Even);
                    break;


                case 3: //Total degree is between 270 and 359
                    targetProduct.CornerPoints[0] = new PointF(location.X - Sin_Even, location.Y + Cos_Even);
                    targetProduct.CornerPoints[2] = new PointF(location.X + Sin_Even, location.Y - Cos_Even);
                    break;
                default:
                    goto case 0;
            }
            switch (directional_Uneven)
            {
                case 0: //Total degree is between 1 and 90
                    targetProduct.CornerPoints[1] = new PointF(location.X + Cos_Uneven, location.Y + Sin_Uneven);
                    targetProduct.CornerPoints[3] = new PointF(location.X - Cos_Uneven, location.Y - Sin_Uneven);
                    break;


                case 1: //Total degree is between 91 and 180
                    targetProduct.CornerPoints[1] = new PointF(location.X - Sin_Uneven, location.Y + Cos_Uneven);
                    targetProduct.CornerPoints[3] = new PointF(location.X + Sin_Uneven, location.Y - Cos_Uneven);
                    break;


                case 2: //Total degree is between 181 and 270
                    targetProduct.CornerPoints[1] = new PointF(location.X - Cos_Uneven, location.Y - Sin_Uneven);
                    targetProduct.CornerPoints[3] = new PointF(location.X + Cos_Uneven, location.Y + Sin_Uneven);
                    break;


                case 3: //Total degree is between 271 and 360
                    targetProduct.CornerPoints[1] = new PointF(location.X + Sin_Uneven, location.Y - Cos_Uneven);
                    targetProduct.CornerPoints[3] = new PointF(location.X - Sin_Uneven, location.Y + Cos_Uneven);
                    break;
                default:
                    goto case 0;
            }
            //Set the last angle to the first angle to complete the square
            targetProduct.CornerPoints[4] = targetProduct.CornerPoints[0];



            //Setting the new points to the polygon
            targetProduct.Poly = new Polygon();
            foreach (PointF point in targetProduct.CornerPoints)
            {
                targetProduct.Poly.Points.Add(new Vector(point.X, point.Y));
            }
            targetProduct.Poly.BuildEdges();




            //Testing if turning caused a collision
            foreach (Polygon placedPoly in targetProduct.PolyList)
            {
                //Test if the selected polygon is himself
                if (placedPoly == targetProduct.Poly)
                {
                    continue;
                }

                //Test if the polygon collides with others
                PolygonCollisionController.PolygonCollisionResult r = PolygonCollisionController.PolygonCollision(targetProduct.Poly, placedPoly, new Vector(0, 0));

                //If it does, cancel the rotation
                if (r.WillIntersect)
                {
                    //Issue the fallback
                    targetProduct.CurrentAngle = fallbackAngle;

                    //Issue the fallback
                    for (int index = 0; index < targetProduct.CornerPoints.Length; index++)
                    {
                        targetProduct.CornerPoints[index] = fallbackPoints[index];
                    }

                    //Restate the polygon
                    targetProduct.Poly = new Polygon();
                    foreach (PointF point in targetProduct.CornerPoints)
                    {
                        targetProduct.Poly.Points.Add(new Vector(point.X, point.Y));
                    }
                    targetProduct.Poly.BuildEdges();

                    //MessageBox.Show("The rotation has caused a collision.");
                }
            }
        }
        

        /// <summary>
        /// Issues the rotation of the image of the product.
        /// </summary>
        public static void placement_rotateImg(PlacedProduct targetProduct)
        {
            Color bkColor = Color.Transparent;
            int angle = targetProduct.CurrentAngle;
            Bitmap defaultMap = targetProduct.DefaultBitMap;

            angle = angle % 360;
            if (angle > 180)
                angle -= 360;

            PixelFormat pf = default(PixelFormat);
            if (bkColor == Color.Transparent)
            {
                pf = PixelFormat.Format32bppArgb;
            }
            else
            {
                pf = defaultMap.PixelFormat;
            }

            float sin = (float)Math.Abs(Math.Sin(angle * Math.PI / 180.0)); // this function takes radians
            float cos = (float)Math.Abs(Math.Cos(angle * Math.PI / 180.0)); // this one too
            float newImgWidth = sin * defaultMap.Height + cos * defaultMap.Width;
            float newImgHeight = sin * defaultMap.Width + cos * defaultMap.Height;
            float originX = 0f;
            float originY = 0f;

            if (angle > 0)
            {
                if (angle <= 90)
                    originX = sin * defaultMap.Height;
                else
                {
                    originX = newImgWidth;
                    originY = newImgHeight - sin * defaultMap.Width;
                }
            }
            else
            {
                if (angle >= -90)
                    originY = sin * defaultMap.Width;
                else
                {
                    originX = newImgWidth - sin * defaultMap.Height;
                    originY = newImgHeight;
                }
            }

            Bitmap newImg = new Bitmap((int)newImgWidth, (int)newImgHeight, pf);
            Graphics g = Graphics.FromImage(newImg);
            g.Clear(bkColor);
            g.TranslateTransform(originX, originY); // offset the origin to our calculated values
            g.RotateTransform(angle); // set up rotate
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.DrawImageUnscaled(defaultMap, 0, 0); // draw the image at 0, 0
            g.Dispose();

            targetProduct.RotatedMap = newImg;
        }
        #endregion Placement Methods



#region Resize Images
        //
        //Methods to resize an image, should it be to large for the container it is in.
        //
        public static Image ResizeImage(Image img, int maxWidth, int maxHeight)
        {
            if (img.Height < maxHeight && img.Width < maxWidth) return img;
            using (img)
            {
                Double xRatio = (double)img.Width / maxWidth;
                Double yRatio = (double)img.Height / maxHeight;
                Double ratio = Math.Max(xRatio, yRatio);
                int nnx = (int)Math.Floor(img.Width / ratio);
                int nny = (int)Math.Floor(img.Height / ratio);
                Bitmap cpy = new Bitmap(nnx, nny, PixelFormat.Format32bppArgb);
                using (Graphics gr = Graphics.FromImage(cpy))
                {
                    gr.Clear(Color.Transparent);

                    // This is said to give best quality when resizing images
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    gr.DrawImage(img,
                        new Rectangle(0, 0, nnx, nny),
                        new Rectangle(0, 0, img.Width, img.Height),
                        GraphicsUnit.Pixel);
                }
                return cpy;
            }

        }

        private MemoryStream BytearrayToStream(byte[] arr)
        {
            return new MemoryStream(arr, 0, arr.Length);
        }

        private void HandleImageUpload(byte[] binaryImage)
        {
            Image img = ResizeImage(Image.FromStream(BytearrayToStream(binaryImage)), 103, 32);
            img.Save("IMAGELOCATION.png", System.Drawing.Imaging.ImageFormat.Gif);
        }
        #endregion Resize Images

    }
}
