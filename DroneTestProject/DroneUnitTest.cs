using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DroneCodingTest.DroneClasses;

namespace DroneTestProject
{
    [TestClass]
    public class DroneUnitTest
    {
        [TestMethod]
        public void TestDrones()
        {
            Battlefield battlefield = new Battlefield("5 5");
            Drones droneOne = new Drones(battlefield, "1 2 N", "LMLMLMLMM");
            Drones droneTwo = new Drones(battlefield, "3 3 E", "MMRMMRMRRM");

            Assert.IsTrue(Convert.ToInt32(droneOne.initialPositionOfDrone[0]) == 1, "Drone One: X != 1");
            Assert.IsTrue(Convert.ToInt32(droneOne.initialPositionOfDrone[1]) == 3, "Drone One: Y != 3");
            Assert.IsTrue(droneOne.initialPositionOfDrone[2] == "N", "Drone One: Direction != North");

            Assert.IsTrue(Convert.ToInt32(droneTwo.initialPositionOfDrone[0]) == 5, "Drone Two: X != 5");
            Assert.IsTrue(Convert.ToInt32(droneTwo.initialPositionOfDrone[1]) == 1, "Drone Two: Y != 1");
            Assert.IsTrue(droneTwo.initialPositionOfDrone[2] == "E", "Drone Two: Direction != East");
        }
            
    }
}
