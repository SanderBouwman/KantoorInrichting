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

namespace KantoorInrichting.Models.Product
{
    public class PlacedProduct
    {
        public Product product { get; private set; }
        public PointF location { get; private set; }
        public PointF[] cornerPoints { get; private set; }
        private Bitmap defaultBitMap = new Bitmap(Properties.Resources.No_Image_Available);
        public Bitmap rotatedMap { get; private set; }
        public int currentAngle { get; private set; }
        public Polygon Poly { get; private set; }



        /// <summary>
        /// Make a product to be placed on the map
        /// </summary>
        /// <param name="product">Give a product that will be presented.</param>
        /// <param name="center">The center location of the item</param>
        public PlacedProduct(Product product, PointF center) : this(product, center, 0) { }



        /// <summary>
        /// Make a product to be placed on the map with a custom angle.
        /// </summary>
        /// <param name="product">Give a product that will be presented.</param>
        /// <param name="center">The center location of the item.</param>
        /// <param name="angle">Give the product a set angle to take.</param>
        public PlacedProduct(Product product, PointF center, int angle)
        {
            //Core variables
            this.product = product;
            location = center;


            //Corner and image
            cornerPoints = new PointF[5];
            defaultBitMap = new Bitmap(product.Image);
            defaultBitMap = new Bitmap(RezizeImage(Properties.Resources.No_Image_Available, product.width, product.length));
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

            rotatePoints(fallbackAngle);
            rotateImg();
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
            rotatePoints(fallbackAngle);
            rotateImg();
        }



        /// <summary>
        /// Moves the product a certain amount to a certain direction
        /// </summary>
        /// <param name="Velocity">The distance that the product covers. Can contain a negative value to go left/up</param>
        /// <param name="X_Axis">Chooses the axis that the product moves on. True for X-axis. False for Y-axis</param>
        public void Move(int Velocity, bool X_Axis)
        {
            int x = 0;
            int y = 0;
            if (X_Axis) { x += Velocity; }
            else { y += Velocity; }

            Vector velocity = new Vector(x, y);
            Vector playerTranslation = velocity;

            foreach (PlacedProduct placedP in ProductAdding.ppList)
            {
                //Test if the selected polygon is himself
                if (placedP.Poly == this.Poly)
                {
                    continue;
                }

                //Test if the polygon collides with others
                PolygonCollisionController.PolygonCollisionResult r = PolygonCollisionController.PolygonCollision(this.Poly, placedP.Poly, velocity);

                //If it does, alter the speed
                if (r.WillIntersect)
                {
                    playerTranslation = velocity + r.MinimumTranslationVector;
                    break;
                }
            }

            //Set the polygon points
            Poly.Offset(playerTranslation);

            //Update the corner points
            for (int index = 0; index < Poly.Points.Count; index++)
            {
                cornerPoints[index] = new PointF(Poly.Points[index].X, Poly.Points[index].Y);
            }

            //Update the center point            
            location = new PointF(Poly.Center.X, Poly.Center.Y);

        }



