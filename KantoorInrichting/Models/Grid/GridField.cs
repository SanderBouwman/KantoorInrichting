using KantoorInrichting.Controllers.Product;

namespace KantoorInrichting.Models.Grid {
    public class GridField {

        public Tile[, ] Rows { get; }

        public Tile this[ int i, int j ] {
            get { return Rows[ i, j ]; }
        }

        /// <summary>
        /// Initializes the grid based on given parameters.
        /// Width, height and squareSize are in meters for ease of use.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="squareSize"></param>
        public GridField( int width, int height, float squareSize ) {
            Rows = new Tile[ height, width ];
            InitRows(squareSize);
        }

        /// <summary>
        //  Fills the array of squares with empty Square objects.
        //  Since the array is multi-dimensional, one way to access the different layers is
        //  by using the GetLength(depth) method provided by the array class.
        /// </summary>
        /// <param name="squareSize"></param>
        private void InitRows( float squareSize ) {
            for( int i = 0; i < Rows.GetLength(0); i++ ) { // first dimension (rows)
                for( int j = 0; j < Rows.GetLength(1); j++ ) { // second dimension (columns)
                    Rows[ i, j ] = new Tile(squareSize);
                }
            }
        }

        /// <summary>
        /// Adds an item to the square on the given position.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="item"></param>
        public void AddItem( int x, int y, Product item ) {
            Rows[ y, x ].Product = item;
        }
    }
}