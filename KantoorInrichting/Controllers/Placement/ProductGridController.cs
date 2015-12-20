// created by: Robin
// on: 20-12-2015

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using KantoorInrichting.Views;
using KantoorInrichting.Views.Placement;

namespace KantoorInrichting.Controllers.Placement
{
    public class ProductGridController : IController
    {
        private IView<ProductGrid.PropertyEnum> view;
        private float meterWidth, meterHeight, tileSize,
            tileWidth, tileHeight;

        public ProductGridController(IView<ProductGrid.PropertyEnum> view, 
            float meterWidth, float meterHeight, float tileSize)
        {
            this.meterWidth = meterWidth;
            this.meterHeight = meterHeight;
            this.tileSize = tileSize;
            this.view = view;
            this.view.SetController(this); // set controller
        }

        public void Paint(object sender, PaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void CheckboxChanged(bool b)
        {
            throw new NotImplementedException();
        }

        public void Notify(object sender, EventArgs e)
        {
            // Made a switch using lambda expressions in a dictionary, since you can not do a switch on types
            var @switch = new Dictionary<Type, Action>
            {
                {typeof(EventArgs), () => HandleOtherEvent(sender, e)},
                {typeof(LayoutEventArgs), () =>  LayoutChanged(sender, (LayoutEventArgs) e)}
            };
            Type typeToCheck = e.GetType();
            @switch[ typeToCheck ]();
        }

        public void Dispose(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HandleOtherEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Other event happened... {0}", e.GetType());
        }

        public void LayoutChanged(object sender, LayoutEventArgs e)
        {
            Control panel = view.Get(ProductGrid.PropertyEnum.panel);
            panel.BackgroundImage = CreateBackground(panel.Size);
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
                {
                    gfx.DrawLine(Pens.Black, x, 0, x, size.Height);
                }
                for (float y = 0; y < size.Height; y += tileHeight)
                {
                    gfx.DrawLine(Pens.Black, 0, y, size.Width, y);
                }
            }
            return bitmap;
        }

        /// <summary>
        /// Updates the tileHeight and tileSize fields.
        /// </summary>
        /// <param name="size"></param>
        public void UpdateTileSize(Size size)
        {
            this.tileWidth = (size.Width/meterWidth)*tileSize;
            this.tileHeight = (size.Height/meterHeight)*tileSize;
        }
    }
}