// created by: Robin
// on: 20-11-2015

#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using KantoorInrichting.Controllers;

#endregion

namespace KantoorInrichting.Views.Grid
{
    public partial class GridFieldView : UserControl//, IView
    {
        private IController _controller;

        public GridFieldView()
        {
            InitializeComponent();
            SetEvents();
        }

        public void SetController(IController controller)
        {
            _controller = controller;
        }

        public Control Get(string property)
        {
            Control toReturn = null;
            switch (property)
            {
                case "Panel":
                    toReturn = drawPanel;
                    break;
                case "Trackbar":
                    toReturn = trackBar;
                    break;
                case "ListView":
                    toReturn = listView;
                    break;
                case "ComboBox":
                    toReturn = algoSelector;
                    break;
                case "Checkbox":
                    toReturn = zoomCheckbox;
                    break;
            }
            return toReturn;
        }

        // TODO Move this method to controller
        public void SetListView(Dictionary<string, Image> possibilities)
        {
            listView.Items.Clear();
            foreach (KeyValuePair<string, Image> keyValuePair in possibilities)
            {
                imageList.Images.Add(keyValuePair.Key, keyValuePair.Value);
                ListViewItem item = new ListViewItem
                {
                    ImageKey = keyValuePair.Key,
                    Text = keyValuePair.Key
                };
                // TODO SET TAG AS PRODUCTMODEL
                listView.Items.Add(item);
            }
            listView.LargeImageList = imageList;
        }

        private void SetEvents()
        {
            // Hook to events of the view in here.
            drawPanel.Paint += DrawPanel_Paint;
            drawPanel.Resize += DrawPanel_Resize;
            drawPanel.MouseDown += DrawPanel_MouseDown;
            drawPanel.MouseMove += DrawPanel_MouseMove;
            zoomCheckbox.CheckedChanged += ZoomCheckbox_CheckedChanged;
            trackBar.Scroll += TrackBar_Scroll;
            listView.ItemDrag += ListView_ItemDrag;
            listView.GiveFeedback += ListView_GiveFeedback;
            drawPanel.DragEnter += DrawPanel_DragEnter;
            drawPanel.DragDrop += DrawPanel_DragDrop;
            algoButton.Click += AlgoButton_Click;
            clearFieldButton.Click += ClearFieldButton_Click;
            Disposed += GridFieldView_Disposed;
        }

        public void GridFieldView_Disposed(object sender, EventArgs e)
        {
            _controller?.Dispose(sender, e);
        }

        private void ClearFieldButton_Click(object sender, EventArgs e)
        {
            _controller.Notify(sender, e);
        }

        private void AlgoButton_Click(object sender, EventArgs e)
        {
            _controller.Notify(sender, e);
        }

        private void DrawPanel_DragDrop(object sender, DragEventArgs e)
        {
            _controller.Notify(sender, e);
        }

        private void ListView_GiveFeedback(object sender,
            GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            if (e.Effect == DragDropEffects.Copy)
            {
                Bitmap selected = (Bitmap) imageList.Images[listView.SelectedItems[0].ImageKey];
                if (selected != null)
                    Cursor.Current = new Cursor(selected.GetHicon());
            }
        }

        private void DrawPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void ListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            _controller.Notify(sender, e);
            listView.DoDragDrop(listView.SelectedItems[0],
                DragDropEffects.Copy);
        }

        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            _controller.Notify(sender, e);
        }

        private void ZoomCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            _controller.CheckboxChanged(zoomCheckbox.Checked);
        }

        private void DrawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            _controller.Notify(sender, e);
        }

        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _controller.Notify(sender, e);
        }

        private void DrawPanel_Resize(object sender, EventArgs e)
        {
            //_controller.Resize(sender, e);
        }

        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            _controller.Paint(sender, e);
        }
    }
}