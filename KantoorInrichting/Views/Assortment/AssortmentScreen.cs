using System;
using System.Windows.Forms;
using KantoorInrichting.Models.Product;

namespace KantoorInrichting.Views.Assortment
{
    public partial class AssortmentScreen : UserControl
    {
        public MainFrame hoofdscherm;

        public AssortmentScreen(MainFrame hoofdscherm)
        {
            this.hoofdscherm = hoofdscherm;
            InitializeComponent();
            FillData();
            Invalidate();
        }

        //Fill the datagridview with data
        public void FillData()
        {
            //Fill the TableAdapter with data from the dataset
            productTableAdapter.Fill(kantoorInrichtingDataSet.Product);
            var productLijst = kantoorInrichtingDataSet.Product;

            //Foreach product in the database create a product object
            foreach (var product in productLijst)
            {
                var p1 = new ProductModel(product.Product_ID, product.Name, product.Brand, product.Type,
                    product.Category_ID, product.Length, product.Width, product.Height, product.Description,
                    product.Amount, product.Image);
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ProductModel.list;
        }

        //Opens AddNewProductScreen when this button is pressed
        private void AddProductButton_Click(object sender, EventArgs e)
        {
            var addNewProduct = new AddNewProductScreen();
            addNewProduct.ShowDialog();
            dataGridView1.DataSource = ProductModel.list;
            this.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView) sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)               // There's not supposed to be any logic in the view
            {                                                                                                   // For an example, look at the GridFieldView class
                if (e.ColumnIndex == 9)                                                                         // -Robin
                {
                    // run edit screen here
                    // make an editscreen with current product as argument
                    var editProduct = new EditProductScreen(ProductModel.list[e.RowIndex]);
                    editProduct.ShowDialog();
                    dataGridView1.DataSource = ProductModel.list;
                    this.Refresh();
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