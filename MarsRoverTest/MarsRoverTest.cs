using MarsRover.Services;
using MarsRover.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MarsRoverTest
{
    public class MarsRoverTest
    {
        [Test]
        public void PositiveTestScenario1()
        {
            List<int> maximumPositions = new List<int>() { 5, 5 };

            PositionService positionService = new PositionService(maximumPositions)
            {
                X = 1,
                Y = 2,
                Direction = Directions.N
            };

            var movements = "LMLMLMLMM";

            positionService.Move(movements);

            var result = $"{positionService.X} {positionService.Y} {positionService.Direction}";
            var expectedResult = "1 3 N";

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void PositiveTestScenario2()
        {
            List<int> maximumPositions = new List<int>() { 5, 5 };

            PositionService positionService = new PositionService(maximumPositions)
            {
                X = 3,
                Y = 3,
                Direction = Directions.E
            };

            var movements = "MRRMMRMRRM";

            positionService.Move(movements);

            var result = $"{positionService.X} {positionService.Y} {positionService.Direction}";
            var expectedResult = "2 3 S";

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void NegativeTestScenario1()
        {
            List<int> maximumPositions = new List<int>() { 5, 5 };

            PositionService positionService = new PositionService(maximumPositions)
            {
                X = 1,
                Y = 2,
                Direction = (Directions)Enum.Parse(typeof(Directions), "C")
            };

            var movements = "LMLMLMLMM";

            positionService.Move(movements);

            var result = $"{positionService.X} {positionService.Y} {positionService.Direction}";
            var expectedResult = "1 3 N";

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void NegativeTestScenario2()
        {
            List<int> maximumPositions = new List<int>() { 5, 5 };

            PositionService positionService = new PositionService(maximumPositions)
            {
                X = 2,
                Y = 2,
                Direction = Directions.N
            };

            var movements = "LMLMLMLMMLM";

            positionService.Move(movements);

            var result = $"{positionService.X} {positionService.Y} {positionService.Direction}";
            var expectedResult = "1 3 N";

            Assert.AreEqual(expectedResult, result);
        }
    }
}