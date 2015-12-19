using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Controllers;

namespace KantoorInrichting.Views.Placement {
    public partial class ProductGrid : UserControl, IView
    {
        private IController controller;

        public static Size PanelSize = new Size(1280, 720);

        public ProductGrid() {
            InitializeComponent();
        }

        public void SetController(IController c)
        {
            controller = c;
        }

        public Control Get(string property)
        {
            throw new NotImplementedException();
        }
    }
}
