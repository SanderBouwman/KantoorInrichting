using KantoorInrichting.Controllers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KantoorInrichting.Models.Product
{
    public class StaticObjectModel
    {
        public static SortableBindingList<StaticObjectModel> List = new SortableBindingList<StaticObjectModel>();

        public PointF Location;
        public int ProductId { get; set;}
        public string Name { get; set; }
        public bool Wall { get; set; }
        public string Description { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public Image Image { get; set; }

        //public StaticObjectModel(int id, string n, bool w, string d, int wi, int h, int l, Image img)
        //{
        //    ProductId = id;
        //    Name = n;
        //    Wall = w;
        //    Description = d;
        //    Width = wi;
        //    Height = h;
        //    Length = l;
        //    Image = img;

        //    if (n != "") { List.Add(this); } //If the name if empty, don't add it to the list. This is because the name is part of the primary key in the database.
        //}
    }
}
