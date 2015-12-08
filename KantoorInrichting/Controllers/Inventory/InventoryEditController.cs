using KantoorInrichting.Models.Product;
using KantoorInrichting.Views.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KantoorInrichting.Controllers.Inventory
{
    class InventoryEditController
    {
        private DatabaseController dbc;
        private InventoryEdit screen;

        public InventoryEditController(InventoryEdit screen , ProductModel product)
        {
            dbc = DatabaseController.Instance;
            this.screen = screen;
        }

        //sets the amount from the product to the given value
        private void button1_Click(object sender, EventArgs e)
        {
            //P.Amount = Convert.ToInt32(productAmount.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
    }
}
