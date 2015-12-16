using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantoorInrichting.Views.CreateSpace
{
    public partial class SpaceInfoDialog : Form
    {
        public SpaceInfoDialog()
        {
            InitializeComponent();

            cbx_Building.SelectedIndex = 0; //Setting a default value
        }

        private void NumberChanged(object sender, EventArgs e)
        {
            //Update the label that displays the number of the space in full
            lbl_CalculatedNumber.Text = cbx_Building.Text + nud_Floor.ToString() + "." + nud_Room.ToString();
        }
    }
}
