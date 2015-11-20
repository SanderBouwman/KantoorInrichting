using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantoorInrichting
{
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            AddPanels();
            InitializeComponent();
        }


        public void AddPanels()
        {
            this.inventoryScreen1 = new KantoorInrichting.Views.Inventory.InventoryScreen(this);
            this.mainScreen1 = new KantoorInrichting.Views.MainScreen(this);
            this.gridFieldView = new KantoorInrichting.Views.Grid.GridFieldView(this);

            //
            // gridFieldView
            //
            this.gridFieldView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
| System.Windows.Forms.AnchorStyles.Left)
| System.Windows.Forms.AnchorStyles.Right)));
            this.gridFieldView.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gridFieldView.AutoSize = true;
            this.gridFieldView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gridFieldView.Enabled = false;
            this.gridFieldView.Location = new System.Drawing.Point(0, 28);
            this.gridFieldView.MinimumSize = new System.Drawing.Size(700, 500);
            this.gridFieldView.Name = "gridFieldView";
            this.gridFieldView.Size = new System.Drawing.Size(700, 500);
            this.gridFieldView.TabIndex = 3;
            this.gridFieldView.Visible = false;

            // 
            // inventoryScreen1
            // 
            this.inventoryScreen1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
| System.Windows.Forms.AnchorStyles.Left)
| System.Windows.Forms.AnchorStyles.Right)));
            this.inventoryScreen1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.inventoryScreen1.AutoSize = true;
            this.inventoryScreen1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.inventoryScreen1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.inventoryScreen1.Enabled = false;
            this.inventoryScreen1.Location = new System.Drawing.Point(0, 28);
            this.inventoryScreen1.MinimumSize = new System.Drawing.Size(700, 500);
            this.inventoryScreen1.Name = "inventoryScreen1";
            this.inventoryScreen1.Size = new System.Drawing.Size(700, 500);
            this.inventoryScreen1.TabIndex = 1;
            this.inventoryScreen1.Visible = false;

            // 
            // mainScreen1
            // 
            this.mainScreen1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
| System.Windows.Forms.AnchorStyles.Left)
| System.Windows.Forms.AnchorStyles.Right)));
            this.mainScreen1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.mainScreen1.AutoSize = true;
            this.mainScreen1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainScreen1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainScreen1.Location = new System.Drawing.Point(0, 28);
            this.mainScreen1.MinimumSize = new System.Drawing.Size(700, 500); 
            this.mainScreen1.Name = "mainScreen1";
            this.mainScreen1.Size = new System.Drawing.Size(700, 500);
            this.mainScreen1.TabIndex = 0;


            this.Controls.Add(this.inventoryScreen1);
            this.Controls.Add(this.gridFieldView);
            this.Controls.Add(this.mainScreen1);
        }

        private void terugNaarHoofdschermToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mainScreen1.Visible = true;
            mainScreen1.Enabled = true;
            inventoryScreen1.Visible = false;
            gridFieldView.Visible = false;
            mainScreen1.BringToFront();
        }
    }
}
