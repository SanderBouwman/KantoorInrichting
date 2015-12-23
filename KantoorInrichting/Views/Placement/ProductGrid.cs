// created by: Robin
// on: 19-12-2015

#region

using System;
using System.Drawing;
using System.Windows.Forms;
using KantoorInrichting.Controllers;

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
        private IController controller;

        public ProductGrid()
        {
            InitializeComponent();
            VisibleChanged += ProductGrid_VisibleChanged;
        }

        public PropertyEnum Properties { get; set; }

        public void SetController(IController c)
        {
            controller = c;
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
                    result = this.legend;
                    break;
                default:
                    result = null;
                    break;
            }
            return result;
        }

        private void ProductGrid_VisibleChanged(object sender, EventArgs e)
        {
            SetEvents();
        }

        public void SetEvents()
        {
            Layout += ProductGrid_Layout;
            gridFieldPanel.Paint += GridFieldPanel_Paint1;
            gridFieldPanel.MouseMove += GridFieldPanel_MouseMove;
            zoomCheckbox.CheckedChanged += ZoomCheckbox_CheckedChanged;
            zoomTrackbar.ValueChanged += ZoomTrackbar_ValueChanged;
            algorithmButton.Click += AlgorithmButton_Click;
        }

        private void AlgorithmButton_Click( object sender, EventArgs e ) {
            controller.Notify(sender, e);
        }

        private void ZoomTrackbar_ValueChanged(object sender, EventArgs e)
        {
            controller.Notify(sender, e);
        }

        private void GridFieldPanel_Paint1(object sender, PaintEventArgs e)
        {
            controller.Paint(sender, e);
        }

        private void GridFieldPanel_MouseMove(object sender, MouseEventArgs e)
        {
            controller.Notify(sender, e);
        }

        private void ZoomCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            controller.Notify(sender, e);
        }

        private void ProductGrid_Layout(object sender, LayoutEventArgs e)
        {
            controller.Notify(sender, e);
        }
    }
}
