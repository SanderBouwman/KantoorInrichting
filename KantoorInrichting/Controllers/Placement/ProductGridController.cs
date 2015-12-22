// created by: Robin
// on: 20-12-2015

#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using KantoorInrichting.Views;
using KantoorInrichting.Views.Placement;

#endregion

namespace KantoorInrichting.Controllers.Placement
{
    public class ProductGridController : IController
    {
        private readonly float meterHeight;
        private readonly float meterWidth;

        private readonly float tileSize;

        private readonly IView<ProductGrid.PropertyEnum> view;

        private float tileWidth, tileHeight;
        private Rectangle zoomArea;

        private bool zoomCheckboxChecked;
        private int zoomSize;


        public ProductGridController(IView<ProductGrid.PropertyEnum> view,
            float meterWidth, float meterHeight, float tileSize)
        {
            this.meterWidth = meterWidth;
            this.meterHeight = meterHeight;
            this.tileSize = tileSize;
            this.view = view;
            zoomSize = 50;
            zoomArea = new Rectangle(0, 0, zoomSize, zoomSize);
            this.view.SetController(this); // set controller
        }

        public void Paint(object sender, PaintEventArgs e)
        {
            if (zoomCheckboxChecked)
                e.Graphics.DrawRectangle(Pens.Red, zoomArea);
        }

        public void Notify(object sender, EventArgs e)
        {
            // Made a switch using lambda expressions in a dictionary, since you can not do a switch on types
            var @switch = new Dictionary<Type, Action>
            {
                {typeof (EventArgs), () => HandleOtherEvent(sender, e)},
                {typeof (LayoutEventArgs), () => LayoutChanged(sender, (LayoutEventArgs) e)},
                {typeof (MouseEventArgs), () => HandleMouseEvent(sender, (MouseEventArgs) e)}
            };
            Type typeToCheck = e.GetType();
            @switch[typeToCheck]();
        }

        public void Dispose(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HandleMouseEvent(object sender, MouseEventArgs e)
        {
            if (zoomCheckboxChecked)
            {
                UpdateRectangle(e.X, e.Y, view.Get(ProductGrid.PropertyEnum.Panel).Width,
                    view.Get(ProductGrid.PropertyEnum.Panel).Height);

                view.Get(ProductGrid.PropertyEnum.Panel).Invalidate();
            }
        }

        public void HandleOtherEvent(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof (CheckBox))
            {
                CheckBox checkBox = (CheckBox) sender;
                zoomCheckboxChecked = checkBox.Checked;
                view.Get(ProductGrid.PropertyEnum.Trackbar).Enabled = zoomCheckboxChecked;
            }
            if (sender.GetType() == typeof (TrackBar))
            {
                TrackBar trackBar = (TrackBar) sender;
                zoomSize = trackBar.Value;
            }
        }

        public void LayoutChanged(object sender, LayoutEventArgs e)
        {
            Control panel = view.Get(ProductGrid.PropertyEnum.Panel);
            panel.BackgroundImage = CreateBackground(panel.Size);
        }

        public void UpdateRectangle(int x, int y, int? maxX, int? maxY)
        {
            if (maxX.HasValue && maxY.HasValue && zoomCheckboxChecked)
            {
                int boundX = (int) maxX;
                int boundY = (int) maxY;
                zoomArea.Width = zoomSize;
                zoomArea.Height = zoomSize;
                zoomArea.X = x - zoomArea.Width/2;
                zoomArea.Y = y - zoomArea.Height/2;
                if (zoomArea.Right > boundX)
                    zoomArea.X = boundX - zoomArea.Width;
                if (zoomArea.Bottom > boundY)
                    zoomArea.Y = boundY - zoomArea.Height;
                if (zoomArea.Top < 0)
                    zoomArea.Y = 0;
                if (zoomArea.Left < 0)
                    zoomArea.X = 0;
            }
        }

        /// <summary>
        /// Creates the background image used by the panel.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public Bitmap CreateBackground(Size size)
        {
            UpdateTileSize(size);
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            using (Graphics gfx = Graphics.FromImage(bitmap))
            {
                for (float x = 0; x < size.Width; x += tileWidth)
                    gfx.DrawLine(Pens.Black, x, 0, x, size.Height);
                for (float y = 0; y < size.Height; y += tileHeight)
                    gfx.DrawLine(Pens.Black, 0, y, size.Width, y);
            }
            return bitmap;
        }

        /// <summary>
        /// Updates the tileHeight and tileSize fields.
        /// </summary>
        /// <param name="size"></param>
        public void UpdateTileSize(Size size)
        {
            tileWidth = size.Width/meterWidth*tileSize;
            tileHeight = size.Height/meterHeight*tileSize;
        }
    }
}
