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
            Invalidate();
        }

        public InventoryScreen()
        {
            InitializeComponent();
            FillData();
            Invalidate();
        }

        public void FillData()
        {
            this.dataGridView1.DataSource = null;
            dataGridView1.AutoGenerateColumns = false;
            Models.Product.Product.result = Models.Product.Product.list;
            this.dataGridView1.DataSource = Models.Product.Product.result;    
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            if (checkBox1.Checked == true)
            {
                //foreach (Models.Product.Product product in Models.Product.Product.result)
                //{
                //    if (product.amount == 0)
                //    {
                //        Models.Product.Product.result.Remove(product);
                //    }
                //}
            }
            else if (checkBox1.Checked == false)
            {
                //foreach (Models.Product.Product product in Models.Product.Product.result)
                //{
                //    if (product.amount == 0)
                //    {
                //        Models.Product.Product.result.Add(product);
                //    }
                //}
            }
            
            dataGridView1.DataSource = Models.Product.Product.result;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0) {

                if (e.ColumnIndex == 8)
                {
                    // run edit screen here
                    DialogResult result = MessageBox.Show("run edit screen here", "Confirmation", MessageBoxButtons.YesNoCancel);
                    // make an editscreen with current product as argument
                    InventoryEdit edit = new InventoryEdit(Models.Product.Product.list[e.RowIndex]);
                }

                if (e.ColumnIndex == 9)
                {
                    // run delete screen here
                    DialogResult result = MessageBox.Show("run delete screen here", "Confirmation", MessageBoxButtons.YesNoCancel);
                    // make an Removescreen with current product as argument
                    InventoryRemove remove = new InventoryRemove(Models.Product.Product.list[e.RowIndex]);
                }

            }
                  
        }
    }
    }

