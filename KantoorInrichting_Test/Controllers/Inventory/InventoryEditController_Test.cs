using KantoorInrichting.Controllers.Inventory;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Views.Inventory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KantoorInrichting_Test.Controllers.Inventory
{
    [TestClass]
    public class InventoryEditController_Test
    {
        [TestMethod]
        public void ShouldChangeAmount()
        {
            ProductModel p = new ProductModel();
            InventoryEdit s = new InventoryEdit(p);
            InventoryEditController t = new InventoryEditController(s, p);

            p.Amount = 10;
            s.productAmount.Value = 0;

            t.UpdateProductModel();

            Assert.IsTrue(p.Amount == 0);

        }
    }
}
