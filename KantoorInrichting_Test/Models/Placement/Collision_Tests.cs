using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KantoorInrichting_Test.Models.Placement
{
    [TestClass]
    public class Collision_Tests
    {
        [TestMethod]
        public void collision_MoveCollision()
        {
            //Move -> Collision
        }

        [TestMethod]
        public void collision_RotateCollision()
        {
            //Rotate -> Collision
        }

        [TestMethod]
        public void collision_MoveRotateCollision()
        {
            //Move
            //Rotate -> Collision
        }

        [TestMethod]
        public void collision_RotateMoveCollision()
        {
            //Rotate
            //Move -> Collision
        }
    }
}
