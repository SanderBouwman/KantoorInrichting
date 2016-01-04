// created by: Robin
// on: 31-12-2015

#region

using System.Collections.Generic;

#endregion

namespace KantoorInrichting.Controllers.Placement.Handler
{
    public interface ICollisionHandler<T>
    {
        bool Collision(T t, List<T> list);
    }
}