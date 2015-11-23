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


            Product p1 = new Product("stoel henk", "Ahrend", "A1",null,null,  140, 40, 40,"hele fijne stoel",0);
            Product p2 = new Product("stoel piet",  "Ahrend", "B1", null, null, 140, 40, 40, "hele fijne stoel", 124);
            Product p3 = new Product("tafel anna",  "Ahrend", "243A1", null, null, 100, 140, 40, "hele fijne tafel", 0);
            Product p4 = new Product("tafel grietje",  "Ahrend", "A4521", null, null, 140, 200, 140, "hele fijne tafel", 124);
            Product p5 = new Product("tafel grietjesss", "Ahrend", "A4521", null, null, 140, 200, 140, "hele fijne tafel", 124);
            Product p6 = new Product("prullenbak harrie", "Ahrend", "243A3431", null, null, 100, 140, 40, "hele fijne prullenbak", 124);
            Product p7 = new Product("Prullenbak recycle", "Ahrend", "C41", null, null, 140, 200, 140, "hele fijne prullenbak", 0);
            Product p8 = new Product("Prullenbak w0llah", "Ahrend", "z321", null, null, 140, 200, 140, "hele fijne prullenbak", 124);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrame());
        }
    }
}
