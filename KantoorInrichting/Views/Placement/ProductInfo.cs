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
using KantoorInrichting.Controllers;

namespace KantoorInrichting.Views.Placement
{
    public partial class ProductInfo : UserControl
    {
        public ProductModel product { get; private set; }
        DatabaseController dbc = DatabaseController.Instance;

        public ProductInfo()
        {
            InitializeComponent();
        }

        public ProductInfo(ProductModel model) : this()
        {   
            setProduct(model);
        }


        public void setProduct(ProductModel p)
        {
            product = p;
            txt_Name.Text = product.Name;
            txt_Dimension.Text = product.Length.ToString() + " x " + product.Width.ToString() + " x " + product.Height.ToString();
            pbx_Image.Image = product.Image;

            if (!p.StaticProduct) //If it is a Non-Static Product, add extra information.
            {
                int count = dbc.CountProductsAmountPlaced(product);
                
                txt_Brand.Text = product.Brand;
                txt_Type.Text = product.Type;
                txt_Stock.Text = product.Amount.ToString() + " (" + count + " in gebruik )";
                CurrentlyPlaced.Text = ProductGridController.PlacementCount(product).ToString();   
            }
            
        }
        
        //Reload the info, if changes have occured
        public void ReloadInfo()
        {
            setProduct(this.product);
        }

        private void pbx_Image_MouseDown(object sender, MouseEventArgs e)
        {
            pbx_Image.DoDragDrop(product, DragDropEffects.Copy);
        }
    }
}
