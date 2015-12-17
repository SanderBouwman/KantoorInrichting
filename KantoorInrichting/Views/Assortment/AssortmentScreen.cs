using System;
using System.Windows.Forms;
using KantoorInrichting.Controllers.Assortment;
using KantoorInrichting.Models.Product;

namespace KantoorInrichting.Views.Assortment
{
    public partial class AssortmentScreen : UserControl
    {
        public MainFrame hoofdscherm;
        private AssortmentController controller;

        public AssortmentScreen(MainFrame hoofdscherm)
        {
            InitializeComponent();
            this.hoofdscherm = hoofdscherm;
            controller = new AssortmentController(this);
            noAmountCheckBox.Checked = true;
            deleteCheckBox.Checked = true;
            DropdownBrand.SelectedIndex = 0;
            DropdownCategory.SelectedIndex = 0;
            Invalidate();

        }

        //Opens AddNewProductScreen when this button is pressed
        private void AddProductButton_Click(object sender, EventArgs e)
        {
            controller.AddProduct();
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            controller.DataGridView_CellContentClick(sender, e);

        }

        private void DropdownBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.DropdownBrand();
        }

        private void DropdownCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.DropdownCategory();
        }

        private void noAmountCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.NoAmountProductCheckBox();
            this.Refresh();
        }

        private void DeleteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.DeleteProductCheckBox();
        }

        private void removeFiltersButton_Click(object sender, EventArgs e)
        {
            controller.RemoveFilters();
        }
    }
}