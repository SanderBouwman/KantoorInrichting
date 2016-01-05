using KantoorInrichting.Controllers;
using KantoorInrichting.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace KantoorInrichting.Models.Space
{
    public class Space
    {
        public static SortableBindingList<Space> List = new SortableBindingList<Space>();
        public static SortableBindingList<Space> Result = new SortableBindingList<Space>();
        public int Length;
        public int Width;
        public bool Final;
        public string Building { get; private set; }
        public string Floor { get; private set; }
        public string Room { get; private set; }
        public string Roomnumber { get; private set; }


        public Space(string space, string floor, string building, string roomnumber, int length, int width, bool final)
        {
            Building = building;
            Room = space;
            Floor = floor;         // why is floor a string? should be integer -- Edwin
            Roomnumber = roomnumber;
            this.Length = length;
            this.Width = width;
            this.Final = final;

            List.Add(this);
        }

        public override string ToString()
        {
            return "Lokaal: " + Room + " Dimenties: " + Length + "x" + Width;
        }
    }
}
