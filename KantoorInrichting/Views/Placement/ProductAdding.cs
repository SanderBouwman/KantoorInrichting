using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting;
using KantoorInrichting.Models.Placement;
using KantoorInrichting.Models.Product;
using System.Collections.ObjectModel;
using System.Drawing.Drawing2D;
using KantoorInrichting.Controllers.Placement;

namespace KantoorInrichting.Views.Placement
{
    public partial class ProductAdding : UserControl
    {
        public MainFrame hoofdscherm;
        private PlacementController controller;
        
        public ProductAdding(MainFrame hoofdscherm)
        {
            this.hoofdscherm = hoofdscherm;

            InitializeComponent();

            //Needs to be after initializeComponents to prevent NULL errors
            controller = new PlacementController(hoofdscherm, this);
        }
        

        protected override void OnPaint(PaintEventArgs e)
        {
            //Automatically redraws the pannel when it's the form needs to paint            
            controller.redrawPanel();
        }
        

        private void Mousedown_Panel(object sender, MouseEventArgs e)
        { controller.event_PanelMouseDown(sender, e); }



        private void DragDrop_DragEnter(object sender, DragEventArgs e)
        { controller.event_DragEnter(sender, e); }

        private void DragDrop_DragDrop(object sender, DragEventArgs e)
        { controller.event_DragDrop(sender, e); }



        //says which buttons are being pressed and sends that info the controller
        private void btn_CCW_Click(object sender, EventArgs e)
        { controller.button_Turn(PlacementController.Direction.COUNTERCLOCKWISE); }

        private void btn_CW_Click(object sender, EventArgs e)
        { controller.button_Turn(PlacementController.Direction.CLOCKWISE); }


        private void btn_Up_Click(object sender, EventArgs e)
        { controller.button_Move(PlacementController.Direction.UP); }

        private void btn_Left_Click(object sender, EventArgs e)
        { controller.button_Move(PlacementController.Direction.LEFT); }

        private void btn_Down_Click(object sender, EventArgs e)
        { controller.button_Move(PlacementController.Direction.DOWN); }

        private void btn_Right_Click(object sender, EventArgs e)
        { controller.button_Move(PlacementController.Direction.RIGHT); }
    }
}
