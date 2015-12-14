using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Controllers.Assortment;
using KantoorInrichting.Models.Product;

namespace KantoorInrichting.Views.Assortment
{
    public partial class RemoveProductScreen : Form
    {
        private RemoveProductController controller;

        public RemoveProductScreen(ProductModel product)
        {
            InitializeComponent();
            controller = new RemoveProductController(this, product);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            controller.RemoveButton();
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            controller.CancelButton();
        }
    }
}
