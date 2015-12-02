using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Controllers;

namespace KantoorInrichting.Views.Inventory
{
    public partial class InventoryScreen : UserControl
    {

        public MainFrame hoofdscherm;
        public InventoryScreen(MainFrame hoofdscherm )  // There's not supposed to be any logic in the view, I'd move most of the methods in here to a controller.
        {                                               // For an example, look at GridFieldView
            this.hoofdscherm = hoofdscherm;             // -Robin
            // init screen and fill all the data
            InitializeComponent();
            FillData();
            FillDropdown();
            Invalidate();

            // debug tool 
            //foreach (var product in ProductModel.list)
            //{
            //    MessageBox.Show(product.Name);
            //}

        }

       

        public void FillData()
        {
            this.dataGridView1.DataSource = null;
            dataGridView1.AutoGenerateColumns = false;
            // filter default no 0 values
            List<ProductModel> filterResult = FilterNoAmount();
            // add filterResult to new sortable list
            ProductModel.result = new SortableBindingList<ProductModel>(filterResult);
            // the datasource of the datagridview is the filterresult
            this.dataGridView1.DataSource = ProductModel.result;

        }

        public void FillDropdown()
        {
            // clear both dropdowns
            DropdownMerk.Items.Clear();
            DropdownCategorie.Items.Clear();

            // distinct from all the items in the productlist
            var BrandResult = ProductModel.list.GroupBy(product => product.Brand)
                   .Select(grp => grp.First())
                   .ToList();

            var CategoryResult = ProductModel.list.GroupBy(product => product.Category)
                   .Select(grp => grp.First())
                   .ToList();

            // insert default
            DropdownMerk.Items.Insert(0, "geen merkfilter");
            DropdownCategorie.Items.Insert(0, "geen categoriefilter");

            
            // add the unique items to brand dropdown
            foreach (ProductModel product in BrandResult)
            {
                if (product.Brand != null)
                {
                    DropdownMerk.Items.Add(product.Brand);
                }
            }
            // add the unique items to category dropdown
            foreach (ProductModel product in CategoryResult)
            {
                if (product.Category != null)
                {
                    DropdownCategorie.Items.Add(product.Category);
                }
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // if the checkbox has changed 

            // check if there is an brand filter
            if (DropdownMerk.SelectedIndex > 0)
            {
                // add all product with amount of less than 1 and filtered on the brand
                if (checkBox1.Checked == false)
                {
                    foreach (ProductModel product in ProductModel.list)
                    {
                        if (product.amount < 1 && product.brand == DropdownMerk.SelectedItem.ToString())
                        {
                            ProductModel.result.Add(product);
                        }
                    }
                }
                // remove all product with amount of less than 1 and filtered on the brand
                if (checkBox1.Checked == true)
                {
                    foreach (ProductModel product in ProductModel.list)
                    {
                        if (product.amount < 1 && product.brand == DropdownMerk.SelectedItem.ToString())
                        {
                            ProductModel.result.Remove(product);
                        }
                    }
                }
            }

            // if there is a category filter only
            else if (DropdownCategorie.SelectedIndex > 0){
                // add all product with amount of less than 1 and filtered on the brand
                if (checkBox1.Checked == false)
                {
                    foreach (ProductModel product in ProductModel.list)
                    {
                        if (product.amount < 1 && product.Category == DropdownCategorie.SelectedItem.ToString())
                        {
                            ProductModel.result.Add(product);
                        }
                    }
                }
                // remove all product with amount of less than 1 and filtered on the brand
                if (checkBox1.Checked == true)
                {
                    foreach (ProductModel product in ProductModel.list)
                    {
                        if (product.amount < 1 && product.Category == DropdownCategorie.SelectedItem.ToString())
                        {
                            ProductModel.result.Remove(product);
                        }
                    }
                }
            }
            else
            {
                // add all product with amount of less than 1
                if (checkBox1.Checked == false)
                {
                    foreach (ProductModel product in ProductModel.list)
                    {
                        if (product.amount < 1)
                        {

                            ProductModel.result.Add(product);
                        }
                    }
                }
                // remove all product with amount of less than 1
                if (checkBox1.Checked == true)
                {
                    foreach (ProductModel product in ProductModel.list)
                    {
                        if (product.amount < 1)
                        {
                            ProductModel.result.Remove(product);
                        }
                    }
                }
            }

                dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // when an cell is clicked
            var senderGrid = (DataGridView)sender;

            // if the clicked cell is an column, and the row is not the header
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0) {

                // if thecolumnindex is 11 opens the edit screen
                if (e.ColumnIndex == 11)
                {

                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                    string currentProductId = Convert.ToString(selectedRow.Cells["nr"].Value);
                    int currentProduct = Int32.Parse(currentProductId);
                   
                    ////test
                    //MessageBox.Show(currentProductId);

 
                    // linq select product with the current ID
                    var selectedproduct1 = ProductModel.list
                            .Where(t => t.product_ID == currentProduct)
                            .Select(t => t)
                            .ToList();


                    // run edit screen here
                    // make an editscreen with current product as argument
                    InventoryEdit edit = new InventoryEdit(selectedproduct1[0], this);
                    edit.Show();
                }
            }
                  
        }

