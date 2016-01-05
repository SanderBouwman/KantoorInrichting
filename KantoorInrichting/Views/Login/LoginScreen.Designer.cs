namespace KantoorInrichting.Views
{
    partial class LoginScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginButton = new System.Windows.Forms.Button();
            this.UsernameTB = new System.Windows.Forms.TextBox();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UsernameError = new System.Windows.Forms.Label();
            this.PasswordError = new System.Windows.Forms.Label();
            this.GeneralLoginError = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(124, 176);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(4);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(100, 28);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "Inloggen";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // UsernameTB
            // 
            this.UsernameTB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.UsernameTB.Location = new System.Drawing.Point(124, 108);
            this.UsernameTB.Margin = new System.Windows.Forms.Padding(4);
            this.UsernameTB.Name = "UsernameTB";
            this.UsernameTB.Size = new System.Drawing.Size(245, 27);
            this.UsernameTB.TabIndex = 1;
            // 
            // PasswordTB
            // 
            this.PasswordTB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PasswordTB.Location = new System.Drawing.Point(124, 144);
            this.PasswordTB.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.Size = new System.Drawing.Size(245, 27);
            this.PasswordTB.TabIndex = 2;
            this.PasswordTB.TextChanged += new System.EventHandler(this.PasswordTB_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(4, 112);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Gebruikersnaam";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(4, 148);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Wachtwoord";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(60, -9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(342, 91);
            this.label3.TabIndex = 5;
            this.label3.Text = "Inloggen";
            // 
            // UsernameError
            // 
            this.UsernameError.AutoSize = true;
            this.UsernameError.ForeColor = System.Drawing.Color.Red;
            this.UsernameError.Location = new System.Drawing.Point(379, 112);
            this.UsernameError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UsernameError.Name = "UsernameError";
            this.UsernameError.Size = new System.Drawing.Size(0, 17);
            this.UsernameError.TabIndex = 6;
            // 
            // PasswordError
            // 
            this.PasswordError.AutoSize = true;
            this.PasswordError.ForeColor = System.Drawing.Color.Red;
            this.PasswordError.Location = new System.Drawing.Point(379, 148);
            this.PasswordError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PasswordError.Name = "PasswordError";
            this.PasswordError.Size = new System.Drawing.Size(0, 17);
            this.PasswordError.TabIndex = 7;
            // 
            // GeneralLoginError
            // 
            this.GeneralLoginError.AutoSize = true;
            this.GeneralLoginError.ForeColor = System.Drawing.Color.Red;
            this.GeneralLoginError.Location = new System.Drawing.Point(232, 182);
            this.GeneralLoginError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GeneralLoginError.Name = "GeneralLoginError";
            this.GeneralLoginError.Size = new System.Drawing.Size(0, 17);
            this.GeneralLoginError.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.GeneralLoginError);
            this.panel1.Controls.Add(this.LoginButton);
            this.panel1.Controls.Add(this.PasswordError);
            this.panel1.Controls.Add(this.UsernameTB);
            this.panel1.Controls.Add(this.UsernameError);
            this.panel1.Controls.Add(this.PasswordTB);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(338, 140);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 250);
            this.panel1.TabIndex = 0;
            // 
            // LoginScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginScreen";
            this.Size = new System.Drawing.Size(1047, 575);
            this.Load += new System.EventHandler(this.LoginScreen_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button LoginButton;
        public System.Windows.Forms.TextBox UsernameTB;
        public System.Windows.Forms.TextBox PasswordTB;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label UsernameError;
        public System.Windows.Forms.Label PasswordError;
        public System.Windows.Forms.Label GeneralLoginError;
        public System.Windows.Forms.Panel panel1;
    }
}
