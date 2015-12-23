// created by: Robin
// on: 07-12-2015

#region

using System.Collections.Generic;
using KantoorInrichting.Models.Product;

#endregion

namespace KantoorInrichting.Controllers.Algorithm
{
    public interface IDesignAlgorithm
    {
        /// <summary>
        /// This method is used to Design a template based on the width, height and margins of a pair of chairs and tables, 
        /// and the width and height of the room.
        /// 
        /// </summary>
        /// <param name="exampleChair"></param>
        /// <param name="exampleTable"></param>
        /// <param name="people"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="margin"></param>
        /// <returns></returns>
        List<ProductModel> Design(ProductModel exampleChair, ProductModel exampleTable,
            int people, float width, float height, float margin);
    }
}