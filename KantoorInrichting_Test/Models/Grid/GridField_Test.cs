// created by: Robin
// on: 18-11-2015

#region

using KantoorInrichting.Models.Grid;
using KantoorInrichting.Models.Product;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace KantoorInrichting_Test.Models.Grid {
    [TestClass]
    public class GridFieldModel_Test {
        [TestMethod]
        public void CreateGrid_Test() {
            GridFieldModel grid = new GridFieldModel(10, 10, 0.5f); // the size of the room is given in meters
            Assert.IsTrue(grid.Rows.Length == 100);
        }

        [TestMethod]
        public void ContainsSquares_Test() {
            GridFieldModel grid = new GridFieldModel(10, 10, 0.5f);
            for (int i = 0; i < grid.Rows.GetLength(0); i++)
                for (int j = 0; j < grid.Rows.GetLength(1); j++) Assert.IsInstanceOfType(grid[i, j], typeof (Tile));
        }

        [TestMethod]
        public void AddItem_Test() {
            GridFieldModel grid = new GridFieldModel(10, 10, 0.5f);
            ProductModel i1 = new ProductModel("Chair 1", "Atlas", "Chair", "Chair", "Deskchair", 2, 2, 2, "een stoel", 1);

            int x = 5; // x and y have to be the tilenumber that the user wants to add an item to.
            int y = 5; //

            grid.AddItem(5, 2, i1);

            bool found = false;
            for (int i = 0; i < grid.Rows.GetLength(0); i++)
                for (int j = 0; j < grid.Rows.GetLength(1); j++) if (grid[i, j].Product == i1) found = true;
            Assert.IsTrue(found);
        }
    }
}