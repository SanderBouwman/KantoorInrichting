using System;
using System.Drawing;
using System.Windows.Forms;
using KantoorInrichting.Models.Grid;
using KantoorInrichting.Views.Grid;

namespace KantoorInrichting.Controllers.Grid {

    public class GridController {

        private GridFieldView _view;
        private GridFieldModel _model;

        private Bitmap _buffer;
        private Bitmap _background;

        private int _tileWidth,
            _tileHeight,
            _tileX,
            _tileY;

        public GridController( GridFieldView view, GridFieldModel model ) {
            _view = view;
            _model = model;

            _view.SetController(this);

            float tWidth = _view.GetPanel().Width / _model.Rows.GetLength(1);
            float tHeight = _view.GetPanel().Height / _model.Rows.GetLength(0);
            // Doing these check to make sure that we don't have pixels left
            _tileWidth = ( _view.GetPanel().Width % _model.Rows.GetLength(1) != 0 ) ? ( int ) tWidth++ : ( int ) tWidth;
            _tileHeight = ( _view.GetPanel().Width % _model.Rows.GetLength(0) != 0 ) ? ( int ) tHeight++ : ( int ) tHeight;

            Resize(this, null);
        }

        public void MouseDown( object sender, MouseEventArgs e ) {
            _tileX = e.X / _tileWidth;
            _tileY = e.Y / _tileHeight;
            Console.WriteLine("X: {0}, Y: {1}", _tileX, _tileY);
        }

        public void Resize( object sender, EventArgs e ) {
            if( _buffer == null || _buffer.Width < _view.GetPanel().Width ||
                _buffer.Height < _view.GetPanel().Height ) {
                Bitmap newBuffer = new Bitmap(_view.GetPanel().Width, _view.GetPanel().Height);

                if( _buffer != null )
                    using( Graphics bufferGraphics = Graphics.FromImage(newBuffer) )
                        bufferGraphics.DrawImageUnscaled(_buffer, Point.Empty);

                _buffer = newBuffer;
            }
        }

        public void Paint( object sender, PaintEventArgs e ) {
            PaintModel();
            e.Graphics.DrawImage(_buffer, Point.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        private void PaintModel() {
            if( _view.GetPanel().BackgroundImage == null ) {
                PaintBackground();
                _view.GetPanel().BackgroundImage = _background;
            }
            // TODO Drawing items in model

            _view.GetPanel().Invalidate();
        }

        private void PaintBackground() {
            using( Graphics bufferGraphics = Graphics.FromImage(_buffer) ) {

                int x = 0,
                    y = 0;

                for( int i = 0; i < _model.Rows.GetLength(0); i++ ) {
                    // first dimension

                    for( int j = 0; j < _model.Rows.GetLength(1); j++ ) {
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
    }
}