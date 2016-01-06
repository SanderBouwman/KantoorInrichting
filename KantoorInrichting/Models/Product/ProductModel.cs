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
        public static SortableBindingList<ProductModel> List = new SortableBindingList<ProductModel>();
        public static SortableBindingList<ProductModel> Result = new SortableBindingList<ProductModel>();  // list for filtering data

        public PointF Location;

        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public SizeF Size { get; set; }
        public int ProductId { get; }
        public string ImageFileName { get; set; }
        public string Description { get; set; }
        public CategoryModel ProductCategory { get; set; }

        public string Name { get; set; }      
        public string Type { get; set; }      
        public string Brand { get; set; }   
        public Image Image { get; set; }   
        public int Amount { get; set; }
        public int AmountPlaced { get; set; }
        public int Id { get; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public bool Removed { get; set; }
        public decimal Price { get; set; }
        
        public bool Collidable = true;

        //public Supplier supplier { get; private set; }

        public static int IdNumber;

        public ProductModel(string n, string b, string t, string c, string s, int l, int w, int h, string d, int a)
        {
            Id = IdNumber;

            IdNumber++;
            Name = n;
            Brand = b;
            Type = t;

            Length = l;
            Width = w;
            Height = h;

            Description = d;
            Amount = a;
            this.Image = KantoorInrichting.Properties.Resources.No_Image_Available;
            if (n != "") { List.Add(this); } //If the name if empty, don't add it to the list. This is because the name is part of the primary key in the database.
        }

        public ProductModel(int i, string n, string b, string t, int c, int l, int w, int h, string d, int a, string im,
            bool r, decimal p, int ap)
        {
            ProductId = i;

            Name = n;
            Brand = b;
            Type = t;

            this.ProductCategory = CategoryModel.List[c];
            this.Category = ProductCategory.Name;

            Length = l;
            Width = w;
            Height = h;

            Description = d;
            Amount = a;
            AmountPlaced = ap;
            ImageFileName = im;
            SetProductImage();
            Removed = r;
            Price = p;
            //list.Add(this);
            if (n != "") { List.Add(this); } //If the name if empty, don't add it to the list. This is because the name is part of the primary key in the database.
        }

        //This methods sets the Product image using the name of the image
        public void SetProductImage()
        {
            string imagePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + @"\Resources\" + ImageFileName;
            try
            {
                Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(imagePath)));
            }
            catch (Exception ex)
            {
                string v = ex.Data.ToString();
                Image = Properties.Resources.No_Image_Available;
            }
        }

        /// <summary>
        /// Return a default Product
        /// </summary>
        //public ProductModel() : this("", "", "", "", "", 1, 1, 1, "", 1) { }
        public ProductModel() : this(1, 1, 1) { }



        //Contructor if you only want to make models that have a size
        public ProductModel(int length, int width, int height) : this(0, "", "", "", 0, length, width, height, "", 1, "No_Image_Found", false, 0.01m, 0) { }
    }
}
