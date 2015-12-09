using KantoorInrichting.Models.Placement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KantoorInrichting.Models.Product
{
    public class StaticlyPlacedObject
    {

        public Vector beginPoint { get; private set; }
        public Vector endPoint { get; private set; }

        public StaticlyPlacedObject(Vector begin, Vector end)
        {
            beginPoint = begin;
            endPoint = end;
        }


    }
}
