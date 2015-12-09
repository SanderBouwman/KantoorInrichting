// created by: Robin
// on: 25-11-2015

using System;
using System.Windows.Forms;

namespace KantoorInrichting.Controllers {
    public interface IController {

        void MouseDown( object sender, MouseEventArgs e );
        void MouseMove( object sender, MouseEventArgs e );
        void Resize( object sender, EventArgs e );
        void Paint( object sender, PaintEventArgs e );
        void TrackbarScroll( object sender, EventArgs e );
        void CheckboxChanged( bool b );
        void Notify(object sender, EventArgs e);
        void ButtonClick(object sender, EventArgs e);
        void Dispose(object sender, EventArgs e);

    }
}