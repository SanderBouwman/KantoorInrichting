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
            checkBox1.Checked = true;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            controller.CheckBox1();
            this.Refresh();
        }


        private void DeleteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.DeleteProductCheckBox();
        }
    }
}