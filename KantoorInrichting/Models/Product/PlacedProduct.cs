using KantoorInrichting.Models.Placement;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KantoorInrichting.Controllers.Placement;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using KantoorInrichting.Views.Placement;
using System.Windows.Forms;
using KantoorInrichting.Controllers;

namespace KantoorInrichting.Models.Product
{
    public class PlacedProduct
    {

        public static List<PlacedProduct> List = new List<PlacedProduct>();
        public static List<PlacedProduct> StaticList = new List<PlacedProduct>(); 

        public ProductModel Product { get; private set; }
        public PointF Location { get; set; }
        public PointF OriginalLocation { get; set; }
        public PointF[] CornerPoints { get; private set; }
        public Bitmap DefaultBitMap { get; private set; }
        public Bitmap RotatedMap { get; set; }
        public int CurrentAngle { get; set; }
        public Polygon Poly { get; set; }

        public string SpaceID { get; set; }
        public int ProductID { get; set; }

        public int GridSpace = 5;

        public bool StaticProductBoolean { get; private set; }

        /// <summary>
        /// Make a product to be placed on the map
        /// </summary>
        /// <param name="product">Give a product that will be presented.</param>
        /// <param name="center">The center location of the item</param>
        public PlacedProduct(ProductModel product, PointF center) : this(product, center, 0) { }



        /// <summary>
        /// Make a product to be placed on the map with a custom angle.
        /// </summary>
        /// <param name="product">Give a product that will be presented.</param>
        /// <param name="center">The center location of the item.</param>
        /// <param name="angle">Give the product a set angle to take.</param>
        public PlacedProduct(ProductModel product, PointF center, int angle)
        {
            //Core variables
            this.Product = product;
            Location = center;
            this.ProductID = Product.ProductId;

            //static or not
            StaticProductBoolean = product.StaticProduct;
            ToList();

            //angle
            CurrentAngle = angle;

            //space
            //this.SpaceID = space;

            //Corner and image
            CornerPoints = new PointF[5];
            ResetImage();
        }


        private void ToList()
        {
            if (StaticProductBoolean)
                StaticList.Add(this);
            else
                List.Add(this);
        }

        /// <summary>
        /// Resets the images, in the case that the products are updated
        /// </summary>
        public void ResetImage()
        {
            DefaultBitMap = new Bitmap(Product.Width, Product.Length);
            Graphics gfx = Graphics.FromImage(DefaultBitMap);
            // check if this product is an subcategory and get the color
            Color color = PlacementController.GetMainCategoryColorIfNeeded(Product.ProductCategory.CatId);


            SolidBrush brush = new SolidBrush(color);
            gfx.FillRectangle(brush, 0, 0, Product.Width, Product.Length);

            DefaultBitMap = new Bitmap(PlacementController.ResizeImage(DefaultBitMap, Product.Width, Product.Length));
            //MessageBox.Show(String.Format("Name: {0} -- Width: {1} -- Length: {2}", product.Name, product.Width, product.Length));

            try { RotatedMap.Dispose(); }
            catch { }
            RotatedMap = new Bitmap(DefaultBitMap, DefaultBitMap.Width, DefaultBitMap.Height);
            //MessageBox.Show(String.Format("Name: {0} -- Width: {1} -- Length: {2}", "Rotated Map", product.Width, product.Length));

            SetAngle(CurrentAngle);
        }

        

        /// <summary>
        /// Set the angle of the product.
        /// </summary>
        /// <param name="angle">Value must be between 0 and 360.</param>
        public void SetAngle(int angle)
        {
            int fallbackAngle = CurrentAngle;
            angle = angle % 360;
            CurrentAngle = angle;

            PlacementController.placement_rotatePoints(this, fallbackAngle);
            PlacementController.placement_rotateImg(this);
        }



        /// <summary>
        /// Turns the product a set amount of degrees.
        /// </summary>
        /// <param name="value">Amount of added degrees</param>
        public void AddAngle(int value)
        {
            int fallbackAngle = CurrentAngle;

            CurrentAngle += value;
            while (CurrentAngle > 359)
            {
                CurrentAngle -= 360;
            }
            while (CurrentAngle < 0)
            {
                CurrentAngle += 360;
            }
            PlacementController.placement_rotatePoints(this, fallbackAngle);
            PlacementController.placement_rotateImg(this);
        }
        
        public void Move(bool xAxis)
        {
            PlacementController.placement_Move(this, xAxis);
        }

        public void MoveTo(Point newLocation)
        {
            Location = newLocation;
            SetAngle(CurrentAngle);
        }

        public Polygon GetVirtualPolygon(Point newLocation)
        {
            Polygon virtualPolygon = new Polygon();
            foreach (Vector v in Poly.Points)
            {
                virtualPolygon.Points.Add(v);
            }

            Vector delta = new Vector(new Vector(newLocation) - new Vector(Location));

            virtualPolygon.Offset(delta);
            virtualPolygon.BuildEdges();

            return virtualPolygon;
        }


        //This is only used when moving. It will check if it doesn't run into walls. That is it's only function. WALLS.
        //This will be replaced with a full list of static objects, which will include walls.
        //Remove this later.
        //NOTE: Don't move this to another class. It's better to replace this List with the StaticlyPlacedObjectLis than to move this.
        /// <summary>
        /// Gives a list of PlacedProduct as well as walls?
        /// </summary>
        public List<Polygon> PolyList
        {
            get
            {
                //Make a polygon list and add all existing products' polygons to it.
                List<Polygon> list = new List<Polygon>();
                foreach (PlacedProduct pp in PlacementController.placedProductList)
                {
                    //Test if the selected polygon is himself
                    if (pp.Poly == this.Poly)
                    {
                        continue;
                    }

                    list.Add(pp.Poly);
                }

                //
                //Add the 4 corners at the end, because the other products have collision priority
                //
                Polygon pTop = new Polygon();
                Polygon pRight = new Polygon();
                Polygon pBottom = new Polygon();
                Polygon pLeft = new Polygon();

                //Points for corners
                //Point pointTopLeft = new Point(0, 0);
                //Point pointTopRight = new Point(ProductAdding.productFieldPanel.Width, 0);
                //Point pointBottomLeft = new Point(0, ProductAdding.productFieldPanel.Height);
                //Point pointBottomRight = new Point(ProductAdding.productFieldPanel.Width, ProductAdding.productFieldPanel.Height);

                Vector pointTopLeft = new Vector(0, 0);
                Vector pointTopRight = new Vector(600, 0);
                Vector pointBottomLeft = new Vector(0, 600);
                Vector pointBottomRight = new Vector(600, 600);
                

                //Add points/vectors
                pTop.Points.Add(pointTopLeft);
                pTop.Points.Add(pointTopRight);
                //
                pRight.Points.Add(pointTopRight);
                pRight.Points.Add(pointBottomRight);
                //
                pBottom.Points.Add(pointBottomRight);
                pBottom.Points.Add(pointBottomLeft);
                //
                pLeft.Points.Add(pointBottomLeft);
                pLeft.Points.Add(pointTopLeft);


                //Build edges
                pTop.BuildEdges();
                pRight.BuildEdges();
                pBottom.BuildEdges();
                pLeft.BuildEdges();


                //Add to the list
                list.Add(pTop);
                list.Add(pRight);
                list.Add(pBottom);
                list.Add(pLeft);


                return list;
            }
        }        
    }
}
