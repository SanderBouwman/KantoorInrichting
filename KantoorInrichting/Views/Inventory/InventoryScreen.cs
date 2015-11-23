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
    }
    }

