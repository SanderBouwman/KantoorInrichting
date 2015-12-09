using KantoorInrichting.Models.Maps;
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
        public ShowSpaceScreen spacescreen;
        private string currentImagePath;
        private MapsScreen screen;
        public MapsController(MapsScreen screen)
        {
            this.screen = screen;
            Space.result = Space.list;
            screen.MapsGridView1.DataSource = Space.result;
        }

        public void MapsGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {

                var space = screen.MapsGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                currentImagePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));

                spacescreen = new ShowSpaceScreen();

                try
                {
                    Image imageCircle = Image.FromStream(new MemoryStream(File.ReadAllBytes(currentImagePath + "\\Resources\\" + space + ".JPG")));
                    spacescreen.BackgroundImage = imageCircle;
                    spacescreen.BackgroundImageLayout = ImageLayout.Stretch;
                    spacescreen.Text = "Plattegrond van ruimte: " + space;
                    spacescreen.Show();
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Van lokaal " + space + " bestaat geen plattegrond...");
                }

            }
        }
    }
}
