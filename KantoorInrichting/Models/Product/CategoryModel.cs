using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KantoorInrichting.Models.Product
{
    class CategoryModel
    {
        public int catID;
        public string name;
        public bool issub;
        public Color colour;

        public CategoryModel(int catID, string name, bool issub, string colour)
        {
            this.catID = catID;
            this.name = name;
            this.issub = issub;
            this.colour = Color.FromArgb(Int32.Parse(colour));
        }
    }
}
