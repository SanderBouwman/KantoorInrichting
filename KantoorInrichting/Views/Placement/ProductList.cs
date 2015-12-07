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
            

            GenerateProducts();
        }
        
        private void GenerateProducts()
        {
            //Make generate all the products currently in the list, to display them to the user
            int y = 0;
            foreach (ProductModel product in listOfProducts)
            {
                ProductInfo pi = new ProductInfo();
                pi.Location = new Point(0, y);
                pi.setProduct(product);
                pi.Click += new EventHandler(product_Selected); //The event
                this.Controls.Add(pi);
                y += pi.Height;
            }
            
        }

        private void product_Selected(object sender, EventArgs e)
        {
            //If the ProductInfo has been clicked, change the 
            try { SelectionChanged((ProductInfo)sender); }
            catch { }
        }
    }

    
}