        private void DropdownMerk_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if the brand dropdown is changed, the checkbox is set to true.
            checkBox1.Checked = true;
            // filter the datagridview with the selected brand
            FilterBrand();
        }

        private void DropdownCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if the category dropdown is changed, the checkbox is set to true.
            checkBox1.Checked = true;
            // filter the datagridview with the selected category
            FilterCategory();
        }

        public void FilterBrand()
        {
            // filter the data
            List<ProductModel> filterResult1 = FilterNoAmount();
            ProductModel.result = new SortableBindingList<ProductModel>(filterResult1);

            // delete datasource
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            // get selected brand
            string selectedBrand = DropdownMerk.SelectedItem.ToString();
            
            // if there is a brand selected and it is not default
            if (DropdownMerk.SelectedIndex != 0)
            {
                // filter on the selected brand
                var filteredProducts = from product in ProductModel.result
                                       where product.Brand == selectedBrand
                                       select product;

                // add filter list to result list
                var filterResult2 = new List<ProductModel>();
                filterResult2 = filteredProducts.ToList();
                ProductModel.result = new SortableBindingList<ProductModel>(filterResult2);
            }
            // bind the datasource again
            dataGridView1.DataSource = ProductModel.result;
            dataGridView1.Refresh();

        }

        public void FilterCategory()
        {
            // filter the data
            List<ProductModel> filterResult1 = FilterNoAmount();
            ProductModel.result = new SortableBindingList<ProductModel>(filterResult1);
            // delete datasource
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            // get selected category
            string selectedCategory = DropdownCategorie.SelectedItem.ToString();

            // if there is a category selected and it is not default
            if (DropdownCategorie.SelectedIndex != 0)
            {
                // filter on the selected category
                var filteredProducts = from product in ProductModel.result
                                       where product.category == selectedCategory
                                       select product;
                // add filter list to result list
                var filterResult2 = new List<ProductModel>();
                filterResult2 = filteredProducts.ToList();
                ProductModel.result = new SortableBindingList<ProductModel>(filterResult2);
            }
            // bind the datasource again
            dataGridView1.DataSource = ProductModel.result;
            dataGridView1.Refresh();
        }

        public List<ProductModel> FilterNoAmount()
        {
            // filter the data to only view products with an amount
            var filteredProducts = from product in ProductModel.list
                                   where product.Amount >= 1
                                   select product;

            // return the filtered results.
            var filterResult = new List<ProductModel>();
            filterResult = filteredProducts.ToList();
            return filterResult;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // if button 1 is clicked, all filters are reset
            checkBox1.Checked = true;
            DropdownMerk.SelectedIndex = 0;
            DropdownCategorie.SelectedIndex = 0;
            dataGridView1.Refresh();
        }
    }
    }

