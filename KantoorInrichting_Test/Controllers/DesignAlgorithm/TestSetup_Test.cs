// created by: Robin
// on: 04-12-2015

#region

using System.Collections.Generic;
using System.Drawing;
using KantoorInrichting.Controllers.Algorithm;
using KantoorInrichting.Controllers.Algorithm.TestSetup;
using KantoorInrichting.Models.Product;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace KantoorInrichting_Test.Controllers.designalgorithm {
    [TestClass]
    public class TestSetup_Test {
        [TestMethod]
        public void ShouldCreateAPairOfProducts() {
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
            Assert.IsInstanceOfType(ChairTablePair.CreatePair(chair, table, 1), typeof (ChairTablePair));
        }

        [TestMethod]
        public void ShouldCalculateAllPossibilitiesInRoom_WithHorizontalOrientation() {
            TestSetupDesign algo = new TestSetupDesign();
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
            ChairTablePair pair = ChairTablePair.CreatePair(chair, table, 0.5f);
            List<Rectangle> result = algo.CalculatePossibilities(pair, 10, 10, 0.5f);

            Assert.IsTrue(result.Count > 1);
        }

        [TestMethod]
        public void PairShouldBeCorrectSize() {
            TestSetupDesign algo = new TestSetupDesign();
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
            float margin = 0.5f;
            int expectedWidth = (int) (chair.Height + table.Height + margin*2);
            int expectedHeight = (int) (table.Width + margin*2);

            int width = 10;
            int height = 10;
            ChairTablePair pair = ChairTablePair.CreatePair(chair, table, 0.5f);
            List<Rectangle> possibilities = algo.CalculatePossibilities(pair, width, height, 0.5f);
            List<ChairTablePair> designResult = algo.FillRoom(7, pair, possibilities);
            ChairTablePair teacher = designResult[0];
            Rectangle teacherRectangle = teacher.Representation;
            int actualWidth = teacherRectangle.Width;
            int actualHeight = teacherRectangle.Height;
            Assert.IsTrue(actualHeight == expectedHeight && actualWidth == expectedWidth);
        }

        [TestMethod]
        public void ShouldReturnAllPairsWithCorrectColAndRows_Teacher_X0_YHalfHeight() {
            TestSetupDesign algo = new TestSetupDesign();
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
            ChairTablePair pair = ChairTablePair.CreatePair(chair, table, margin);
            List<Rectangle> possibilities = algo.CalculatePossibilities(pair, width, height, margin);
            List<ChairTablePair> result = algo.FillRoom(7, pair, possibilities);
            Rectangle teacher = result[0].Representation;
            int rectanglewidth = (int) (chair.Height + table.Height + margin*2); // 3
            int columns = width/rectanglewidth; // 3 (col 0, col 1, col 2)
            int teachercol = 0; // Should be the first column since we want a left orientation
            int teacherrow = 3; // teacher should be in the middle of the column
            Assert.IsTrue(teacher.X == teachercol && teacher.Y == teacherrow);
        }
    }
}
