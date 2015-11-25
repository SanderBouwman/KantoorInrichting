// created by: Robin
// on: 20-11-2015

#region

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using KantoorInrichting.Models.Grid;
using KantoorInrichting.Views;
using KantoorInrichting.Views.Grid;

#endregion

namespace KantoorInrichting.Controllers.Grid {
    public class GridController : IController {
        private readonly GridFieldModel _model;
        private readonly float _tileHeight;

        private readonly float _tileWidth;

        private readonly IView _view;
        private readonly Panel _panel;
        private readonly TrackBar _trackBar;

        private Bitmap _background;
        private Bitmap _buffer;

        private Point _mousePosition;

        private int _tileX,
            _tileY,
            _zoomRectangleWidth,
            _zoomRectangleHeight;

        private bool _zoomRectangleEnabled;
        private ZoomView _zoomView;

        public GridController(IView view, GridFieldModel model) {
            _view = view;
            _model = model;

            _zoomRectangleWidth = 50; // has to be set by the slider control
            _zoomRectangleHeight = 50;

            _view.SetController(this);

            _panel = (Panel) _view.Get("Panel");
            _trackBar = (TrackBar) _view.Get("Trackbar");

            float tWidth = _panel.Width/_model.Rows.GetLength(1);
            float tHeight = _panel.Height/_model.Rows.GetLength(0);
            // Doing these check to make sure that we don't have pixels left
            _tileWidth = (_panel.Width%_model.Rows.GetLength(1) != 0 ? (int) tWidth++ : (int) tWidth)*
                         _model.Rows[0, 0].Width;
            _tileHeight = (_panel.Width%_model.Rows.GetLength(0) != 0 ? (int) tHeight++ : (int) tHeight)*
                          _model.Rows[0, 0].Height;


            Resize(this, null);
        }

        public void MouseDown(object sender, MouseEventArgs e) {
            // getting the index of the tile in the array which has been clicked on
            _tileX = (int) (e.X/_tileWidth*_model.Rows[0, 0].Width);
            _tileY = (int) (e.Y/_tileHeight*_model.Rows[0, 0].Height);
            Console.WriteLine("X: {0}, Y: {1}", _tileX, _tileY);
        }

        public void Resize(object sender, EventArgs e) {
            if (_buffer == null || _buffer.Width < _panel.Width ||
                _buffer.Height < _panel.Height) {
                Bitmap newBuffer = new Bitmap(_panel.Width, _panel.Height);

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
                Bitmap tempBuffer = new Bitmap(_panel.Width, _panel.Height);
                using (Graphics bufferGraphics = Graphics.FromImage(tempBuffer)) {
                    bufferGraphics.DrawRectangle(
                        Pens.Red,
                        _mousePosition.X - _zoomRectangleWidth/2,
                        _mousePosition.Y - _zoomRectangleHeight/2,
                        _zoomRectangleWidth,
                        _zoomRectangleHeight
                        );
                }

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
            if (_panel.BackgroundImage == null) PaintBackground();
            // TODO Drawing items in model (draw on _buffer)

            _panel.Invalidate();
        }

        private void PaintBackground() {
            using (Graphics bufferGraphics = Graphics.FromImage(_buffer)) {
                float x = 0,
                    y = 0;

                for (float i = 0; i < _model.Rows.GetLength(0); i += _model.Rows[0, 0].Height) {
                    // first dimension (rows)
                    for (float j = 0; j < _model.Rows.GetLength(1); j += _model.Rows[0, 0].Height) {
                        // second dimension (columns)
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
        }

        public void MouseMove(object sender, MouseEventArgs e) {
            _mousePosition = e.Location;
            _panel.Invalidate();
            if (_zoomView != null) UpdateZoom();
        }

        public void CheckboxChanged(bool b) {
            _zoomRectangleEnabled = b;
            if (_zoomRectangleEnabled) {
                _zoomView = new ZoomView();
                UpdateZoom();
                _zoomView.Show();
            }
            else if (!_zoomRectangleEnabled) _zoomView?.Dispose();
        }

        private void UpdateZoom() {
            _zoomView.SetArea(GetZoomedArea());
        }

        private Bitmap GetZoomedArea() {
            int x = (_mousePosition.X < _panel.Width - _zoomRectangleWidth/2) &&
                    _mousePosition.X - _zoomRectangleWidth/2 > 0 // if x is not an invalid position
                ? _mousePosition.X - _zoomRectangleWidth/2 // then set x
                : 0;
            int y = (_mousePosition.Y < _panel.Height - _zoomRectangleHeight/2) &&
                    _mousePosition.Y - _zoomRectangleHeight/2 > 0 // if y is not an invalid position
                ? _mousePosition.Y - _zoomRectangleHeight/2 // then set y
                : 0;
            Rectangle cloneRectangle = new Rectangle(x, y, _zoomRectangleWidth, _zoomRectangleHeight);
            PixelFormat format = _buffer.PixelFormat;
            return _buffer.Clone(cloneRectangle, format);
        }

        public void TrackbarScroll(object sender, EventArgs e) {
            _zoomRectangleWidth = _trackBar.Value;
            _zoomRectangleHeight = _trackBar.Value;
        }
    }
}