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
        List<KantoorInrichting.Models.Product.ProductModel> listOfProducts;
        public event ProductSelectionChanged SelectionChanged;

        public ProductList()
        {
            InitializeComponent();

            
            listOfProducts = new List<KantoorInrichting.Models.Product.ProductModel>();
            listOfProducts.Add(new KantoorInrichting.Models.Product.ProductModel("Black Chair", "Chairs'R'Yours", "A", "Chair", "Deskchair", 50, 50, 60, "Chair - Stackable", 9));
            listOfProducts.Add(new KantoorInrichting.Models.Product.ProductModel("Red Table", "Dem Tables", "A", "Tables", "", 100, 300, 100, "Table - Dining", 0));
            listOfProducts.Add(new KantoorInrichting.Models.Product.ProductModel("Yellow Coffee Table", "Dem Tables", "B", "Tables", "Coffee tables",50, 100, 75, "Table - Coffee", 6));
            listOfProducts.Add(new KantoorInrichting.Models.Product.ProductModel("Blue-Board", "Color Board", "H","Boards","", 10, 200, 200, "Board - White Board", 4));

            GenerateTexture();
        }
        
        private void GenerateTexture()
        {
            int y = 0;
            foreach (KantoorInrichting.Models.Product.ProductModel product in listOfProducts)
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
