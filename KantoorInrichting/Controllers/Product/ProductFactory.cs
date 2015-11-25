// created by: Robin
// on: 25-11-2015

using System.Collections.Generic;
using System.Drawing;

namespace KantoorInrichting.Controllers.Product {

    public class ProductFactory {

        public static Dictionary<string, Image> GetPossibilities() {
            Dictionary<string, Image> temp = new Dictionary<string, Image>();
            // first image
            Bitmap image1 = new Bitmap(50, 50);
            using (Graphics gfx = Graphics.FromImage(image1)) {
                gfx.FillRectangle(Brushes.Blue, 0, 0, 50, 50);
            }
            Bitmap image2 = new Bitmap(50, 50);
            using( Graphics gfx = Graphics.FromImage(image2) ) {
                gfx.FillRectangle(Brushes.Red, 0, 0, 50, 50);
            }
            temp.Add("Elek", image1);
            temp.Add("Door", image2);
            return temp;
        } 
    }
}