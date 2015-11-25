using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using KantoorInrichting.Models.Product;

namespace KantoorInrichting_Test.Models.Placement
{
    [TestClass]
    public class RotationTests
    {
        [TestMethod]
        public void addRotation_45()
        {
            //Make
            PointF point = new PointF(200, 200);
            ProductModel product = new ProductModel("", "", "", "", "", 10, 10, 50, "", 1);
            PlacedProduct placedP = new PlacedProduct(product, point);

            PointF[] pointCorner = new PointF[4];
            pointCorner[0] = new PointF(point.X, point.Y - (float)Math.Sqrt(50));    //{200 ; 200-√50}
            pointCorner[1] = new PointF(point.X + (float)Math.Sqrt(50), point.Y);                           //{200+√50 ; 200}
            pointCorner[2] = new PointF(point.X, point.Y + (float)Math.Sqrt(50));    //{200 ; 200+√50}
            pointCorner[3] = new PointF(point.X - (float)Math.Sqrt(50), point.Y);                           //{200-√50 ; 200}

            /*
                Coordinate = {(centerlocation) (direction + or -) (size/2)}

                Point 0 = Top Left
                {200-(10/2) ; 200-(10/2)} = {195 ; 195}

                Point 1 = Top Right
                {200+(10/2) ; 200-(10/2)} = {205 ; 195}

                Point 2 = Lower Right
                {200+(10/2) ; 200+(10/2)} = {205 ; 205}

                Point 3 = Lower Left
                {200-(10/2) ; 200+(10/2)} = {195 ; 205}


                Do some math, and when the square turns 45 degrees, the points are the following:

                [0] = {200 ; 200-√50}
                [1] = {200+√50 ; 200}
                [2] = {200 ; 200+√50}
                [3] = {200-√50 ; 200}
            */



            //Do
            placedP.setAngle(45);



            //Look
            Assert.AreEqual(point.X, placedP.location.X, 0.1, "The horizontal location of the product has changed!");
            Assert.AreEqual(point.Y, placedP.location.Y, 0.1, "The vertical location of the product has changed!");

            for (int index = 0; index < pointCorner.Length; index++)
            {
                Assert.AreEqual(pointCorner[index].ToString(), placedP.cornerPoints[index].ToString(), true, "Corner #" + index + " is in the wrong spot!");
            }

        }

        [TestMethod]
        public void addRotation_90()
        {
            //Make
            PointF point = new PointF(200, 200);
            ProductModel product = new ProductModel("", "", "", "", "", 10, 10, 50, "", 1);
            PlacedProduct placedP = new PlacedProduct(product, point);

            PointF[] pointCorner = new PointF[4];
            pointCorner[0] = new PointF(point.X + product.width / 2, point.Y - product.length / 2); //now the top right
            pointCorner[1] = new PointF(point.X + product.width / 2, point.Y + product.length / 2); //now the lower right
            pointCorner[2] = new PointF(point.X - product.width / 2, point.Y + product.length / 2); //now the lower left
            pointCorner[3] = new PointF(point.X - product.width / 2, point.Y - product.length / 2); //now the top left


            //Do
            placedP.setAngle(90);



            //Look
            Assert.AreEqual(point.X, placedP.location.X, 0.1, "The horizontal location of the product has changed!");
            Assert.AreEqual(point.Y, placedP.location.Y, 0.1, "The vertical location of the product has changed!");

            for (int index = 0; index < pointCorner.Length; index++)
            {
                Assert.AreEqual(pointCorner[index].ToString(), placedP.cornerPoints[index].ToString(), true, "Corner #" + index + " is in the wrong spot!");
            }
        }

        [TestMethod]
        public void addRotation_180()
        {
            //Make
            PointF point = new PointF(200, 200);
            ProductModel product = new ProductModel("", "", "", "", "", 10, 10, 50, "", 1);
            PlacedProduct placedP = new PlacedProduct(product, point);

            PointF[] pointCorner = new PointF[4];
            pointCorner[0] = new PointF(point.X + product.width / 2, point.Y + product.length / 2); //now the lower right
            pointCorner[1] = new PointF(point.X - product.width / 2, point.Y + product.length / 2); //now the lower left
            pointCorner[2] = new PointF(point.X - product.width / 2, point.Y - product.length / 2); //now the top left
            pointCorner[3] = new PointF(point.X + product.width / 2, point.Y - product.length / 2); //now the top right

            //Do
            placedP.setAngle(180);



            //Look
            Assert.AreEqual(point.X, placedP.location.X, 0.1, "The horizontal location of the product has changed!");
            Assert.AreEqual(point.Y, placedP.location.Y, 0.1, "The vertical location of the product has changed!");

            for (int index = 0; index < pointCorner.Length; index++)
            {
                Assert.AreEqual(pointCorner[index].ToString(), placedP.cornerPoints[index].ToString(), true, "Corner #" + index + " is in the wrong spot!");
            }
        }

        [TestMethod]
        public void addRotation_360()
        {
            //Make
            PointF point = new PointF(200, 200);
            ProductModel product = new ProductModel("", "", "", "", "", 10, 10, 50, "", 1);
            PlacedProduct placedP = new PlacedProduct(product, point);

            PointF[] pointCorner = new PointF[4];
            pointCorner[0] = new PointF(point.X - product.width / 2, point.Y - product.length / 2); //now the top left
            pointCorner[1] = new PointF(point.X + product.width / 2, point.Y - product.length / 2); //now the top right
            pointCorner[2] = new PointF(point.X + product.width / 2, point.Y + product.length / 2); //now the lower right
            pointCorner[3] = new PointF(point.X - product.width / 2, point.Y + product.length / 2); //now the lower left

            //Do
            placedP.setAngle(360);



            //Look
            Assert.AreEqual(point.X, placedP.location.X, 0.1, "The horizontal location of the product has changed!");
            Assert.AreEqual(point.Y, placedP.location.Y, 0.1, "The vertical location of the product has changed!");

            for (int index = 0; index < pointCorner.Length; index++)
            {
                Assert.AreEqual(pointCorner[index].ToString(), placedP.cornerPoints[index].ToString(), true, "Corner #" + index + " is in the wrong spot!");
            }
        }
    }
}
