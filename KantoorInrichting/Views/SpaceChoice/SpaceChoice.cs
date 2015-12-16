using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantoorInrichting.Views.SpaceChoice
{
    public partial class SpaceChoice : UserControl
    {
        public MainFrame hoofdscherm;

        public SpaceChoice(MainFrame hoofdscherm)
        {
            this.hoofdscherm = hoofdscherm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hoofdscherm.Size = new Size(1150, 750);
            hoofdscherm.MinimumSize = new Size(1100, 720);
            hoofdscherm.placement.Visible = true;
            hoofdscherm.placement.Enabled = true;

            //Update the data (size and colour of the PlacedProduct, information of the ProductList and ProductInfo)
            hoofdscherm.placement.fixData();

            this.Visible = false;
            hoofdscherm.placement.BringToFront();
        }
    }
}