        /// <summary>
        /// Issues the rotation of the product.
        /// </summary>
        /// <param name="fallbackAngle">The fallback angle to provide should the product not be able to rotate.</param>
        private void rotatePoints(int fallbackAngle)
        {
            PointF[] fallbackPoints = new PointF[5];
            for (int index = 0; index < cornerPoints.Length; index++)
            {
                fallbackPoints[index] = cornerPoints[index];
            }

            double angle_Even = currentAngle;
            double angle_Uneven = currentAngle;
            double radius = Math.Sqrt(Math.Pow(0.5 * product.width, 2) + Math.Pow(0.5 * product.length, 2));


            //Tan^-1 ( (1/2H) / (1/2W) )
            //This is to get the angle of the center of the rectangle relevant to the sides. (To get the angle inside the rectangle)
            angle_Even += (Math.Atan((0.5 * product.length) / (0.5 * product.width)) * 180 / Math.PI);
            angle_Uneven -= 90 - (Math.Atan((0.5 * product.width) / (0.5 * product.length)) * 180 / Math.PI);
            //If the angle is negative, add 360 to it to get the positive version
            while (angle_Uneven < 0)
            {
                angle_Uneven += 360;
            }
            while (angle_Even < 0)
            {
                angle_Even += 360;
            }
            //MessageBox.Show("Depth: " + product.depth + ". Width: " + product.width);
            //MessageBox.Show("Even angle: " + angle_Even.ToString() + ". Uneven angle: " + angle_Uneven.ToString());

            //Get the total angle to know what direction the item is facing. (To know where to apply the deltaX and deltaY)
            int directional_Even = Convert.ToInt32(angle_Even) % 360;
            int directional_Uneven = Convert.ToInt32(angle_Uneven) % 360;
            //Gets a 4 possible outcome to determine what deltaX and deltaY do.
            directional_Even = directional_Even / 90;
            directional_Uneven = directional_Uneven / 90;
            /*
            0-89 = 0 (360 degrees is 0 degrees)
            90-179 = 1
            180-269 = 2
            270-359 = 3
            */


            //Gets the angle nearest to 90, so that the Cos and Sin methods work.
            angle_Even = angle_Even % 90;
            angle_Uneven = angle_Uneven % 90;
            //MessageBox.Show("Even angle: " + angle_Even.ToString() + ". Uneven angle: " + angle_Uneven.ToString());


            //Get the difference in X and Y to be applied to the centre point so the corner points can be calculated
            float Cos_Even = (float)(Math.Cos(angle_Even * Math.PI / 180) * radius);
            float Sin_Even = (float)(Math.Sin(angle_Even * Math.PI / 180) * radius);

            float Cos_Uneven = (float)(Math.Cos(angle_Uneven * Math.PI / 180) * radius);
            float Sin_Uneven = (float)(Math.Sin(angle_Uneven * Math.PI / 180) * radius);



            //Determine what deltaX and deltaY do.
            switch (directional_Even)
            {
                case 0: //Total degree is between 0 and 89
                    cornerPoints[0] = new PointF(location.X - Cos_Even, location.Y - Sin_Even);
                    cornerPoints[2] = new PointF(location.X + Cos_Even, location.Y + Sin_Even);
                    break;


                case 1: //Total degree is between 90 and 179
                    cornerPoints[0] = new PointF(location.X + Sin_Even, location.Y - Cos_Even);
                    cornerPoints[2] = new PointF(location.X - Sin_Even, location.Y + Cos_Even);
                    break;


                case 2: //Total degree is between 180 and 269
                    cornerPoints[0] = new PointF(location.X + Cos_Even, location.Y + Sin_Even);
                    cornerPoints[2] = new PointF(location.X - Cos_Even, location.Y - Sin_Even);
                    break;


                case 3: //Total degree is between 270 and 359
                    cornerPoints[0] = new PointF(location.X - Sin_Even, location.Y + Cos_Even);
                    cornerPoints[2] = new PointF(location.X + Sin_Even, location.Y - Cos_Even);
                    break;
                default:
                    goto case 0;
            }
            switch (directional_Uneven)
            {
                case 0: //Total degree is between 1 and 90
                    cornerPoints[1] = new PointF(location.X + Cos_Uneven, location.Y + Sin_Uneven);
                    cornerPoints[3] = new PointF(location.X - Cos_Uneven, location.Y - Sin_Uneven);
                    break;


                case 1: //Total degree is between 91 and 180
                    cornerPoints[1] = new PointF(location.X - Sin_Uneven, location.Y + Cos_Uneven);
                    cornerPoints[3] = new PointF(location.X + Sin_Uneven, location.Y - Cos_Uneven);
                    break;


                case 2: //Total degree is between 181 and 270
                    cornerPoints[1] = new PointF(location.X - Cos_Uneven, location.Y - Sin_Uneven);
                    cornerPoints[3] = new PointF(location.X + Cos_Uneven, location.Y + Sin_Uneven);
                    break;


                case 3: //Total degree is between 271 and 360
                    cornerPoints[1] = new PointF(location.X + Sin_Uneven, location.Y - Cos_Uneven);
                    cornerPoints[3] = new PointF(location.X - Sin_Uneven, location.Y + Cos_Uneven);
                    break;
                default:
                    goto case 0;
            }
            //Set the last angle to the first angle to complete the square
            cornerPoints[4] = cornerPoints[0];



            //Setting the new points to the polygon
            Poly = new Polygon();
            foreach (PointF point in cornerPoints)
            {
                Poly.Points.Add(new Vector(point.X, point.Y));
            }
            Poly.BuildEdges();




            //Testing if turning caused a collision
            foreach (PlacedProduct placedP in ProductAdding.ppList)
            {
                //Test if the selected polygon is himself
                if (placedP.Poly == this.Poly)
                {
                    continue;
                }

                //Test if the polygon collides with others
                PolygonCollisionController.PolygonCollisionResult r = PolygonCollisionController.PolygonCollision(this.Poly, placedP.Poly, new Vector(0, 0));

                //If it does, cancel the rotation
                if (r.WillIntersect)
                {
                    //Issue the fallback
                    currentAngle = fallbackAngle;

                    //Issue the fallback
                    for (int index = 0; index < cornerPoints.Length; index++)
                    {
                        cornerPoints[index] = fallbackPoints[index];
                    }

                    //Restate the polygon
                    Poly = new Polygon();
                    foreach (PointF point in cornerPoints)
                    {
                        Poly.Points.Add(new Vector(point.X, point.Y));
                    }
                    Poly.BuildEdges();

                    //MessageBox.Show("The rotation has caused a collision.");
                }
            }
        }



