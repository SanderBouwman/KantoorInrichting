// created by: Robin
// on: 07-12-2015

#region

using System.Drawing;

#endregion

namespace KantoorInrichting.Models.Product {
    public struct ChairTablePair {
        public ProductModel Chair { get; set; }
        public ProductModel Table { get; set; }
        public Rectangle Representation { get; set; }

        //creates a product where a table and chair are combined.
        public static ChairTablePair CreatePair(ProductModel chair, ProductModel table, float margin) {
            ChairTablePair pair = new ChairTablePair();
            pair.Chair = chair;
            pair.Table = table;
            pair.Representation = DetermineSize(pair, margin);
            return pair;
        }

        //checks how large the pair will be.
        public static Rectangle DetermineSize(ChairTablePair pair, float margin) {
            Rectangle rectangle = new Rectangle();
            rectangle.Height = (int) (pair.Table.Width + margin*2);
            rectangle.Width = (int) (pair.Chair.Height + pair.Table.Height + margin*2);
            return rectangle;
        }

        //creates a new instance of an already existing pair.
        public ChairTablePair Clone() {
            return new ChairTablePair {
                Chair = Chair,
                Table = Table,
                Representation = Representation
            };
        }

        public override string ToString() {
            return "{Chair=" + Chair.Brand + " Table=" + Table.Brand + "Rectangle=" + Representation + " }";
        }
    }
}
