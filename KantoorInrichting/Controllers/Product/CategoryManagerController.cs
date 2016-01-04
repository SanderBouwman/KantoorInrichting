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
        public DatabaseController Dbc;
        public CategoryManagerController()
        {
            Dbc = DatabaseController.Instance;
            catman = new CategoryManager(this);
            catman.ShowDialog();
            

            if (catman.DialogResult == DialogResult.OK)
            {
                //update database
            }
        }

        public void Fillcombobox(SortableBindingList<CategoryModel> categoryList, ComboBox categoryComboBox)
        {
            categoryComboBox.Items.Clear();
            categoryComboBox.Items.Insert(0, "geen categoriefilter");
            categoryComboBox.SelectedIndex = 0;

            foreach (var category in categoryList)
            {
                categoryComboBox.Items.Add(category.Name);
            }
        }

        public void FillSubcombobox(SortableBindingList<CategoryModel> categoryList, ComboBox subcategoryComboBox, ComboBox categoryComboBox)
        {
            subcategoryComboBox.Items.Clear();

            // check if there is an category selected in the head dropdown
            if (categoryComboBox.SelectedIndex == 0)
            {
                foreach (var category in categoryList)
                {
                    subcategoryComboBox.Items.Add(category.Name);
                }
            } else
            {
                // get selected category
                string selectedCategory = categoryComboBox.SelectedItem.ToString();
                CategoryModel currentCategory;
                int currentId = -1;


                // get the current category object
                foreach (CategoryModel cat in CategoryModel.List)
                {
                    if (cat.Name == selectedCategory)
                    {
                        currentCategory = cat;
                        currentId = currentCategory.CatId;
                    }
                }

                foreach (var category in categoryList)
                {
                    // check wich subcategories are from the selected main category
                    if (category.IsSubcategoryFrom == currentId)
                    {
                        subcategoryComboBox.Items.Add(category.Name);
                    }
                }
            }
        }


        public void AddCategory(string text, string color)
        {
            
            //Fill the TableAdapter with data from the dataset, select MAX category_ID, Create an in with MAX category_ID + 1
            var maxCategoryId = Dbc.DataSet.category.Select("category_id = MAX(category_id)");

            var newCategoryId = (int)maxCategoryId[0]["category_id"] + 1;

            // add the object
            var category = new CategoryModel(newCategoryId, text, -1, color);
            Console.WriteLine(newCategoryId);

            //add in the database

            //Create a newProductrow and fill the row for each corresponding column
            var newCategory = Dbc.DataSet.category.NewcategoryRow();
            newCategory.name =category.Name;
            newCategory.category_id = category.CatId;
            newCategory.removed = false;
            newCategory.subcategory_of = (int)category.IsSubcategoryFrom;
            newCategory.color = color;

            //Try to add the new product row in the database
            try
            {
                Dbc.DataSet.category.Rows.Add(newCategory);
                Dbc.CategoryTableAdapter.Update(Dbc.DataSet.category);
                MessageBox.Show("Update successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed" + ex);
                category = null;
            }

        }

        public void AddSubCategory(string text, string color, int mainId)
        {

            //Fill the TableAdapter with data from the dataset, select MAX category_ID, Create an in with MAX category_ID + 1
            var maxCategoryId = Dbc.DataSet.category.Select("category_id = MAX(category_id)");

            var newCategoryId = (int)maxCategoryId[0]["category_id"] + 1;

            // add the object
            var category = new CategoryModel(newCategoryId, text, mainId, color);
            Console.WriteLine(newCategoryId);

            //add in the database

            //Create a newProductrow and fill the row for each corresponding column
            var newCategory = Dbc.DataSet.category.NewcategoryRow();
            newCategory.name = category.Name;
            newCategory.category_id = category.CatId;
            newCategory.removed = false;
            newCategory.subcategory_of = (int)category.IsSubcategoryFrom;
            newCategory.color = color;

            //Try to add the new product row in the database
            try
            {
                Dbc.DataSet.category.Rows.Add(newCategory);
                Dbc.CategoryTableAdapter.Update(Dbc.DataSet.category);
                MessageBox.Show("Update successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed" + ex);
                category = null;
            }

        }

        public int CheckAmountOfProducts(string catName)
        {
            int amount =0;
            foreach(ProductModel product in ProductModel.List)
            {
                if(product.ProductCategory.Name == catName)
                {
                    amount++;
                }
            }
            return amount;
        }

        public int CheckAmountOfSubs(string catName)
        {

            int amount = 0;
            int mainID = -1;
            foreach (CategoryModel main in CategoryModel.List)
            {
                if (main.Name == catName)
                {
                    mainID = main.CatId;
                }
            }

            foreach (CategoryModel cat in CategoryModel.List)
            {
                if (mainID == cat.IsSubcategoryFrom)
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
