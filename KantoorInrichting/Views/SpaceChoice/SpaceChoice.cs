using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Models.Maps;
using KantoorInrichting.Controllers;
using KantoorInrichting.Controllers.Placement;
using KantoorInrichting.Views.Placement;

namespace KantoorInrichting.Views.SpaceChoice
{
    public partial class SpaceChoice : UserControl
    {
        public MainFrame hoofdscherm;

        public SpaceChoice(MainFrame hoofdscherm)
        {
            this.hoofdscherm = hoofdscherm;      
            InitializeComponent();
            FillComboBox(comboBox1);
            Invalidate();
        }

        private void FillComboBox(ComboBox dropdown)
        {
            // clear dropdown
            dropdown.Items.Clear();
            // Select all the items in de spaces list
            var SpaceResult = Models.Maps.Space.list.GroupBy(space => space.Room)
                   .Select(grp => grp.First())
                   .ToList();
            // add the unique items to space dropdown
            foreach (Space space in SpaceResult)
            {
                if (space.Room != null)
                {
                    dropdown.Items.Add(space.Room);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // select dropdown selected item
            var selected = comboBox1.SelectedItem;

            // check which object to open

            // linq select space with the current ID
            var selectedSpace = Space.list
                    .Where(s => s.Room == (string)selected)
                    .Select(t => t)
                    .ToList();

            // give the design panel the current space ------------old
            //hoofdscherm.placement.OpenPanel(selectedSpace[0]);


            // ------------------------- new 
            hoofdscherm.Size = ProductGrid.PanelSize;
            IController controller = new ProductGridController(hoofdscherm.productGrid, 10, 10, 0.5f);
            hoofdscherm.productGrid.controller.OpenPanel(hoofdscherm.productGrid, selectedSpace[0]);
            hoofdscherm.productGrid.Visible=true;
            hoofdscherm.productGrid.Enabled = true;
            hoofdscherm.productGrid.BringToFront();


            //---------
            this.Visible = false;
           
        }
    }
}
