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
using KantoorInrichting.Controllers.Placement;

namespace KantoorInrichting.Views.Placement
{
    public partial class ProductInfo : UserControl
    {
        public ProductModel product { get; private set; }
        public StaticObjectModel staticProduct { get; private set; }

        public ProductInfo()
        {
            InitializeComponent();
        }

        public ProductInfo(ProductModel model) : this()
        {   
            setProduct(model);
        }

        public ProductInfo(StaticObjectModel model) : this()
        {
            setProduct(model);
        }


        public void setProduct(ProductModel p)
        {
            product = p;

            txt_Name.Text = product.Name;
            txt_Brand.Text = product.Brand;
            txt_Type.Text = product.Type;
            txt_Stock.Text = product.Amount.ToString() + " (" + product.AmountPlaced + " in gebruik )";
            CurrentlyPlaced.Text = ProductGridController.PlacementCount(product).ToString();
            txt_Dimension.Text = product.Length.ToString() + "x" + product.Width.ToString() + "x" + product.Height.ToString();

            pbx_Image.Image = product.Image;
        }

        public void setProduct(StaticObjectModel p)
        {
            staticProduct = p;

            txt_Name.Text = staticProduct.Name;
            txt_Dimension.Text = staticProduct.Length.ToString() + "x" + staticProduct.Width.ToString() + "x" + staticProduct.Height.ToString();

            pbx_Image.Image = staticProduct.Image;
        }

        public void ReloadInfo()
        {
            setProduct(this.product);
        }

        private void pbx_Image_MouseDown(object sender, MouseEventArgs e)
        {
            pbx_Image.DoDragDrop(product, DragDropEffects.Copy);
        }

        private void lbl_4_Click(object sender, EventArgs e)
        {

        }

        private void txt_Stock_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_3_Click(object sender, EventArgs e)
        {

        }
    }
}
