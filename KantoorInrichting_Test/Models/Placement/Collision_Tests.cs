using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Views.Placement;

namespace KantoorInrichting_Test.Models.Placement
{
    [TestClass]
    public class Collision_Tests
    {
        [TestMethod]
        public void collision_MoveCollision()
        {
            //Move -> Collision

            //Move X+50, Y+0
            //Move X+50, Y+0 - can't move all the way because collision, so only X+30

            //Make
            PointF point = new PointF(200, 200); //Right end = 350 (200+150)
            PointF pointWall = new PointF(440, 200); //Left end = 430 (440-10)

            ProductModel product = new ProductModel("", "", "", "", "", 100, 300, 50, "", 1); //Width = 300, so it's 150 + 150
            ProductModel productWall = new ProductModel("", "", "", "", "", 20, 20, 50, "", 1); //Width = 20, so it's 10 + 10
            

            PlacedProduct placedP = new PlacedProduct(product, point);
            PlacedProduct placedWall = new PlacedProduct(productWall, pointWall);

            ProductAdding.ppList.Add(placedP);
            ProductAdding.ppList.Add(placedWall);

            int move_x = 60;
            int move_y = 0; 

            PointF[] pointCorner = new PointF[4];
            pointCorner[0] = new PointF(point.X - (product.width / 2) + move_x, point.Y - (product.length / 2) + move_y);   //{205 ; 195}
            pointCorner[1] = new PointF(point.X + (product.width / 2) + move_x, point.Y - (product.length / 2) + move_y);   //{215 ; 195}
            pointCorner[2] = new PointF(point.X + (product.width / 2) + move_x, point.Y + (product.length / 2) + move_y);   //{215 ; 205}
            pointCorner[3] = new PointF(point.X - (product.width / 2) + move_x, point.Y + (product.length / 2) + move_y);   //{205 ; 205}




            //Do
            placedP.gridSpace = 50; //Set grid (movement speed) to 50.
            placedP.Move(true); //{250;200}
            placedP.Move(true); //{300;200}Cant perform this.
            placedP.gridSpace = 10;
            placedP.Move(true); //{260;200} Now it can, because the grid was changed, and that allowed it to move 'slower'
            point.X += move_x;
            point.Y += move_y;


            //Look
            Assert.AreEqual(point.X, placedP.location.X, 0.1, "The horizontal location of the product is different!");
            Assert.AreEqual(point.Y, placedP.location.Y, 0.1, "The vertical location of the product is different!");

            for (int index = 0; index < pointCorner.Length; index++)
            {
                Assert.AreEqual(pointCorner[index].ToString(), placedP.cornerPoints[index].ToString(), true, "Corner #" + index + " is in the wrong spot!");
            }
        }

