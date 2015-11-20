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
using KantoorInrichting.Models.Grid;

namespace KantoorInrichting.Views {
    public partial class MainScreen : UserControl {
        public MainFrame hoofdscherm;
        public MainScreen( MainFrame hoofdscherm ) {
            this.hoofdscherm = hoofdscherm;
            InitializeComponent();
        }

        private void VooraadButton_Click( object sender, EventArgs e ) {
            hoofdscherm.inventoryScreen1.Visible = true;
            hoofdscherm.inventoryScreen1.Enabled = true;
            this.Visible = false;
            hoofdscherm.inventoryScreen1.BringToFront();
        }

        private void MapButton_Click( object sender, EventArgs e ) {
//            GridController gc = new GridController(hoofdscherm.gridFieldView, new GridFieldModel(10, 10, 0.5f));
//
            hoofdscherm.Width = hoofdscherm.gridFieldView.Width;
            hoofdscherm.Height = hoofdscherm.gridFieldView.Height;

            hoofdscherm.gridFieldView.Visible = true;
            hoofdscherm.gridFieldView.Enabled = true;
            this.Visible = false;
            hoofdscherm.gridFieldView.BringToFront();
        }
    }
}
