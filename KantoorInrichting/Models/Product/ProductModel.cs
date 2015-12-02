using KantoorInrichting.Controllers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KantoorInrichting.Models.Product
{
    public class ProductModel
    {
        public static SortableBindingList<ProductModel> list = new SortableBindingList<ProductModel>();
        public static SortableBindingList<ProductModel> result = new SortableBindingList<ProductModel>();  // list for filtering data

        public string name;
        public string brand;
        public string type;
        public string category { get; set; }
        public string subcategory { get; set; }
        public Image image;

        public int length { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int amount { get; set; }
        public int id { get; private set; }
        public int product_ID { get; private set; }
        public int category_ID { get; set; }
        public string imageFileName { get; set; }
        public string description { get; set; }

        public string Name { get { return name; } private set { name = value; } }
        public string Type { get { return type; } private set { type = value; } }
        public string Brand { get { return brand; } private set { brand = value; } }
        public Image Image { get { return image; } }
        public int Amount { get { return amount; } private set { amount = value; } }
        public int Id { get { return id; } private set { id = value; } }
        public string Category { get { return category; } private set { category = value; } }
        public string Subcategory { get { return subcategory; } private set { subcategory = value; } }

        //public Supplier supplier { get; private set; }

        public static int IDnumber;

        public ProductModel(string n, string b, string t, string c, string s, int l, int w, int h, string d, int a)
        {
            id = IDnumber;
            IDnumber++;
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
            if (n != "") { list.Add(this); } //If the name if empty, don't add it to the list. This is because the name is part of the primary key in the database.
        }

        public ProductModel(int i, string n, string b, string t, int c, int l, int w, int h, string d, int a, string im)
        {
            product_ID = i;
            name = n;
            brand = b;
            type = t;
            category_ID = c;

            length = l;
            width = w;
            height = h;

            description = d;
            amount = a;
            imageFileName = im;
            SetProductImage();

            list.Add(this);
        }

        //This methods sets the Product image using the name of the image
        public void SetProductImage()
        {
            string imagePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + @"\Resources\" + imageFileName;
            try
            {
                image = Image.FromStream(new MemoryStream(File.ReadAllBytes(imagePath)));
            }
            catch (Exception ex)
            {
                image = Properties.Resources.No_Image_Available;
            }
        }

        /// <summary>
        /// Return a default Product
        /// </summary>
        public ProductModel() : this("", "", "", "", "", 1, 1, 1, "", 1) { }

    }
}