        [TestMethod]
        public void collision_RotateCollision()
        {
            //Rotate -> Collision

            //Rotate 15
            //Rotate 15
            //Rotate 15
            //Rotate 15 -can't do this because collision

            //Make
            PointF point = new PointF(400, 200);
            PointF pointWall = new PointF(400, 50);

            ProductModel product = new ProductModel("", "", "", "", "", 100, 300, 50, "", 1);
            ProductModel productWall = new ProductModel("", "", "", "", "", 100, 50, 50, "", 1);

            PlacedProduct placedP = new PlacedProduct(product, point);
            PlacedProduct placedWall = new PlacedProduct(productWall, pointWall);

            ProductAdding.ppList.Add(placedP);
            ProductAdding.ppList.Add(placedWall);
            

            double radius = Math.Sqrt(Math.Pow(product.width/2, 2) + Math.Pow(product.length/2, 2));
            double initialAngle = (Math.Atan((0.5 * product.length) / (0.5 * product.width)) * 180 / Math.PI);
            
            double angle_Even = 45 + initialAngle;
            double angle_Uneven = 45 - initialAngle;            

            float Cos_Even = (float)(Math.Cos(angle_Even * Math.PI / 180) * radius);
            float Sin_Even = (float)(Math.Sin(angle_Even * Math.PI / 180) * radius);

            float Cos_Uneven = (float)(Math.Cos(angle_Uneven * Math.PI / 180) * radius);
            float Sin_Uneven = (float)(Math.Sin(angle_Uneven * Math.PI / 180) * radius);


            PointF[] pointCorner = new PointF[4];
            pointCorner[0] = new PointF(point.X - Cos_Even, point.Y - Sin_Even);   //{205 ; 195}
            pointCorner[1] = new PointF(point.X + Cos_Uneven, point.Y + Sin_Uneven);   //{215 ; 195}
            pointCorner[2] = new PointF(point.X + Cos_Even, point.Y + Sin_Even);   //{215 ; 205}
            pointCorner[3] = new PointF(point.X - Cos_Uneven, point.Y - Sin_Uneven);   //{205 ; 205}



            //Do
            placedP.addAngle(15); //after this it's 15
            placedP.addAngle(15); //after this it's 30
            placedP.addAngle(15); //after this it's 45
            placedP.addAngle(15); //after this it's 60 -Can't perform this because of the collision.
            placedP.addAngle(15); //after this it's 75 -Can't perform this.
            placedP.addAngle(15); //after this it's 90 -Can't perform this.


            //Look
            Assert.AreEqual(point.X, placedP.location.X, 0.1, "The horizontal location of the product is different!");
            Assert.AreEqual(point.Y, placedP.location.Y, 0.1, "The vertical location of the product is different!");

            for (int index = 1; index < pointCorner.Length; index++)
            {
                Assert.AreEqual(pointCorner[index].ToString(), placedP.cornerPoints[index].ToString(), true, "Corner #" + index + " is in the wrong spot!");
            }
        }

        [TestMethod]
        public void collision_MoveRotateCollision()
        {
            //Move
            //Rotate -> Collision


            //Make
            PointF point = new PointF(200, 200);
            PointF pointWall = new PointF(400, 50);

            ProductModel product = new ProductModel("", "", "", "", "", 100, 300, 50, "", 1);
            ProductModel productWall = new ProductModel("", "", "", "", "", 100, 50, 50, "", 1);

            PlacedProduct placedP = new PlacedProduct(product, point);
            PlacedProduct placedWall = new PlacedProduct(productWall, pointWall);

            ProductAdding.ppList.Add(placedP);
            ProductAdding.ppList.Add(placedWall);


            double radius = Math.Sqrt(Math.Pow(product.width / 2, 2) + Math.Pow(product.length / 2, 2));
            double initialAngle = (Math.Atan((0.5 * product.length) / (0.5 * product.width)) * 180 / Math.PI);

            double angle_Even = 45 + initialAngle;
            double angle_Uneven = 45 - initialAngle;

            float Cos_Even = (float)(Math.Cos(angle_Even * Math.PI / 180) * radius);
            float Sin_Even = (float)(Math.Sin(angle_Even * Math.PI / 180) * radius);

            float Cos_Uneven = (float)(Math.Cos(angle_Uneven * Math.PI / 180) * radius);
            float Sin_Uneven = (float)(Math.Sin(angle_Uneven * Math.PI / 180) * radius);

            int move_x = 200;
            int move_y = 0; 

            PointF[] pointCorner = new PointF[4];
            pointCorner[0] = new PointF(point.X + move_x - Cos_Even, point.Y + move_y - Sin_Even);   //{205 ; 195}
            pointCorner[1] = new PointF(point.X + move_x + Cos_Uneven, point.Y + move_y + Sin_Uneven);   //{215 ; 195}
            pointCorner[2] = new PointF(point.X + move_x + Cos_Even, point.Y + move_y + Sin_Even);   //{215 ; 205}
            pointCorner[3] = new PointF(point.X + move_x - Cos_Uneven, point.Y + move_y - Sin_Uneven);   //{205 ; 205}



            //Do
            placedP.gridSpace = 100; //Set the grid to 100, so that it moves 100 pixels per move
            placedP.Move(true); //Towards center = { 300 ; 200}
            placedP.Move(true); //Towards center = { 400 ; 200}
            placedP.addAngle(15); //after this it's 15
            placedP.addAngle(15); //after this it's 30
            placedP.addAngle(15); //after this it's 45
            placedP.addAngle(15); //after this it's 60 -Can't perform this because of the collision.
            placedP.addAngle(15); //after this it's 75 -Can't perform this.
            placedP.addAngle(15); //after this it's 90 -Can't perform this.
            point.X += move_x;
            point.Y += move_y;


            //Look
            Assert.AreEqual(point.X, placedP.location.X, 0.1, "The horizontal location of the product is different!");
            Assert.AreEqual(point.Y, placedP.location.Y, 0.1, "The vertical location of the product is different!");

            for (int index = 1; index < pointCorner.Length; index++)
            {
                Assert.AreEqual(pointCorner[index].ToString(), placedP.cornerPoints[index].ToString(), true, "Corner #" + index + " is in the wrong spot!");
            }
        }

