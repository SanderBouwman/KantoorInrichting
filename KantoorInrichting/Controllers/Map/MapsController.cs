using KantoorInrichting.Models.Space;
using KantoorInrichting.Views.Maps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantoorInrichting.Controllers.Map
{
    class MapsController
    {
        public ShowSpaceScreen Spacescreen;
        private readonly MapsScreen _screen;
        private string _currentImagePath;

        public MapsController(MapsScreen screen)
        {
            this._screen = screen;
            Space.Result = Space.List;
            screen.MapsGridView1.DataSource = Space.Result;
        }

        
        public void MapsGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //looks at where is being clicked and wether or not it is a button.
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //puts the room in a variable.
                var space = _screen.MapsGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                _currentImagePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));

                Spacescreen = new ShowSpaceScreen();

                try
                {
                    //checks if the image if present, if it is it will put it as the background and stretches out in the screen.
                    Image imageCircle = Image.FromStream(new MemoryStream(File.ReadAllBytes(_currentImagePath + "\\Resources\\" + space + ".bmp")));
                    Spacescreen.BackgroundImage = imageCircle;
                    Spacescreen.BackgroundImageLayout = ImageLayout.Stretch;
                    Spacescreen.Text = "Plattegrond van ruimte: " + space;
                    Spacescreen.Show();
                }
                catch (FileNotFoundException)
                {
                    //if the file is not found, this message will be displayed.
                    MessageBox.Show("Van lokaal " + space + " bestaat geen plattegrond...");
                }

            }
        }
    }
}
