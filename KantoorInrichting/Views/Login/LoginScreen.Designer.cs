﻿namespace KantoorInrichting.Views
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
            this.components = new System.ComponentModel.Container();
            this.LoginButton = new System.Windows.Forms.Button();
            this.UsernameTB = new System.Windows.Forms.TextBox();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UsernameError = new System.Windows.Forms.Label();
            this.PasswordError = new System.Windows.Forms.Label();
            this.GeneralLoginError = new System.Windows.Forms.Label();
            this.userTableAdapter = new KantoorInrichting.KantoorInrichtingDataSetTableAdapters.UserTableAdapter();
            this.tableAdapterManager = new KantoorInrichting.KantoorInrichtingDataSetTableAdapters.TableAdapterManager();
            this.kantoorInrichtingDataSet = new KantoorInrichting.KantoorInrichtingDataSet();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.kantoorInrichtingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(93, 143);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "Inloggen";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // UsernameTB
            // 
            this.UsernameTB.Location = new System.Drawing.Point(93, 88);
            this.UsernameTB.Name = "UsernameTB";
            this.UsernameTB.Size = new System.Drawing.Size(185, 20);
            this.UsernameTB.TabIndex = 1;
            // 
            // PasswordTB
            // 
            this.PasswordTB.Location = new System.Drawing.Point(93, 117);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.Size = new System.Drawing.Size(185, 20);
            this.PasswordTB.TabIndex = 2;
            this.PasswordTB.TextChanged += new System.EventHandler(this.PasswordTB_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Gebruikersnaam";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Wachtwoord";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 73);
            this.label3.TabIndex = 5;
            this.label3.Text = "Inloggen";
            // 
            // UsernameError
            // 
            this.UsernameError.AutoSize = true;
            this.UsernameError.Location = new System.Drawing.Point(284, 91);
            this.UsernameError.Name = "UsernameError";
            this.UsernameError.Size = new System.Drawing.Size(0, 13);
            this.UsernameError.TabIndex = 6;
            // 
            // PasswordError
            // 
            this.PasswordError.AutoSize = true;
            this.PasswordError.Location = new System.Drawing.Point(284, 120);
            this.PasswordError.Name = "PasswordError";
            this.PasswordError.Size = new System.Drawing.Size(0, 13);
            this.PasswordError.TabIndex = 7;
            // 
            // GeneralLoginError
            // 
            this.GeneralLoginError.AutoSize = true;
            this.GeneralLoginError.Location = new System.Drawing.Point(174, 148);
            this.GeneralLoginError.Name = "GeneralLoginError";
            this.GeneralLoginError.Size = new System.Drawing.Size(0, 13);
            this.GeneralLoginError.TabIndex = 8;
            this.GeneralLoginError.Click += new System.EventHandler(this.GeneralLoginError_Click);
            // 
            // userTableAdapter
            // 
            this.userTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CategoryTableAdapter = null;
            this.tableAdapterManager.ProductTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = KantoorInrichting.KantoorInrichtingDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UserTableAdapter = this.userTableAdapter;
            // 
            // kantoorInrichtingDataSet
            // 
            this.kantoorInrichtingDataSet.DataSetName = "KantoorInrichtingDataSet";
            this.kantoorInrichtingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = this.kantoorInrichtingDataSet;
            this.userBindingSource.Position = 0;
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
            this.panel1.Location = new System.Drawing.Point(226, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 203);
            this.panel1.TabIndex = 0;
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "LoginScreen";
            this.Size = new System.Drawing.Size(785, 467);
            this.Load += new System.EventHandler(this.LoginScreen_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.kantoorInrichtingDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox UsernameTB;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label UsernameError;
        private System.Windows.Forms.Label PasswordError;
        private System.Windows.Forms.Label GeneralLoginError;
        private KantoorInrichtingDataSet kantoorInrichtingDataSet;
        private System.Windows.Forms.BindingSource userBindingSource;
        private KantoorInrichtingDataSetTableAdapters.UserTableAdapter userTableAdapter;
        private KantoorInrichtingDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Panel panel1;
    }
}
