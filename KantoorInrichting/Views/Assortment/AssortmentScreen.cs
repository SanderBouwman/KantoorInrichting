using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.productTableAdapter.Fill(this.kantoorInrichtingDataSet.Product);
            var productLijst = kantoorInrichtingDataSet.Product;

            //Foreach product in the database create a product object
            foreach (var product in productLijst)
            {
                Models.Product.ProductModel p1 = new Models.Product.ProductModel(product.Product_ID, product.Name, product.Brand, product.Type,
                    product.Category_ID.ToString(), "Stoeltje", product.Length, product.Width, product.Height, product.Description, product.Amount);
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = Models.Product.ProductModel.list2;
        }

        //Opens AddNewProductScreen when this button is pressed
        private void AddProductButton_Click(object sender, EventArgs e)
        {
            AddNewProductScreen addNewProduct = new AddNewProductScreen();
            addNewProduct.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 9)
                {
                    // run edit screen here
                    // make an editscreen with current product as argument

                    EditProductScreen editProduct =  new EditProductScreen(Models.Product.ProductModel.list2[e.RowIndex]);
                    editProduct.ShowDialog();
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

                    /*
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                    int product_ID = Convert.ToInt32(selectedRow.Cells["Product_ID"].Value);

                    KantoorInrichtingDataSet.ProductRow productRow =
                        kantoorInrichtingDataSet.Product.FindByProduct_ID(product_ID);
                    */
