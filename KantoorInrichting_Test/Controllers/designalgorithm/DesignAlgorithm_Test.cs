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
        List<ChairTablePair> Design( ProductModel exampleChair, ProductModel exampleTable, int people, int width, int height, float margin, DesignOrientation orientation );
    }

    public class StandardDesign : IDesignAlgorithm {
        private int _columns;
        private int _rows;

        public List<ChairTablePair> Design( ProductModel chair, ProductModel table, int people, int width, int height, float margin, DesignOrientation orientation ) {
            ChairTablePair pair = ChairTablePair.CreatePair(chair, table, margin, orientation);
            List<Rectangle> possibilities = CalculatePossibilities(pair, width, height, margin);
            List<ChairTablePair> result = FillRoom(people, pair, possibilities, orientation);
            return result;
        }

        public List<Rectangle> CalculatePossibilities(ChairTablePair pair, int width,
                                                      int height, float margin) {
            List<Rectangle> possibilities = new List<Rectangle>();
            _columns = width/(pair.Representation.Width);
            _rows = height/(pair.Representation.Height);
            for (int i = 0; i < _columns; i++) {
                for (int j = 0; j < _rows; j++) {
                    possibilities.Add(new Rectangle() {
                        X = i,
                        Y = j
                    });
                }
            }
            return possibilities;
        } 

        private List<ChairTablePair> FillRoom( int people, ChairTablePair pair, List<Rectangle> possibilities, 
                                                DesignOrientation orientation ) {
            List<ChairTablePair> result;
            switch( orientation ) {
                case DesignOrientation.Top:
                case DesignOrientation.Bottom:
                    result = OrderRoomVertical(people, pair, possibilities, orientation);
                    break;
                case DesignOrientation.Left:
                case DesignOrientation.Right:
                    result = OrderRoomHorizontal(people, pair, possibilities, orientation);
                    break;
                default:
                    result = new List<ChairTablePair>();
                    break;
            }
            return result;
        }

        private List<ChairTablePair> OrderRoomHorizontal( int people, ChairTablePair pair,
                                                            List<Rectangle> possibilities, 
                                                            DesignOrientation orientation ) {
            List<ChairTablePair> result = null;
            if (orientation == DesignOrientation.Right)
                result = OrderRoomHorizontal_Right(people, pair, possibilities);
            else if (orientation == DesignOrientation.Left)
                result = OrderRoomHorizontal_Left(people, pair, possibilities);
            return result;
        }

        #region Horizontal orientation methods
        private List<ChairTablePair> OrderRoomHorizontal_Right(int people, ChairTablePair pair, 
                                                                List<Rectangle> possibilities) {

            List<ChairTablePair> result = new List<ChairTablePair>();
            int currentPossibility = ( _columns * _rows ) - 1;
            for( int i = people - 1; i >= 0; i-- ) {
                try {
                    ChairTablePair newPair = pair.Clone();
                    Rectangle temp = new Rectangle();
                    if( i == people - 1 ) { // teacher column
                        temp.Height = pair.Representation.Height;
                        temp.Width = pair.Representation.Width;
                        temp.X = ( _columns ) * 2;
                        temp.Y = ( _rows );
                        currentPossibility -= _rows; // students start on the next column
                    } else { // student column
                        temp.Height = pair.Representation.Height;
                        temp.Width = pair.Representation.Width;
                        temp.X = possibilities[ currentPossibility ].X * pair.Representation.Width;
                        temp.Y = possibilities[ currentPossibility ].Y * pair.Representation.Height;
                        currentPossibility--;
                    }
                    newPair.Representation = temp;
                    result.Add(newPair);
                } catch( ArgumentOutOfRangeException e ) {
                    string v = e.Data.ToString();
                    Console.WriteLine("Does not exist");
                }
            }
            return result;

        }

        private List<ChairTablePair> OrderRoomHorizontal_Left(int people, ChairTablePair pair,
                                                                List<Rectangle> possibilities) {
            List<ChairTablePair> result = new List<ChairTablePair>();
            int currentPossibility = 0;
            for( int i = 0; i < people; i++ ) {
                try {
                    ChairTablePair newPair = pair.Clone();
                    Rectangle temp = new Rectangle();
                    if( i == 0 ) { // teacher column
                        temp.Height = pair.Representation.Height;
                        temp.Width = pair.Representation.Width;
                        temp.X = 0;
                        temp.Y = ( _rows );
                        currentPossibility += _rows; // students start on the next column
                    } else { // student column
                        temp.Height = pair.Representation.Height;
                        temp.Width = pair.Representation.Width;
                        temp.X = possibilities[ currentPossibility ].X * pair.Representation.Width;
                        temp.Y = possibilities[ currentPossibility ].Y * pair.Representation.Height;
                        currentPossibility++;
                    }
                    newPair.Representation = temp;
                    result.Add(newPair);
                } catch( ArgumentOutOfRangeException e ) {
                    string v = e.Data.ToString();
                    Console.WriteLine("Does not exist");
                }
            }
            return result;
        }

        #endregion

        private List<ChairTablePair> OrderRoomVertical( int people, ChairTablePair pair, List<Rectangle> list, 
                                                        DesignOrientation orientation ) {
            return null;
        }

        

        
    }

    public struct ChairTablePair {
        public ProductModel Chair { get; set; }
        public ProductModel Table { get; set; }
        public Rectangle Representation { get; set; }

        public static ChairTablePair CreatePair( ProductModel chair, ProductModel table, float margin,
                                            DesignOrientation orientation ) {
            ChairTablePair pair = new ChairTablePair();
            pair.Chair = chair;
            pair.Table = table;
            pair.Representation = DetermineSize(pair, margin, orientation);
            return pair;
        }

        public static Rectangle DetermineSize( ChairTablePair pair, float margin, DesignOrientation orientation ) {
            Rectangle rectangle = new Rectangle();
            switch( orientation ) {
                case DesignOrientation.Top:
                case DesignOrientation.Bottom:
                    rectangle.Height = ( int ) ( pair.Chair.height + pair.Table.height + ( margin * 2 ) );
                    rectangle.Width = ( int ) ( pair.Table.width + ( margin * 2 ) );
                    break;

                case DesignOrientation.Left:
                case DesignOrientation.Right:
                    rectangle.Height = ( int ) ( pair.Table.width + ( margin * 2 ) );
                    rectangle.Width = ( int ) ( pair.Chair.height + pair.Table.height + ( margin * 2 ) );
                    break;
            }
            return rectangle;
        }

        public ChairTablePair Clone() {
            return new ChairTablePair() {
                Chair = this.Chair,
                Table = this.Table,
                Representation = this.Representation
            };
        }

        public override string ToString() {
            return "{Chair=" + Chair.Brand + " Table=" + Table.Brand + "Rectangle=" + Representation + " }";
        }
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
            Assert.IsInstanceOfType(ChairTablePair.CreatePair(chair, table, 1, DesignOrientation.Right), typeof(ChairTablePair));
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
            ChairTablePair pair = ChairTablePair.CreatePair(chair, table, 0.5f, DesignOrientation.Right);
            List<Rectangle> result = algo.CalculatePossibilities(pair, 10, 10, 0.5f);

            Assert.IsTrue(result.Count > 1);
        }

        [TestMethod]
        public void ShouldReturnAllPairsWithCorrectColAndRows_OrientationRight() {
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

            int width = 10;
            int height = 10;
            int people = 7;
            float margin = 0.5f;
            List<ChairTablePair> result = algo.Design(chair, table, people, width, height, margin, DesignOrientation.Right);
            Rectangle teacher = result[0].Representation;
            int rectanglewidth = (int) (chair.height + table.height + (margin*2)); // 3
            int columns = width/rectanglewidth; // 3 (col 0, col 1, col 2)
            int teachercol = columns*2; // (amountofcolumns*lastcolumnnumber) = 6
            int teacherrow = 3; // teacher should be in the middle of the column
            Assert.IsTrue(teacher.X == teachercol && teacher.Y == teacherrow);
        }

        [TestMethod]
        public void ShouldReturnAllPairsWithCorrectColAndRows_OrientationLeft() {
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

            int width = 10;
            int height = 10;
            int people = 7;
            float margin = 0.5f;
            List<ChairTablePair> result = algo.Design(chair, table, people, width, height, margin, DesignOrientation.Left);
            Rectangle teacher = result[ 0 ].Representation;
            int rectanglewidth = ( int ) ( chair.height + table.height + ( margin * 2 ) ); // 3
            int columns = width / rectanglewidth; // 3 (col 0, col 1, col 2)
            int teachercol = 0; // Should be the first column since we want a left orientation
            int teacherrow = 3; // teacher should be in the middle of the column
            Assert.IsTrue(teacher.X == teachercol && teacher.Y == teacherrow);
        }
    }
}