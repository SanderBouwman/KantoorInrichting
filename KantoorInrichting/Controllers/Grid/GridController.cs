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
        private readonly ComboBox _comboBox;
        private readonly GridFieldModel _model;
        private readonly Panel _panel;

        private readonly float _tileHeight,
            _tileWidth;

        private readonly TrackBar _trackBar;
        private readonly IView _view;

        private IDesignAlgorithm _algorithm;
        private Bitmap _buffer;

        private List<ProductModel> _products;
        private Rectangle _rectangle;

        private int _tileX,
            _tileY;

        private bool _zoomCheckbox;
        private ZoomView _zoomView;

        public GridController(IView view, GridFieldModel model) {
            this._view = view;
            this._model = model;
            this._zoomCheckbox = false;

            this._view.SetController(this);
            this._panel = (Panel) this._view.Get("Panel");
            this._trackBar = (TrackBar) this._view.Get("Trackbar");
            this._trackBar.Enabled = false;
            this._comboBox = (ComboBox) this._view.Get("ComboBox");

            float tWidth = this._panel.Width/this._model.Rows.GetLength(1);
            float tHeight = this._panel.Height/this._model.Rows.GetLength(0);
            // Doing these checks to make sure that we don't have pixels left

            this._tileWidth = (this._panel.Width%this._model.Rows.GetLength(1) != 0 // if width%length != 0
                ? (int) tWidth++ // then set to width++
                : (int) tWidth) // else set to width
                              *this._model.Rows[0, 0].Width; // finally multiply by the tile width
            this._tileHeight = (this._panel.Width%this._model.Rows.GetLength(0) != 0
                ? (int) tHeight++
                : (int) tHeight)
                               *this._model.Rows[0, 0].Height;

            // only need to draw the grid once, so we can set it as the panel's background
            this._panel.BackgroundImage = PaintBackground();
            this._rectangle = new Rectangle(0, 0, 50, 50);
            this._buffer = new Bitmap(this._panel.Width, this._panel.Height);

            PopulateCombobox();
            Resize(this, null);
        }


        public void Notify(object sender, EventArgs e) {
            // Made a switch using lambda expressions in a dictionary, since you can not do a switch on types
            var @switch = new Dictionary<Type, Action> {
                {typeof (EventArgs), () => HandleOtherEvent(sender, e)},
                {typeof (MouseEventArgs), () => ButtonClick(sender, e)},
                {typeof (DragEventArgs), () => Handle_DragDropEvent(sender, (DragEventArgs) e)},
                {typeof (ItemDragEventArgs), () => Handle_ItemDragEvent(sender, (ItemDragEventArgs) e)}
            };
            Type typeToCheck = e.GetType();
            @switch[typeToCheck]();
        }

        public void Dispose(object sender, EventArgs e) {
            CheckboxChanged(false);
            ((CheckBox) this._view.Get("Checkbox")).Checked = false;
        }

