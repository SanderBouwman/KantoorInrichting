using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantoorInrichting.Views.Maps
{
    public partial class MapsScreen : UserControl
    {
        public MainFrame mainFrame;
        public MapsScreen(MainFrame mainFrame)                        
        {                                                                                                                                
            this.mainFrame = mainFrame;
            InitializeComponent();
        }
    }
}
