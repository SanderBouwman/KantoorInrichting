// created by: Robin
// on: 20-11-2015

#region

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Windows.Forms;
using KantoorInrichting.Models.Grid;
using KantoorInrichting.Views;
using KantoorInrichting.Views.Grid;

#endregion

namespace KantoorInrichting.Controllers.Grid {
    public class GridController : IController {
        private readonly GridFieldModel _model;
        private readonly Panel _panel;
        private readonly float _tileHeight;

        private readonly float _tileWidth;
        private readonly TrackBar _trackBar;

        private readonly IView _view;

        private Bitmap _background;
        private Bitmap _buffer;

        private Point _mousePosition;

        private int _tileX,
            _tileY,
            _zoomRectangleWidth,
            _zoomRectangleHeight;

        private bool _zoomRectangleEnabled;
        private ZoomView _zoomView;

        public GridController( IView view, GridFieldModel model ) {
            _view = view;
            _model = model;

            _zoomRectangleWidth = 50; // initial size of zoom rectangle
            _zoomRectangleHeight = 50;
            _zoomRectangleEnabled = false;

            _view.SetController(this);

            _panel = ( Panel ) _view.Get("Panel");
            _trackBar = ( TrackBar ) _view.Get("Trackbar");

            float tWidth = _panel.Width / _model.Rows.GetLength(1);
            float tHeight = _panel.Height / _model.Rows.GetLength(0);
            // Doing these checks to make sure that we don't have pixels left

            _tileWidth = ( _panel.Width % _model.Rows.GetLength(1) != 0 // if width%length != 0
                ? ( int ) tWidth++ // then set to width++
                : ( int ) tWidth ) // else set to width
                         * _model.Rows[ 0, 0 ].Width; // finally multiply by the tile width
            _tileHeight = ( _panel.Width % _model.Rows.GetLength(0) != 0
                ? ( int ) tHeight++
                : ( int ) tHeight )
                          * _model.Rows[ 0, 0 ].Height;

            _panel.BackgroundImage = this.PaintBackground();
            Resize(this, null);
        }

        public void MouseDown( object sender, MouseEventArgs e ) {
            // getting the index of the tile in the array which has been clicked on
            _tileX = ( int ) ( e.X / _tileWidth * _model.Rows[ 0, 0 ].Width );
            _tileY = ( int ) ( e.Y / _tileHeight * _model.Rows[ 0, 0 ].Height );
        }

        public void Resize( object sender, EventArgs e ) {
            if( _buffer == null || _buffer.Width < _panel.Width ||
                _buffer.Height < _panel.Height ) {
                Bitmap newBuffer = new Bitmap(_panel.Width, _panel.Height);

                if( _buffer != null ) {
                    using( Graphics bufferGraphics = Graphics.FromImage(newBuffer) )
                        bufferGraphics.DrawImageUnscaled(_buffer, Point.Empty);
                }

                _buffer = newBuffer;
            }

        }

        public void Paint( object sender, PaintEventArgs e ) {
            PaintMouseRectangle();
            PaintModel();
            e.Graphics.DrawImage(_buffer, Point.Empty);
        }

        public void MouseMove( object sender, MouseEventArgs e ) {
            _mousePosition = e.Location;
            _panel.Invalidate();
            if( _zoomView != null )
                UpdateZoom();
        }

        public void CheckboxChanged( bool b ) {
            _zoomRectangleEnabled = b;
            if( _zoomRectangleEnabled ) {
                _view.Get("ListView").Enabled = false; // Disable listview when zooming
                _zoomView = new ZoomView();
                UpdateZoom();
                _zoomView.Show();
            } else if( !_zoomRectangleEnabled ) {
                _view.Get("ListView").Enabled = true; // Enable listview when not zooming
                _zoomView?.Dispose();
            }
        }

        public void TrackbarScroll( object sender, EventArgs e ) {
            _zoomRectangleWidth = _trackBar.Value;
            _zoomRectangleHeight = _trackBar.Value;
        }

        private void PaintMouseRectangle() {
            if( _zoomRectangleEnabled ) {
                Bitmap tempBuffer = new Bitmap(_panel.Width, _panel.Height);
                using( Graphics bufferGraphics = Graphics.FromImage(tempBuffer) ) {
                    bufferGraphics.DrawRectangle(
                        Pens.Red,
                        _mousePosition.X - _zoomRectangleWidth / 2,
                        _mousePosition.Y - _zoomRectangleHeight / 2,
                        _zoomRectangleWidth,
                        _zoomRectangleHeight
                        );
                }

                _buffer = tempBuffer;
            } else {
                _buffer = null;
                Resize(this, null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void PaintModel() {
            // TODO Drawing items in model (draw on _buffer)
            
        }

        private Bitmap PaintBackground() {
            Bitmap temp = new Bitmap(_panel.Width, _panel.Height);
            using( Graphics bufferGraphics = Graphics.FromImage(temp) ) {
                float x = 0,
                    y = 0;

                int panelHeight = _view.Get("Panel").Height,
                    panelWidth = _view.Get("Panel").Width;

                Pen pen = new Pen(Color.Black, 1);
                for( float i = 0; i <= _model.Rows.GetLength(0); i += _model.Rows[ 0, 0 ].Height ) { // draw rows
                    bufferGraphics.DrawLine(pen, 0, y, panelWidth, y);
                    y += _tileHeight;
                }
                for( float j = 0; j <= _model.Rows.GetLength(1); j += _model.Rows[ 0, 0 ].Width ) { // draw columns
                    bufferGraphics.DrawLine(pen, x, 0, x, panelHeight);
                    x += _tileWidth;
                }
            }
            return temp;
        }

        private void UpdateZoom() {
            _zoomView.SetArea(GetZoomedArea());
        }

        private Bitmap GetZoomedArea() {
            int x = ( _mousePosition.X < _panel.Width - _zoomRectangleWidth / 2 ) &&
                    _mousePosition.X - _zoomRectangleWidth / 2 > 0 // if x is not an invalid position
                ? _mousePosition.X - _zoomRectangleWidth / 2 // then set x
                : 0;
            int y = ( _mousePosition.Y < _panel.Height - _zoomRectangleHeight / 2 ) &&
                    _mousePosition.Y - _zoomRectangleHeight / 2 > 0 // if y is not an invalid position
                ? _mousePosition.Y - _zoomRectangleHeight / 2 // then set y
                : 0;
            Rectangle cloneRectangle = new Rectangle(x, y, _zoomRectangleWidth, _zoomRectangleHeight);
            PixelFormat format = _buffer.PixelFormat;
            Bitmap temp = new Bitmap(_zoomRectangleWidth, _zoomRectangleHeight);
            using( Graphics g = Graphics.FromImage(temp) ) {
                Bitmap backgroundRegion = ( ( Bitmap ) _panel.BackgroundImage ).Clone(cloneRectangle, format);
                Bitmap bufferRegion = _buffer.Clone(cloneRectangle, format);
                g.DrawImage(backgroundRegion, Point.Empty);
                g.DrawImage(bufferRegion, Point.Empty);
            }
            return temp;
        }
    }
}