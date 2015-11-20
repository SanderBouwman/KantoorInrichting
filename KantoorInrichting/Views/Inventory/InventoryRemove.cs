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
    public partial class InventoryRemove : Form
    {
        public event EventHandler InventoryEditorScreenClick;

        public InventoryRemove()
        {
            InitializeComponent();
        }


        private void InventoryEditor_Load(object sender, EventArgs e)
        {
            MessageBox.Show("gelukt");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Verwijderd!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Geannuleerd!");
        }

    }
}
