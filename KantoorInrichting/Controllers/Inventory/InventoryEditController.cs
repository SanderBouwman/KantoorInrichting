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
        private readonly DatabaseController _dbc;
        private readonly InventoryEdit _screen;
        private readonly ProductModel _product;
        private readonly InventoryScreen _inventoryScreen;
        public int Amount { get; set; }

        public InventoryEditController(InventoryEdit screen, ProductModel product, InventoryScreen inventoryScreen)
        {
            _dbc = DatabaseController.Instance;
            this._product = product;
            this._screen = screen;
            this._inventoryScreen = inventoryScreen;
            FillWithProductInfo();
        }

        //Get the product info and set the matching labels/fields
        private void FillWithProductInfo()
        {
            _screen.productNameLabel.Text = _product.Name;
            _screen.productAmount.Value = _product.Amount;
        }

        //Update the existing ProductModel
        public void UpdateProductModel()
        {
            Amount = (int)_screen.productAmount.Value;
            _product.Amount = Amount;
            //If the amount is 0, remove it from the result list.
            if (_product.Amount == 0 && _inventoryScreen.checkBox1.Checked)
            {
                ProductModel.result.Remove(_product);
            }
        }

        //Update the prodcut in the database
        private void UpdateProductInDatabase()
        {
            //Fill the TableAdapter with data from the dataset
            try
            {
                //Search the tabel Product for a certain ProductID
                var productRow = _dbc.DataSet.product.FindByproduct_id(_product.Product_id);

                productRow.amount = _product.Amount;

                //Update the database with the new Data
                _dbc.ProductTableAdapter.Update(_dbc.DataSet.product);

                MessageBox.Show("Update successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed" + ex);
            }
        }

        //Edit product button
        public void EditButton()
        {
            UpdateProductModel();
            UpdateProductInDatabase();
            _screen.Close();
        }

        //Closes this form
        public void CancelButton()
        {
            _screen.Close();
        }
    }
}
