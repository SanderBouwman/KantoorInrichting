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
        private bool _locked = false;

        public ProductList()
        {
            InitializeComponent();

            listOfInformation = new List<ProductInfo>();
            _locked = true;
            GenerateProducts();
        }

        public ProductList(bool uselessparam)
        {
            InitializeComponent();

            listOfInformation = new List<ProductInfo>();
            _locked = false;
            GenerateProducts();
        }

        private void GenerateProducts()
        {
            //remove all ProductInfos
            RemoveItems();


            //Make generate all the products currently in the list, to display them to the user
            int y = 0;
            if (!_locked)
            {
                foreach (StaticObjectModel product in StaticObjectModel.List)
                {
                    //MessageBox.Show("Test Static");
                    ProductInfo pi = new ProductInfo(product);
                    pi.Location = new Point(0, y);
                    pi.MouseClick += new MouseEventHandler(product_Selected); //The event
                    pi.pbx_Image.MouseDown += new MouseEventHandler(product_Selected); //The event
                    this.Controls.Add(pi);
                    listOfInformation.Add(pi);
                    y += pi.Height;
                }
            }
            else if (_locked)
            {
                var onlyAvailibleProducts =
                    from products in ProductModel.List
                    where products.Removed == false
                    select products;

                foreach (ProductModel product in onlyAvailibleProducts)
                {
                    //MessageBox.Show("Test Product");
                    ProductInfo pi = new ProductInfo(product);
                    pi.Location = new Point(0, y);
                    pi.MouseClick += new MouseEventHandler(product_Selected); //The event
                    pi.pbx_Image.MouseDown += new MouseEventHandler(product_Selected); //The event
                    this.Controls.Add(pi);
                    listOfInformation.Add(pi);
                    y += pi.Height;
                }
            }

            fixInformation();
        }

        private void product_Selected(object sender, MouseEventArgs e)
        {
            try
            {
                //If the ProductInfo has been clicked, change the product
                ProductInfo pi = (ProductInfo) sender;
                SelectionChanged(pi);
            }
            catch
            {
            }

            try
            {
                //If the immage was selected
                PictureBox pb = (PictureBox) sender;
                product_Selected(pb.Parent, e);
            }
            catch
            {
            }
        }

        public void fixInformation()
        {
            try
            {
                foreach (ProductInfo info in listOfInformation)
                {
                    info.ReloadInfo();
                }
            }
            catch
            {
                //There are no ProductInfos in the list.
            }
        }

        public void LockRoom()
        {
            //Now furniture can be placed
            MessageBox.Show("Locked!");
            _locked = true;
            GenerateProducts();
        }

        public void UnlockRoom()
        {
            //Now Statics can be placed
            MessageBox.Show("Unlocked");
            _locked = false;
            GenerateProducts();
        }


        public void RemoveItems()
        {
            listOfInformation = new List<ProductInfo>();
            foreach (Control a in Controls)
            {
                Controls.Remove(a);
            }
            if (Controls.Count > 0)
            {
                RemoveItems();
            }
            Invalidate();
        }


    }
}
