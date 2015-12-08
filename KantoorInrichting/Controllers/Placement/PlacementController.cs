using KantoorInrichting.Models.Placement;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Views.Placement;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantoorInrichting.Controllers.Placement
{
    public class PlacementController
    {
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
        public static ObservableCollection<PlacedProduct> ppList = new ObservableCollection<PlacedProduct>();

        public MainFrame motherFrame;
        private ProductAdding productAdding;
        private Graphics g;
        private PlacedProduct currentProduct;
        private Point clickLocation;
        private int MovementSpeed = 5;

        private void ppList_CollectionChanged(object sender, EventArgs e)
        {
            //The method to repaint the panel if the information stored inside the list has changed (ie. a product has moved).
            redrawPanel();
        }

        public PlacementController(MainFrame motherFrame, ProductAdding pa)
        {
            this.motherFrame = motherFrame;
            productAdding = pa;
            motherFrame.Size = new Size(1500, 800);
            clickLocation = new Point(0, 0);

            //Make an event when the selection of the ASSORTMENT or INVENTORY has changed
            productAdding.productList1.SelectionChanged += new ProductSelectionChanged(this.changeSelected);


            //Select the first product from the product list, and display it in the default info
            ProductInfo defaultInfo = new ProductInfo();
            defaultInfo.setProduct(ProductModel.list[0]);
            changeSelected(defaultInfo);
            

            //Make an event that triggers when the list is changed, so that it automatically repaints the screen.
            ppList.CollectionChanged += ppList_CollectionChanged;
        }


        public void changeSelected(ProductInfo sender)
        {
            productAdding.productInfo1.setProduct(sender.product); //Sets a new product
        }




        public void redrawPanel()
        {
            g = productAdding.productPanel.CreateGraphics();
            //TODO: ADD Grid Brush            
            g.Clear(productAdding.productPanel.BackColor);

            
            Pen p = new Pen(Brushes.Gray, 1);
            for (int y = 0; y < productAdding.productPanel.Height; y += MovementSpeed)
            {
                g.DrawLine(p, 0, y, productAdding.productPanel.Width, y);
            }

            for (int x = 0; x < productAdding.productPanel.Width; x += MovementSpeed)
            {
                g.DrawLine(p, x, 0, x, productAdding.productPanel.Height);
            }


            //g.DrawRectangle(new Pen(Color.Black, 1), new Rectangle(0, 0, productAdding.productPanel.Width - 1, productAdding.productPanel.Height - 1));

            Vector p1;
            Vector p2;
            foreach (PlacedProduct pp in ppList)
            {
                for (int i = 0; i < pp.Poly.Points.Count; i++)
                {
                    //Get the lines
                    p1 = pp.Poly.Points[i];
                    if (i + 1 >= pp.Poly.Points.Count)  { p2 = pp.Poly.Points[0]; }
                    else                                { p2 = pp.Poly.Points[i + 1]; }
                    //Draw lines between every point
                    g.DrawLine(new Pen(Color.Black), p1, p2);
                }
                //Draw the image
                g.DrawImage(pp.rotatedMap, pp.location.X - (pp.rotatedMap.Width / 2), pp.location.Y - (pp.rotatedMap.Height / 2));
            }

        }



        

        /// <summary>
        /// Turn a product
        /// </summary>
        /// <param name="d">Give a clockwise of counter clockwise direction for the product to turn to</param>
        public void button_Turn(Direction d)
        {
            if (currentProduct == null || (d != Direction.CLOCKWISE && d != Direction.COUNTERCLOCKWISE)) { return; }

            int angle = 15;

            if (d == Direction.COUNTERCLOCKWISE) { angle *= -1; }

            currentProduct.addAngle(angle);

            redrawPanel();
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

            currentProduct.gridSpace = speed;
            currentProduct.Move(x_Axis);

            redrawPanel();
        }

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
                NewProduct(sender, e);
            }
            
            if(e.Data.GetDataPresent(typeof(PlacedProduct)))
            {
                MoveProduct(sender, e);
            }
            
            return;   
        }

        public void event_PanelMouseDown(object sender, MouseEventArgs e)
        {
            foreach (PlacedProduct PlacedP in PlacementController.ppList)
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
                    productAdding.productInfo1.setProduct(PlacedP.product);
                    currentProduct = PlacedP;
                    break;
                }
            }
        }

        private void NewProduct(object sender, DragEventArgs e)
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
            foreach (PlacedProduct placedP in ppList)
            {
                PolygonCollisionController.PolygonCollisionResult r = PolygonCollisionController.PolygonCollision(product.Poly, placedP.Poly, new Vector(0, 0));

                if (r.WillIntersect)
                {
                    //At the collision, quit the method
                    return;
                }
            }

            //The adding of the product
            ppList.Add(product);
            //Set as current product
            productAdding.productInfo1.setProduct(product.product);
            currentProduct = product;
            //Redraw
            redrawPanel();
        }

        private void MoveProduct(object sender, DragEventArgs e)
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
                return;
            }

            
            int deltaX = newLocation.X - clickLocation.X;
            int deltaY = newLocation.Y - clickLocation.Y;

            deltaX = ((deltaX / MovementSpeed) * MovementSpeed);
            deltaY = ((deltaY / MovementSpeed) * MovementSpeed);


            Point delta = new Point((int)(product.location.X + deltaX), (int)(product.location.Y + deltaY));
            Polygon movedProduct = product.getVirtualPolygon(delta);


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
                    return;
                }

            }

            //The moving of the product
            product.MoveTo(delta);
            redrawPanel();
        }

        
    }
}
