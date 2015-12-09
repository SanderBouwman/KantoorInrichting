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
        private DatabaseController dbc;
        private ProductModel product;
        private RemoveProductScreen screen;


        public RemoveProductController(RemoveProductScreen screen, ProductModel product)
        {
            dbc = DatabaseController.Instance;
            this.screen = screen;
            this.product = product;
            screen.productNameLabel.Text = product.Name;
        }

        //Update the existing ProductModel
        private void UpdateProductModel()
        {
            product.Removed = true;
        }

        //Update the product in the database
        private void UpdateProductInDatabase()
        {
            try
            {
                //Search the tabel Product for a certain ProductID
                var productRow = dbc.DataSet.product.FindByproduct_id(product.Product_id);
                productRow.removed = product.Removed;

                //Update the database with the new Data
                dbc.ProductTableAdapter.Update(dbc.DataSet.product);
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
            screen.Close();
        }

        //The cancel button
        public void CancelButton()
        {
            screen.Close();
        }
    }
}
