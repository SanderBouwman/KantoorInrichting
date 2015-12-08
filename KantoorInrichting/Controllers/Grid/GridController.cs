// created by: Robin
// on: 27-11-2015

#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using KantoorInrichting.Controllers.Algorithm;
using KantoorInrichting.Controllers.Algorithm.TestSetup;
using KantoorInrichting.Models.Grid;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Views;
using KantoorInrichting.Views.Grid;

#endregion

namespace KantoorInrichting.Controllers.Grid {
    public class GridController : IController {

        private readonly GridFieldModel _model;
        private readonly Panel _panel;
        private readonly TrackBar _trackBar;
        private ComboBox _comboBox;
        private readonly IView _view;
        private readonly float _tileHeight,
            _tileWidth;
        private ZoomView _zoomView;
        private Bitmap _buffer;
        private Rectangle _rectangle;
        private int _tileX,
            _tileY;
        private bool _zoomCheckbox;

        private IDesignAlgorithm _algorithm;

        private List<ProductModel> _products;

        public GridController(IView view, GridFieldModel model) {
            _view = view;
            _model = model;
            _zoomCheckbox = false;
            _view.SetController(this);
            _panel = (Panel) _view.Get("Panel");
            _trackBar = (TrackBar) _view.Get("Trackbar");
            _trackBar.Enabled = false;
            _comboBox = (ComboBox) _view.Get("ComboBox");

            float tWidth = _panel.Width/_model.Rows.GetLength(1);
            float tHeight = _panel.Height/_model.Rows.GetLength(0);
            // Doing these checks to make sure that we don't have pixels left

            _tileWidth = (_panel.Width%_model.Rows.GetLength(1) != 0 // if width%length != 0
                ? (int) tWidth++ // then set to width++
                : (int) tWidth) // else set to width
                         *_model.Rows[0, 0].Width; // finally multiply by the tile width
            _tileHeight = (_panel.Width%_model.Rows.GetLength(0) != 0
                ? (int) tHeight++
                : (int) tHeight)
                          *_model.Rows[0, 0].Height;

            // only need to draw the grid once, so we can set it as the panel's background
            _panel.BackgroundImage = PaintBackground();
            _rectangle = new Rectangle(0, 0, 50, 50);
            _buffer = new Bitmap(_panel.Width, _panel.Height);

            PopulateCombobox();
            Resize(this, null);
        }


        public void Notify(object sender, EventArgs e) {
            // Made a switch using lambda expressions in a dictionary, since you can not do a switch on types
            var @switch = new Dictionary<Type, Action> {
                {typeof (DragEventArgs), () => Handle_DragDropEvent(sender, (DragEventArgs) e)},
                {typeof (ItemDragEventArgs), () => Handle_ItemDragEvent(sender, (ItemDragEventArgs) e)}
            };
            Type typeToCheck = e.GetType();
            @switch[typeToCheck]();
        }

        public void ButtonClick(object sender, EventArgs e) {
            switch( ( ( Button ) sender ).Text ) {
                case "Go":
                    AlgorithmClick(sender, e);
                    break;
                case "Clear field":
                    ClearField();
                    break;
            }
        }

        /// <summary>
        /// Handles the MouseDown event for the given view object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseDown(object sender, MouseEventArgs e) {
            // getting the index of the tile in the array which has been clicked on
            _tileX = (int) (e.X/_tileWidth*_model.Rows[0, 0].Width);
            _tileY = (int) (e.Y/_tileHeight*_model.Rows[0, 0].Height);
        }

//        /// <summary>
//        /// Handles the resize event for the given view object.
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
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

