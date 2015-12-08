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
        LoginController controllerLogin = new LoginController();
        public MainFrame mainFrame;
        public LoginScreen(MainFrame mainFrame)                         // There's not supposed to be any logic in the view, so I'd move most of the methods in here to a controller
        {                                                               // For an example, look at GridFieldView
            dbc = DatabaseController.Instance;
            this.mainFrame = mainFrame;
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginMethod(UsernameTB.Text, PasswordTB.Text);
        }

        public void LoginMethod(string UsernameField, string PasswordField)
        {
            // TODO: This line of code loads data into the 'kantoorInrichtingDataSet.User' table. You can move, or remove it, as needed.
            dbc.UserTableAdapter.Fill(dbc.DataSet.user);
            var INLOGGEN = dbc.DataSet.user;
            string USERNAME = "";
            string PASSWORD = "";
            int ROLE;
            int attempts = 0;
            string hash = controllerLogin.GetSHA1(PasswordField);

            // Get data only when password and username match
            var linqInloggen =
                       from inloggegevens in INLOGGEN
                       where inloggegevens.username == UsernameField && inloggegevens.password == hash
                       select inloggegevens;

            foreach (var p in linqInloggen)
            {
                USERNAME = p.username;
                PASSWORD = p.password;
                attempts = p.attempts;
                ROLE = p.role_id;
            }

            // UsernameField is empty
            if (UsernameField == "")
            {
                UsernameError.Text = "Vul uw gebruikersnaam in";
            }
            else { UsernameError.Text = ""; }

            //PasswordField is empty
            if (PasswordField == "")
            {
                PasswordError.Text = "Vul uw wachtwoord in";
            }
            else { PasswordError.Text = ""; }

            // Both fields are filled
            if (PasswordField != "" && UsernameField != "")
            {
                var linq =
                       from inloggegevens in INLOGGEN
                       where inloggegevens.username == UsernameField
                       select inloggegevens;

                foreach (var p in linq)
                {
                    attempts = p.attempts;
                    USERNAME = p.username;
                }

                if (attempts < 3)
                {
                    // If username and password are still empty the combination is wrong
                    if (USERNAME == "" || PASSWORD == "")
                    {
                        GeneralLoginError.Text = "Deze inlogcombinatie is onjuist";

                        KantoorInrichtingDataSet.userRow UserRow = dbc.DataSet.user.FindByusername(UsernameField);
                        if (USERNAME != "")
                        {
                            UserRow.attempts++;
                            dbc.UserTableAdapter.Update(dbc.DataSet.user);
                        }
                    }
                    // Username and password are correct
                    else
                    {
                        //SHOWING MAIN MENU
                        mainFrame.mainScreen1.Visible = true;
                        mainFrame.mainScreen1.Enabled = true;
                        this.Visible = false;
                        this.Enabled = false;

                        //IF EVERYTHING IS CORRECT RESET ATTEMPTS TO 0
                        KantoorInrichtingDataSet.userRow UserRow = dbc.DataSet.user.FindByusername(UsernameField);
                        UserRow.attempts = 0;
                        dbc.UserTableAdapter.Update(dbc.DataSet.user);
                    }
                }
                else
                {
                    GeneralLoginError.Text = "Dit account is geblokkeerd";
                }
            }
        }

        private void LoginScreen_Load_1(object sender, EventArgs e)
        {
            UsernameTB.Text = "Rick";
            PasswordTB.Text = "rick";
        }



        private void PasswordTB_TextChanged_1(object sender, EventArgs e)
        {
            PasswordTB.PasswordChar = '*';

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                LoginButton.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
