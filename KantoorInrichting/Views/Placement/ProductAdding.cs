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


        private void btn_Turn_Click(object sender, EventArgs e)
        {
            PlacementController.Direction direction = PlacementController.Direction.CLOCKWISE;
            if (cbx_TurnValue.Text == "Counter Clockwise") direction = PlacementController.Direction.COUNTERCLOCKWISE; 
            controller.button_Turn(direction);
        }

        private void btn_Move_Click(object sender, EventArgs e)
        {
            PlacementController.Direction direction = PlacementController.Direction.UP;
            if (cbx_MoveValue.Text == "Down") direction = PlacementController.Direction.DOWN;
            else if (cbx_MoveValue.Text == "Left") direction = PlacementController.Direction.LEFT;
            else if (cbx_MoveValue.Text == "Right") direction = PlacementController.Direction.RIGHT;
            controller.button_Move(direction);
        }

        private void Mousedown_Panel(object sender, MouseEventArgs e)
        {
            controller.event_PanelMouseDown(sender, e);
        }
            


        private void DragDrop_DragEnter(object sender, DragEventArgs e)
        {
            controller.event_DragEnter(sender, e);
        }

        private void DragDrop_DragDrop(object sender, DragEventArgs e)
        {
            controller.event_DragDrop(sender, e);
        }
    }
}
