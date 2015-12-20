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
            panel
        }
        public static Size PanelSize = new Size(1280, 720);
        private IController controller;
        public PropertyEnum Properties { get; set; }

        public ProductGrid()
        {
            InitializeComponent();
            SetEvents();
        }


        public void SetController(IController c)
        {
            controller = c;
        }

        public Control Get(PropertyEnum property)
        {
            Control result;
            switch( property ) {
                case PropertyEnum.panel:
                    result = this.gridFieldPanel;
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
        }

        private void ProductGrid_Layout(object sender, LayoutEventArgs e)
        {
            controller.Notify(sender, e);
        }
    }
    
}