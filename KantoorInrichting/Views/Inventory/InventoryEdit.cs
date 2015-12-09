using KantoorInrichting.Controllers.Inventory;
using KantoorInrichting.Models.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantoorInrichting.Views.Inventory
{
    public partial class InventoryEdit : Form
    {
        private InventoryEditController controller;

        //makes sure the productnaam and amount are filled in correctly in the screen
        public InventoryEdit(ProductModel product)
        {
            InitializeComponent();
            controller = new InventoryEditController(this, product);
        }

        //Edit product button
        private void editButton_Click(object sender, EventArgs e)
        {
            controller.editButton();
        }

        //Cancel button
        private void cancelButton_Click(object sender, EventArgs e)
        {
            controller.cancelButton();
        }
    }
}