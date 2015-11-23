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
        private string productnaam = "Stoel";
        private int productammount = 5;



        public InventoryEdit()
        {
            InitializeComponent();
            ProductNaam.Text = "productnaam: " + productnaam;
            ProductAantal.Value = productammount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal productaantal = ProductAantal.Value;
            MessageBox.Show("SQL query:\nUPDATE product \nSET aantal = " + productaantal + " \nWHERE productnaam = '" + productnaam + "'");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}