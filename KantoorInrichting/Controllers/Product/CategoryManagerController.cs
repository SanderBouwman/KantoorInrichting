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
        public DatabaseController dbc;
        public CategoryManagerController()
        {
            dbc = DatabaseController.Instance;
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


        public void AddCategory(string text, string color)
        {
            
            //Fill the TableAdapter with data from the dataset, select MAX category_ID, Create an in with MAX category_ID + 1
            var maxCategory_ID = dbc.DataSet.category.Select("category_id = MAX(category_id)");

            var newCategory_ID = (int)maxCategory_ID[0]["category_id"] + 1;

            // add the object
            var Category = new CategoryModel(newCategory_ID, text, -1, color);
            Console.WriteLine(newCategory_ID);

            //add in the database

            //Create a newProductrow and fill the row for each corresponding column
            var newCategory = dbc.DataSet.category.NewcategoryRow();
            newCategory.name =Category.name;
            newCategory.category_id = Category.catID;
            newCategory.removed = false;
            newCategory.subcategory_of = (int)Category.isSubcategoryFrom;
            newCategory.color = color;

            //Try to add the new product row in the database
            try
            {
                dbc.DataSet.category.Rows.Add(newCategory);
                dbc.CategoryTableAdapter.Update(dbc.DataSet.category);
                MessageBox.Show("Update successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed" + ex);
                Category = null;
            }

        }

        public void AddSubCategory(string text, string color, int mainId)
        {

            //Fill the TableAdapter with data from the dataset, select MAX category_ID, Create an in with MAX category_ID + 1
            var maxCategory_ID = dbc.DataSet.category.Select("category_id = MAX(category_id)");

            var newCategory_ID = (int)maxCategory_ID[0]["category_id"] + 1;

            // add the object
            var Category = new CategoryModel(newCategory_ID, text, mainId, color);
            Console.WriteLine(newCategory_ID);

            //add in the database

            //Create a newProductrow and fill the row for each corresponding column
            var newCategory = dbc.DataSet.category.NewcategoryRow();
            newCategory.name = Category.name;
            newCategory.category_id = Category.catID;
            newCategory.removed = false;
            newCategory.subcategory_of = (int)Category.isSubcategoryFrom;
            newCategory.color = color;

            //Try to add the new product row in the database
            try
            {
                dbc.DataSet.category.Rows.Add(newCategory);
                dbc.CategoryTableAdapter.Update(dbc.DataSet.category);
                MessageBox.Show("Update successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed" + ex);
                Category = null;
            }

        }

        public int checkAmountOfProducts(string CatName)
        {
            int amount =0;
            foreach(ProductModel product in ProductModel.list)
            {
                if(product.ProductCategory.name == CatName)
                {
                    amount++;
                }
            }
            return amount;
        }

        public int checkAmountOfSubs(string CatName)
        {

            int amount = 0;
            int mainID = -1;
            foreach (CategoryModel main in CategoryModel.list)
            {
                if (main.name == CatName)
                {
                    mainID = main.catID;
                }
            }

            foreach (CategoryModel cat in CategoryModel.list)
            {
                if (mainID == cat.isSubcategoryFrom)
                {
                    amount++;
                }
            }
                return amount;
        }

        public void changeNameButton(string categoryName, int categoryId)
        {
            ChangeCategoryName changeCategoryName = new ChangeCategoryName(categoryName);
            changeCategoryName.ShowDialog();
        }

        public void changeNameButton2(string subCategoryName, int subCategoryId)
        {
            ChangeCategoryName changeCategoryName = new ChangeCategoryName(subCategoryName);
            changeCategoryName.ShowDialog();

        }
    }
}
