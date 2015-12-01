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
            this.pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public void SetArea(Bitmap image) {
            pictureBox.Image = image;
            pictureBox.Refresh();
        }
    }
}