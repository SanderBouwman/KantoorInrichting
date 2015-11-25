using KantoorInrichting.Models.Product;
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


            ProductModel p1 = new ProductModel("stoel henk", "Ahrend", "A1",null,null,  140, 40, 40,"hele fijne stoel",0);
            ProductModel p2 = new ProductModel("stoel piet",  "Quantore", "B1", null, null, 140, 40, 40, "hele fijne stoel", 124);
            ProductModel p3 = new ProductModel("tafel anna",  "Ahrend", "243A1", null, null, 100, 140, 40, "hele fijne tafel", 0);
            ProductModel p4 = new ProductModel("tafel grietje",  "Ahrend", "A4521", null, null, 140, 200, 140, "hele fijne tafel", 124);
            ProductModel p5 = new ProductModel("tafel grietjesss", "Ahrend", "A4521", null, null, 140, 200, 140, "hele fijne tafel", 124);
            ProductModel p6 = new ProductModel("prullenbak harrie", "Quantore", "243A3431", null, null, 100, 140, 40, "hele fijne prullenbak", 124);
            ProductModel p7 = new ProductModel("Prullenbak recycle", "Ahrend", "C41", null, null, 140, 200, 140, "hele fijne prullenbak", 0);
            ProductModel p8 = new ProductModel("Prullenbak w0llah", "Ahrend", "z321", null, null, 140, 200, 140, "hele fijne prullenbak", 124);
            ProductModel p9 = new ProductModel("Black Chair", "Chairs'R'Yours", "A", null, null, 50, 50, 60, "Chair - Stackable", 9);
            ProductModel p10 = new ProductModel("Red Table", "Dem Tables", "A", null, null, 100, 300, 100, "Table - Dining", 0);
            ProductModel p11 = new ProductModel("Yellow Coffee Table", "Dem Tables", "B", null, null, 50, 100, 75, "Table - Coffee", 6);
            ProductModel p12 = new ProductModel("Blue-Board", "Color Board", "H", null, null, 10, 200, 200, "Board - White Board", 4);







            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrame());
        }
    }
}
