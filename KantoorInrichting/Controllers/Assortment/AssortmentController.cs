using KantoorInrichting.Models.Product;
using KantoorInrichting.Views.Assortment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantoorInrichting.Controllers.Assortment
{
    class AssortmentController
    {
        private AssortmentScreen screen;

        public AssortmentController(AssortmentScreen assortment)
        {
            this.screen = assortment;

        }

        //Fill the datagridview with data
        public void FillData()
        {
            screen.assortmentGridView.AutoGenerateColumns = false;
            screen.assortmentGridView.DataSource = ProductModel.list;
        }

        //Opens AddNewProductScreen when this button is pressed
        public void AddProduct()
        {
            var addNewProduct = new AddNewProductScreen();
            addNewProduct.ShowDialog();
            screen.assortmentGridView.DataSource = ProductModel.list;
            screen.Refresh();
        }


        //This methods checks which cell has been clicked and then opens a dialog to edit or remove a specific product 
        public void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 9)
                {
                    // run edit screen here
                    // make an editscreen with current product as argument
                    var editProduct = new EditProductScreen(ProductModel.list[e.RowIndex]);
                    editProduct.ShowDialog();
                    screen.assortmentGridView.DataSource = ProductModel.list;
                    screen.Refresh();
                }

                if (e.ColumnIndex == 10)
                {
                    // run delete screen here
                    // make an Removescreen with current product as argument
                }
            }
        }
    }
}
