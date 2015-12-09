using KantoorInrichting.Models.Product;
using KantoorInrichting.Views.Assortment;
using System.Windows.Forms;

namespace KantoorInrichting.Controllers.Assortment
{
    class AssortmentController
    {
        private AssortmentScreen screen;

        public AssortmentController(AssortmentScreen assortment)
        {
            this.screen = assortment;
            FillData();
        }

        //Fill the datagridview with data
        private void FillData()
        {
            screen.assortmentGridView.AutoGenerateColumns = false;
            screen.assortmentGridView.DataSource = ProductModel.list;
        }

        //Opens AddNewProductScreen when this button is pressed
        public void AddProduct()
        {
            var addNewProduct = new AddNewProductScreen();
            addNewProduct.ShowDialog();
            screen.assortmentGridView.DataSource = null;
            screen.assortmentGridView.DataSource = ProductModel.list;
            screen.assortmentGridView.Refresh();
        }


        //This methods checks which cell has been clicked and then opens a dialog to edit or remove a specific product 
        public void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 10)
                {
                    // run edit screen here
                    // make an editscreen with current product as argument
                    var editProduct = new EditProductScreen(ProductModel.list[e.RowIndex]);
                    editProduct.ShowDialog();
                    screen.assortmentGridView.DataSource = null;
                    screen.assortmentGridView.DataSource = ProductModel.list;
                    screen.assortmentGridView.Refresh();
                }

                if (e.ColumnIndex == 11)
                {
                    var removeProduct = new RemoveProductScreen(ProductModel.list[e.RowIndex]);
                    removeProduct.ShowDialog();
                    screen.assortmentGridView.DataSource = null;
                    screen.assortmentGridView.DataSource = ProductModel.list;
                    screen.assortmentGridView.Refresh();
                }
            }
        }
    }
}
