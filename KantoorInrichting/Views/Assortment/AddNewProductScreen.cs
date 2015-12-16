using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Controllers;
using KantoorInrichting.Controllers.Assortment;

namespace KantoorInrichting.Views.Assortment
{
    public partial class AddNewProductScreen : Form
    {
        private AddNewProductController controller;
        

        public AddNewProductScreen()
        {
            InitializeComponent();
            controller = new AddNewProductController(this);
        }

        //Select image button
        private void SelectImageButton_Click(object sender, EventArgs e)
        {
            controller.SelectImageButton();
        }

        //Add new product button
        private void AddButton_Click(object sender, EventArgs e)
        {
            controller.AddButton();
        }

        //Closes this form
        private void CancelButton_Click(object sender, EventArgs e)
        {
            controller.CancelButton();
        }

        private void AddNewProductScreen_Load(object sender, EventArgs e)
        {

        }
    }
}