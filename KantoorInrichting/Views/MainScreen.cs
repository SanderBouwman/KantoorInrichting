using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantoorInrichting.Views
{
    public partial class MainScreen : UserControl
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void VooraadButton_Click(object sender, EventArgs e)
        {
            //VoorraadScherm.Visible = true;
            //VoorraadScherm.Enabled = true;
            this.Visible = false;
            //VoorraadScherm.BringToFront();
        }
    }
}
