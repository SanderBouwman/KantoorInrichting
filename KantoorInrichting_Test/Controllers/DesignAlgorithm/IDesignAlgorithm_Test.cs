// created by: Robin
// on: 09-12-2015

using System;
using System.Collections.Generic;
using KantoorInrichting.Controllers.Algorithm;
using KantoorInrichting.Controllers.Algorithm.TestSetup;
using KantoorInrichting.Models.Product;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KantoorInrichting_Test.Controllers.designalgorithm {

    [TestClass]
    public class IDesignAlgorithm_Test {

        [TestMethod]
        public void ShouldReturnListOfProducts() {
            IDesignAlgorithm algorithm = new TestSetupDesign();
            ProductModel chair = new ProductModel {
                Brand = "Ahrend",
                Width = 1,
                Height = 1
            };
            ProductModel table = new ProductModel {
                Brand = "TableCompany",
                Width = 2,
                Height = 1
            };

            int width = 10;
            int height = 10;
            int people = 7;
            float margin = 0.5f;

            List<ProductModel> result = algorithm.Design(chair, table, people, width, height, margin);

            Assert.IsTrue(result.Count > 0);
            Assert.IsTrue(result.Count == (people*2));
        }

        [TestMethod]
        [ExpectedException(typeof(RoomTooSmallException))]
        public void ShouldThrowExceptionWhenRoomIsTooSmall() {
            IDesignAlgorithm algorithm = new TestSetupDesign();
            ProductModel chair = new ProductModel {
                Brand = "Ahrend",
                Width = 1,
                Height = 1
            };
            ProductModel table = new ProductModel {
                Brand = "TableCompany",
                Width = 2,
                Height = 1
            };

            int width = 10;
            int height = 10;
            int people = 10;
            float margin = 0.5f;

            try {
                List<ProductModel> result = algorithm.Design(chair, table, people, width, height, margin);
            }
            catch (RoomTooSmallException e) {
                throw;
            }
        }
    }
}