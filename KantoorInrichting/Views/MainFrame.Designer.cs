using KantoorInrichting.Controllers.Grid;
using KantoorInrichting.Models.Grid;
using KantoorInrichting.Views.Grid;

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
            this.navigatieToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.afsluitenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.terugNaarHoofdschermToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigatieToolStripMenuItem1
            // 
            this.navigatieToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.terugNaarHoofdschermToolStripMenuItem1,
            this.afsluitenToolStripMenuItem1});
            this.navigatieToolStripMenuItem1.Name = "navigatieToolStripMenuItem1";
            this.navigatieToolStripMenuItem1.Size = new System.Drawing.Size(85, 24);
            this.navigatieToolStripMenuItem1.Text = "Navigatie";
            // 
            // afsluitenToolStripMenuItem1
            // 
            this.afsluitenToolStripMenuItem1.Name = "afsluitenToolStripMenuItem1";
            this.afsluitenToolStripMenuItem1.Size = new System.Drawing.Size(181, 26);
            this.afsluitenToolStripMenuItem1.Text = "Afsluiten";
            this.afsluitenToolStripMenuItem1.Click += new System.EventHandler(this.afsluitenToolStripMenuItem1_Click);
            // 
            // terugNaarHoofdschermToolStripMenuItem1
            // 
            this.terugNaarHoofdschermToolStripMenuItem1.Name = "terugNaarHoofdschermToolStripMenuItem1";
            this.terugNaarHoofdschermToolStripMenuItem1.Size = new System.Drawing.Size(181, 26);
            this.terugNaarHoofdschermToolStripMenuItem1.Text = "Hoofdscherm";
            this.terugNaarHoofdschermToolStripMenuItem1.Click += new System.EventHandler(this.terugNaarHoofdschermToolStripMenuItem1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navigatieToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(784, 28);
            this.menuStrip1.TabIndex = 2;
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(799, 598);
            this.Name = "MainFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainFrame";
            this.Resize += new System.EventHandler(this.MainFrame_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Views.Assortment.AssortmentScreen assortmentScreen;
        public Views.MainScreen mainScreen1;
        public Views.Inventory.InventoryScreen inventoryScreen1;
        public Views.LoginScreen loginScreen1;
        public Views.Maps.MapsScreen MapsScreen;
        public Views.Grid.GridFieldView gridFieldView;
        public Views.Placement.ProductAdding placement;
        public Views.SpaceChoice.SpaceChoice spaceChoice;
        public Views.Placement.ProductGrid productGrid;
        private System.Windows.Forms.ToolStripMenuItem navigatieToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem terugNaarHoofdschermToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem afsluitenToolStripMenuItem1;
        public System.Windows.Forms.MenuStrip menuStrip1;
    }
}