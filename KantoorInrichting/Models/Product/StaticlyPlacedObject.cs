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

        public Vector BeginPoint { get; private set; }
        public Vector EndPoint { get; private set; }

        public StaticlyPlacedObject(Vector begin, Vector end)
        {
            BeginPoint = begin;
            EndPoint = end;
        }
        
        public Polygon ToPolygon()
        {
            //Make, add points, build and return.
            Polygon p = new Polygon();

            p.Points.Add(BeginPoint);
            p.Points.Add(EndPoint);

            p.BuildEdges();

            return p;
        }
    }
}
