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
        private Models.Product.ProductModel P;

        public InventoryEdit(Models.Product.ProductModel p)
        {
            InitializeComponent();
            P = p;

            ProductNaam.Text = "productnaam: " + P.Name;
            ProductAantal.Value = P.Amount;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            P.Amount = Convert.ToInt32(ProductAantal.Value);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}