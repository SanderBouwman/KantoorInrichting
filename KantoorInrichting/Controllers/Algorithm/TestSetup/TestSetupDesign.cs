// created by: Robin
// on: 07-12-2015

#region

using System;
using System.Collections.Generic;
using System.Drawing;
using KantoorInrichting.Models.Product;

#endregion

namespace KantoorInrichting.Controllers.Algorithm.TestSetup {
    public class TestSetupDesign : IDesignAlgorithm {
        private int _columns;
        private int _rows;

        public List<ProductModel> Design(ProductModel chair, ProductModel table,
                                            int people, int width, int height, float margin) {
            ChairTablePair pair = ChairTablePair.CreatePair(chair, table, margin);
            List<Rectangle> possibilities = CalculatePossibilities(pair, width, height, margin);
            List<ChairTablePair> result = FillRoom(people, pair, possibilities);
            List<ProductModel> finalResult = CreateModelList(result);
            
            return finalResult;
        }

        public List<Rectangle> CalculatePossibilities(ChairTablePair pair, int width,
                                                        int height, float margin) {
            List<Rectangle> possibilities = new List<Rectangle>();
            _columns = width/pair.Representation.Width;
            _rows = height/pair.Representation.Height;
            for (int i = 0; i < _columns; i++) {
                for (int j = 0; j < _rows; j++) {
                    possibilities.Add(new Rectangle {
                        X = i,
                        Y = j
                    });
                }
            }
            return possibilities;
        }

        public List<ChairTablePair> FillRoom(int people, ChairTablePair pair,
                                                List<Rectangle> possibilities) {
            List<ChairTablePair> result = new List<ChairTablePair>();
            int currentPossibility = 0;
            for (int i = 0; i < people; i++) {
                try {
                    ChairTablePair newPair = pair.Clone();
                    Rectangle temp = new Rectangle();
                    if (i == 0) {
                        // teacher column
                        temp.Height = pair.Representation.Height;
                        temp.Width = pair.Representation.Width;
                        temp.X = 0;
                        temp.Y = _rows;
                        currentPossibility += _rows; // students start on the next column
                    }
                    else {
                        // student column
                        temp.Height = pair.Representation.Height;
                        temp.Width = pair.Representation.Width;
                        temp.X = possibilities[currentPossibility].X*pair.Representation.Width;
                        temp.Y = possibilities[currentPossibility].Y*pair.Representation.Height;
                        currentPossibility++;
                    }
                    newPair.Representation = temp;
                    result.Add(newPair);
                }
                catch (ArgumentOutOfRangeException e) {
                    string v = e.Data.ToString();
                    Console.WriteLine("Does not exist");
                }
            }
            return result;
        }

        public List<ProductModel> CreateModelList(List<ChairTablePair> pairs) {
            List<ProductModel> result = new List<ProductModel>();
            for (int i = 0; i < pairs.Count; i++) {
                Point chairPoint, tablePoint;
                ChairTablePair current = pairs[i];

                ProductModel newChair = new ProductModel() {
                    Brand = current.Chair.Brand,
                    Width = current.Chair.Width,
                    Height = current.Chair.Height
                };
                ProductModel newTable = new ProductModel() {
                    Brand = current.Table.Brand,
                    Width = current.Table.Width,
                    Height = current.Table.Height
                };

                int chairX, chairY,
                    tableX, tableY;
                if (i == 0) {
                    chairX = 0;
                    tableX = current.Representation.X + newChair.Width;
                    chairY = current.Representation.Y + newChair.Height;
                    tableY = current.Representation.Y;
                    
                }
                else {
                    chairX = current.Representation.X + newTable.Height;
                    chairY = current.Representation.Y + (newTable.Width/2);
                    tableX = current.Representation.X;
                    tableY = current.Representation.Y;
                }
                SetLocation(newChair, chairX, chairY);
                SetLocation(newTable, tableX, tableY);
                result.Add(newChair);
                result.Add(newTable);
            }
            return result;
        }

        public void SetLocation(ProductModel p, int x, int y) {
            Point point = new Point(x, y);
            p.location = point;
        }
    }
}
