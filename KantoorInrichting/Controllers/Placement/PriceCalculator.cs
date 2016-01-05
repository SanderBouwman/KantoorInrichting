using KantoorInrichting.Models.Product;

namespace KantoorInrichting.Controllers.Placement
{
    public class PriceCalculator
    {
        private decimal totalPrice;

        public PriceCalculator()
        {
            
        }

        public void CalculatePricePerProduct(int amountPlaced, ProductModel product)
        {
            if (product.Amount < amountPlaced)
            {
                int amountNeeded = amountPlaced - product.Amount;
                totalPrice =+ product.Price * amountNeeded;
            }
        }
         
    }
}