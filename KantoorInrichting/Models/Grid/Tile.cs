// created by: Robin
// on: 18-11-2015

namespace KantoorInrichting.Models.Grid {
    public struct Tile {
        public float Width { get; }
        public float Height { get; }
        public Product.ProductModel Product { get; set; }

        public Tile(float squareSize) {
            Width = squareSize;
            Height = squareSize;
            Product = null;
        }
    }
}