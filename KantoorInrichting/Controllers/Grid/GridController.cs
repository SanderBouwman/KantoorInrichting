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

        private int _tileWidth,
            _tileHeight;

        public GridController( GridFieldView view, GridFieldModel model ) {
            _view = view;
            _model = model;

            _view.SetController(this);

            _tileWidth = _view.GetPanel().Width / _model.Rows.GetLength(0);
            _tileHeight = _view.GetPanel().Height / _model.Rows.GetLength(1);
            Console.WriteLine("Started controller");
        }

        public void MouseDown( object sender, MouseEventArgs e ) {
            throw new System.NotImplementedException();
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

        private void PaintModel() {
            using (Graphics bufferGraphics = Graphics.FromImage(_buffer)) {

                int x = 0,
                    y = 0;

                for (int i = 0; i < _model.Rows.GetLength(0); i++) { // first dimension

                    for (int j = 0; j < _model.Rows.GetLength(1); j++) { // second dimension
                        // Painting logic
                        Pen pen = new Pen(Color.Black, 1); // create Pen for drawing lines
                        bufferGraphics.DrawRectangle(pen, x, y, _tileWidth, _tileHeight);
                        x += _tileWidth; // increment x with _tileWidth to put the next tile on the right side of the current.

                    }
                    x = 0; // reset x
                    y += _tileHeight; // increment y with _tileHeight to put the next row below the current
                }
            }
            _view.GetPanel().Invalidate();
        }
    }
}