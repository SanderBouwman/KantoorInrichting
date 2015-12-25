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
using KantoorInrichting.Models.Maps;
using KantoorInrichting.Controllers;

namespace KantoorInrichting.Views.Placement
{
    public partial class ProductAdding : UserControl
    {
        public MainFrame hoofdscherm;
        private PlacementController controller;
        public Space space;       


        public ProductAdding(MainFrame hoofdscherm)
        {
            this.hoofdscherm = hoofdscherm;

            InitializeComponent();
            
            Invalidate();

            //Needs to be after initializeComponents to prevent NULL errors
            controller = new PlacementController(hoofdscherm, this);

            //Invalidate();
        }

        public void OpenPanel(Space spacenr)
        {
            PlacementController.placedProductList.Clear();
            hoofdscherm.placement.space = spacenr;
            //this.SpaceNumberTitle.Text = space.Room;
            this.SpaceNumberTextbox.Text = space.Room;
            this.SpaceDimensionsTextbox.Text = space.length + " + " + space.width;

            hoofdscherm.Size = new Size(1150, 750);
            hoofdscherm.MinimumSize = new Size(1100, 720);
            hoofdscherm.placement.Visible = true;
            hoofdscherm.placement.Enabled = true;

            //Update the data (size and colour of the PlacedProduct, information of the ProductList and ProductInfo)
            hoofdscherm.placement.fixData();
            hoofdscherm.placement.controller.placeProducts();
            hoofdscherm.placement.BringToFront();
        }

        public void fixData()
        {
            controller.FixUserData();
        }
        
        
        //When mouse is down on the panel
        private void Mousedown_Panel(object sender, MouseEventArgs e)
        { controller.event_PanelMouseDown(sender, e); }


        //DragEnter Event - ADD
        private void DragDrop_DragEnter(object sender, DragEventArgs e)
        {
            Console.WriteLine("DRAGENTER");
            controller.event_DragEnter(sender, e);
        }
        //DragDrop Event - ADD
        private void DragDrop_DragDrop(object sender, DragEventArgs e)
        { controller.event_DragDrop(sender, e); }

        //DragOver Event - GHOST
        private void Ghost_DragOver(object sender, DragEventArgs e)
        { controller.event_DragOver(sender, e); }
        //DragLeave Event - GHOST
        private void Ghost_DragLeave(object sender, EventArgs e)
        { controller.event_DragLeave(sender, e); }

        //DragEnter Event - DELETE
        private void Delete_DragEnter(object sender, DragEventArgs e)
        { controller.event_DeleteEnter(sender, e); }
        //DragDrop Event - DELETE
        private void Delete_DragDrop(object sender, DragEventArgs e)
        { controller.event_DeleteDrop(sender, e); }

        //Turn Couter Clockwise
        private void btn_CCW_Click(object sender, EventArgs e)
        { controller.button_Turn(PlacementController.Direction.COUNTERCLOCKWISE); }
        //Turn Clockwise
        private void btn_CW_Click(object sender, EventArgs e)
        { controller.button_Turn(PlacementController.Direction.CLOCKWISE); }

        //Move Up
        private void btn_Up_Click(object sender, EventArgs e)
        { controller.button_Move(PlacementController.Direction.UP); }
        //Move Left
        private void btn_Left_Click(object sender, EventArgs e)
        { controller.button_Move(PlacementController.Direction.LEFT); }
        //Move Down
        private void btn_Down_Click(object sender, EventArgs e)
        { controller.button_Move(PlacementController.Direction.DOWN); }
        //Move Right
        private void btn_Right_Click(object sender, EventArgs e)
        { controller.button_Move(PlacementController.Direction.RIGHT); }

        //When a key is pressed
        private void ProductAdding_KeyDown(object sender, KeyEventArgs e)
        { controller.event_PanelKeyDown(sender, e); MessageBox.Show("This is the keypress test. You found it, good job!\nI would like to give you a cookie, but I'm just a message box. :c"); }

        //Deletes the current selected product
        private void btn_Delete_Click(object sender, EventArgs e)
        { controller.button_Delete(); }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.button_Save(space.Room);
        }
    }
}