        [TestMethod]
        public void collision_RotateMoveCollision()
        {
            //Rotate
            //Move -> Collision

            //Make
            PointF point = new PointF(200, 200);
            PointF pointWall = new PointF(400, 50);

            ProductModel product = new ProductModel("", "", "", "", "", 100, 300, 50, "", 1);
            ProductModel productWall = new ProductModel("", "", "", "", "", 100, 50, 50, "", 1);

            PlacedProduct placedP = new PlacedProduct(product, point);
            PlacedProduct placedWall = new PlacedProduct(productWall, pointWall);

            ProductAdding.ppList.Add(placedP);
            ProductAdding.ppList.Add(placedWall);


            double radius = Math.Sqrt(Math.Pow(product.width / 2, 2) + Math.Pow(product.length / 2, 2));
            double initialAngle = (Math.Atan((0.5 * product.length) / (0.5 * product.width)) * 180 / Math.PI);

            double angle_Even = 45 + initialAngle;
            double angle_Uneven = 45 - initialAngle;

            float Cos_Even = (float)(Math.Cos(angle_Even * Math.PI / 180) * radius);
            float Sin_Even = (float)(Math.Sin(angle_Even * Math.PI / 180) * radius);

            float Cos_Uneven = (float)(Math.Cos(angle_Uneven * Math.PI / 180) * radius);
            float Sin_Uneven = (float)(Math.Sin(angle_Uneven * Math.PI / 180) * radius);

            int move_x = 200;
            int move_y = 0;

            PointF[] pointCorner = new PointF[4];
            pointCorner[0] = new PointF(point.X + move_x - Cos_Even, point.Y + move_y - Sin_Even);   //{205 ; 195}
            pointCorner[1] = new PointF(point.X + move_x + Cos_Uneven, point.Y + move_y + Sin_Uneven);   //{215 ; 195}
            pointCorner[2] = new PointF(point.X + move_x + Cos_Even, point.Y + move_y + Sin_Even);   //{215 ; 205}
            pointCorner[3] = new PointF(point.X + move_x - Cos_Uneven, point.Y + move_y - Sin_Uneven);   //{205 ; 205}



            //Do
            placedP.gridSpace = 50; //Set to 50
            placedP.addAngle(15); //after this it's 15
            placedP.addAngle(15); //after this it's 30
            placedP.addAngle(15); //after this it's 45
            placedP.Move(true); //Towards center = { 250 ; 200}            
            placedP.Move(true); //Towards center = { 300 ; 200}
            placedP.Move(true); //Towards center = { 350 ; 200}
            placedP.Move(true); //Towards center = { 400 ; 200}
            placedP.Move(true); //Towards center = { 450 ; 200} -Can't perform this because of the collision.
            placedP.Move(true); //Towards center = { 500 ; 200} -Can't perform this.
            point.X += move_x;
            point.Y += move_y;


            //Look
            Assert.AreEqual(point.X, placedP.location.X, 0.1, "The horizontal location of the product is different!");
            Assert.AreEqual(point.Y, placedP.location.Y, 0.1, "The vertical location of the product is different!");

            for (int index = 1; index < pointCorner.Length; index++)
            {
                Assert.AreEqual(pointCorner[index].ToString(), placedP.cornerPoints[index].ToString(), true, "Corner #" + index + " is in the wrong spot!");
            }
        }
    }
}
