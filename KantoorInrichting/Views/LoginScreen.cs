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
    public partial class LoginScreen : UserControl
    {
        public MainFrame mainFrame;
        public LoginScreen(MainFrame mainFrame)
        {
            this.mainFrame = mainFrame;
            InitializeComponent();
        }

        private void GeneralLoginError_Click(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            mainFrame.mainScreen1.Visible = true;
            this.Visible = false;
            this.Enabled = false;
        }
    }
}
