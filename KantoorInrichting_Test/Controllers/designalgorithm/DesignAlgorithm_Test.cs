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

        private int _maxX;
        private int _maxY;
        private int _margin;
        private int _amountOfProducts;

        private DesignOrientation _orientation;

        public List<ChairTablePair> Design( ProductModel chair, ProductModel table, int people, int width, int height, float margin, DesignOrientation orientation ) {
            ChairTablePair pair = CreatePair(chair, table, margin, orientation);
            List<Rectangle> possibilities = CalculatePossibilities(pair, width, height, margin);
            List<ChairTablePair> result = FillRoom(people, pair, possibilities, orientation);
            return result;
        }

        public List<Rectangle> CalculatePossibilities(ChairTablePair pair, int width,
                                                      int height, float margin) {
            List<Rectangle> possibilities = new List<Rectangle>();
            int columns = width/(pair.Representation.Width);
            int rows = height/(pair.Representation.Height);
            for (int i = 0; i < columns; i++) {
                for (int j = 0; j < rows; j++) {
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

        private List<ChairTablePair> OrderRoomHorizontal( int people, ChairTablePair pair, List<Rectangle> possibilities, 
                                                        DesignOrientation orientation ) {
            List<ChairTablePair> result = new List<ChairTablePair>();
            for (int i = 0; i < people; i++) {
                // TODO GET TEACHER POSITION ROW AND COLUMN
                try {
                    ChairTablePair newPair = pair.Clone();
                    Rectangle temp = new Rectangle() {
                        Height = pair.Representation.Height,
                        Width = pair.Representation.Width,
                        X = possibilities[i].X * pair.Representation.Width,
                        Y = possibilities[i].Y * pair.Representation.Height
                    };
                    newPair.Representation = temp;
                    result.Add(newPair);
                }
                catch (ArgumentOutOfRangeException e) {
                    Console.WriteLine("Does not exist");
                }
            }
            return result;
        }

        private List<ChairTablePair> OrderRoomVertical( int people, ChairTablePair pair, List<Rectangle> list, 
                                                        DesignOrientation orientation ) {
            return null;
        }

        public ChairTablePair CreatePair( ProductModel chair, ProductModel table, float margin, 
                                            DesignOrientation orientation ) {
            ChairTablePair pair = new ChairTablePair();
            pair.Chair = chair;
            pair.Table = table;
            pair.Representation = DetermineSize(pair, margin, orientation);
            return pair;
        }

        public Rectangle DetermineSize( ChairTablePair pair, float margin, DesignOrientation orientation ) {
            Rectangle rectangle = new Rectangle();
            switch( orientation ) {
                case DesignOrientation.Top:
                case DesignOrientation.Bottom:
                    rectangle.Height = (int) (pair.Chair.height + pair.Table.height + (margin*2));
                    rectangle.Width = (int) (pair.Table.width + (margin*2));
                    break;

                case DesignOrientation.Left:
                case DesignOrientation.Right:
                    rectangle.Height = (int) (pair.Table.width + (margin*2));
                    rectangle.Width = (int) (pair.Chair.height + pair.Table.height + (margin*2));
                    break;
            }
            return rectangle;
        }
    }

    public struct ChairTablePair {
        public ProductModel Chair { get; set; }
        public ProductModel Table { get; set; }
        public Rectangle Representation { get; set; }

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
            Assert.IsInstanceOfType(algo.CreatePair(chair, table, 1, DesignOrientation.Right), typeof(ChairTablePair));
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
            ChairTablePair pair = algo.CreatePair(chair, table, 0.5f, DesignOrientation.Right);
            List<Rectangle> result = algo.CalculatePossibilities(pair, 10, 10, 0.5f);

            Assert.IsTrue(result.Count > 1);
        }

        [TestMethod]
        public void ShouldReturnAllPairsWithCorrectColAndRows() {
            StandardDesign algo = new StandardDesign();
            ProductModel chair = new ProductModel() {
                brand = "Ahrend",
                width = 1,
                height = 1
            };
            ProductModel table = new ProductModel() {
                brand = "TableCompany",
                width = 4,
                height = 1
            };
            List<ChairTablePair> result = algo.Design(chair, table, 10, 10, 10, 0.5f, DesignOrientation.Right);
            foreach (var pair in result) {
                Console.WriteLine(pair);
            }
        }
    }
}