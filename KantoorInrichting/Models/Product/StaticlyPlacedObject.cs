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
        
        public Polygon toPolygon()
        {
            //Make, add points, build and return.
            Polygon p = new Polygon();

            p.Points.Add(beginPoint);
            p.Points.Add(endPoint);

            p.BuildEdges();

            return p;
        }
    }
}
