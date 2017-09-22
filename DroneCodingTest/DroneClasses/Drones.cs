using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DroneCodingTest.DroneException;

namespace DroneCodingTest.DroneClasses
{
   
    public class Drones
    {
        private Battlefield battlefield;
        public string[] initialPositionOfDrone;

        public Drones(Battlefield battlefield, string initialPositionAndDirection, string movementCommands)
        {
            this.battlefield = battlefield;
            initialPositionOfDrone = initialPositionAndDirection.Split(' ');
            if (initialPositionOfDrone.Count() == 3)
            {
                if ((Convert.ToInt32(initialPositionOfDrone[0]) <= battlefield.upperRightColumnValue || Convert.ToInt32(initialPositionOfDrone[1]) <= battlefield.upperRightRowValue))
                {
                    if (!Regex.IsMatch(movementCommands, @"^[a-zA-Z]+$"))
                    {
                        Console.WriteLine("Invalid navigation command for Drone");
                        Console.ReadKey();
                        throw new DroneMovementException("Invalid navigation command for Drone");
                    }
                    else
                    {
                        foreach (char c in movementCommands)
                        {
                            if (c == 'L' || c == 'R')
                            {
                                ChangeDroneDirection(c, Convert.ToChar(initialPositionOfDrone[2].ToString().ToUpper()));
                            }
                            if (c == 'M')
                            {
                                MoveDrone();
                            }
                        }
                        //Display the final position co-ordinates of the Drone
                        Console.WriteLine("{0} {1} {2}", initialPositionOfDrone[0].ToString(), initialPositionOfDrone[1].ToString(), initialPositionOfDrone[2].ToString().ToUpper());
                    }
                }
                else
                {
                    Console.WriteLine("Invalid start position values for Drone");
                    Console.ReadKey();
                    throw new DroneMovementException("Invalid start position values for Drone");
                }
            }
            else
            {
                Console.WriteLine("Invalid number of navigation parameters");
                Console.ReadKey();
                throw new DroneMovementException("Invalid number of navigation parameters");
            }
        }

        /// <summary>
        /// Method to move the drone
        /// </summary>
        /// <returns></returns>
        private bool MoveDrone()
        {

            string currentFacingDirection = string.Empty;
            int currentPositionRow = 0;
            int currentPositionCol = 0;

            currentFacingDirection = initialPositionOfDrone[2].ToString();
            currentPositionCol = Convert.ToInt32(initialPositionOfDrone[0]);
            currentPositionRow = Convert.ToInt32(initialPositionOfDrone[1]);

            if (currentFacingDirection.ToUpper() == "N")
            {
                if (currentPositionRow == battlefield.upperRightRowValue)
                {
                    return false;
                }
                else
                {
                    currentPositionRow = currentPositionRow + 1;
                    initialPositionOfDrone[1] = currentPositionRow.ToString();
                }
            }

            if (currentFacingDirection.ToUpper() == "E")
            {
                if (currentPositionCol == battlefield.upperRightColumnValue)
                {
                    return false;
                }
                else
                {
                    currentPositionCol = currentPositionCol + 1;
                    initialPositionOfDrone[0] = currentPositionCol.ToString();
                }
            }

            if (currentFacingDirection.ToUpper() == "W")
            {
                if (currentPositionCol == 0)
                {
                    return false;
                }
                else
                {
                    currentPositionCol = currentPositionCol - 1;
                    initialPositionOfDrone[0] = currentPositionCol.ToString();
                }
            }

            if (currentFacingDirection.ToUpper() == "S")
            {
                if (currentPositionRow == 0)
                {
                    return false;
                }
                else
                {
                    currentPositionRow = currentPositionRow - 1;
                    initialPositionOfDrone[1] = currentPositionRow.ToString();
                }
            }
            return true;
        }

        /// <summary>
        /// Method to change the direction of the Drone by passing direction and currentHeadedDirection
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="currentHeadedDirection"></param>
        private void ChangeDroneDirection(char direction, char currentHeadedDirection)
        {
            string newDirection = string.Empty;
            string currentDirection = string.Empty;

            if (direction == 'R')
            {
                if (currentHeadedDirection == 'N')
                    newDirection = "E";
                if (currentHeadedDirection == 'E')
                    newDirection = "S";
                if (currentHeadedDirection == 'W')
                    newDirection = "N";
                if (currentHeadedDirection == 'S')
                    newDirection = "W";
            }

            if (direction == 'L')
            {
                if (currentHeadedDirection == 'N')
                    newDirection = "W";
                if (currentHeadedDirection == 'E')
                    newDirection = "N";
                if (currentHeadedDirection == 'W')
                    newDirection = "S";
                if (currentHeadedDirection == 'S')
                    newDirection = "E";
            }
            initialPositionOfDrone[2] = newDirection;
            
        }
    }
}
