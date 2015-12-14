using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Models.Product;

namespace KantoorInrichting.Views.Placement
{
    public delegate void ProductSelectionChanged(ProductInfo sender);

    public partial class ProductList : UserControl
    {
        private List<ProductInfo> listOfInformation; 
        public event ProductSelectionChanged SelectionChanged;

        public ProductList()
        {
            InitializeComponent();
            
            listOfInformation = new List<ProductInfo>();
            
            GenerateProducts(false);
        }
        
        public ProductList(bool uselessparam)
        {
            InitializeComponent();
            
            listOfInformation = new List<ProductInfo>();
            
            GenerateProducts(true);
        }

        private void GenerateProducts(bool StaticOrNot)
        {
            //Make generate all the products currently in the list, to display them to the user
            int y = 0;
            if (StaticOrNot == true)
            {
                foreach (StaticObjectModel product in StaticObjectModel.list)
                {
                    ProductInfo pi = new ProductInfo();
                    pi.Location = new Point(0, y);
                    pi.setProduct(product);
                    pi.MouseClick += new MouseEventHandler(product_Selected); //The event
                    pi.pbx_Image.MouseDown += new MouseEventHandler(product_Selected); //The event
                    this.Controls.Add(pi);
                    listOfInformation.Add(pi);
                    y += pi.Height;
                }
            } else
            {
                foreach (ProductModel product in ProductModel.list)
                {
                    ProductInfo pi = new ProductInfo();
                    pi.Location = new Point(0, y);
                    pi.setProduct(product);
                    pi.MouseClick += new MouseEventHandler(product_Selected); //The event
                    pi.pbx_Image.MouseDown += new MouseEventHandler(product_Selected); //The event
                    this.Controls.Add(pi);
                    listOfInformation.Add(pi);
                    y += pi.Height;
                }
            }
            
        }

        private void product_Selected(object sender, MouseEventArgs e)
        {
            try
            {
                //If the ProductInfo has been clicked, change the product
                ProductInfo pi = (ProductInfo)sender;
                SelectionChanged(pi);
            }
            catch { }
            
            try
            {
                //If the immage was selected
                PictureBox pb = (PictureBox)sender;
                product_Selected(pb.Parent, e);
            }
            catch { }
        }

        public void fixInformation()
        {

            try
            {
                this.Controls.Clear();
                GenerateProducts(false);
            }
            catch
            {
                
            }
        }
    }

    
}