        /// <summary>
        /// Issues the rotation of the image of the product.
        /// </summary>
        private void rotateImg()
        {
            Color bkColor = Color.Transparent;
            int angle = currentAngle;

            angle = angle % 360;
            if (angle > 180)
                angle -= 360;

            PixelFormat pf = default(PixelFormat);
            if (bkColor == Color.Transparent)
            {
                pf = PixelFormat.Format32bppArgb;
            }
            else
            {
                pf = defaultBitMap.PixelFormat;
            }

            float sin = (float)Math.Abs(Math.Sin(angle * Math.PI / 180.0)); // this function takes radians
            float cos = (float)Math.Abs(Math.Cos(angle * Math.PI / 180.0)); // this one too
            float newImgWidth = sin * defaultBitMap.Height + cos * defaultBitMap.Width;
            float newImgHeight = sin * defaultBitMap.Width + cos * defaultBitMap.Height;
            float originX = 0f;
            float originY = 0f;

            if (angle > 0)
            {
                if (angle <= 90)
                    originX = sin * defaultBitMap.Height;
                else
                {
                    originX = newImgWidth;
                    originY = newImgHeight - sin * defaultBitMap.Width;
                }
            }
            else
            {
                if (angle >= -90)
                    originY = sin * defaultBitMap.Width;
                else
                {
                    originX = newImgWidth - sin * defaultBitMap.Height;
                    originY = newImgHeight;
                }
            }

            Bitmap newImg = new Bitmap((int)newImgWidth, (int)newImgHeight, pf);
            Graphics g = Graphics.FromImage(newImg);
            g.Clear(bkColor);
            g.TranslateTransform(originX, originY); // offset the origin to our calculated values
            g.RotateTransform(angle); // set up rotate
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.DrawImageUnscaled(defaultBitMap, 0, 0); // draw the image at 0, 0
            g.Dispose();

            rotatedMap = newImg;
        }



        #region Resize Images
        //
        //Methods to resize an image, should it be to large for the container it is in.
        //
        private Image RezizeImage(Image img, int maxWidth, int maxHeight)
        {
            if (img.Height < maxHeight && img.Width < maxWidth) return img;
            using (img)
            {
                Double xRatio = (double)img.Width / maxWidth;
                Double yRatio = (double)img.Height / maxHeight;
                Double ratio = Math.Max(xRatio, yRatio);
                int nnx = (int)Math.Floor(img.Width / ratio);
                int nny = (int)Math.Floor(img.Height / ratio);
                Bitmap cpy = new Bitmap(nnx, nny, PixelFormat.Format32bppArgb);
                using (Graphics gr = Graphics.FromImage(cpy))
                {
                    gr.Clear(Color.Transparent);

                    // This is said to give best quality when resizing images
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    gr.DrawImage(img,
                        new Rectangle(0, 0, nnx, nny),
                        new Rectangle(0, 0, img.Width, img.Height),
                        GraphicsUnit.Pixel);
                }
                return cpy;
            }

        }

        private MemoryStream BytearrayToStream(byte[] arr)
        {
            return new MemoryStream(arr, 0, arr.Length);
        }

        private void HandleImageUpload(byte[] binaryImage)
        {
            Image img = RezizeImage(Image.FromStream(BytearrayToStream(binaryImage)), 103, 32);
            img.Save("IMAGELOCATION.png", System.Drawing.Imaging.ImageFormat.Gif);
        }
        #endregion Resize Images
    }
}
