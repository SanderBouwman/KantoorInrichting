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

            productNameLabel.Text = "Productnaam: " + product.Name;
            productAmount.Value = product.Amount;
        }
        //sets the amount from the product to the given value
        private void button1_Click(object sender, EventArgs e)
        {
            //P.Amount = Convert.ToInt32(productAmount.Value);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editButton_Click(object sender, EventArgs e)
        {

        }
    }
}