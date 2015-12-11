// created by: Robin
// on: 25-11-2015

#region

using System;
using System.Windows.Forms;

#endregion

namespace KantoorInrichting.Controllers {
    public interface IController {
        void Resize(object sender, EventArgs e);
        void Paint(object sender, PaintEventArgs e);
        void CheckboxChanged(bool b);
        void Notify(object sender, EventArgs e);
        void Dispose(object sender, EventArgs e);
    }
}