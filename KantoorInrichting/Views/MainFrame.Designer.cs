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
            this.assortimentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plattegrondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ruimteIndelenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categorieBeheerderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plattegrondTonennToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afsluitenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hoofdmenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigatieToolStripMenuItem1
            // 
            this.navigatieToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assortimentToolStripMenuItem,
            this.plattegrondToolStripMenuItem,
            this.ruimteIndelenToolStripMenuItem,
            this.categorieBeheerderToolStripMenuItem,
            this.plattegrondTonennToolStripMenuItem,
            this.afsluitenToolStripMenuItem1});
            this.navigatieToolStripMenuItem1.Name = "navigatieToolStripMenuItem1";
            this.navigatieToolStripMenuItem1.Size = new System.Drawing.Size(85, 24);
            this.navigatieToolStripMenuItem1.Text = "Navigatie";
            // 
            // assortimentToolStripMenuItem
            // 
            this.assortimentToolStripMenuItem.Name = "assortimentToolStripMenuItem";
            this.assortimentToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.assortimentToolStripMenuItem.Text = "Assortiment";
            this.assortimentToolStripMenuItem.Click += new System.EventHandler(this.assortimentToolStripMenuItem_Click);
            // 
            // plattegrondToolStripMenuItem
            // 
            this.plattegrondToolStripMenuItem.Name = "plattegrondToolStripMenuItem";
            this.plattegrondToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.plattegrondToolStripMenuItem.Text = "Plattegrond";
            this.plattegrondToolStripMenuItem.Click += new System.EventHandler(this.plattegrondToolStripMenuItem_Click);
            // 
            // ruimteIndelenToolStripMenuItem
            // 
            this.ruimteIndelenToolStripMenuItem.Name = "ruimteIndelenToolStripMenuItem";
            this.ruimteIndelenToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.ruimteIndelenToolStripMenuItem.Text = "Ruimte indelen";
            this.ruimteIndelenToolStripMenuItem.Click += new System.EventHandler(this.ruimteIndelenToolStripMenuItem_Click);
            // 
            // categorieBeheerderToolStripMenuItem
            // 
            this.categorieBeheerderToolStripMenuItem.Name = "categorieBeheerderToolStripMenuItem";
            this.categorieBeheerderToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.categorieBeheerderToolStripMenuItem.Text = "Categorie beheerder";
            this.categorieBeheerderToolStripMenuItem.Click += new System.EventHandler(this.categorieBeheerderToolStripMenuItem_Click);
            // 
            // plattegrondTonennToolStripMenuItem
            // 
            this.plattegrondTonennToolStripMenuItem.Name = "plattegrondTonennToolStripMenuItem";
            this.plattegrondTonennToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.plattegrondTonennToolStripMenuItem.Text = "Plattegrond tonen";
            this.plattegrondTonennToolStripMenuItem.Click += new System.EventHandler(this.plattegrondTonennToolStripMenuItem_Click_1);
            // 
            // afsluitenToolStripMenuItem1
            // 
            this.afsluitenToolStripMenuItem1.Name = "afsluitenToolStripMenuItem1";
            this.afsluitenToolStripMenuItem1.Size = new System.Drawing.Size(221, 26);
            this.afsluitenToolStripMenuItem1.Text = "Afsluiten";
            this.afsluitenToolStripMenuItem1.Click += new System.EventHandler(this.afsluitenToolStripMenuItem1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hoofdmenuToolStripMenuItem,
            this.navigatieToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(802, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Visible = false;
            // 
            // hoofdmenuToolStripMenuItem
            // 
            this.hoofdmenuToolStripMenuItem.Name = "hoofdmenuToolStripMenuItem";
            this.hoofdmenuToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.hoofdmenuToolStripMenuItem.Text = "Hoofdmenu";
            this.hoofdmenuToolStripMenuItem.Click += new System.EventHandler(this.hoofdmenuToolStripMenuItem_Click);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(802, 701);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(800, 600);
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
        private System.Windows.Forms.ToolStripMenuItem afsluitenToolStripMenuItem1;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hoofdmenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assortimentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plattegrondToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ruimteIndelenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categorieBeheerderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plattegrondTonennToolStripMenuItem;
    }
}