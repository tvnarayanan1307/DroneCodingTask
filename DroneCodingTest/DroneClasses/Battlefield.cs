using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DroneCodingTest.DroneException;

namespace DroneCodingTest.DroneClasses
{
    public class Battlefield
    {
        public int upperRightColumnValue = 0;
        public int upperRightRowValue = 0;
        public Battlefield(string topRightCoordinates)
        {
            if (string.IsNullOrEmpty(topRightCoordinates))
                throw new ArgumentException();
            string[] upperRightCoordinates = topRightCoordinates.Split(' ');
            int coordinateValue = 0;

            if (upperRightCoordinates.Count() == 2 && int.TryParse(upperRightCoordinates[0], out coordinateValue) && int.TryParse(upperRightCoordinates[1], out coordinateValue))
            {
                upperRightColumnValue = Convert.ToInt32(upperRightCoordinates[0]);
                upperRightRowValue = Convert.ToInt32(upperRightCoordinates[1]);
                if (upperRightRowValue != upperRightColumnValue)
                {
                    Console.WriteLine("Upper-right co-ordinate values for the battlefield must be equal");
                    Console.ReadKey();
                    throw new DroneMovementException("Upper-right co-ordinate values for the battlefield must be equal");
                }
            }
            else
            {
                Console.WriteLine("Invalid number of co-ordinates or co-ordinates are non-numeric");
                Console.ReadKey();
                throw new DroneMovementException("Invalid number of co-ordinates or co-ordinates are non-numeric");
            }
        }
    }
}
