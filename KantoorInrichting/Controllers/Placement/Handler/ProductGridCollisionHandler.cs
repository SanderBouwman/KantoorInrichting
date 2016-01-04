// created by: Robin
// on: 31-12-2015

#region

using System.Collections.Generic;
using KantoorInrichting.Models.Product;

#endregion

namespace KantoorInrichting.Controllers.Placement.Handler
{
    public class ProductGridCollisionHandler : ICollisionHandler<PlacedProduct>
    {
        public bool Collision(PlacedProduct t, List<PlacedProduct> list)
        {
            foreach (PlacedProduct current in list)
            {
                if (current == t)
                    continue;

                if (t.Product.Collidable && current.Product.Collidable)
                {
                    bool intersectLeft = current.Location.X < t.Location.X + t.Product.Size.Width,
                        intersectRight = current.Location.X + current.Product.Size.Width > t.Location.X,
                        intersectTop = current.Location.Y < t.Location.Y + t.Product.Size.Height,
                        intersectBottom = current.Location.Y + current.Product.Size.Height > t.Location.Y;

                    if (intersectLeft && intersectRight && intersectTop && intersectBottom)
                        return true;
                }
            }
            return false;
        }
    }
}