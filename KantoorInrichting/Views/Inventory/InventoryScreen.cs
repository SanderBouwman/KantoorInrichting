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
            dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = KantoorInrichting.Models.Product.Product.list;
            
        }
    }
}
