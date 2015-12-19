// created by: Robin
// on: 25-11-2015

#region

using System.Windows.Forms;
using KantoorInrichting.Controllers;

#endregion

namespace KantoorInrichting.Views
{
    public interface IView
    {
        void SetController(IController c);
        Control Get(string property);
    }
}