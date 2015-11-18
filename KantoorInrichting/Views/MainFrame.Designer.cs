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
            this.inventoryScreen1 = new KantoorInrichting.Views.Inventory.InventoryScreen(this);
            this.mainScreen1 = new KantoorInrichting.Views.MainScreen(this);
            this.SuspendLayout();
            // 
            // inventoryScreen1
            // 
            this.inventoryScreen1.AutoSize = true;
            this.inventoryScreen1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.inventoryScreen1.Enabled = false;
            this.inventoryScreen1.Location = new System.Drawing.Point(0, 0);
            this.inventoryScreen1.Name = "inventoryScreen1";
            this.inventoryScreen1.Size = new System.Drawing.Size(464, 95);
            this.inventoryScreen1.TabIndex = 1;
            this.inventoryScreen1.Visible = false;
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
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 409);
            this.Controls.Add(this.inventoryScreen1);
            this.Controls.Add(this.mainScreen1);
            this.Name = "MainFrame";
            this.Text = "MainFrame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Views.MainScreen mainScreen1;
        public Views.Inventory.InventoryScreen inventoryScreen1;
        //private Views.InventoryScreen inventoryScreen1;
    }
}