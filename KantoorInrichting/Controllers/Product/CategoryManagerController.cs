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
            foreach (var category in categoryList)
            {
                categoryComboBox.Items.Add(category.name);
            }
        }
    }
}
