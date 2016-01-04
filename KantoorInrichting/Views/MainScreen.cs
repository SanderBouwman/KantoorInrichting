using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Controllers;
using KantoorInrichting.Controllers.Grid;
using KantoorInrichting.Controllers.Placement;
using KantoorInrichting.Controllers.Product;
using KantoorInrichting.Models.Grid;
using KantoorInrichting.Views.Grid;
using KantoorInrichting.Views.Placement;
using KantoorInrichting.Views.Product;

namespace KantoorInrichting.Views
{
    public partial class MainScreen : UserControl
    {
        public MainFrame MainFrame;
        public MainScreen(MainFrame mainFrame)
        {
            this.MainFrame = mainFrame;
            InitializeComponent();
        }

        public MainScreen()
        {
            InitializeComponent();
        }

        private void VooraadButton_Click(object sender, EventArgs e)
        {
            MainFrame.inventoryScreen1.Visible = true;
            MainFrame.inventoryScreen1.Enabled = true;
            this.Visible = false;
            MainFrame.inventoryScreen1.BringToFront();
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
//            GridController gc = new GridController(MainFrame.gridFieldView, new GridFieldModel(10, 10, 0.5f));
//            // MainFrame overwrites my GridFieldView size, so I have to set the screen size like this
//            MainFrame.Width = 800;
//            MainFrame.Height = 670;
//            MainFrame.gridFieldView.SetListView(ProductFactory.GetPossibilities());
//            Application.DoEvents();
//            MainFrame.Active = MainFrame.gridFieldView;
//            MainFrame.gridFieldView.Visible = true;
//            MainFrame.gridFieldView.Enabled = true;
//            this.Visible = false;
//            MainFrame.gridFieldView.BringToFront();

            Console.WriteLine("Open room selection and get data from there! -- MainScreen.cs Line 58"); 
            MainFrame.AddPanelToMainscreen(MainFrame.productGrid);
            MainFrame.Size = ProductGrid.PanelSize;
            MainFrame.productGrid.Visible = true;
            MainFrame.productGrid.Enabled = true;
            this.Visible = false;
            MainFrame.productGrid.BringToFront();
        }

        private void assortmentButton_Click(object sender, EventArgs e)
        {
            MainFrame.assortmentScreen.Visible = true;
            MainFrame.assortmentScreen.Enabled = true;
            this.Visible = false;
            MainFrame.assortmentScreen.BringToFront();
        }

        private void ProductAddingButton_Click(object sender, EventArgs e)
        {

            MainFrame.spaceChoice.Visible = true;
            MainFrame.spaceChoice.Enabled = true;
            this.Visible = false;
            MainFrame.spaceChoice.BringToFront();
        }

        private void CategoryManager_Click(object sender, EventArgs e)
        {
            MainFrame.CategoryManagerController = new CategoryManagerController();
            MainFrame.CategoryManager = new CategoryManager(MainFrame.CategoryManagerController);
        }

        private void MapsButton_Click(object sender, EventArgs e)
        {
            MainFrame.MapsScreen.Visible = true;
            MainFrame.MapsScreen.Enabled = true;
            this.Visible = false;
            MainFrame.MapsScreen.BringToFront();
        }
    }
}
