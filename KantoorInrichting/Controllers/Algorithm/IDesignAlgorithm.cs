// created by: Robin
// on: 07-12-2015

#region

using System.Collections.Generic;
using KantoorInrichting.Models.Product;

#endregion

namespace KantoorInrichting.Controllers.Algorithm {
    public interface IDesignAlgorithm {
        List<ChairTablePair> Design(ProductModel exampleChair, ProductModel exampleTable,
                                    int people, int width, int height, float margin);
    }
}
