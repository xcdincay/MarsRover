using MarsRover.Services;
using MarsRover.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    class Program
    {
        static void Main()
        {
            //  Max positions for the movement. Trim and Split used for the spaces
            List<int> maximumPositions = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            //  Defined as a string array because split for the business logic
            string[] startingPositionArray = Console.ReadLine().Trim().Split(' ');

            // Checkin Position Count
            if (startingPositionArray.Count() == 3)
            {
                // Using the DI for the instance
                PositionService positionService = new PositionService(maximumPositions)
                {
                    X = Int32.Parse(startingPositionArray[0]),
                    Y = Int32.Parse(startingPositionArray[1])
                };

                // Check the input direction
                if (Enum.GetNames(typeof(Directions)).Any(c => c == startingPositionArray[2]))
                    positionService.Direction = (Directions)Enum.Parse(typeof(Directions), startingPositionArray[2]);
                else
                    throw new Exception("Invalid direction entered.");

                // Get Movements as a string because we can iterate string. Just sure that uppercase
                var movements = Console.ReadLine().ToUpper();

                try
                {
                    positionService.Move(movements);
                    Console.WriteLine($"{positionService.X} {positionService.Y} {positionService.Direction}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
                Console.WriteLine("Positions have to be 3 characters.");

            Console.ReadLine();
        }
    }
}
