// created by: Robin
// on: 19-12-2015

#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KantoorInrichting.Controllers;
using KantoorInrichting.Controllers.Placement;

#endregion

namespace KantoorInrichting.Views.Placement
{
    public partial class ProductGrid : UserControl, IView<ProductGrid.PropertyEnum>
    {
        public enum PropertyEnum
        {
            Panel,
            Trackbar,
            AlgorithmComboBox,
            Legend
        }

        public static Size PanelSize = new Size(1280, 720);
        public IController controller;

        public ProductGrid()
        {
            InitializeComponent();
            controller = new ProductGridController(this, 10, 10, 0.5f);
        }

        public PropertyEnum Properties { get; set; }

        public void SetController(IController c)
        {
            controller = c;
            SetEvents();
        }

        public Control Get(PropertyEnum property)
        {
            Control result;
            switch (property)
            {
                case PropertyEnum.Panel:
                    result = gridFieldPanel;
                    break;
                case PropertyEnum.Trackbar:
                    result = zoomTrackbar;
                    break;
                case PropertyEnum.AlgorithmComboBox:
                    result = algorithmComboBox;
                    break;
                case PropertyEnum.Legend:
                    result = legend;
                    break;
                default:
                    result = null;
                    break;
            }
            return result;
        }

        public void SetEvents()
        {
            Layout += ProductGrid_Layout;
            Resize += ProductGrid_Resize;
            gridFieldPanel.Paint += GridFieldPanel_Paint1;
            gridFieldPanel.MouseMove += GridFieldPanel_MouseMove;
            zoomCheckbox.CheckedChanged += ZoomCheckbox_CheckedChanged;
            zoomTrackbar.ValueChanged += ZoomTrackbar_ValueChanged;
            algorithmButton.Click += AlgorithmButton_Click;

            // Rotation buttons
            buttonCW.Click += ButtonCW_Click;
            buttonCCW.Click += ButtonCCW_Click;

            // Delete and save buttons
            buttonSave.Click += ButtonSave_Click;
            buttonDelete.Click += ButtonDelete_Click;
            buttonLock.Click += ButtonLock_Click;

            // DragDrop events
            gridFieldPanel.DragDrop += GridFieldPanel_DragDrop;
            gridFieldPanel.DragEnter += GridFieldPanel_DragEnter;
            gridFieldPanel.MouseDown += GridFieldPanel_MouseDown;
            gridFieldPanel.MouseUp += GridFieldPanel_MouseUp;
            gridFieldPanel.MouseMove += GridFieldPanel_MouseMove1;
        }

        private void ProductGrid_Resize(object sender, EventArgs e)
        {
            ProductGrid_Layout(sender, new LayoutEventArgs((IComponent)sender, e.ToString()));
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            controller.Notify(sender, e, "ButtonDelete");
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            controller.Notify(sender, e, "ButtonSave");
        }

        private void ButtonLock_Click(object sender, EventArgs e)
        {
            controller.Notify(sender, e, "ButtonLock");
        }

        private void ButtonCCW_Click(object sender, EventArgs e)
        {
            controller.Notify(sender, e, "ButtonCCW");
        }

        private void ButtonCW_Click(object sender, EventArgs e)
        {
            controller.Notify(sender, e, "ButtonCW");
        }

        private void GridFieldPanel_MouseUp(object sender, MouseEventArgs e)
        {
            controller.Notify(sender, e, "PanelMouseUp");
        }

        private void GridFieldPanel_MouseMove1(object sender, MouseEventArgs e)
        {
            controller.Notify(sender, e, "PanelMouseMove");
        }

        private void GridFieldPanel_MouseDown(object sender, MouseEventArgs e)
        {
            controller.Notify(sender, e, "PanelMouseDown");
        }

        private void GridFieldPanel_DragEnter(object sender, DragEventArgs e)
        {
            controller.Notify(sender, e, "PanelDragEnter");
        }

        private void GridFieldPanel_DragDrop(object sender, DragEventArgs e)
        {
            // Have to translate the mouseposition to the position on the panel
            // since the default is based on the resolution of your screen
            Point pointInPanel = gridFieldPanel.PointToClient(new Point(e.X, e.Y));
            DragEventArgs newEvent = new DragEventArgs(e.Data, e.KeyState,
                pointInPanel.X, pointInPanel.Y, e.AllowedEffect, e.Effect);
            controller.Notify(sender, newEvent, "PanelDragDrop");
        }

        private void AlgorithmButton_Click(object sender, EventArgs e)
        {
            controller.Notify(sender, e, "AlgorithmClick");
        }

        private void ZoomTrackbar_ValueChanged(object sender, EventArgs e)
        {
            controller.Notify(sender, e, "TrackbarValueChanged");
        }

        private void GridFieldPanel_Paint1(object sender, PaintEventArgs e)
        {
            controller.Paint(sender, e);
        }

        private void GridFieldPanel_MouseMove(object sender, MouseEventArgs e)
        {
            controller.Notify(sender, e, "PanelMouseMove");
        }

        private void ZoomCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            controller.Notify(sender, e, "CheckboxCheckedChanged");
        }

        private void ProductGrid_Layout(object sender, LayoutEventArgs e)
        {
            controller.Notify(sender, e, "GridLayout");
        }

        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            controller.Notify(sender, e, "ButtonCalculate");
        }
    }
}