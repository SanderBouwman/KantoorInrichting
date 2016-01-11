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

        private void assortmentButton_Click(object sender, EventArgs e)
        {
            MainFrame.OpenAssortment();
        }

        private void ProductAddingButton_Click(object sender, EventArgs e)
        {
            MainFrame.OpenProductAdding();
        }

        private void CategoryManager_Click(object sender, EventArgs e)
        {
            MainFrame.OpenCategoryManager();
        }

        private void MapsButton_Click(object sender, EventArgs e)
        {
            MainFrame.OpenMaps();
        }
    }
}
