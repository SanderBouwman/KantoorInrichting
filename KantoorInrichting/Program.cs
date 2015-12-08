using KantoorInrichting.Models.Product;
using KantoorInrichting.Controllers.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Models.Maps;
using KantoorInrichting.Controllers;

namespace KantoorInrichting {
    class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Space Plattegrond1 = new Space("T4,11",5, "T", "15");
            Space Plattegrond2 = new Space("T4,11", 5, "T", "15");
            Space Plattegrond3 = new Space("T4,11", 5, "T", "15");
            Space Plattegrond4 = new Space("T4,11", 5, "T", "15");
            Space Plattegrond5 = new Space("T4,11", 5, "T", "15");
            Space Plattegrond6 = new Space("T4,11", 5, "T", "15");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrame());
        }
    }
}
