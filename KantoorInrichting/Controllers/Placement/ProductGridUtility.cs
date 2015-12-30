// created by: Robin
// on: 28-12-2015

#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Views.Placement;

#endregion

namespace KantoorInrichting.Controllers.Placement
{
    public class ProductGridUtility
    {

        public bool Collision(PlacedProduct product, List<PlacedProduct> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                PlacedProduct current = products[i];

                if(current == product)
                    continue;

                if (product.product.Collidable && current.product.Collidable)
                {
                    bool intersectLeft = (current.location.X < product.location.X + product.product.Size.Width),
                        intersectRight = (current.location.X + current.product.Size.Width > product.location.X),
                        intersectTop = (current.location.Y < product.location.Y + product.product.Size.Height),
                        intersectBottom = (current.location.Y + current.product.Size.Height > product.location.Y);

                    if (intersectLeft && intersectRight && intersectTop && intersectBottom)
                        return true;
                }
            }
            return false;
        }

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
        /// Selects the Brush where the type matches from the Dictionary kept in the Legend.
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
                // This means that the type is not found in the dictionary, and so I will set the Brush to Black
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
                PointF currentLocation = current.location;
                
                bool xOnPoint = (currentLocation.X <= realPoint.X) &&
                                (currentLocation.X + current.product.Size.Width >= realPoint.X),

                    yOnPoint = (currentLocation.Y <= realPoint.Y) &&
                               currentLocation.Y + current.product.Size.Height >= realPoint.Y;

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

        public void MoveProduct(PlacedProduct selectedProduct, List<PlacedProduct> placedProducts , int boundWidth, int boundHeight, 
            float realWidth, float realHeight, int x, int y)
        {
            float selectedWidth = selectedProduct.product.Size.Width,
                selectedHeight = selectedProduct.product.Size.Height;
            
            float newX = x / ( float ) boundWidth * realWidth
                         - selectedWidth / 2,
                newY = y / ( float ) boundHeight * realHeight
                       - selectedHeight / 2;

            if( newX <= 0 )
                newX = 0;
            if( newX + selectedWidth / 2 >= realWidth )
                newX = realWidth - selectedWidth * 2;
            if( newY <= 0 )
                newY = selectedHeight / 2;
            if( newY + selectedHeight / 2 >= realHeight )
                newY = realHeight - selectedHeight;

            PointF newLocation = new PointF(newX, newY);
            selectedProduct.location = !Collision(selectedProduct, placedProducts)
                ? newLocation
                : selectedProduct.OriginalLocation;
        }
    }
}