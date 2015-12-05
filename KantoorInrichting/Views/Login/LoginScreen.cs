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

namespace KantoorInrichting.Views
{
    public partial class LoginScreen : UserControl
    {
        LoginController controllerLogin = new LoginController();
        public MainFrame mainFrame;
        public LoginScreen(MainFrame mainFrame)                         // There's not supposed to be any logic in the view, so I'd move most of the methods in here to a controller
        {                                                               // For an example, look at GridFieldView
                                                                        // -Robin
            this.mainFrame = mainFrame;
            InitializeComponent();
        }

        private void GeneralLoginError_Click(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginMethod(UsernameTB.Text, PasswordTB.Text);
        }

       

        public void LoginMethod(string UsernameField, string PasswordField)
        {
            // TODO: This line of code loads data into the 'kantoorInrichtingDataSet.User' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.kantoorInrichtingDataSet.User);
            var INLOGGEN = kantoorInrichtingDataSet.User;
            string USERNAME = "";
            string PASSWORD = "";
            string ROLE = "";
            int attempts = 0;
            string hash = controllerLogin.GetSHA1(PasswordField);

            // Get data only when password and username match
            var linqInloggen =
                       from inloggegevens in INLOGGEN
                       where inloggegevens.Username == UsernameField && inloggegevens.Password == hash
                       select inloggegevens;

            foreach (var p in linqInloggen)
            {
                USERNAME = p.Username;
                PASSWORD = p.Password;
                attempts = p.Attempts;
                ROLE = p.Role;
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
                       where inloggegevens.Username == UsernameField
                       select inloggegevens;

                foreach (var p in linq)
                {
                    attempts = p.Attempts;
                    USERNAME = p.Username;
                }

                if (attempts < 3)
                {
                    // If username and password are still empty the combination is wrong
                    if (USERNAME == "" || PASSWORD == "")
                    {
                        GeneralLoginError.Text = "Deze inlogcombinatie is onjuist";

                        KantoorInrichtingDataSet.UserRow UserRow = kantoorInrichtingDataSet.User.FindByUsername(UsernameField);
                        if (USERNAME != "")
                        {
                            UserRow.Attempts++;
                            this.userTableAdapter.Update(this.kantoorInrichtingDataSet.User);
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
                        KantoorInrichtingDataSet.UserRow UserRow = kantoorInrichtingDataSet.User.FindByUsername(UsernameField);
                        UserRow.Attempts = 0;
                        this.userTableAdapter.Update(this.kantoorInrichtingDataSet.User);
                    }
                }
                else
                {
                    GeneralLoginError.Text = "Dit account is geblokkeerd";
                }
            }
        }

        private void userBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.userBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.kantoorInrichtingDataSet);

        }

        private void LoginScreen_Load_1(object sender, EventArgs e)
        {
           // UsernameTB.Text = "Rick";
           // PasswordTB.Text = "rick";
        }

       

        private void PasswordTB_TextChanged_1(object sender, EventArgs e)
        {
            PasswordTB.PasswordChar = '*';
        }
    }
}
