using KantoorInrichting.Controllers.Product;

namespace KantoorInrichting.Models.Grid {
    public struct Tile {

        public float Width { get; }
        public float Height { get; }
        public Product Product { get; set; }

        public Tile( float squareSize ) {
            this.Width = squareSize;
            this.Height = squareSize;
            this.Product = null;
        }
    }
}