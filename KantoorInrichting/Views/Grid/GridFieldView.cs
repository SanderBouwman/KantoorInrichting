// created by: Robin
// on: 20-11-2015

#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using KantoorInrichting.Controllers;
using KantoorInrichting.Controllers.Grid;
using KantoorInrichting.Controllers.Product;

#endregion

namespace KantoorInrichting.Views.Grid {
    public partial class GridFieldView : UserControl, IView {
        private IController _controller;


        public GridFieldView() {
            InitializeComponent();
            SetEvents();
        }

        public void SetController( IController controller ) {
            _controller = controller;
        }

        public Control Get( string property ) {
            Control toReturn = null;
            switch( property ) {
                case "Panel":
                    toReturn = this.drawPanel;
                    break;
                case "Trackbar":
                    toReturn = this.trackBar;
                    break;
                case "ListView":
                    return this.listView;
                    break;
            }
            return toReturn;
        }

        public void SetListView( Dictionary<string, Image> possibilities ) {

            listView.Items.Clear();
            foreach( KeyValuePair<string, Image> keyValuePair in possibilities ) {
                imageList.Images.Add(keyValuePair.Key, keyValuePair.Value);
                ListViewItem item = new ListViewItem() { ImageKey = keyValuePair.Key, Text = keyValuePair.Key };
                listView.Items.Add(item);
            }
            listView.LargeImageList = imageList;
            listView.View = View.LargeIcon;
        }

        private void SetEvents() {
            // Hook to events of the view in here.
            drawPanel.Paint += DrawPanel_Paint;
            drawPanel.Resize += DrawPanel_Resize;
            drawPanel.MouseDown += DrawPanel_MouseDown;
            drawPanel.MouseMove += DrawPanel_MouseMove;
            zoomCheckbox.CheckedChanged += ZoomCheckbox_CheckedChanged;
            trackBar.Scroll += TrackBar_Scroll;
        }

        private void TrackBar_Scroll( object sender, EventArgs e ) {
            _controller.TrackbarScroll(sender, e);
        }

        private void ZoomCheckbox_CheckedChanged( object sender, EventArgs e ) {
            _controller.CheckboxChanged(zoomCheckbox.Checked);
        }

        private void DrawPanel_MouseMove( object sender, MouseEventArgs e ) {
            _controller.MouseMove(sender, e);
        }

        private void DrawPanel_MouseDown( object sender, MouseEventArgs e ) {
            _controller.MouseDown(sender, e);
        }

        private void DrawPanel_Resize( object sender, EventArgs e ) {
            _controller.Resize(sender, e);
        }

        private void DrawPanel_Paint( object sender, PaintEventArgs e ) {
            _controller.Paint(sender, e);
        }
    }
}