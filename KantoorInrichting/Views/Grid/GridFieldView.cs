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
        private MainFrame mainframe;


        public GridFieldView(MainFrame mainframe) {
            this.mainframe = mainframe;
            InitializeComponent();
            SetEvents();
        }

        public void SetController(GridController controller) {
            _controller = controller;
        }

        private void SetEvents() {
            // Hook to events of the view in here.
            this.drawPanel.Paint += DrawPanel_Paint;
            this.drawPanel.Resize += DrawPanel_Resize;
            this.drawPanel.MouseDown += DrawPanel_MouseDown;
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

        public Panel GetPanel() {
            return this.drawPanel;
        }
    }
}
