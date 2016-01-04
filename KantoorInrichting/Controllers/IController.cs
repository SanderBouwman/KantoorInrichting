// created by: Robin
// on: 25-11-2015

#region

using System;
using System.Windows.Forms;

#endregion

namespace KantoorInrichting.Controllers {
    public interface IController {
        void Paint(object sender, PaintEventArgs e);
        void Notify(object sender, EventArgs e, string eventName);
        void Dispose(object sender, EventArgs e);
    }
}