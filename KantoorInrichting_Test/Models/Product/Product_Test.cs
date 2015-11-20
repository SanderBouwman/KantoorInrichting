using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KantoorInrichting.Models.Product;

namespace KantoorInrichting_Test.Models.Product_Test
{
    [TestClass]
    public class Product_Test
    {
        //these tests will need to be expanded to include a check if the database has indeed been changed.
        [TestMethod]
        public void Createproduct_Test()
        {
            Product p = new Product();
            Assert.IsNotNull(p);
        }

        [TestMethod]
        public void ChangeProductCategory_Test()
        {
            Product p = new Product();
            p.category = "changed category";
            p.subcategory = "changed subcategory";

            Assert.AreEqual(p.category, "changed category");
            Assert.AreEqual(p.subcategory, "changed subcategory");
        }

        [TestMethod]
        public void DeleteProductCategory_Test()
        {
            Product p = new Product("", "", "", "category", "subcategory", 0, 0, 0, "", 0);
            p.category = "";
            p.subcategory = "";

            Assert.AreEqual(p.category, "");
            Assert.AreEqual(p.subcategory, "");
        }
    }
}
