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
        public static SortableBindingList<CategoryModel> List = new SortableBindingList<CategoryModel>();

        public static SortableBindingList<CategoryModel> SubcategoryList = new SortableBindingList<CategoryModel>();
        public static SortableBindingList<CategoryModel> CategoryList = new SortableBindingList<CategoryModel>();

        public int CatId;
        public string Name { get; set; }
        public int? IsSubcategoryFrom;
        public Color Colour;

        public CategoryModel(int catId, string name, int issub, string colour)
        {
            this.CatId = catId;
            this.Name = name;
            this.IsSubcategoryFrom = issub;

            this.Colour = System.Drawing.ColorTranslator.FromHtml(colour);

            List.Add(this);

            if (this.IsSubcategoryFrom >= 0)
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
