using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Views.Product;
using System.Windows.Forms;

namespace KantoorInrichting.Controllers.Product
{
    public class CategoryManagerController
    {
        private CategoryManager catman;

        public CategoryManagerController()
        {
            catman = new CategoryManager(this);
            catman.ShowDialog();

            if (catman.DialogResult == DialogResult.OK)
            {
                //update database
            }
        }

        public void fillcombobox(SortableBindingList<CategoryModel> categoryList, ComboBox categoryComboBox)
        {
            categoryComboBox.Items.Clear();
            categoryComboBox.Items.Insert(0, "geen categoriefilter");
            categoryComboBox.SelectedIndex = 0;

            foreach (var category in categoryList)
            {
                categoryComboBox.Items.Add(category.name);
            }
        }
        // insert default


        public void fillSubcombobox(SortableBindingList<CategoryModel> categoryList, ComboBox subcategoryComboBox, ComboBox categoryComboBox)
        {
            subcategoryComboBox.Items.Clear();

            // check if there is an category selected in the head dropdown
            if (categoryComboBox.SelectedIndex == 0)
            {
                foreach (var category in categoryList)
                {
                    subcategoryComboBox.Items.Add(category.name);
                }
            } else
            {
                // get selected category
                string selectedCategory = categoryComboBox.SelectedItem.ToString();
                CategoryModel currentCategory;
                int CurrentID = -1;


                // get the current category object
                foreach (CategoryModel cat in CategoryModel.list)
                {
                    if (cat.name == selectedCategory)
                    {
                        currentCategory = cat;
                        CurrentID = currentCategory.catID;
                    }
                }

                foreach (var category in categoryList)
                {
                    // check wich subcategories are from the selected main category
                    if (category.isSubcategoryFrom == CurrentID)
                    {
                        subcategoryComboBox.Items.Add(category.name);
                    }
                }
            }
       


        }
    }
}
