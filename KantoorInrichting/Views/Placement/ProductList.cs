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
            int y = 0;
            foreach (ProductModel product in listOfProducts)
            {
                ProductInfo pi = new ProductInfo();
                pi.Location = new Point(0, y);
                pi.setProduct(product);
                pi.Click += new EventHandler(product_Selected);
                this.Controls.Add(pi);
                y += pi.Height;
                //MessageBox.Show("Test " + product.name);
            }
            
        }

        private void product_Selected(object sender, EventArgs e)
        {
            try { SelectionChanged((ProductInfo)sender); }
            catch { }
        }
    }

    
}
