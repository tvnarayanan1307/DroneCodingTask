using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneCodingTest.DroneException
{
    class DroneMovementException : Exception
    {
        public DroneMovementException(string message): base(message)
        {

        }
    }
}
