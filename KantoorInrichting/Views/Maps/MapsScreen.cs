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

namespace KantoorInrichting.Views.Maps
{
    public partial class MapsScreen : UserControl
    {
        public MainFrame mainFrame;
        public MapsScreen(MainFrame mainFrame)
        {
            this.mainFrame = mainFrame;
            InitializeComponent();
            Space.result = Space.list;
            this.MapsGridView1.DataSource = Space.result;

        }
    }
}
