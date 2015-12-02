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

            ProductModel p1 = new ProductModel(1, "stoel henk", "Ahrend", "A1", "kantoorstoel", 140, 40, 40, "hele fijne stoel", 0,"stoel.jpg");
             
            ProductModel p2 = new ProductModel(2,"stoel piet", "Quantore", "B1", "stoel",  140, 40, 40, "hele fijne stoel", 124, "stoel.jpg");
            ProductModel p3 = new ProductModel(3,"tafel anna", "Ahrend", "243A1",  "bureaustoel", 100, 140, 40, "hele fijne tafel", 0, "tafel.jpg");
            ProductModel p4 = new ProductModel(4,"tafel grietje", "Ahrend", "A4521", "tafel", 140, 200, 140, "hele fijne tafel", 124, "tafel.jpg");
            ProductModel p5 = new ProductModel(5,"statafel jan", "Ahrend", "A4521", "statafel", 140, 200, 140, "hele fijne tafel", 124, "statafel.jpg");
            ProductModel p6 = new ProductModel(6,"prullenbak harrie", "Quantore", "243A3431", "prullenbak",  100, 140, 40, "hele fijne prullenbak", 0, "prullenbak.jpg");
            ProductModel p7 = new ProductModel(7,"Prullenbak recycle", "Ahrend", "C41", "prullenbak",  140, 200, 140, "hele fijne prullenbak", 0, "prullenbak.jpg");
            ProductModel p8 = new ProductModel(8,"Prullenbak w0llah", "Ahrend", "z321", "prullenbak", 140, 200, 140, "hele fijne prullenbak", 124, "prullenbak.jpg");
            ProductModel p9 = new ProductModel(9,"Black Chair", "Chairs'R'Yours", "A", "stoel", 50, 50, 60, "Chair - Stackable", 9, "stoel.jpg");
            ProductModel p10 = new ProductModel(10,"Red Table", "Dem Tables", "A", "tafel",  100, 300, 100, "Table - Dining", 0, "tafel.jpg");
            ProductModel p11 = new ProductModel(11,"Yellow Coffee Table", "Dem Tables", "B",  "koffietafel", 50, 100, 75, "Table - Coffee", 6, "tafel.jpg");
            ProductModel p12 = new ProductModel(12,"Blue-Board", "Color Board", "H", "whiteboard",  10, 200, 200, "Board - White Board", 4, "No_Image_Available.png");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrame());
        }
    }
}
