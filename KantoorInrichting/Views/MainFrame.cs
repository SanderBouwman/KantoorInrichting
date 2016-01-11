using KantoorInrichting.Controllers;
using KantoorInrichting.Controllers.Product;
using KantoorInrichting.Views.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Views.Grid;
using KantoorInrichting.Views.Placement;

namespace KantoorInrichting
{
    public partial class MainFrame : Form
    {
        private static readonly List<UserControl> Panels = new List<UserControl>();
        public CategoryManagerController CategoryManagerController;
        public CategoryManager CategoryManager;

        public UserControl Active { get; set; }

        public MainFrame()
        {
            DatabaseController dbc = DatabaseController.Instance;
            AddPanels();
            InitializeComponent();
            OnBootup();
        }

        public void AddPanels()
        {
            // make the Panels
            this.inventoryScreen1 = new KantoorInrichting.Views.Inventory.InventoryScreen(this);
            this.mainScreen1 = new KantoorInrichting.Views.MainScreen(this);
            this.gridFieldView = new KantoorInrichting.Views.Grid.GridFieldView();
            this.assortmentScreen = new Views.Assortment.AssortmentScreen(this);
            this.placement = new Views.Placement.ProductAdding(this);
            this.loginScreen1 = new Views.LoginScreen(this);
            this.MapsScreen = new Views.Maps.MapsScreen(this);
            this.spaceChoice = new Views.SpaceChoice.SpaceChoice(this);
            this.productGrid = new KantoorInrichting.Views.Placement.ProductGrid();

            //
            // assortmentScreen
            //

            this.assortmentScreen.Anchor =
                ((AnchorStyles) ((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this.assortmentScreen.Name = "inventoryScreen1";
            this.assortmentScreen.TabIndex = 3;
            // 
            // inventoryScreen1
            // 
            this.inventoryScreen1.Anchor =
                ((AnchorStyles) ((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this.inventoryScreen1.Name = "inventoryScreen1";
            this.inventoryScreen1.TabIndex = 1;

            //
            // gridFieldView
            //
            this.gridFieldView.Anchor =
                ((AnchorStyles) ((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this.gridFieldView.Name = "gridFieldView";
            this.gridFieldView.TabIndex = 2;
            // 
            // productGrid
            // 
            this.productGrid.Anchor =
                ((AnchorStyles) ((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this.productGrid.Name = "productGrid";
            this.productGrid.TabIndex = 2;

            // 
            // mainScreen1
            // 
            this.mainScreen1.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.mainScreen1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainScreen1.Name = "mainScreen1";
            this.mainScreen1.TabIndex = 0;

            // loginScreen
            //
            this.loginScreen1.Anchor =
                ((AnchorStyles) ((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this.loginScreen1.Dock = System.Windows.Forms.DockStyle.Fill;

            this.loginScreen1.Name = "inventoryScreen1";
            this.loginScreen1.TabIndex = 3;

            // 
            // inventoryScreen1
            // 
            this.MapsScreen.Anchor =
                ((AnchorStyles) ((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this.MapsScreen.Name = "Plattegronden";
            this.MapsScreen.TabIndex = 1;

            // 
            // spaceChoice
            // 
            this.spaceChoice.Anchor =
                ((AnchorStyles) ((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this.spaceChoice.Name = "Kies een ruimte";
            this.spaceChoice.TabIndex = 1;



            AddPanelToMainscreen(assortmentScreen);
            AddPanelToMainscreen(inventoryScreen1);
            AddPanelToMainscreen(gridFieldView);
            AddPanelToMainscreen(mainScreen1);
            AddPanelToMainscreen(loginScreen1);
            AddPanelToMainscreen(placement);
            AddPanelToMainscreen(MapsScreen);
            AddPanelToMainscreen(spaceChoice);
            AddPanelToMainscreen(productGrid);

            //after adding the Panels make the loginscreen visisble (other then default)

            this.loginScreen1.Enabled = true;
            this.loginScreen1.Visible = true;
        }

        public void AddPanelToMainscreen(UserControl panel)
        {
            // this method must be used for every panel!!

            // start after menubar
            panel.Location = new System.Drawing.Point(0, 25);

            // give the panel our default background color
            panel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;

            // enable autosize for fullscreenmode
            panel.AutoSize = true;
            panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

            // default all Panels are not visible and disabled
            panel.Visible = false;
            panel.Enabled = false;

            // add Panels to the controls of MainFrame
            this.Controls.Add(panel);
            // add Panels to the panellist
            Panels.Add(panel);
        }

        private void OnBootup()
        {
            MainFrame_Resize(this, null);
        }


        //methods for opening the different screens.
        public void OpenAssortment()
        {
            this.assortmentScreen.Visible = true;
            this.assortmentScreen.Enabled = true;
            this.mainScreen1.Visible = false;
            this.assortmentScreen.BringToFront();
        }

        public void OpenProductAdding()
        {
            this.spaceChoice.Visible = true;
            this.spaceChoice.Enabled = true;
            this.mainScreen1.Visible = false;
            this.spaceChoice.BringToFront();
            this.spaceChoice.ReloadTable();
        }

        public void OpenCategoryManager()
        {
            this.CategoryManagerController = new CategoryManagerController();
            this.CategoryManager = new CategoryManager(this.CategoryManagerController);
        }

        public void OpenMaps()
        {
            this.MapsScreen.Visible = true;
            this.MapsScreen.Enabled = true;
            this.mainScreen1.Visible = false;
            this.MapsScreen.BringToFront();
        }

        private void MainFrame_Resize(object sender, EventArgs e)
        {
            int height = (int) this.Height;
            int width = (int) this.Width;
            height -= 50;
            width -= 15;
            Point size = new Point(width, height);
            Size panelsize = new Size(size);

            // loop trough all Panels in this form and resize.
            foreach (UserControl control in Panels)
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

        private void hoofdmenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainScreen1.Visible = true;
            mainScreen1.Enabled = true;
            mainScreen1.BringToFront();
            inventoryScreen1.Visible = false;
            gridFieldView.Visible = false;
            assortmentScreen.Visible = false;
            placement.Visible = false;
            if (Active == this.gridFieldView)
            {
                ((GridFieldView) Active).GridFieldView_Disposed(this, null);
            }
        }

        private void assortimentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenAssortment();
        }

        private void ruimteIndelenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenProductAdding();
        }

        private void categorieBeheerderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenCategoryManager();
        }

        private void plattegrondTonennToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.OpenMaps();
        }
    }
}
