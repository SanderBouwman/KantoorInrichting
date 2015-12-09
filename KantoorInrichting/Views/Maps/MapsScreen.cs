using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Models.Maps;
using System.IO;

namespace KantoorInrichting.Views.Maps
{
    public partial class MapsScreen : UserControl
    {
        public ShowSpaceScreen spacescreen;
        private string currentImagePath;
        public MainFrame mainFrame;
        public MapsScreen(MainFrame mainFrame)
        {
            this.mainFrame = mainFrame;
            InitializeComponent();
            Space.result = Space.list;
            this.MapsGridView1.DataSource = Space.result;


        }

        private void MapsGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {

                var space = MapsGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
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
