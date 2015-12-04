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
        List<ChairTablePair> Design( int people, int width, int height, int margin, DesignOrientation orientation );
    }

    public class StandardDesign : IDesignAlgorithm {

        private int _maxX;
        private int _maxY;
        private int _margin;
        private int _amountOfProducts;

        private DesignOrientation _orientation;

        public List<ChairTablePair> Design( int people, int width, int height, int margin, DesignOrientation orientation ) {
            _maxX = width;
            _maxY = height;
            _margin = margin;
            _amountOfProducts = people * 2; //chairs and tables
            _orientation = orientation;
            List<ChairTablePair> design = new List<ChairTablePair>();
            for( int i = 0; i < people; i++ ) {
                // Testing chairs and tables
                ProductModel chair = new ProductModel() {
                    amount = 1,
                    brand = "Ahrend",
                    category = "Chair",
                    width = 1,
                    height = 1
                };
                ProductModel table = new ProductModel() {
                    amount = 1,
                    brand = "TheTableCompany",
                    category = "table",
                    width = 2,
                    height = 1
                };
                design.Add(CreatePair(chair, table));
            }
            return OrderRoom(design);
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
            int incY = list[ 0 ].Size.Height;
            int currentX = (_orientation == DesignOrientation.Right) ? _maxX - list[0].Size.Width : 0;
            int currentY = 0;
            for( int i = 0; i < list.Count; i++ ) {
                ChairTablePair current = list[i];
                if (i == 0) {
                    current.Location = new Point(currentX, _maxY/2);
                }
                // TODO SET OTHER PAIRS
                currentX += incX;
                currentY += incY;
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
    public class DesignAlgorithm_Test {

        private IDesignAlgorithm _algorithm;

        [TestMethod]
        public void ShouldReturnListOfPairs() {
            _algorithm = new StandardDesign();
            Assert.IsInstanceOfType(_algorithm.Design(10, 10, 10, 1, DesignOrientation.Top), typeof(List<ChairTablePair>));
        }

        [TestMethod]
        public void ShouldReturnListWithRightAmountOfPairs() {
            _algorithm = new StandardDesign();
            int expectedResult = 10; // 10 pairs of tables and chairs
            int result = _algorithm.Design(10, 10, 10, 1, DesignOrientation.Top).Count;
            Assert.IsTrue(result == expectedResult);
        }

        [TestMethod]
        public void ShouldReturnListWithPairs_WithCorrectSize_TopOrientation() {
            _algorithm = new StandardDesign();
            int expectedWidth = 2;
            int expectedHeight = 2;
            Size returnedSize = _algorithm.Design(10, 10, 10, 1, DesignOrientation.Top)[ 0 ].Size;
            int actualWidth = returnedSize.Width;
            int actualHeight = returnedSize.Height;
            Assert.IsTrue(actualHeight == expectedHeight && actualWidth == expectedWidth);
        }

        [TestMethod]
        public void ShouldReturnListWithPairs_WithCorrectSize_LeftOrientation() {
            _algorithm = new StandardDesign();
            int expectedWidth = 2;
            int expectedHeight = 2;
            Size returnedSize = _algorithm.Design(10, 10, 10, 1, DesignOrientation.Left)[ 0 ].Size;
            int actualWidth = returnedSize.Width;
            int actualHeight = returnedSize.Height;

            Assert.IsTrue(actualHeight == expectedHeight && actualWidth == expectedWidth);
        }

        [TestMethod]
        public void ShouldReturnListWithPairs_WithCorrectLocation_OfTeacherChairTablePair() {
            _algorithm = new StandardDesign();
            int expectedY = 4;
            int expectedX = 0;
            Point location = _algorithm.Design(10, 10, 10, 1, DesignOrientation.Top)[ 0 ].Location;
            int actualY = location.Y;
            int actualX = location.X;

            Assert.IsTrue(actualX == expectedX && actualY == expectedY);
        }
    }
}