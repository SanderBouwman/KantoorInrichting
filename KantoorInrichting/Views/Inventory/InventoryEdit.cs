using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantoorInrichting.Views.Inventory
{
    public partial class InventoryEdit : Form
    {
        private string productname;
        private decimal productamount;
        private UserControl U;



        public InventoryEdit(Models.Product.ProductModel p, UserControl u)
        {
            InitializeComponent();
            this.productamount = p.amount;
            this.productname = p.name;
            this.U = u;

            ProductNaam.Text = "productnaam: " + productname;
            ProductAantal.Value = productamount;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal amount = ProductAantal.Value;
            MessageBox.Show("SQL query:\nUPDATE product \nSET aantal = " + amount + " \nWHERE productnaam = '" + productname + "'");
            this.Close();
            U.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            U.Refresh();
        }
    }
}