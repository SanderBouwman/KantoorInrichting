using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Views.Product;

namespace KantoorInrichting.Controllers.Product
{
    public class ChangeCategoryNameController
    {
        public DatabaseController dbc;
        public ChangeCategoryName screen;
        public int categoryId;


        public ChangeCategoryNameController(ChangeCategoryName screen)
        {
            dbc = DatabaseController.Instance;
            this.screen = screen;
        }

        //Checks the user input
        public bool Validation()
        {
            string Text = screen.categoryNameTextBox.Text;
            bool exists = false;
            // check if there is some name filled in
            if (Text.Length < 3)
            {
                MessageBox.Show("U heeft geen categorienaam ingevuld van minstens 3 karakters, kies een andere naam");
                return false;
            }
            // check for special chars
            if (!Regex.IsMatch(Text, @"^[a-zA-Z0-9_\s]+$"))
            {
                MessageBox.Show("Uw categorie bevat speciale tekens, kies een andere naam");
                return false;
            }

            // check if text already exists
            foreach (var category in dbc.DataSet.category)
            {
                if (category.name == Text)
                {
                    exists = true;
                }
            }

            if (exists == true)
            {
                // if exists error rename
                MessageBox.Show("Deze categorienaam bestaat al kies een andere naam");
                return false;
            }
            return true;
        }

        //Updates the Categorymodel
        public void UpdateCategoryModel()
        {
            //Select the correct Categorymodel
            var selectedCategory = CategoryModel.list
                           .Where(c => c.name == screen.name)
                           .Select(c => c)
                           .ToList();
            //Update the Category with it's new name
            selectedCategory[0].name = screen.categoryNameTextBox.Text;
            //Retrieve the ID of Category
            categoryId = selectedCategory[0].catID;

        }

        //Update the Category in the database
        public void UpdateCategoryInDatabase()
        {
            try
            {
                //Retrieve the row of category and update it
                var categoryRow = dbc.DataSet.category.FindBycategory_id(categoryId);
                categoryRow.name = screen.categoryNameTextBox.Text;
                dbc.CategoryTableAdapter.Update(dbc.DataSet.category);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update mislukt" + ex);
            }
        }

        //Save button handler, validates user input then it will update the model and the database.
        public void saveButton()
        {
            if (Validation())
            {
                UpdateCategoryModel();
                UpdateCategoryInDatabase();
                screen.Close();
            }
        }

        //Cancel button handler
        public void cancelButton()
        {
            screen.Close();
        }
    }
}