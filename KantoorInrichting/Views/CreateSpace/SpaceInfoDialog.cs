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
        public Dictionary<string, string> SpaceInfo { get; private set; }

        public SpaceInfoDialog()
        {
            InitializeComponent();

            cbx_Building.SelectedIndex = 0; //Setting a default value
        }

        private void NumberChanged(object sender, EventArgs e)
        {
            //Update the label that displays the number of the space in full
            SpaceInfo["Building"] = cbx_Building.Text;
            SpaceInfo["Floor"] = nud_Floor.ToString();
            SpaceInfo["Room"] = nud_Room.ToString();
            SpaceInfo["Total"] = SpaceInfo["Building"] + SpaceInfo["Floor"] + "." + SpaceInfo["Room"];
            SpaceInfo["Width"] = nud_Width.ToString();
            SpaceInfo["Length"] = nud_Length.ToString();
            lbl_CalculatedNumber.Text = SpaceInfo["Total"];
        }
    }
}
