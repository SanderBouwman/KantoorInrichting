using KantoorInrichting.Controllers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KantoorInrichting.Models.Product
{
    public class CategoryModel
    {
        public static SortableBindingList<CategoryModel> list = new SortableBindingList<CategoryModel>();

        public int catID;
        public string name;
        public int isSubcategoryFrom;
        public Color colour;

        public CategoryModel(int catID, string name, int issub, string colour)
        {
            this.catID = catID;
            this.name = name;
            this.isSubcategoryFrom = issub;
            //this.colour = Color.FromArgb(Int32.Parse(colour));

            list.Add(this);
        }

        public static CategoryModel CheckCategories(int CatId)
        {
            CategoryModel categorymodel = new CategoryModel(999, "", 0, "");
            bool isinitized = false;

            // loop through all categories and check if the given id existst
            foreach (CategoryModel category in CategoryModel.list)
            {
                if (category.catID == CatId)
                {
                    categorymodel= category;
                    isinitized = true;
                } else
                {
                    isinitized = false;
                    categorymodel = null;
                }
            }

            return categorymodel;
    
        }



    }
}
