// created by: Robin
// on: 07-12-2015

#region

using System;
using System.Collections.Generic;
using System.Drawing;
using KantoorInrichting.Models.Product;

#endregion

namespace KantoorInrichting.Controllers.Algorithm.TestSetup
{
    public class TestSetupDesign : IDesignAlgorithm
    {
        private int _columns;
        private int _rows;

        public List<ProductModel> Design(ProductModel chair, ProductModel table,
            int people, float width, float height, float margin)
        {
            ChairTablePair pair = ChairTablePair.CreatePair(chair, table, margin);
            List<Rectangle> possibilities = CalculatePossibilities(pair, width, height, margin);
            List<ChairTablePair> result = FillRoom(people, pair, possibilities);
            List<ProductModel> finalResult = CreateModelList(result, margin);

            return finalResult;
        }

        /// <summary>
        /// Calculates how many pairs of Chairs and Tables can be fit in the room.
        /// I first need to know how many columns and rows the room can have, which I get from:
        /// columns = roomwidth/pairwidth
        /// rows = roomheight/pairheight
        /// 
        /// Then I add a rectangle to a list for every row/column combination.
        /// </summary>
        /// <param name="pair"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="margin"></param>
        /// <returns></returns>
        public List<Rectangle> CalculatePossibilities(ChairTablePair pair, float width,
            float height, float margin)
        {
            List<Rectangle> possibilities = new List<Rectangle>();
            _columns = (int) width/pair.Representation.Width; // We need to know how many columns and rows there are in a room
            _rows = (int) height/pair.Representation.Height; // to put the pairs in later.
            for (int i = 0; i < _columns; i++)
            {
                for (int j = 0; j < _rows; j++)
                {
                    // For every row/column combination, add a rectangle with the x,y values of the row/columns.
                    possibilities.Add(new Rectangle
                    {
                        X = i,
                        Y = j
                    });
                }
            }
            return possibilities;
        }

        /// <summary>
        /// Fills the room with ChairTablePairs. I don't assign ProductModels directly here because the
        /// amount of possibilities is based on the width and height of the pairs.
        /// </summary>
        /// <param name="people"></param>
        /// <param name="pair"></param>
        /// <param name="possibilities"></param>
        /// <returns></returns>
        public List<ChairTablePair> FillRoom(int people, ChairTablePair pair,
            List<Rectangle> possibilities)
        {
            List<ChairTablePair> result = new List<ChairTablePair>();
            int currentPossibility = 0;
            for (int i = 0; i < people; i++)
            {
                try
                {
                    ChairTablePair newPair = pair.Clone();
                    Rectangle temp = new Rectangle();
                    if (i == 0)
                    {
                        // teacher column
                        temp.Height = pair.Representation.Height;
                        temp.Width = pair.Representation.Width;
                        temp.X = 0; // teacher should be on the left side of the room in this setup
                        temp.Y = _rows; // and should be placed in the middle.
                        currentPossibility += _rows; // students start on the next column
                    }
                    else
                    {
                        // student column
                        temp.Height = pair.Representation.Height;
                        temp.Width = pair.Representation.Width;
                        temp.X = possibilities[currentPossibility].X*pair.Representation.Width;
                            // setting the X coordinate of a student
                        temp.Y = possibilities[currentPossibility].Y*pair.Representation.Height;
                            // setting Y coordinate.
                        currentPossibility++;
                    }
                    newPair.Representation = temp; // assign rectangle to pair
                    result.Add(newPair);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    // You get this exception when the amount of people don't fit in the room.
                    throw new RoomTooSmallException("Room is too small to fit the specified amount of people.", e);
                }
            }
            return result;
        }

        /// <summary>
        /// Creates a List of ProductModels from a list of ChairTablePairs.
        /// This also sets the X and Y values for the ProductModel, based on the X,Y values of their ChairTablePair.
        /// </summary>
        /// <param name="pairs"></param>
        /// <param name="margin"></param>
        /// <returns></returns>
        public List<ProductModel> CreateModelList(List<ChairTablePair> pairs, float margin)
        {
            List<ProductModel> result = new List<ProductModel>();
            for (int i = 0; i < pairs.Count; i++)
            {
                ChairTablePair current = pairs[i];

                // creating new chairs and tables from the current pair.
                ProductModel newChair = ProductFactory.CreateProduct(current.Chair.Brand, current.Chair.Width,
                                                                    current.Chair.Height, current.Chair.Type);
                ProductModel newTable = ProductFactory.CreateProduct(current.Table.Brand, current.Table.Width,
                                                                    current.Table.Height, current.Table.Type);

                float chairX,
                    chairY,
                    tableX,
                    tableY;
                if (i == 0)
                {
                    // set teacher chair and table positions
                    chairX = 0;
                    tableX = current.Representation.X + newChair.Width;
                    chairY = current.Representation.Y + newChair.Height;
                    tableY = current.Representation.Y + margin;
                }
                else
                {
                    // set student chair and table positions
                    chairX = current.Representation.X + newTable.Height;
                    chairY = current.Representation.Y + newChair.Height;
                    tableX = current.Representation.X;
                    tableY = current.Representation.Y + margin;
                }
                SetLocation(newChair, chairX, chairY);
                SetLocation(newTable, tableX, tableY);
                result.Add(newChair);
                result.Add(newTable);
            }
            return result;
        }

        /// <summary>
        /// This is a helper method for the CreateModelList method, so that I don't have to assign PointF objects there.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetLocation(ProductModel p, float x, float y)
        {
            PointF point = new PointF(x, y); // using a PointF instead of a Point to increase accuracy.
            p.location = point;
        }
    }
}