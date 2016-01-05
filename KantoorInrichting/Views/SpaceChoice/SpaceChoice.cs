using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Models.Space;
using KantoorInrichting.Controllers;
using KantoorInrichting.Controllers.CreateSpace;
using KantoorInrichting.Controllers.Placement;
using KantoorInrichting.Views.Placement;

namespace KantoorInrichting.Views.SpaceChoice
{
    public partial class SpaceChoice : UserControl
    {
        public MainFrame MainScreen;

        public SpaceChoice(MainFrame mainScreen)
        {
            this.MainScreen = mainScreen;      
            InitializeComponent();
            FillComboBox(comboBox1);
            Invalidate();
        }

        private void FillComboBox(ComboBox dropdown)
        {
            // clear dropdown
            dropdown.Items.Clear();
            // Select all the items in de spaces list
            var spaceResult = Models.Space.Space.List.GroupBy(space => space.Room)
                   .Select(grp => grp.First())
                   .ToList();
            // add default 

            dropdown.Items.Add("selecteer een ruimte");
            dropdown.SelectedIndex = 0;
            // add the unique items to space dropdown
            foreach (Space space in spaceResult)
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

            // check if something is selected
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("maak eerst een keuze uit een ruimte");
            }
            else
            {
                // check which object to open

                // linq select space with the current ID
                var selectedSpace = Space.List
                        .Where(s => s.Room == (string)selected)
                        .Select(t => t)
                        .ToList();

                // give the design panel the current space ------------old
                //MainScreen.placement.OpenPanel(selectedSpace[0]);


                // ------------------------- new 
                MainScreen.Size = ProductGrid.PanelSize;
                MainScreen.productGrid.controller.OpenPanel(MainScreen.productGrid, selectedSpace[0]);
                MainScreen.productGrid.Visible = true;
                MainScreen.productGrid.Enabled = true;
                MainScreen.productGrid.BringToFront();


                //---------
                this.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Do new space
            CreateSpaceController.Instance.NewSpace();
            //Refill the combobox by sorting them into
            FillComboBox(comboBox1);

            //If there is no space saved, there is no space to load, thus quit now
            if (CreateSpaceController.space == null) { return; }

            //Find the Space
            for (int counter = 0; counter < comboBox1.Items.Count; counter++)
            {
                if (CreateSpaceController.space.Room == (string)comboBox1.Items[counter])
                {
                    comboBox1.SelectedIndex = counter;
                    button1_Click(sender, e);
                    break;
                }
            }
        }
    }
}
