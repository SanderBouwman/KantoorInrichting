using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KantoorInrichting.Models.Product
{
    public class Product
    {
        public string name { get; private set; }
        public string brand { get; private set; }
        public string type { get; private set; }
        public string category { get; set; }
        public string subcategory { get; set; }

        public int length { get; private set; }
        public int width { get; private set; }
        public int height { get; private set; }

        //public Supplier supplier { get; private set; }
        //public Image image { get; private set; }

        public string description { get; private set; }
        public int amount { get; private set; }

        public Product(string n, string b, string t, string c, string s, int l, int w, int h, string d, int a)
        {
            name = n;
            brand = b;
            type = t;
            category = c;
            subcategory = s;

            length = l;
            width = w;
            height = h;

            description = d;
            amount = a;
        }

        /// <summary>
        /// Return a default Product
        /// </summary>
        public Product() : this("", "", "", "", "", 0, 0, 0, "", 0) { }

    }
}
