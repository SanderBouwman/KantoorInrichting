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
        List<ProductModel> listOfProducts;
        List<StaticObjectModel> listOfStaticProducts;
        public event ProductSelectionChanged SelectionChanged;

        public ProductList()
        {
            InitializeComponent();

            listOfProducts = new List<ProductModel>();

            //FUTURE: Get all products from the 'Assortiment'
            foreach (ProductModel product in ProductModel.list)
            {
                listOfProducts.Add(product);
            }
            
            GenerateProducts(false);
        }
        
        public ProductList(bool uselessparam)
        {
            InitializeComponent();

            listOfStaticProducts = new List<StaticObjectModel>();

            foreach (StaticObjectModel staticobject in StaticObjectModel.list)
            {
                listOfStaticProducts.Add(staticobject);
            }
            GenerateProducts(true);
        }

        private void GenerateProducts(bool StaticOrNot)
        {
            //Make generate all the products currently in the list, to display them to the user
            int y = 0;
            if (StaticOrNot == true)
            {
                foreach (StaticObjectModel product in listOfStaticProducts)
                {
                    ProductInfo pi = new ProductInfo();
                    pi.Location = new Point(0, y);
                    pi.setProduct(product);
                    pi.MouseClick += new MouseEventHandler(product_Selected); //The event
                    pi.pbx_Image.MouseDown += new MouseEventHandler(product_Selected); //The event
                    this.Controls.Add(pi);
                    y += pi.Height;
                }
            } else
            {
                foreach (ProductModel product in listOfProducts)
                {
                    ProductInfo pi = new ProductInfo();
                    pi.Location = new Point(0, y);
                    pi.setProduct(product);
                    pi.MouseClick += new MouseEventHandler(product_Selected); //The event
                    pi.pbx_Image.MouseDown += new MouseEventHandler(product_Selected); //The event
                    this.Controls.Add(pi);
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
    }

    
}
