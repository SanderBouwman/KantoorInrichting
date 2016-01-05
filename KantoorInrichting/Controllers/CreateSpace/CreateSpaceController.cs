using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Views.CreateSpace;
using KantoorInrichting.Models.Space;

namespace KantoorInrichting.Controllers.CreateSpace
{
    class CreateSpaceController
    {
        private static CreateSpaceController instance;
        public static CreateSpaceController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CreateSpaceController();
                }
                return instance;
            }
        }

        public static Space space;
        DatabaseController dbc = DatabaseController.Instance;

        private CreateSpaceController()
        {
            //
        }

        //Activate when a new space is being made
        public void NewSpace()
        {
            SpaceInfoDialog spaceInfoDialog = new SpaceInfoDialog();
            spaceInfoDialog.ShowDialog();
            switch (spaceInfoDialog.DialogResult)
            {
                case DialogResult.Yes:
                    CreateNewSpace(spaceInfoDialog.SpaceInfo);
                    break;

                case DialogResult.OK:
                    CreateNewSpace(spaceInfoDialog.SpaceInfo);
                    space = null;
                    break;
                default:
                    space = null;
                    break;
            }
            //Dispose after use
            spaceInfoDialog.Dispose();
        }

        
        private void CreateNewSpace(Dictionary<string, string> dict)
        {
            //If room already exists, give an message
            foreach (var spaceCompare in dbc.DataSet.space)
            {
                if (spaceCompare.space_number == dict["Total"])
                {
                    //Found a duplicate -> quit
                    MessageBox.Show("Het lokaal, " + dict["Total"] + ", is al in gebruik. Kies graag het lokaal in uit de lijst.");
                    space = null;
                    return;
                }
            }

            
            //Multiplies Length and Width by 100 to convert Meters to Centimeters
                space = new Space(dict["Total"], dict["Floor"], dict["Building"], dict["Room"],
                (int)(Double.Parse(dict["Length"])*100), (int)(Double.Parse(dict["Width"])*100), false);
            
            //To the database
            SaveNewSpace(space);

            //Message to the user
            MessageBox.Show(space.ToString(), "U heeft een nieuwe ruimte aangemaakt.");
        }

        private void SaveNewSpace(Space space)
        {
            //Add Space to database
            DataRow anyRow = dbc.DataSet.space.NewRow();
            
            anyRow["space_number"] = space.Room;
            anyRow["floor"] = space.Floor;
            anyRow["building"] = space.Building;
            anyRow["roomnumber"] = space.Roomnumber;
            anyRow["final"] = space.Final;
            anyRow["length"] = space.Length;
            anyRow["width"] = space.Width;

            dbc.DataSet.space.Rows.Add(anyRow);
            dbc.SpaceTableAdapter.Update(dbc.DataSet.space);
        }

    }
}
