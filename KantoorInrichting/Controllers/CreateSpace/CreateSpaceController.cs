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
    class CreateSpaceController
    {

        public CreateSpaceController()
        {
            
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
                    //TODO
                    //Open emediately open the newly created space
                    break;

                    case DialogResult.OK:
                    CreateNewSpace(spaceInfoDialog.SpaceInfo);
                    //TODO
                    //Go back to MainScreen or SpaceChoice. Depends on where the 'Create A New Room' button is placed. 
                    break;
            }
            //Dispose after use
            spaceInfoDialog.Dispose();
        }

        private void CreateNewSpace(Dictionary<string, string> dict)
        {
            Space space = new Space(dict["Total"], dict["Floor"], dict["Building"], dict["Room"], Int32.Parse(dict["Length"]), Int32.Parse(dict["Width"]), false);
        }

    }
}
