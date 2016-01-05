using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Views.CreateSpace;
using KantoorInrichting.Models.Space;

namespace KantoorInrichting.Controllers.CreateSpace
{
    static class CreateSpaceController
    {
        public static Space space;

        //Activate when a new space is being made
        public static void NewSpace()
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

        
        private static void CreateNewSpace(Dictionary<string, string> dict)
        {
            //Multiplies Length and Width by 100 to convert Meters to Centimeters
            space = new Space(dict["Total"], dict["Floor"], dict["Building"], dict["Room"],
                (int)(Double.Parse(dict["Length"])*100), (int)(Double.Parse(dict["Width"])*100), false);


            MessageBox.Show(space.ToString());
        }

    }
}
