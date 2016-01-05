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
            SpaceInfo = new Dictionary<string, string>();
            cbx_Building.SelectedIndex = 0; //Setting a default value
        }

        private void NumberChanged(object sender, EventArgs e)
        {
            SpaceInfo["Building"] = cbx_Building.Text;
            SpaceInfo["Floor"] = nud_Floor.Value.ToString();

            //If the room is less than 10, it gets a 0 before the number. ex. 5 becomes 05 / 9 becomes 09.
            SpaceInfo["Room"] = "";
            if (nud_Room.Value < 10) { SpaceInfo["Room"] = "0"; }            
            SpaceInfo["Room"] += nud_Room.Value.ToString();
            
            SpaceInfo["Width"] = nud_Width.Value.ToString();
            SpaceInfo["Length"] = nud_Length.Value.ToString();

            //Update the label that displays the number of the space in full
            SpaceInfo["Total"] = SpaceInfo["Building"] + SpaceInfo["Floor"] + "." + SpaceInfo["Room"];
            lbl_CalculatedNumber.Text = SpaceInfo["Total"];                 
        }
    }
}
