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
        public InventoryScreen(MainFrame hoofdscherm)
        {
            this.hoofdscherm = hoofdscherm;
            InitializeComponent();
            FillData();
            FillDropdown();
            Invalidate();

        }

       

        public void FillData()
        {
            this.dataGridView1.DataSource = null;
            dataGridView1.AutoGenerateColumns = false;
            List<ProductModel> filterResult = FilterNoAmount();
            ProductModel.result = new SortableBindingList<ProductModel>(filterResult);
            this.dataGridView1.DataSource = ProductModel.result;

        }

        public void FillDropdown()
        {
            DropdownMerk.Items.Clear();

            var MerkResult = ProductModel.list.GroupBy(product => product.Brand)
                   .Select(grp => grp.First())
                   .ToList();

            DropdownMerk.Items.Insert(0, "geen merkfilter");

            foreach (ProductModel product in MerkResult)
            {
                DropdownMerk.Items.Add(product.Brand);

            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // check if there is an brand filter
            if (DropdownMerk.SelectedItem != null)
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
                dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // when an cell is clicked
            var senderGrid = (DataGridView)sender;

            // if the clicked cell is an column, and the row is not the header
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0) {

                // if thecolumnindex is 9 opens the edit screen
                if (e.ColumnIndex == 9)
                {
                    // run edit screen here
                    // make an editscreen with current product as argument
                    InventoryEdit edit = new InventoryEdit(Models.Product.ProductModel.list[e.RowIndex],this);
                    edit.Show();
                }

                // if thecolumnindex is 10 opens the delete screen
                if (e.ColumnIndex == 10)
                {
                    // run delete screen here
                    // make an Removescreen with current product as argument
                    InventoryRemove remove = new InventoryRemove(Models.Product.ProductModel.list[e.RowIndex],this);
                    remove.Show();
                }

            }
                  
        }

        private void DropdownMerk_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterBrand();
        }
        public void FilterBrand()
        {
            List<ProductModel> filterResult1 = FilterNoAmount();
            ProductModel.result = new SortableBindingList<ProductModel>(filterResult1);
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            string selectedBrand = DropdownMerk.SelectedItem.ToString();
            
            // if there is a brand selected and it is not default
            if (DropdownMerk.SelectedIndex != 0)
            {
                // filter on the selected brand
                var filteredProducts = from product in ProductModel.result
                                       where product.Brand == selectedBrand
                                       select product;

                var filterResult2 = new List<ProductModel>();
                filterResult2 = filteredProducts.ToList();
                ProductModel.result = new SortableBindingList<ProductModel>(filterResult2);
            }
            dataGridView1.DataSource = ProductModel.result;
            dataGridView1.Refresh();

        }
        public List<ProductModel> FilterNoAmount()
        {
            // filter the data to only view products with an amount
            var filteredProducts = from product in ProductModel.list
                                   where product.Amount >= 1
                                   select product;

            var filterResult = new List<ProductModel>();
            filterResult = filteredProducts.ToList();
            return filterResult;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            DropdownMerk.SelectedIndex = 0;
            dataGridView1.Refresh();
        }
    }

    }

