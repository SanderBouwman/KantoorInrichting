// created by: Robin
// on: 20-11-2015

#region

using System;
using System.Drawing;
using System.Windows.Forms;
using KantoorInrichting.Models.Grid;
using KantoorInrichting.Views.Grid;

#endregion

namespace KantoorInrichting.Controllers.Grid {
    public class GridController {
        private Bitmap _background;

        private Bitmap _buffer;
        private readonly GridFieldModel _model;

        private Point _mousePosition;

        private readonly int _tileWidth;

        private readonly int _tileHeight;

        private int _tileX,
            _tileY;

        private readonly GridFieldView _view;

        private bool _zoomRectangleEnabled;

        public GridController(GridFieldView view, GridFieldModel model) {
            _view = view;
            _model = model;

            _view.SetController(this);

            float tWidth = _view.GetPanel().Width/_model.Rows.GetLength(1);
            float tHeight = _view.GetPanel().Height/_model.Rows.GetLength(0);
            // Doing these check to make sure that we don't have pixels left
            _tileWidth = _view.GetPanel().Width%_model.Rows.GetLength(1) != 0 ? (int) tWidth++ : (int) tWidth;
            _tileHeight = _view.GetPanel().Width%_model.Rows.GetLength(0) != 0 ? (int) tHeight++ : (int) tHeight;

            Resize(this, null);
        }

        public void MouseDown(object sender, MouseEventArgs e) {
            _tileX = e.X/_tileWidth;
            _tileY = e.Y/_tileHeight;
            Console.WriteLine("X: {0}, Y: {1}", _tileX, _tileY);
        }

        public void Resize(object sender, EventArgs e) {
            if (_buffer == null || _buffer.Width < _view.GetPanel().Width ||
                _buffer.Height < _view.GetPanel().Height) {
                Bitmap newBuffer = new Bitmap(_view.GetPanel().Width, _view.GetPanel().Height);

                if (_buffer != null) {
                    using (Graphics bufferGraphics = Graphics.FromImage(newBuffer))
                        bufferGraphics.DrawImageUnscaled(_buffer, Point.Empty);
                }

                _buffer = newBuffer;
            }
        }

        public void Paint(object sender, PaintEventArgs e) {
            PaintMouseRectangle();
            PaintModel();
            e.Graphics.DrawImage(_buffer, Point.Empty);
        }

        private void PaintMouseRectangle() {
            if (_zoomRectangleEnabled) {
                Bitmap tempBuffer = new Bitmap(_view.GetPanel().Width, _view.GetPanel().Height);
                using (Graphics bufferGraphics = Graphics.FromImage(tempBuffer))
                    bufferGraphics.DrawRectangle(Pens.Red, _mousePosition.X, _mousePosition.Y, 50, 50);

                _buffer = tempBuffer;
            }
            else {
                _buffer = null;
                Resize(this, null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void PaintModel() {
            if (_view.GetPanel().BackgroundImage == null) {
                PaintBackground();
                _view.GetPanel().BackgroundImage = _background;
            }
            // TODO Drawing items in model (draw on _buffer)

            _view.GetPanel().Invalidate();
        }

        private void PaintBackground() {
            using (Graphics bufferGraphics = Graphics.FromImage(_buffer)) {
                int x = 0,
                    y = 0;

                for (int i = 0; i < _model.Rows.GetLength(0); i++) {
                    // first dimension

                    for (int j = 0; j < _model.Rows.GetLength(1); j++) {
                        // second dimension
                        // Painting logic
                        Pen pen = new Pen(Color.Black, 1); // create Pen for drawing lines
                        bufferGraphics.DrawRectangle(pen, x, y, _tileWidth, _tileHeight);
                        x += _tileWidth;
                        // increment x with _tileWidth to put the next tile on the right side of the current.
                    }
                    x = 0; // reset x
                    y += _tileHeight; // increment y with _tileHeight to put the next row below the current
                }
            }
            _background = _buffer;
        }

        public void MouseMove(object sender, MouseEventArgs e) {
            _mousePosition = e.Location;
            _view.GetPanel().Invalidate();
        }

        public void ZoomCheckboxChanged(bool b) {
            _zoomRectangleEnabled = b;
        }
    }
}