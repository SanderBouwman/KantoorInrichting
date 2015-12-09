using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using KantoorInrichting.Controllers.Login;
using KantoorInrichting.Controllers;

namespace KantoorInrichting.Views
{
    public partial class LoginScreen : UserControl
    {
        private DatabaseController dbc;
        private LoginController controller;
        public MainFrame mainFrame;
        public LoginScreen(MainFrame mainFrame)                         // There's not supposed to be any logic in the view, so I'd move most of the methods in here to a controller
        {                                                               // For an example, look at GridFieldView
            dbc = DatabaseController.Instance;
            this.mainFrame = mainFrame;
            InitializeComponent();
            controller = new LoginController(mainFrame, this);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Method that managed login process
            controller.LoginMethod(UsernameTB.Text, PasswordTB.Text);
        }

       // To do: Remove this method when project is done
        private void LoginScreen_Load_1(object sender, EventArgs e)
        {
            UsernameTB.Text = "Rick";
            PasswordTB.Text = "rick";
        }

        private void PasswordTB_TextChanged_1(object sender, EventArgs e)
        {
            // Hide the password text
            PasswordTB.PasswordChar = '*';
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {//Check if enter has been pressed
            if (keyData == Keys.Enter)
            {
                LoginButton.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
