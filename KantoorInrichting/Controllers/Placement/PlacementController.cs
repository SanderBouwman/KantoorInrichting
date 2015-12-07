using KantoorInrichting.Models.Placement;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Views.Placement;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void ppList_CollectionChanged(object sender, EventArgs e)
        {
            //The method to repaint the panel if the information stored inside the list has changed (ie. a product has moved).
            redrawPanel();
        }

        private PlacedProduct placedP;

        public PlacementController(MainFrame motherFrame, ProductAdding pa)
        {
            this.motherFrame = motherFrame;
            productAdding = pa;
            motherFrame.Size = new Size(1500, 800);

            //Make an event when the selection of the ASSORTMENT or INVENTORY has changed
            productAdding.productList1.SelectionChanged += new ProductSelectionChanged(this.changeSelected);


            //Select the first product from the product list, and display it in the default info
            ProductInfo defaultInfo = new ProductInfo();
            defaultInfo.setProduct(ProductModel.list[0]);
            changeSelected(defaultInfo);


            //Add default product
            placedP = new PlacedProduct(productAdding.productInfo1.product, new Vector(200, 200));
            ppList.Add(placedP);


            //Add obstacle !!DELETE LATER!!
            ppList.Add(new PlacedProduct(new ProductModel("", "", "", "", "", 100, 50, 50, "", 1), new PointF(500, 100)));


            //Make an event that triggers when the list is changed, so that it automatically repaints the screen.
            ppList.CollectionChanged += ppList_CollectionChanged;


            productAdding.cbx_TurnValue.SelectedIndex = 0;
            productAdding.cbx_MoveValue.SelectedIndex = 0;


            //redrawPanel();
        }


        public void changeSelected(ProductInfo sender)
        {
            productAdding.productInfo1.setProduct(sender.product); //Sets a new product
        }




        public void redrawPanel()
        {
            g = productAdding.productFieldPanel1.CreateGraphics();
            //TODO: ADD Grid Brush
            //TODO: ADD Border
            g.Clear(productAdding.productFieldPanel1.BackColor);

            g.DrawRectangle(new Pen(Color.Black, 1), new Rectangle(0, 0, productAdding.productFieldPanel1.Width - 1, productAdding.productFieldPanel1.Height - 1));

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
        /// Replace the current object (OLD)
        /// </summary>
        /// <param name="product">Product to be preplaced with</param>
        public void btn_ReplaceProduct(ProductModel product)
        {
            ppList.Remove(placedP);//Removes the old one
            placedP = new PlacedProduct(product, new Vector(200, 200));
            ppList.Add(placedP); //Inserts the new one
            redrawPanel(); //Repaints
        }



        /// <summary>
        /// Turn a product
        /// </summary>
        /// <param name="d">Give a clockwise of counter clockwise direction for the product to turn to</param>
        public void btn_Turn(Direction d)
        {
            int angle = 15;

            if (d == Direction.CLOCKWISE) { angle *= -1; }

            placedP.addAngle(angle);

            redrawPanel();
        }


        /// <summary>
        /// Move a product
        /// </summary>
        /// <param name="d">Give a direction for the product to move</param>
        public void btn_Move(Direction d)
        {
            int speed = 10;
            bool x_Axis = true;
            
            if(d == Direction.UP || d == Direction.LEFT){ speed *= -1; }
            if(d == Direction.UP || d == Direction.DOWN){ x_Axis = false; }

            placedP.gridSpace = speed;
            placedP.Move(x_Axis);

            redrawPanel();
        }
    }
}
