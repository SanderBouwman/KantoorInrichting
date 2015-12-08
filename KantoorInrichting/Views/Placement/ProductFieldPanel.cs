using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Models.Placement;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Controllers.Placement;

namespace KantoorInrichting.Views.Placement
{
    public partial class ProductFieldPanel : Panel
    {
        PlacementController placementController;

        public ProductFieldPanel()
        {
            DoubleBuffered = true;
            Invalidate();
        }

        public void knowYourController(PlacementController pc)
        {
            placementController = pc;
        }

        public void Repaint()
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                placementController.redrawPanel(e.Graphics);
            }
            catch { }
        }
    }
}
