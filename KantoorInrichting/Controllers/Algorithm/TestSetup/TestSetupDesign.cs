// created by: Robin
// on: 07-12-2015

using System;
using System.Collections.Generic;
using System.Drawing;
using KantoorInrichting.Models.Product;

namespace KantoorInrichting.Controllers.Algorithm.TestSetup {
    public class TestSetupDesign : IDesignAlgorithm {

        private int _columns;
        private int _rows;

        public List<ChairTablePair> Design( ProductModel chair, ProductModel table,
                                            int people, int width, int height, float margin ) {
            ChairTablePair pair = ChairTablePair.CreatePair(chair, table, margin);
            List<Rectangle> possibilities = CalculatePossibilities(pair, width, height, margin);
            List<ChairTablePair> result = FillRoom(people, pair, possibilities);
            return result;
        }

        public List<Rectangle> CalculatePossibilities( ChairTablePair pair, int width,
                                                      int height, float margin ) {
            List<Rectangle> possibilities = new List<Rectangle>();
            _columns = width / ( pair.Representation.Width );
            _rows = height / ( pair.Representation.Height );
            for( int i = 0; i < _columns; i++ ) {
                for( int j = 0; j < _rows; j++ ) {
                    possibilities.Add(new Rectangle() {
                        X = i,
                        Y = j
                    });
                }
            }
            return possibilities;
        }

        private List<ChairTablePair> FillRoom( int people, ChairTablePair pair,
                                                List<Rectangle> possibilities ) {
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
    }
}