// created by: Robin
// on: 25-11-2015

using System.Windows.Forms;
using KantoorInrichting.Controllers;

namespace KantoorInrichting.Views {
    public interface IView {

        void SetController(IController c);
        Control Get(string property);

    }
}