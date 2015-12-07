using KantoorInrichting.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KantoorInrichting.Models.Maps
{
    class Map
    {
        public static SortableBindingList<Map> list = new SortableBindingList<Map>();
        public static SortableBindingList<Map> result = new SortableBindingList<Map>();

        public string Building { get; private set; }
        public int Floor { get; private set; }
        public string Room { get; private set; }

        public Map(string Gebouw, int Verdieping, string Lokaal)
        {
            Building = Gebouw;
            Floor = Verdieping;
            Room = Lokaal;

            list.Add(this);
        }
    }
}
