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
using KantoorInrichting.Models.Product;

namespace KantoorInrichting.Views.Placement
{
    public partial class ProductInfo : UserControl
    {
        public ProductModel product { get; private set; }


        public ProductInfo()
        {
            InitializeComponent();
            
            setProduct(new ProductModel());
        }
       

        public void setProduct(ProductModel p)
        {
            product = p;

            txt_Name.Text = product.name;
            txt_Brand.Text = product.brand;
            txt_Type.Text = product.type;
            txt_Dimension.Text = product.length.ToString() + "x" + product.width.ToString() + "x" + product.height.ToString();

            pbx_Image.Image = product.image;
        }

        private void pbx_Image_MouseDown(object sender, MouseEventArgs e)
        {
            pbx_Image.DoDragDrop(product, DragDropEffects.Copy);
        }
    }
}
