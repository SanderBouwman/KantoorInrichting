using KantoorInrichting.Models.Product;
using KantoorInrichting.Controllers.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantoorInrichting {
    class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ProductModel p1 = new ProductModel("stoel henk", "Ahrend", "A1", "stoel", "kantoorstoel", 140, 40, 40, "hele fijne stoel", 0);
            ProductModel p2 = new ProductModel("stoel piet", "Quantore", "B1", "stoel", null, 140, 40, 40, "hele fijne stoel", 124);
            ProductModel p3 = new ProductModel("tafel anna", "Ahrend", "243A1", "tafel", "bureaustoel", 100, 140, 40, "hele fijne tafel", 0);
            ProductModel p4 = new ProductModel("tafel grietje", "Ahrend", "A4521", "tafel", null, 140, 200, 140, "hele fijne tafel", 124);
            ProductModel p5 = new ProductModel("statafel jan", "Ahrend", "A4521", "tafel", "statafel", 140, 200, 140, "hele fijne tafel", 124);
            ProductModel p6 = new ProductModel("prullenbak harrie", "Quantore", "243A3431", "prullenbak", null, 100, 140, 40, "hele fijne prullenbak", 0);
            ProductModel p7 = new ProductModel("Prullenbak recycle", "Ahrend", "C41", "prullenbak", null, 140, 200, 140, "hele fijne prullenbak", 0);
            ProductModel p8 = new ProductModel("Prullenbak w0llah", "Ahrend", "z321", "prullenbak", null, 140, 200, 140, "hele fijne prullenbak", 124);
            ProductModel p9 = new ProductModel("Black Chair", "Chairs'R'Yours", "A", "stoel", null, 50, 50, 60, "Chair - Stackable", 9);
            ProductModel p10 = new ProductModel("Red Table", "Dem Tables", "A", "tafel", null, 100, 300, 100, "Table - Dining", 0);
            ProductModel p11 = new ProductModel("Yellow Coffee Table", "Dem Tables", "B", "tafel", "koffietafel", 50, 100, 75, "Table - Coffee", 6);
            ProductModel p12 = new ProductModel("Blue-Board", "Color Board", "H", null, null, 10, 200, 200, "Board - White Board", 4);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrame());
        }
    }
}
