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

                if (t.product.Collidable && current.product.Collidable)
                {
                    bool intersectLeft = current.location.X < t.location.X + t.product.Size.Width,
                        intersectRight = current.location.X + current.product.Size.Width > t.location.X,
                        intersectTop = current.location.Y < t.location.Y + t.product.Size.Height,
                        intersectBottom = current.location.Y + current.product.Size.Height > t.location.Y;

                    if (intersectLeft && intersectRight && intersectTop && intersectBottom)
                        return true;
                }
            }
            return false;
        }
    }
}