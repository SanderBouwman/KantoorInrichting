// created by: Robin
// on: 28-12-2015

#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using KantoorInrichting.Models.Product;

#endregion

namespace KantoorInrichting.Controllers.Placement
{
    public class ProductGridUtility
    {
        public Rectangle GetProductRectangle(PlacedProduct product, float width, float height, float size)
        {
            Rectangle rectangle;
            if (product.product.Size.IsEmpty)
            {
                // this is a product that came from the algorithm
                rectangle = new Rectangle
                {
                    Height = (int) (product.product.Height/size*height),
                    Width = (int) (product.product.Width/size*width),
                    X = (int) (product.location.X/size*width),
                    Y = (int) (product.location.Y/size*height)
                };
            }
            else
            {
                rectangle = new Rectangle
                {
                    Height = (int) (product.product.Size.Height/size*height),
                    Width = (int) (product.product.Size.Width/size*width),
                    X = (int) (product.location.X/size*width),
                    Y = (int) (product.location.Y/size*height)
                };
            }
            return rectangle;
        }

        /// <summary>
        /// Selects the brush where the type matches from the Dictionary kept in the Legend.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="dict"></param>
        /// <returns></returns>
        public SolidBrush SelectBrush(PlacedProduct product, Dictionary<string, SolidBrush> dict)
        {
            SolidBrush brush;
            try
            {
                brush = dict.Single(pair => pair.Key.Equals(product.product.Type)).Value;
            }
            catch (InvalidOperationException e)
            {
                // This means that the type is not found in the dictionary, and so I will set the brush to Black
                brush = new SolidBrush(Color.Black);
            }
            return brush;
        }

        public PlacedProduct GetProductFromField(Point point, List<PlacedProduct> products, float width, float height,
            float size)
        {
            PlacedProduct result = null;
            PointF realPoint = TransformToRealWorld(point, width, height, size);
            foreach (PlacedProduct current in products)
            {
                PointF currentLocation = current.location.IsEmpty ? current.product.location : current.location;

                float widthInMeters = current.product.Size.Width == 0
                    ? current.product.Width
                    : (float) current.product.Width/100,

                    heightInMeters = current.product.Size.Height == 0
                        ? current.product.Height
                        : (float) current.product.Height/100;

                bool xOnPoint = (currentLocation.X <= realPoint.X) &&
                                (currentLocation.X + widthInMeters >= realPoint.X),

                    yOnPoint = (currentLocation.Y <= realPoint.Y) &&
                               currentLocation.Y + heightInMeters >= realPoint.Y;

                if (xOnPoint && yOnPoint)
                {
                    result = current;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Returns a Point with the X and Y in real world measurements.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public PointF TransformToRealWorld(Point point, float width, float height, float size)
        {
            float resultX = point.X/width*size,
                resultY = point.Y/height*size;
            return new PointF(resultX, resultY);
        }
    }
}