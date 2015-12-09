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

namespace KantoorInrichting.Models.Product
{
    public class PlacedProduct
    {
        public ProductModel product { get; private set; }
        public PointF location { get; set; }
        public PointF[] cornerPoints { get; private set; }
        public Bitmap defaultBitMap { get; private set; }
        public Bitmap rotatedMap { get; set; }
        public int currentAngle { get; set; }
        public Polygon Poly { get; set; }
        
        public int gridSpace = 5;


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
            this.product = product;
            location = center;


            //Corner and image
            cornerPoints = new PointF[5];
            defaultBitMap = new Bitmap(product.Width, product.Length);
            Graphics gfx = Graphics.FromImage(defaultBitMap);
            Color color = product.ProductCategory.colour;
            SolidBrush brush = new SolidBrush(color);
            gfx.FillRectangle(brush, 0, 0, product.Width, product.Length);
            
            defaultBitMap = new Bitmap(PlacementController.RezizeImage(defaultBitMap, product.Width, product.Length));

            rotatedMap = defaultBitMap;

            //Must be last. Set the angle and reset the points
            setAngle(angle);
        }



        /// <summary>
        /// Set the angle of the product.
        /// </summary>
        /// <param name="angle">Value must be between 0 and 360.</param>
        public void setAngle(int angle)
        {
            int fallbackAngle = currentAngle;
            angle = angle % 360;
            currentAngle = angle;

            PlacementController.placement_rotatePoints(this, fallbackAngle);
            PlacementController.placement_rotateImg(this);
        }



        /// <summary>
        /// Turns the product a set amount of degrees.
        /// </summary>
        /// <param name="value">Amount of added degrees</param>
        public void addAngle(int value)
        {
            int fallbackAngle = currentAngle;

            currentAngle += value;
            while (currentAngle > 359)
            {
                currentAngle -= 360;
            }
            while (currentAngle < 0)
            {
                currentAngle += 360;
            }
            PlacementController.placement_rotatePoints(this, fallbackAngle);
            PlacementController.placement_rotateImg(this);
        }
        
        public void Move(bool X_Axis)
        {
            PlacementController.placement_Move(this, X_Axis);
        }

        public void MoveTo(Point newLocation)
        {
            location = newLocation;
            setAngle(currentAngle);
        }

        public Polygon getVirtualPolygon(Point newLocation)
        {
            Polygon virtualPolygon = Poly;
            Vector delta = new Vector(new Vector(newLocation) - new Vector(location));

            Poly.Offset(delta);
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
