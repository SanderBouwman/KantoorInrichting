using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Views.Assortment;

namespace KantoorInrichting.Controllers.Assortment
{
    
    class RemoveProductController
    {
        private readonly DatabaseController _dbc;
        private readonly RemoveProductScreen _screen;
        private readonly ProductModel _product;


        public RemoveProductController(RemoveProductScreen screen, ProductModel product)
        {
            _dbc = DatabaseController.Instance;
            this._screen = screen;
            this._product = product;
            screen.productNameLabel.Text = product.Name;
        }

        //Update the existing ProductModel
        private void UpdateProductModel()
        {
            _product.Removed = true;
        }

        //Update the product in the database
        private void UpdateProductInDatabase()
        {
            try
            {
                //Search the tabel Product for a certain ProductID
                var productRow = _dbc.DataSet.product.FindByproduct_id(_product.Product_id);
                productRow.removed = _product.Removed;

                //Update the database with the new Data
                _dbc.ProductTableAdapter.Update(_dbc.DataSet.product);
                MessageBox.Show("Update successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed" + ex);
            }
        }

        //Remove product button
        public void RemoveButton()
        {
            UpdateProductModel();
            UpdateProductInDatabase();
            _screen.Close();
        }

        //The cancel button
        public void CancelButton()
        {
            _screen.Close();
        }
    }
}
