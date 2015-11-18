namespace KantoorInrichting
{
    partial class MainFrame
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainScreen1 = new KantoorInrichting.Views.MainScreen();
            this.SuspendLayout();
            // 
            // mainScreen1
            // 
            this.mainScreen1.AutoSize = true;
            this.mainScreen1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainScreen1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainScreen1.Location = new System.Drawing.Point(0, 0);
            this.mainScreen1.Name = "mainScreen1";
            this.mainScreen1.Size = new System.Drawing.Size(742, 113);
            this.mainScreen1.TabIndex = 0;
            this.mainScreen1.Load += new System.EventHandler(this.mainScreen1_Load);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 409);
            this.Controls.Add(this.mainScreen1);
            this.Name = "MainFrame";
            this.Text = "MainFrame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Views.MainScreen mainScreen1;
    }
}