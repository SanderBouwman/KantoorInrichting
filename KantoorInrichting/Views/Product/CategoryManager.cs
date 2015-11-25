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
        public string tempcat;
        public string tempsubcat;
        private List<string> allcategories = new List<string>();
        private List<string> allsubcategories = new List<string>();

        public CategoryManager(ProductModel product)
        {
            this.product = product;
            allcategories.Add("koek");
            allsubcategories.Add("jodenkoek");
            InitializeComponent();

            foreach (string item in allcategories){
                categoryComboBox.Items.Add(item);
            }
            foreach (string item in allsubcategories)
            {
                subcategoryComboBox.Items.Add(item);
            }

            categoryComboBox.SelectedItem = product.category;
            subcategoryComboBox.SelectedItem = product.subcategory;

        }

        private void newCategoryButton_Click(object sender, EventArgs e)
        {
            NewCategory newcat = new NewCategory(this);
            newcat.ShowDialog(this);
            if (newcat.DialogResult == DialogResult.OK)
            {
                tempcat = newcat.tempcat;
                categoryComboBox.Items.Add(tempcat);
                categoryComboBox.SelectedItem = tempcat;
            }
        }

        private void newSubCategoryButton_Click(object sender, EventArgs e)
        {
            NewCategory newsubcat = new NewCategory(this);
            newsubcat.ShowDialog(this);
            if (newsubcat.DialogResult == DialogResult.OK)
            {
                tempsubcat = newsubcat.tempcat;
                subcategoryComboBox.Items.Add(tempsubcat);
                subcategoryComboBox.SelectedItem = tempsubcat;
            }
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempcat = categoryComboBox.SelectedItem.ToString();
        }

        private void subcategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempsubcat = subcategoryComboBox.SelectedItem.ToString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            tempcat = categoryComboBox.SelectedItem.ToString();
            tempsubcat = subcategoryComboBox.SelectedItem.ToString();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
