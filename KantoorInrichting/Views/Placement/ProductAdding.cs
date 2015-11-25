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

            productList1.SelectionChanged += new ProductSelectionChanged(this.changeSelected);

            placedP = new PlacedProduct(productInfo1.product, new Vector(200, 200));
            ppList.Add(placedP);

            ppList.CollectionChanged += ppList_CollectionChanged;
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
            productInfo1.setProduct(sender.product);
            ppList.Remove(placedP);//Removes the old one
            placedP = new PlacedProduct(sender.product, new Vector(200, 200));
            ppList.Add(placedP); //Inserts the new one
            this.Invalidate();
        }

        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            ppList.Add(new PlacedProduct(new KantoorInrichting.Models.Product.ProductModel("", "", "", "", "",100, 50, 50, "", 1), new PointF(400, 50)));
        }




        private void btn_Turn_Click(object sender, EventArgs e)
        {
            placedP.addAngle(15);
            this.Invalidate();
        }

        private void btn_Move_Click(object sender, EventArgs e)
        {
            placedP.Move(10, true);
            Invalidate();
        }
    }
}
