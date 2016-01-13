using KantoorInrichting.Controllers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantoorInrichting.Models.Product
{
    public class ProductModel
    {
        public static SortableBindingList<ProductModel> List = new SortableBindingList<ProductModel>();
        public static SortableBindingList<ProductModel> Result = new SortableBindingList<ProductModel>();  // list for filtering data

        public static SortableBindingList<ProductModel> StaticList = new SortableBindingList<ProductModel>(); 

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

        public bool StaticProduct { get; private set; }

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
            ToList(false);
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
            ToList(false);
        }

        /// <summary>
        /// Use this for making Static Products
        /// </summary>
        public ProductModel(int id, string n, string d, int wi, int h, int l, bool isStatic)
        {
            if (!isStatic)
            {
                throw new Exception(
                    "You tried to make a Non-Static Product in a Static Only Method.\nPlease change the boolean to true if you wanted to make a Static Object.\nIf you wanted to make a Non-Static Product, please use a different constructor");
            }
            ProductId = id;
            Name = n;

            Description = d;
            Category = "Other";
            ProductCategory = CategoryModel.List[0];

            Width = wi;
            Height = h;
            Length = l;

            if (Name == "Stopcontact")
            {
                Collidable = false;
            }

            ToList(true);
        }

        /// <summary>
        /// A method to distinguish from Static and Non-Static
        /// </summary>
        private void ToList(bool isStatic)
        {
            StaticProduct = isStatic;
            //return if name is empty
            if (Name == "") { return;}

            //If static, add to static list
            if (StaticProduct)
                StaticList.Add(this);
            else
                List.Add(this);
        }


        //This methods sets the Product image using the name of the image
        public void SetProductImage()
        {
            string imagePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                @"\Kantoor Inrichting\Afbeeldingen producten\" + ImageFileName;

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
