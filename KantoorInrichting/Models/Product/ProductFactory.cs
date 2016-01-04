// created by: Robin
// on: 23-12-2015
namespace KantoorInrichting.Models.Product
{
    public class ProductFactory
    {
        public static ProductModel CreateProduct(string brand, int width, int height, string type)
        {
            return new ProductModel()
            {
                Brand = brand,
                Width = width,
                Height = height,
                Type = type
            };
        } 
    }
}