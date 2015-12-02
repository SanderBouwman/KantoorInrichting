using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting;
using KantoorInrichting.Models.Placement;
using KantoorInrichting.Models.Product;
using System.Collections.ObjectModel;

namespace KantoorInrichting.Views.Placement
{
    public partial class ProductAdding : UserControl
    {
        //List of all product currently placed on the screen.
        public static ObservableCollection<PlacedProduct> ppList = new ObservableCollection<PlacedProduct>();

        public MainFrame hoofdscherm;


        private void ppList_CollectionChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private PlacedProduct placedP;

        public ProductAdding(MainFrame hoofdscherm)
        {
            this.hoofdscherm = hoofdscherm;
            InitializeComponent();

            //Make an event when the selection has changed
            productList1.SelectionChanged += new ProductSelectionChanged(this.changeSelected);


            //Select the first product from the product list
            ProductInfo defaultInfo = new ProductInfo();
            defaultInfo.setProduct(ProductModel.list[0]);
            changeSelected(defaultInfo);


            //Add default product
            placedP = new PlacedProduct(productInfo1.product, new Vector(200, 200));
            ppList.Add(placedP);


            //Add obstacle
            ppList.Add(new PlacedProduct(new ProductModel("", "", "", "", "", 100, 50, 50, "", 1), new PointF(500, 75)));


            //Make an event that triggers when the list is changed, so that it automatically repaints the screen.
            ppList.CollectionChanged += ppList_CollectionChanged;
            

            //Default value for the comboboxes
            cbx_TurnValue.SelectedIndex = 0;
            cbx_MoveValue.SelectedIndex = 0;
        }
        

        protected override void OnPaint(PaintEventArgs e)
        {
            Vector p1;
            Vector p2;
            foreach (PlacedProduct pp in ppList)
            {
                for (int i = 0; i < pp.Poly.Points.Count; i++)
                {
                    //Get the lines
                    p1 = pp.Poly.Points[i];
                    if (i + 1 >= pp.Poly.Points.Count)
                    {
                        p2 = pp.Poly.Points[0];
                    }
                    else
                    {
                        p2 = pp.Poly.Points[i + 1];
                    }
                    //Draw lines between every point
                    e.Graphics.DrawLine(new Pen(Color.Black), p1, p2);
                }
                //Draw the image
                e.Graphics.DrawImage(pp.rotatedMap, pp.location.X - (pp.rotatedMap.Width / 2), pp.location.Y - (pp.rotatedMap.Height / 2));
            }
        }


        public void changeSelected(ProductInfo sender)
        {
            productInfo1.setProduct(sender.product); //Sets a new product
        }

        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            ppList.Remove(placedP);//Removes the old one
            placedP = new PlacedProduct(productInfo1.product, new Vector(200, 200));
            ppList.Add(placedP); //Inserts the new one
            this.Invalidate(); //Repaints
        }




        private void btn_Turn_Click(object sender, EventArgs e)
        {
            int angle = 15;

            if (cbx_TurnValue.Text == "Counter Clockwise") { angle *= -1; }

            placedP.addAngle(angle);

            this.Invalidate();
        }

        private void btn_Move_Click(object sender, EventArgs e)
        {
            int speed = 50;
            bool x_Axis = true;

            if(cbx_MoveValue.Text == "Up" || cbx_MoveValue.Text == "Left")
            {
                speed *= -1;
            }
            if(cbx_MoveValue.Text == "Up" || cbx_MoveValue.Text == "Down")
            {
                x_Axis = false;
            }

            placedP.gridSpace = speed;
            placedP.Move(x_Axis);

            Invalidate();
        }

        private void cbx_TurnValue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
