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
using KantoorInrichting.Controllers.Product;

namespace KantoorInrichting.Views.Product
{
    public partial class CategoryManager : Form
    {
        private CategoryManagerController controller;
        public string tempcat;
        public string tempsubcat;
        public KantoorInrichtingDataSet tempdata;

        public CategoryManager(CategoryManagerController controller)
        {
            this.controller = controller;
            InitializeComponent();

            this.categoryTableAdapter.Fill(this.kantoorInrichtingDataSet.category);
            var categoryList = kantoorInrichtingDataSet.category;
            
            controller.fillcombobox(CategoryModel.CategoryList, categoryComboBox);

            controller.fillcombobox(CategoryModel.SubcategoryList, subcategoryComboBox);
            //categoryComboBox.SelectedItem = ;
            //subcategoryComboBox.SelectedItem = ;
            
        }
        //uses the given data to create a new category
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

        //uses the given data to create a new subcategory
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

        }

        private void subcategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //saves the created categories
        private void saveButton_Click(object sender, EventArgs e)
        {
            tempcat = categoryComboBox.SelectedItem.ToString();
            tempsubcat = subcategoryComboBox.SelectedItem.ToString();
            this.Close();
        }

        //closes the screen
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void categoryBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.categoryBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.kantoorInrichtingDataSet);

        }

        private void CategoryManager_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kantoorInrichtingDataSet.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.kantoorInrichtingDataSet.category);

        }
    }
}
