// created by: Robin
// on: 25-11-2015

#region

using System.Windows.Forms;
using KantoorInrichting.Controllers;

#endregion

namespace KantoorInrichting.Views
{
    public interface IView<T>
    {
        T Properties { get; set; }
        void SetController(IController c);
        Control Get(T property);
    }
}