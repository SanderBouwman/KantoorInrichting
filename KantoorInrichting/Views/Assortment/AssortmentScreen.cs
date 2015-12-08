using System;
using System.Windows.Forms;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Controllers.Assortment;

namespace KantoorInrichting.Views.Assortment
{
    public partial class AssortmentScreen : UserControl
    {
        public MainFrame hoofdscherm;
        private AssortmentController controller;
 
        public AssortmentScreen(MainFrame hoofdscherm)
        {
            controller = new AssortmentController(this);
            this.hoofdscherm = hoofdscherm;
            InitializeComponent();
            controller.FillData();
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