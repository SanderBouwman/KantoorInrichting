using KantoorInrichting.Models.Product;
using KantoorInrichting.Views.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantoorInrichting.Controllers.Inventory
{
    public class InventoryEditController
    {
        private DatabaseController dbc;
        private InventoryEdit screen;
        private ProductModel product;
        private InventoryScreen inventoryScreen;
        public int amount { get; set; }

        public InventoryEditController(InventoryEdit screen, ProductModel product, InventoryScreen inventoryScreen)
        {
            dbc = DatabaseController.Instance;
            this.product = product;
            this.screen = screen;
            this.inventoryScreen = inventoryScreen;
            FillWithProductInfo();
        }

        //Get the product info and set the matching labels/fields
        private void FillWithProductInfo()
        {
            screen.productNameLabel.Text = product.Name;
            screen.productAmount.Value = product.Amount;
        }

        //Update the existing ProductModel
        public void UpdateProductModel()
        {
            amount = (int)screen.productAmount.Value;
            product.Amount = amount;
            //If the amount is 0, remove it from the result list.
            if (product.Amount == 0 && inventoryScreen.checkBox1.Checked)
            {
                ProductModel.result.Remove(product);
            }
        }

        //Update the prodcut in the database
        private void UpdateProductInDatabase()
        {
            //Fill the TableAdapter with data from the dataset
            try
            {
                //Search the tabel Product for a certain ProductID
                var productRow = dbc.DataSet.product.FindByproduct_id(product.Product_id);

                productRow.amount = product.Amount;

                //Update the database with the new Data
                dbc.ProductTableAdapter.Update(dbc.DataSet.product);

                MessageBox.Show("Update successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed" + ex);
            }
        }

        //Edit product button
        public void editButton()
        {
            UpdateProductModel();
            UpdateProductInDatabase();
            screen.Close();
        }

        //Closes this form
        public void cancelButton()
        {
            screen.Close();
        }
    }
}
