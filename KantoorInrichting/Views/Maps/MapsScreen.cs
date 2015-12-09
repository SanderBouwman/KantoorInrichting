using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Models.Maps;
using System.IO;
using KantoorInrichting.Controllers.Map;

namespace KantoorInrichting.Views.Maps
{
    public partial class MapsScreen : UserControl
    {
        private MapsController controller;
        public MainFrame mainFrame;
        public MapsScreen(MainFrame mainFrame)
        {
            this.mainFrame = mainFrame;
            InitializeComponent();
            controller = new MapsController(this);
        }

        private void MapsGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            controller.MapsGridView1_CellContentClick(sender, e);
        }
    }
}
