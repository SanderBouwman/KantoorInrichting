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
        private Models.Product.ProductModel P;
        private UserControl U;



        public InventoryEdit(Models.Product.ProductModel p, UserControl u)
        {
            InitializeComponent();
            P = p;
            this.U = u;

            ProductNaam.Text = "productnaam: " + P.name;
            ProductAantal.Value = P.amount;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            P.amount = Convert.ToInt32(ProductAantal.Value);
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