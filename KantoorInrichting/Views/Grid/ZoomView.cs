// created by: Robin
// on: 23-11-2015

#region

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace KantoorInrichting.Views.Grid {
    public partial class ZoomView : Form {
        public ZoomView() {
            InitializeComponent();
        }

        public void SetArea(Bitmap image) {
            using (image) {
                Bitmap tempBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                using (Graphics gfx = Graphics.FromImage(tempBitmap)) {
                    gfx.InterpolationMode = InterpolationMode.NearestNeighbor;
                    gfx.DrawImage(image, new Rectangle(Point.Empty, tempBitmap.Size));

                    pictureBox.Image = tempBitmap;
                }
            }
            pictureBox.Refresh();
        }
    }
}