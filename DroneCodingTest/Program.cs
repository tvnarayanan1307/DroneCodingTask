using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DroneCodingTest.DroneClasses;

namespace DroneCodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string battleFieldLayout = Console.ReadLine();
            Battlefield battlefield = new Battlefield(battleFieldLayout.Trim());

            string droneOneCoordinates = Console.ReadLine();
            string droneOneCommands = Console.ReadLine();

            string droneTwoCoordinates = Console.ReadLine();
            string droneTwoCommands = Console.ReadLine();

            Drones droneOne = new Drones(battlefield, droneOneCoordinates, droneOneCommands);
            Drones droneTwo = new Drones(battlefield, droneTwoCoordinates, droneTwoCommands);

            Console.ReadKey();

        }
    }
}
