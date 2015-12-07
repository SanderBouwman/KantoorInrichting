// created by: Robin
// on: 07-12-2015

using System.Drawing;

namespace KantoorInrichting.Models.Product {
    public struct ChairTablePair {
        public ProductModel Chair { get; set; }
        public ProductModel Table { get; set; }
        public Rectangle Representation { get; set; }

        public static ChairTablePair CreatePair( ProductModel chair, ProductModel table, float margin ) {
            ChairTablePair pair = new ChairTablePair();
            pair.Chair = chair;
            pair.Table = table;
            pair.Representation = DetermineSize(pair, margin);
            return pair;
        }

        public static Rectangle DetermineSize( ChairTablePair pair, float margin ) {
            Rectangle rectangle = new Rectangle();
            rectangle.Height = ( int ) ( pair.Table.width + ( margin * 2 ) );
            rectangle.Width = ( int ) ( pair.Chair.height + pair.Table.height + ( margin * 2 ) );
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
            return "{Chair=" + Chair.brand + " Table=" + Table.brand + "Rectangle=" + Representation + " }";
        }
    }
}