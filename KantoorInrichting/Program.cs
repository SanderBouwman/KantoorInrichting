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
            Map Plattegrond1 = new Map("T", 4, 15, "T4,15");
            Map Plattegrond2 = new Map("T", 2, 8, "T2,8");
            Map Plattegrond3 = new Map("T", 3, 22, "T3,22");
            Map Plattegrond4 = new Map("T", 1, 29, "T1,29");
            Map Plattegrond5 = new Map("T", 3, 17, "T3,17");
            Map Plattegrond6 = new Map("T", 4, 11, "T4,11");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrame());
        }
    }
}
