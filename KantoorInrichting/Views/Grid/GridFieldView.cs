using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Controllers.Grid;

namespace KantoorInrichting.Views.Grid {
    public partial class GridFieldView : UserControl {

        private GridController _controller;

        public GridFieldView() {
            InitializeComponent();
        }

        public void setController(GridController controller) {
            _controller = controller;
        }
    }
}
