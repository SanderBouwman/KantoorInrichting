using KantoorInrichting.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KantoorInrichting.Models.Maps
{
    public class Space
    {
        public static SortableBindingList<Space> list = new SortableBindingList<Space>();
        public static SortableBindingList<Space> result = new SortableBindingList<Space>();
        public int length;
        public int width;
        public bool final;
        public string Building;
        public string Floor;
        public string Room;
        public string Roomnumber;

        public Space(string Lokaal, string Verdieping, string Gebouw, string Kamernumber, int length, int width, bool final)
        {
            Building = Gebouw;
            Room = Lokaal;
            Floor = Verdieping;         // why is floor a string? should be integer -- Edwin
            Roomnumber = Kamernumber;
            this.length = length;
            this.width = width;
            this.final = final;


            list.Add(this);
        }
    }
}
