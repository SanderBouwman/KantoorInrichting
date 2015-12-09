using KantoorInrichting.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KantoorInrichting.Controllers.Login
{
    class LoginController
    {
        private DatabaseController dbc;
        private LoginScreen screen;
        public MainFrame mainFrame;
        public LoginController(MainFrame mainFrame, LoginScreen screen)
        {
            this.screen = screen;
            dbc = DatabaseController.Instance;
            this.mainFrame = mainFrame;
        }
        public string GetSHA1(string Passwordt)
        {
            SHA1CryptoServiceProvider sh = new SHA1CryptoServiceProvider();
            sh.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Passwordt));
            byte[] re = sh.Hash;
            StringBuilder sb = new StringBuilder();
            foreach (byte b in re)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();

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
            string hash = GetSHA1(PasswordField);

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
                screen.UsernameError.Text = "Vul uw gebruikersnaam in";
            }
            else { screen.UsernameError.Text = ""; }

            //PasswordField is empty
            if (PasswordField == "")
            {
                screen.PasswordError.Text = "Vul uw wachtwoord in";
            }
            else { screen.PasswordError.Text = ""; }

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
                        screen.GeneralLoginError.Text = "Deze inlogcombinatie is onjuist";

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
                        screen.Visible = false;
                        screen.Enabled = false;

                        //IF EVERYTHING IS CORRECT RESET ATTEMPTS TO 0
                        KantoorInrichtingDataSet.userRow UserRow = dbc.DataSet.user.FindByusername(UsernameField);
                        UserRow.attempts = 0;
                        dbc.UserTableAdapter.Update(dbc.DataSet.user);
                    }
                }
                else
                {
                    screen.GeneralLoginError.Text = "Dit account is geblokkeerd";
                }
            }
        }
    }
}
