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

        public Point location;

        public int length { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int product_id { get; }
        public int category_id { get; set; }
        public string imageFileName { get; set; }
        public string description { get; set; }
        public CategoryModel ProductCategory { get; set; }

        public string name { get; set; }      
        public string type { get; set; }      
        public string brand { get; set; }   
        public Image image { get; set; }   
        public int amount { get; set; }    
        public int id { get; }
        public string category { get; }


        //public Supplier supplier { get; private set; }

        public static int IDnumber;

        public ProductModel(string n, string b, string t, string c, string s, int l, int w, int h, string d, int a)
        {
            id = IDnumber;
            IDnumber++;
            name = n;
            brand = b;
            type = t;

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
            product_id = i;
            name = n;
            brand = b;
            type = t;
            category_id = c;

            this.ProductCategory = CategoryModel.CheckCategories(category_id);

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
                string v = ex.Data.ToString();
                image = Properties.Resources.No_Image_Available;
            }
        }

        /// <summary>
        /// Return a default Product
        /// </summary>
        public ProductModel() : this("", "", "", "", "", 1, 1, 1, "", 1) { }

    }
}
