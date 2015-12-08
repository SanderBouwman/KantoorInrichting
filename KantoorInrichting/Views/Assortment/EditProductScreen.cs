using System;
using System.Windows.Forms;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Controllers.Assortment;

namespace KantoorInrichting.Views.Assortment
{
    public partial class EditProductScreen : Form
    {
        private EditProductController controller;

        public EditProductScreen(ProductModel product)
        {
            InitializeComponent();
            controller = new EditProductController(this, product);
        }

        //Select an image from a folder and show the image in the form
        private void SelectImageButton_Click(object sender, EventArgs e)
        {
            controller.SelectImageButton();
        }

        //Add new product button
        private void AddButton_Click(object sender, EventArgs e)
        {
            controller.AddButton();
        }

        //Cancel Button
        private void CancelButton_Click(object sender, EventArgs e)
        {
            controller.CancelButton();
        }
    }
}