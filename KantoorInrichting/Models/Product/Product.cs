using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KantoorInrichting.Models.Product
{
    public class Product
    {

        public static List<Product> lijst = new List<Product>();

        public string name;
        public string brand;
        public string type;
        public string category { get; set; }
        public string subcategory { get; set; }
        public Image image;

        public int length { get; private set; }
        public int width { get; private set; }
        public int height { get; private set; }

        public string Name { get { return name; } private set { name = value; } }
        public string Type { get { return type; } private set { type = value; } }
        public string Brand { get { return brand; } private set { brand = value; } }
        public Image Image { get { return image; } }

        //public Supplier supplier { get; private set; }

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
            this.image = KantoorInrichting.Properties.Resources.No_Image_Available;
            lijst.Add(this);

        }

        /// <summary>
        /// Return a default Product
        /// </summary>
        public Product() : this("", "", "", "", "", 0, 0, 0, "", 0) { }

    }
}