//        /// <summary>
//        /// Handles the resize event for the given view object.
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
        public void Resize(object sender, EventArgs e) {
            if (this._buffer == null || this._buffer.Width < this._panel.Width ||
                this._buffer.Height < this._panel.Height) {
                Bitmap newBuffer = new Bitmap(this._panel.Width,
                    this._panel.Height);

                if (this._buffer != null) {
                    using (
                        Graphics bufferGraphics = Graphics.FromImage(newBuffer)) {
                        bufferGraphics.DrawImageUnscaled(this._buffer,
                            Point.Empty);
                    }
                }

                this._buffer = newBuffer;
            }
        }

        /// <summary>
        /// Enables the zoom frame and also cleans it up depending on the checkbox value.
        /// </summary>
        /// <param name="b"></param>
        public void CheckboxChanged(bool b) {
            this._zoomCheckbox = b;
            if (this._zoomCheckbox) {
                this._trackBar.Enabled = true;
                this._view.Get("ListView").Enabled = false;
                // Disable listview when zooming
                this._zoomView = new ZoomView();
                UpdateZoom();
                this._zoomView.Show();
            } else if (!this._zoomCheckbox) {
                this._panel.Invalidate();
                this._trackBar.Enabled = false;
                this._view.Get("ListView").Enabled = true;
                // Enable listview when not zooming
                this._zoomView?.Dispose();
            }
        }

        /// <summary>
        /// Handles the paint event for the given view object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Paint(object sender, PaintEventArgs e) {
            PaintModel(this._buffer);
            if (this._zoomCheckbox)
                e.Graphics.DrawRectangle(Pens.Red, this._rectangle);
            e.Graphics.DrawImage(this._buffer, Point.Empty);
        }

        public void HandleOtherEvent(object sender, EventArgs e) {
            if (sender.GetType() == typeof (TrackBar))
                TrackbarScroll(sender, e);
        }

        public void ButtonClick(object sender, EventArgs e) {
            Console.WriteLine(sender + " " + e);
            if (e.GetType() == typeof (MouseEventArgs)) {
                MouseEventArgs ev = (MouseEventArgs) e;
                switch (ev.Button) {
                    case MouseButtons.None:
                        MouseMove(sender, ev);
                        break;
                    case MouseButtons.Left:
                        MouseDown(sender, ev);
                        break;
                }
            }
            if (sender.GetType() == typeof (Button)) {
                switch (((Button) sender).Text) {
                    case "Go":
                        AlgorithmClick(sender, e);
                        break;
                    case "Clear field":
                        ClearField();
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the MouseDown event for the given view object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseDown(object sender, MouseEventArgs e) {
            // getting the index of the tile in the array which has been clicked on
            this._tileX = (int) (e.X/this._tileWidth*this._model.Rows[0, 0].Width);
            this._tileY = (int) (e.Y/this._tileHeight*this._model.Rows[0, 0].Height);
        }

        /// <summary>
        /// Sets the mouseposition and updates the zoom frame's image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseMove(object sender, MouseEventArgs e) {
            if (this._zoomCheckbox) {
                this._rectangle.X = e.X - this._rectangle.Width/2;
                this._rectangle.Y = e.Y - this._rectangle.Height/2;
                if (this._rectangle.Right > this._panel.Width)
                    this._rectangle.X = this._panel.Width - this._rectangle.Width;
                if (this._rectangle.Top < 0)
                    this._rectangle.Y = 0;
                if (this._rectangle.Left < 0)
                    this._rectangle.X = 0;
                if (this._rectangle.Bottom > this._panel.Height)
                    this._rectangle.Y = this._panel.Height - this._rectangle.Height;

                this._panel.Invalidate();
            }
            if (this._zoomView != null && this._zoomCheckbox)
                UpdateZoom();
        }

        /// <summary>
        /// Updates the zoom rectangle width and height based on the trackbar value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TrackbarScroll(object sender, EventArgs e) {
            this._rectangle.Size = new Size(this._trackBar.Value,
                this._trackBar.Value);
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
                    foreach (ProductModel product in this._products) {
                        Rectangle rect = new Rectangle {
                            X = (int) (product.location.X/this._model.Rows[0, 0].Width*this._tileWidth),
                            Y = (int) (product.location.Y/this._model.Rows[0, 0].Height*this._tileHeight),
                            Width = (int) (product.Height/this._model.Rows[0, 0].Height*this._tileWidth),
                            Height = (int) (product.Width/this._model.Rows[0, 0].Width*this._tileHeight)
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
            Bitmap temp = new Bitmap(this._panel.Width, this._panel.Height);
            using (Graphics bufferGraphics = Graphics.FromImage(temp)) {
                float x = 0,
                    y = 0;

                int panelHeight = this._view.Get("Panel").Height,
                    panelWidth = this._view.Get("Panel").Width;

                Pen pen = new Pen(Color.Black, 1);
                for (float i = 0; i <= this._model.Rows.GetLength(0); i += this._model.Rows[0, 0].Height) {
                    // draw rows
                    bufferGraphics.DrawLine(pen, 0, y, panelWidth, y);
                    y += this._tileHeight;
                }
                for (float j = 0; j <= this._model.Rows.GetLength(1); j += this._model.Rows[0, 0].Width) {
                    // draw columns
                    bufferGraphics.DrawLine(pen, x, 0, x, panelHeight);
                    x += this._tileWidth;
                }
            }
            return temp;
        }

        /// <summary>
        /// Sets the zoom frame image
        /// </summary>
        private void UpdateZoom() {
            this._zoomView.SetArea(GetZoomedArea(this._buffer));
        }

        /// <summary>
        /// Creates a compound image of the panel's background and the current buffer.
        /// The region and size is given by the zoom rectangle.
        /// </summary>
        /// <returns>Bitmap</returns>
        private Bitmap GetZoomedArea(Bitmap b) {
            Bitmap temp = new Bitmap(this._rectangle.Width, this._rectangle.Height);
            PixelFormat format = b.PixelFormat;
            using (Graphics g = Graphics.FromImage(temp))
                g.DrawImage(b.Clone(this._rectangle, format), Point.Empty);
            return temp;
        }

        private void PopulateCombobox() {
            var dataSource = new List<Algorithm>();
            dataSource.Add(new Algorithm {
                Name = "Toets lokaal",
                Value = typeof (TestSetupDesign)
            });

            this._comboBox.DataSource = dataSource;
            this._comboBox.DisplayMember = "Name";
            this._comboBox.ValueMember = "Value";

            this._comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void AlgorithmClick(object sender, EventArgs e) {
            Type selectedType = ((Algorithm) this._comboBox.SelectedItem).Value;
            this._algorithm =
                (IDesignAlgorithm) Activator.CreateInstance(selectedType);
            // testing code
            ProductModel chair = new ProductModel {
                Brand = "Ahrend",
                Width = 1,
                Height = 1,
                Type = "Chair"
            };
            ProductModel table = new ProductModel {
                Brand = "TableCompany",
                Width = 2,
                Height = 1,
                Type = "Table"
            };
            this._products = this._algorithm.Design(chair, table, 7,
                this._model.Rows.GetLength(0), this._model.Rows.GetLength(1),
                0.5f);
            this._panel.Invalidate();
        }

        public void ClearField() {
            this._products = null;
            this._buffer = null;
            Resize(this, null);
            this._panel.Invalidate();
        }
    }

    public class Algorithm {
        public string Name { get; set; }
        public Type Value { get; set; }
    }
}