// created by: Robin
// on: 20-11-2015

#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using KantoorInrichting.Controllers;

#endregion

namespace KantoorInrichting.Views.Grid {
    public partial class GridFieldView : UserControl, IView {
        private IController _controller;

        public GridFieldView() {
            InitializeComponent();
            SetEvents();
        }

        public void SetController(IController controller) {
            this._controller = controller;
        }

        public Control Get(string property) {
            Control toReturn = null;
            switch (property) {
                case "Panel":
                    toReturn = this.drawPanel;
                    break;
                case "Trackbar":
                    toReturn = this.trackBar;
                    break;
                case "ListView":
                    toReturn = this.listView;
                    break;
                case "ComboBox":
                    toReturn = this.algoSelector;
                    break;
                case "Checkbox":
                    toReturn = this.zoomCheckbox;
                    break;
            }
            return toReturn;
        }

        // TODO Move this method to controller
        public void SetListView(Dictionary<string, Image> possibilities) {
            this.listView.Items.Clear();
            foreach (KeyValuePair<string, Image> keyValuePair in possibilities) {
                this.imageList.Images.Add(keyValuePair.Key, keyValuePair.Value);
                ListViewItem item = new ListViewItem {
                    ImageKey = keyValuePair.Key,
                    Text = keyValuePair.Key
                };
                // TODO SET TAG AS PRODUCTMODEL
                this.listView.Items.Add(item);
            }
            this.listView.LargeImageList = this.imageList;
        }

        private void SetEvents() {
            // Hook to events of the view in here.
            this.drawPanel.Paint += DrawPanel_Paint;
            this.drawPanel.Resize += DrawPanel_Resize;
            this.drawPanel.MouseDown += DrawPanel_MouseDown;
            this.drawPanel.MouseMove += DrawPanel_MouseMove;
            this.zoomCheckbox.CheckedChanged += ZoomCheckbox_CheckedChanged;
            this.trackBar.Scroll += TrackBar_Scroll;
            this.listView.ItemDrag += ListView_ItemDrag;
            this.listView.GiveFeedback += ListView_GiveFeedback;
            this.drawPanel.DragEnter += DrawPanel_DragEnter;
            this.drawPanel.DragDrop += DrawPanel_DragDrop;
            this.algoButton.Click += AlgoButton_Click;
            this.clearFieldButton.Click += ClearFieldButton_Click;
            Disposed += GridFieldView_Disposed;
        }

        public void GridFieldView_Disposed(object sender, EventArgs e) {
            this._controller?.Dispose(sender, e);
        }

        private void ClearFieldButton_Click(object sender, EventArgs e) {
            this._controller.Notify(sender, e);
        }

        private void AlgoButton_Click(object sender, EventArgs e) {
            this._controller.Notify(sender, e);
        }

        private void DrawPanel_DragDrop(object sender, DragEventArgs e) {
            this._controller.Notify(sender, e);
        }

        private void ListView_GiveFeedback(object sender,
            GiveFeedbackEventArgs e) {
            e.UseDefaultCursors = false;
            if (e.Effect == DragDropEffects.Copy) {
                Bitmap selected =
                    (Bitmap)
                        this.imageList.Images[
                            this.listView.SelectedItems[0].ImageKey];
                if (selected != null)
                    Cursor.Current = new Cursor(selected.GetHicon());
            }
        }

        private void DrawPanel_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }

        private void ListView_ItemDrag(object sender, ItemDragEventArgs e) {
            this._controller.Notify(sender, e);
            this.listView.DoDragDrop(this.listView.SelectedItems[0],
                DragDropEffects.Copy);
        }

        private void TrackBar_Scroll(object sender, EventArgs e) {
            this._controller.Notify(sender, e);
        }

        private void ZoomCheckbox_CheckedChanged(object sender, EventArgs e) {
            this._controller.CheckboxChanged(this.zoomCheckbox.Checked);
        }

        private void DrawPanel_MouseMove(object sender, MouseEventArgs e) {
            this._controller.Notify(sender, e);
        }

        private void DrawPanel_MouseDown(object sender, MouseEventArgs e) {
            this._controller.Notify(sender, e);
        }

        private void DrawPanel_Resize(object sender, EventArgs e) {
            this._controller.Resize(sender, e);
        }

        private void DrawPanel_Paint(object sender, PaintEventArgs e) {
            this._controller.Paint(sender, e);
        }
    }
}