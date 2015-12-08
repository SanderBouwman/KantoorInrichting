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

        public static SortableBindingList<CategoryModel> SubcategoryList = new SortableBindingList<CategoryModel>();
        public static SortableBindingList<CategoryModel> CategoryList = new SortableBindingList<CategoryModel>();

        public int catID;
        public string name;
        public int? isSubcategoryFrom;
        public Color colour;

        public CategoryModel(int catID, string name, int issub, string colour)
        {
            this.catID = catID;
            this.name = name;
            this.isSubcategoryFrom = issub;

            this.colour = System.Drawing.ColorTranslator.FromHtml(colour);

            list.Add(this);

            if (this.isSubcategoryFrom >= 0)
            { 
                SubcategoryList.Add(this);
            }
            else
            {
                CategoryList.Add(this);
            }

            

        }

        System.Collections.Generic.IDictionary<string, string> queries;
        public string this[string name]
        {
            get
            {
                return this.queries[name];
            }
        }
    }

}
