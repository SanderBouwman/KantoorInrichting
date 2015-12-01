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
        static List<UserControl> panels = new List<UserControl>();
        public MainFrame()
        {
            AddPanels();
            InitializeComponent();
            OnBootup();
        }


        public void AddPanels()
        {
            // make the panels
            this.inventoryScreen1 = new KantoorInrichting.Views.Inventory.InventoryScreen(this);
            this.mainScreen1 = new KantoorInrichting.Views.MainScreen(this);
            this.gridFieldView = new KantoorInrichting.Views.Grid.GridFieldView();
            this.assortmentScreen = new Views.Assortment.AssortmentScreen(this);
            this.placement = new Views.Placement.ProductAdding(this);
            this.loginScreen1 = new Views.LoginScreen(this);
            //
            // assortmentScreen
            //

            this.assortmentScreen.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this.assortmentScreen.Name = "inventoryScreen1";
            this.assortmentScreen.TabIndex = 3;
            // 
            // inventoryScreen1
            // 
            this.inventoryScreen1.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this.inventoryScreen1.Name = "inventoryScreen1";
            this.inventoryScreen1.TabIndex = 1;

            //
            // gridFieldView
            //
            this.gridFieldView.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this.gridFieldView.Name = "gridFieldView";
            this.gridFieldView.TabIndex = 2;

            // 
            // mainScreen1
            // 
            this.mainScreen1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
| System.Windows.Forms.AnchorStyles.Left)
| System.Windows.Forms.AnchorStyles.Right)));
            this.mainScreen1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainScreen1.Name = "mainScreen1";
            this.mainScreen1.TabIndex = 0;

            // loginScreen
            //
            this.loginScreen1.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this.loginScreen1.Dock = System.Windows.Forms.DockStyle.Fill;

            this.loginScreen1.Name = "inventoryScreen1";
            this.loginScreen1.TabIndex = 3;

           
            AddPanelToMainscreen(assortmentScreen);
            AddPanelToMainscreen(inventoryScreen1);
            AddPanelToMainscreen(gridFieldView);
            AddPanelToMainscreen(mainScreen1);
            AddPanelToMainscreen(loginScreen1);
            AddPanelToMainscreen(placement);

            //after adding the panels make the loginscreen visisble (other then default)

            this.loginScreen1.Enabled = true;
            this.loginScreen1.Visible = true;
        }

        private void AddPanelToMainscreen(UserControl panel)
        {
            // this method must be used for every panel!!
            
            // start after menubar
            panel.Location = new System.Drawing.Point(0, 25);

            // give the panel our default background color
            panel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;

            // enable autosize for fullscreenmode
            panel.AutoSize = true;
            panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

            // default all panels are not visible and disabled
            panel.Visible = false;
            panel.Enabled = false;

            // add panels to the controls of MainFrame
            this.Controls.Add(panel);
            // add panels to the panellist
            panels.Add(panel);
        }

        private void terugNaarHoofdschermToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mainScreen1.Visible = true;
            mainScreen1.Enabled = true;
            inventoryScreen1.Visible = false;
            gridFieldView.Visible = false;
            assortmentScreen.Visible = false;
            placement.Visible = false;
            mainScreen1.BringToFront();
        }

        private void OnBootup()
        {
            MainFrame_Resize(this, null);
        }

        private void MainFrame_Resize(object sender, EventArgs e)
        {
            int height = (int)this.Height;
            int width = (int)this.Width;
            height -= 50;
            width -= 15;
            Point size = new Point(width, height);
            Size panelsize = new Size(size);

            // loop trough all panels in this form and resize.
            foreach (UserControl control in panels)
            {

                control.Size = panelsize;
                control.MaximumSize = panelsize;
                control.MinimumSize = panelsize;
                control.AutoSize = true;
                control.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                control.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

            }

            //this.mainScreen1.Size = panelsize;
            //this.inventoryScreen1.Size = panelsize;
            //this.gridFieldView.Size = panelsize;

        }

        private void afsluitenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
