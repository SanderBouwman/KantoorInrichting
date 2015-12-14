using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Controllers.Grid;
using KantoorInrichting.Controllers.Placement;
using KantoorInrichting.Controllers.Product;
using KantoorInrichting.Models.Grid;
using KantoorInrichting.Views.Grid;
using KantoorInrichting.Views.Product;

namespace KantoorInrichting.Views
{
    public partial class MainScreen : UserControl
    {
        public MainFrame hoofdscherm;
        public MainScreen(MainFrame hoofdscherm)
        {
            this.hoofdscherm = hoofdscherm;
            InitializeComponent();
        }

        public MainScreen()
        {
            InitializeComponent();
        }

        private void VooraadButton_Click(object sender, EventArgs e)
        {
            hoofdscherm.inventoryScreen1.Visible = true;
            hoofdscherm.inventoryScreen1.Enabled = true;
            this.Visible = false;
            hoofdscherm.inventoryScreen1.BringToFront();
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
            GridController gc = new GridController(hoofdscherm.gridFieldView, new GridFieldModel(10, 10, 0.5f));
            // hoofdscherm overwrites my GridFieldView size, so I have to set the screen size like this
            hoofdscherm.Width = 800;
            hoofdscherm.Height = 670;
            hoofdscherm.gridFieldView.SetListView(ProductFactory.GetPossibilities());
            Application.DoEvents();
            hoofdscherm.Active = hoofdscherm.gridFieldView;
            hoofdscherm.gridFieldView.Visible = true;
            hoofdscherm.gridFieldView.Enabled = true;
            this.Visible = false;
            hoofdscherm.gridFieldView.BringToFront();
        }

        private void assortmentButton_Click(object sender, EventArgs e)
        {
            hoofdscherm.assortmentScreen.Visible = true;
            hoofdscherm.assortmentScreen.Enabled = true;
            this.Visible = false;
            hoofdscherm.assortmentScreen.BringToFront();
        }

        private void ProductAddingButton_Click(object sender, EventArgs e)
        {
            hoofdscherm.Size = new Size(1150, 750);
            hoofdscherm.MinimumSize = new Size(1050,675);
            hoofdscherm.placement.Visible = true;
            hoofdscherm.placement.Enabled = true;

            //Update the data (size and colour of the PlacedProduct, information of the ProductList and ProductInfo)
            hoofdscherm.placement.fixData();

            this.Visible = false;
            hoofdscherm.placement.BringToFront();
        }

        private void CategoryManager_Click(object sender, EventArgs e)
        {
            hoofdscherm.categoryManagerController = new CategoryManagerController();
            hoofdscherm.categoryManager = new CategoryManager(hoofdscherm.categoryManagerController);
        }

        private void MapsButton_Click(object sender, EventArgs e)
        {
            hoofdscherm.MapsScreen.Visible = true;
            hoofdscherm.MapsScreen.Enabled = true;
            this.Visible = false;
            hoofdscherm.MapsScreen.BringToFront();
        }
    }
}
