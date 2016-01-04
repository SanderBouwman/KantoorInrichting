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
using KantoorInrichting.Controllers.Inventory;

namespace KantoorInrichting.Views.Inventory
{
    public partial class InventoryScreen : UserControl
    {
        readonly InventoryController _controller; 
        public MainFrame Hoofdscherm;


        public InventoryScreen(MainFrame hoofdscherm ) 
        {
            //create new controller for this screen
            this._controller = new InventoryController(this);                          
  
            this.Hoofdscherm = hoofdscherm;             
            // init screen and fill all the data
            InitializeComponent();
            _controller.FillData();
            _controller.FillDropdown();
            Invalidate();

       
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
                    foreach (ProductModel product in ProductModel.List)
                    {
                        if (product.Amount < 1 && product.Brand == DropdownMerk.SelectedItem.ToString())
                        {
                            ProductModel.Result.Add(product);
                        }
                    }
                }
                // remove all product with amount of less than 1 and filtered on the brand
                if (checkBox1.Checked == true)
                {
                    foreach (ProductModel product in ProductModel.List)
                    {
                        if (product.Amount < 1 && product.Brand == DropdownMerk.SelectedItem.ToString())
                        {
                            ProductModel.Result.Remove(product);
                        }
                    }
                }
            }

            // if there is a category filter only
            else if (DropdownCategorie.SelectedIndex > 0){
                // add all product with amount of less than 1 and filtered on the brand
                if (checkBox1.Checked == false)
                {
                    foreach (ProductModel product in ProductModel.List)
                    {
                        if (product.Amount < 1 && product.Category == DropdownCategorie.SelectedItem.ToString())
                        {
                            ProductModel.Result.Add(product);
                        }
                    }
                }
                // remove all product with amount of less than 1 and filtered on the brand
                if (checkBox1.Checked == true)
                {
                    foreach (ProductModel product in ProductModel.List)
                    {
                        if (product.Amount < 1 && product.Category == DropdownCategorie.SelectedItem.ToString())
                        {
                            ProductModel.Result.Remove(product);
                        }
                    }
                }
            }
            else
            {
                // add all product with amount of less than 1
                if (checkBox1.Checked == false)
                {
                    foreach (ProductModel product in ProductModel.List)
                    {
                        if (product.Amount < 1)
                        {

                            ProductModel.Result.Add(product);
                        }
                    }
                }
                // remove all product with amount of less than 1
                if (checkBox1.Checked == true)
                {
                    foreach (ProductModel product in ProductModel.List)
                    {
                        if (product.Amount < 1)
                        {
                            ProductModel.Result.Remove(product);
                        }
                    }
                }
            }

                dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {                                   
            // when an cell is clicked                                                      ///there is not supposed to be any logic in a view
            var senderGrid = (DataGridView)sender;

            // if the clicked cell is an column, and the row is not the header
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0) {

                // if thecolumnindex is 11 opens the edit screen
                if (e.ColumnIndex == 10)
                {

                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                    string currentProductId = Convert.ToString(selectedRow.Cells["nr"].Value);
                    int currentProduct = Int32.Parse(currentProductId);
                   
                    ////test
                    //MessageBox.Show(currentProductId);

 
                    // linq select product with the current ID
                    var selectedproduct1 = ProductModel.List
                            .Where(t => t.ProductId == currentProduct)
                            .Select(t => t)
                            .ToList();


                    // run edit screen here
                    // make an editscreen with current product as argument
                    InventoryEdit edit = new InventoryEdit(selectedproduct1[0], this);
                    edit.ShowDialog();
                    this.Refresh();
                }
            }
                  
        }

        private void DropdownMerk_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if the brand dropdown is changed, the checkbox is set to true.
            checkBox1.Checked = true;
            // filter the datagridview with the selected brand
            _controller.FilterBrand();
        }

        private void DropdownCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if the category dropdown is changed, the checkbox is set to true.
            checkBox1.Checked = true;
            // filter the datagridview with the selected category
            _controller.FilterCategory();
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

