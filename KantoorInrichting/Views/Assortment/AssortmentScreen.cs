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
            Invalidate();
        }

        //Opens AddNewProductScreen when this button is pressed
        private void AddProductButton_Click(object sender, EventArgs e)
        {
            controller.AddProduct();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            controller.dataGridView_CellContentClick(sender, e);

        }
    }
}