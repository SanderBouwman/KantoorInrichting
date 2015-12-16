using KantoorInrichting.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KantoorInrichting.Models.Maps
{
    class Space
    {
        public static SortableBindingList<Space> list = new SortableBindingList<Space>();
        public static SortableBindingList<Space> result = new SortableBindingList<Space>();

        public string Building { get; private set; }
        public int Floor { get; private set; }
        public string Room { get; private set; }
        public string Roomnumber { get; private set; }

        public Space(string Lokaal, int Verdieping, string Gebouw, string Kamernumber )
        {
            Building = Gebouw;
            Floor = Verdieping;
            Room = Lokaal;
            Roomnumber = Kamernumber;

            list.Add(this);
        }

        //contstructor for wrong parameters
        public Space(string Lokaal, string Verdieping, string Gebouw, string Kamernumber)
        {
            Building = Gebouw;
            Room = Lokaal;
            Roomnumber = Kamernumber;

            list.Add(this);
        }
    }
}
