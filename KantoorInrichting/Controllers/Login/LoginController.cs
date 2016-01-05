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
        private readonly DatabaseController _dbc;
        private readonly LoginScreen _screen;
        public MainFrame MainFrame;
        public LoginController(MainFrame mainFrame, LoginScreen screen)
        {
            this._screen = screen;
            _dbc = DatabaseController.Instance;
            this.MainFrame = mainFrame;
        }
        public string GetSha1(string password)
        {
            SHA1CryptoServiceProvider sh = new SHA1CryptoServiceProvider();
            sh.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
            byte[] re = sh.Hash;
            StringBuilder sb = new StringBuilder();
            foreach (byte b in re)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();

        }

        public void LoginMethod(string usernameField, string passwordField)
        {
            // TODO: This line of code loads data into the 'kantoorInrichtingDataSet.User' table. You can move, or remove it, as needed.
            _dbc.UserTableAdapter.Fill(_dbc.DataSet.user);
            var login = _dbc.DataSet.user;
            string username = "";
            string password = "";
            int role;
            int attempts = 0;
            string hash = GetSha1(passwordField);

            // Get data only when password and username match
            var linqLogin =
                       from inloggegevens in login
                       where inloggegevens.username == usernameField && inloggegevens.password == hash
                       select inloggegevens;

            foreach (var p in linqLogin)
            {
                username = p.username;
                password = p.password;
                attempts = p.attempts;
                role = p.role_id;
            }

            // UsernameField is empty
            if (usernameField == "")
            {
                _screen.UsernameError.Text = "Vul uw gebruikersnaam in";
            }
            else { _screen.UsernameError.Text = ""; }

            //PasswordField is empty
            if (passwordField == "")
            {
                _screen.PasswordError.Text = "Vul uw wachtwoord in";
            }
            else { _screen.PasswordError.Text = ""; }

            // Both fields are filled
            if (passwordField != "" && usernameField != "")
            {
                var linq =
                       from inloggegevens in login
                       where inloggegevens.username == usernameField
                       select inloggegevens;

                foreach (var p in linq)
                {
                    attempts = p.attempts;
                    username = p.username;
                }

                if (attempts < 3)
                {
                    // If username and password are still empty the combination is wrong
                    if (username == "" || password == "")
                    {
                        _screen.GeneralLoginError.Text = "Deze inlogcombinatie is onjuist";

                        KantoorInrichtingDataSet.userRow userRow = _dbc.DataSet.user.FindByusername(usernameField);
                        if (username != "")
                        {
                            userRow.attempts++;
                            _dbc.UserTableAdapter.Update(_dbc.DataSet.user);
                        }
                    }
                    // Username and password are correct
                    else
                    {
                        //SHOWING MAIN MENU
                        MainFrame.mainScreen1.Visible = true;
                        MainFrame.mainScreen1.Enabled = true;
                        MainFrame.menuStrip1.Visible = true;
                        _screen.Visible = false;
                        _screen.Enabled = false;

                        //IF EVERYTHING IS CORRECT RESET ATTEMPTS TO 0
                        KantoorInrichtingDataSet.userRow userRow = _dbc.DataSet.user.FindByusername(usernameField);
                        userRow.attempts = 0;
                        _dbc.UserTableAdapter.Update(_dbc.DataSet.user);
                    }
                }
                else
                {
                    _screen.GeneralLoginError.Text = "Dit account is geblokkeerd";
                }
            }
        }
    }
}
