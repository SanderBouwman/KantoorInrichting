// created by: Robin
// on: 04-12-2015

using System;
using System.Collections.Generic;
using System.Drawing;
using KantoorInrichting.Models.Product;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KantoorInrichting_Test.Controllers.designalgorithm {

    public enum DesignOrientation {
        Top,
        Left,
        Bottom,
        Right
    }

    public interface IDesignAlgorithm {
        List<ChairTablePair> Design( ProductModel exampleChair, ProductModel exampleTable, int people, int width, int height, int margin, DesignOrientation orientation );
    }

    public class StandardDesign : IDesignAlgorithm {

        private int _maxX;
        private int _maxY;
        private int _margin;
        private int _amountOfProducts;

        private DesignOrientation _orientation;

        public List<ChairTablePair> Design( ProductModel chair, ProductModel table, int people, int width, int height, int margin, DesignOrientation orientation ) {
            ChairTablePair pair = CreatePair(chair, table);
            List<PointF> possibilities;
            if (orientation == DesignOrientation.Right || orientation == DesignOrientation.Left) {
                possibilities = CalculatePossibilitiesHorizontalOrientation(pair, width, height, margin, orientation);
            }

            return null;
        }

        public List<PointF> CalculatePossibilitiesHorizontalOrientation(ChairTablePair pair, int width, int height, int margin, DesignOrientation orientation) {
            List<PointF> possibilities = new List<PointF>();
            int columns = width/(pair.Size.Width+(margin*2));
            int rows = height/(pair.Size.Height+(margin*2));
            for (int i = 0; i < columns; i++) {
                // TODO get all possibilities (use rectangles to create protected spaces and check if they don't intersect!
                if (i == 0) {
                    possibilities.Add(new PointF(width-pair.Size.Width, (height/2)-(pair.Size.Height/2)));
                    i++;
                }
            }
            return possibilities;
        } 

        private List<ChairTablePair> OrderRoom( List<ChairTablePair> list ) {
            int currentX = 0;
            int currentY = 0;
            switch( _orientation ) {
                case DesignOrientation.Top:
                case DesignOrientation.Bottom:
                    OrderRoomVertical(list);
                    break;
                case DesignOrientation.Left:
                case DesignOrientation.Right:
                    OrderRoomHorizontal(list);
                    break;
            }
            return list;
        }

        private void OrderRoomHorizontal( List<ChairTablePair> list ) {

            int incX = ( _orientation == DesignOrientation.Right ) ? -( list[ 0 ].Size.Width + _margin ) : list[ 0 ].Size.Width + _margin;
            int incY = list[ 0 ].Size.Height + _margin;
            int currentX = (_orientation == DesignOrientation.Right) ? _maxX - list[0].Size.Width : 0;
            int currentY = 0;
            int maxPairsOnRow = (_maxX/(list[0].Size.Width+_margin))+1;
            int maxPairsOnCol = (_maxY/(list[0].Size.Height+_margin))+1;
            Console.WriteLine("Width = {0} Height = {1}", list[0].Size.Width, list[0].Size.Height);
            for (int i = 0; i < list.Count; i++) {
                if (i == 0) {
                    Console.WriteLine("Setting teacher position");
                }
                else {

                    Console.WriteLine("Setting student {0} position", i);
                }

                
            }
        }

        private void OrderRoomVertical( List<ChairTablePair> list ) {
            throw new NotImplementedException();
        }

        public ChairTablePair CreatePair( ProductModel chair, ProductModel table ) {
            ChairTablePair pair = new ChairTablePair();
            pair.Chair = chair;
            pair.Table = table;
            pair.Size = DetermineSize(pair);
            return pair;
        }

        public Size DetermineSize( ChairTablePair pair ) {
            Size size = new Size();
            switch( _orientation ) {
                case DesignOrientation.Top:
                case DesignOrientation.Bottom:
                    size.Height = pair.Chair.height + pair.Table.height;
                    size.Width = pair.Table.width;
                    break;

                case DesignOrientation.Left:
                case DesignOrientation.Right:
                    size.Height = pair.Table.width;
                    size.Width = pair.Chair.height + pair.Table.height;
                    break;
            }
            return size;
        }
    }

    public struct ChairTablePair {
        public ProductModel Chair { get; set; }
        public ProductModel Table { get; set; }
        public Point Location { get; set; }
        public Size Size { get; set; }
    }

    [TestClass]
    public class StandardDesign_Test {

        [TestMethod]
        public void ShouldCreateAPairOfProducts() {
            StandardDesign algo = new StandardDesign();
            ProductModel chair = new ProductModel() {
                brand = "Ahrend",
                width = 1,
                height = 1
            };
            ProductModel table = new ProductModel() {
                brand = "TableCompany",
                width = 2,
                height = 1
            };
            Assert.IsInstanceOfType(algo.CreatePair(chair, table), typeof(ChairTablePair));
        }

        [TestMethod]
        public void ShouldCalculateAllPossibilitiesInRoom_WithHorizontalOrientation() {
            // Arrange
            StandardDesign algo = new StandardDesign();
            ProductModel chair = new ProductModel() {
                brand = "Ahrend",
                width = 1,
                height = 1
            };
            ProductModel table = new ProductModel() {
                brand = "TableCompany",
                width = 2,
                height = 1
            };
            ChairTablePair pair = algo.CreatePair(chair, table);
            List<PointF> result = algo.CalculatePossibilitiesHorizontalOrientation(pair, 10, 10, 1, DesignOrientation.Right);
            Assert.IsTrue(result.Count > 1);
        }
    }
}