using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Models.Product;

namespace KantoorInrichting.Views.Product
{
    public partial class CategoryManager : Form
    {
        private ProductModel product;

        public CategoryManager()
        {
            InitializeComponent();
        }


        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void subcategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void newCategoryButton_Click(object sender, EventArgs e)
        {
            NewCategory newcat = new NewCategory();
            newcat.ShowDialog(this);
        }

        private void newSubCategoryButton_Click(object sender, EventArgs e)
        {
            NewCategory newsubcat = new NewCategory();
            newsubcat.ShowDialog(this);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