        /// <summary>
        /// Sets the mouseposition and updates the zoom frame's image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseMove(object sender, MouseEventArgs e) {
            if (_zoomCheckbox) {
                _rectangle.X = e.X - _rectangle.Width/2;
                _rectangle.Y = e.Y - _rectangle.Height/2;
                if (_rectangle.Right > _panel.Width)
                    _rectangle.X = _panel.Width - _rectangle.Width;
                if (_rectangle.Top < 0)
                    _rectangle.Y = 0;
                if (_rectangle.Left < 0)
                    _rectangle.X = 0;
                if (_rectangle.Bottom > _panel.Height)
                    _rectangle.Y = _panel.Height - _rectangle.Height;

                _panel.Invalidate();
            }
            if (_zoomView != null && _zoomCheckbox)
                UpdateZoom();
        }

        /// <summary>
        /// Enables the zoom frame and also cleans it up depending on the checkbox value.
        /// </summary>
        /// <param name="b"></param>
        public void CheckboxChanged(bool b) {
            _zoomCheckbox = b;
            if (_zoomCheckbox) {
                _trackBar.Enabled = true;
                _view.Get("ListView").Enabled = false; // Disable listview when zooming
                _zoomView = new ZoomView();
                UpdateZoom();
                _zoomView.Show();
            }
            else if (!_zoomCheckbox) {
                _panel.Invalidate();
                _trackBar.Enabled = false;
                _view.Get("ListView").Enabled = true; // Enable listview when not zooming
                _zoomView.Dispose();
            }
        }

        /// <summary>
        /// Updates the zoom rectangle width and height based on the trackbar value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TrackbarScroll(object sender, EventArgs e) {
            _rectangle.Size = new Size(_trackBar.Value, _trackBar.Value);
        }

        /// <summary>
        /// Handles the paint event for the given view object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Paint(object sender, PaintEventArgs e) {
            PaintModel(_buffer);
            if (_zoomCheckbox) e.Graphics.DrawRectangle(Pens.Red, _rectangle);
            e.Graphics.DrawImage(_buffer, Point.Empty);
        }

        public void Handle_DragDropEvent(object sender, DragEventArgs e) {
            Console.WriteLine("DROPPED SOMETHING!");
        }

        public void Handle_ItemDragEvent(object sender, ItemDragEventArgs e) {
            Console.WriteLine("ITEM DRAG");
        }

        /// <summary>
        /// Paints the model on the screen.
        /// </summary>
        private void PaintModel(Bitmap b) {
//            _model.Draw(b);

            if (this._products != null) {
                using (Graphics g = Graphics.FromImage(b)) {
                    foreach (ProductModel product in _products) {

                        Rectangle rect = new Rectangle() {
                            X = ( int ) ( ( product.location.X / _model.Rows[ 0, 0 ].Width ) * _tileWidth ),
                            Y = ( int ) ( ( product.location.Y / _model.Rows[ 0, 0 ].Height ) * _tileHeight ),
                            Width = ( int ) ( ( product.Height / _model.Rows[ 0, 0 ].Height ) * _tileWidth ),
                            Height = ( int ) ( ( product.Width / _model.Rows[ 0, 0 ].Width ) * _tileHeight )
                        };
                        Pen pen = new Pen(Color.DarkBlue, 3f);
                        g.DrawRectangle(pen, rect);
                    }
                }
            }
        }

        

        /// <summary>
        /// Creates the background image using the dimensions given to the model.
        /// </summary>
        /// <returns>Bitmap</returns>
        private Bitmap PaintBackground() {
            Bitmap temp = new Bitmap(_panel.Width, _panel.Height);
            using (Graphics bufferGraphics = Graphics.FromImage(temp)) {
                float x = 0,
                    y = 0;

                int panelHeight = _view.Get("Panel").Height,
                    panelWidth = _view.Get("Panel").Width;

                Pen pen = new Pen(Color.Black, 1);
                for (float i = 0; i <= _model.Rows.GetLength(0); i += _model.Rows[0, 0].Height) {
                    // draw rows
                    bufferGraphics.DrawLine(pen, 0, y, panelWidth, y);
                    y += _tileHeight;
                }
                for (float j = 0; j <= _model.Rows.GetLength(1); j += _model.Rows[0, 0].Width) {
                    // draw columns
                    bufferGraphics.DrawLine(pen, x, 0, x, panelHeight);
                    x += _tileWidth;
                }
            }
            return temp;
        }

        /// <summary>
        /// Sets the zoom frame image
        /// </summary>
        private void UpdateZoom() {
            _zoomView.SetArea(GetZoomedArea(_buffer));
        }

        /// <summary>
        /// Creates a compound image of the panel's background and the current buffer.
        /// The region and size is given by the zoom rectangle.
        /// </summary>
        /// <returns>Bitmap</returns>
        private Bitmap GetZoomedArea(Bitmap b) {
            Bitmap temp = new Bitmap(_rectangle.Width, _rectangle.Height);
            PixelFormat format = b.PixelFormat;
            using (Graphics g = Graphics.FromImage(temp)) g.DrawImage(b.Clone(_rectangle, format), Point.Empty);
            return temp;
        }

        private void PopulateCombobox() {
            var dataSource = new List<Algorithm>();
            dataSource.Add(new Algorithm() {Name = "Toets lokaal", Value = typeof(TestSetupDesign)});

            _comboBox.DataSource = dataSource;
            _comboBox.DisplayMember = "Name";
            _comboBox.ValueMember = "Value";

            _comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void AlgorithmClick( object sender, EventArgs e ) {
            Type selectedType = ((Algorithm) _comboBox.SelectedItem).Value;
            _algorithm = (IDesignAlgorithm) Activator.CreateInstance(selectedType);
            // testing code
            ProductModel chair = new ProductModel {
                Brand = "Ahrend",
                Width = 1,
                Height = 1
            };
            ProductModel table = new ProductModel {
                Brand = "TableCompany",
                Width = 2,
                Height = 1
            };
            _products = _algorithm.Design(chair, table, 7, _model.Rows.GetLength(0), _model.Rows.GetLength(1), 0.5f);
            _panel.Invalidate();
        }

        public void ClearField() {
            this._products = null;
            _buffer = null;
            Resize(this, null);
            _panel.Invalidate();
        }
    }

    public class Algorithm {
        public string Name { get; set; }
        public Type Value { get; set; }
    }
}