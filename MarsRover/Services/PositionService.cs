using MarsRover.Utils;
using System;
using System.Collections.Generic;

namespace MarsRover.Services
{
    public class PositionService
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Directions Direction { get; set; }

        private List<int> MaximumPositions { get; set; }

        public PositionService(List<int> maximumPositions)
        {
            this.MaximumPositions = maximumPositions;
        }

        #region Movement Operations
        public void Move(string movements)
        {
            foreach (var movement in movements)
            {
                switch (movement)
                {
                    case 'M':
                        this.MoveWithSameDirection();
                        break;
                    case 'L':
                        this.Turn90DegreeLeft();
                        break;
                    case 'R':
                        this.Turn90DegreeRight();
                        break;
                }
            }

            if (this.X < 0 || this.X > this.MaximumPositions[0] || this.Y < 0 || this.Y > this.MaximumPositions[1])
            {
                throw new Exception("Cannot move that direction. It is out of maximum given range.");
            }
        }

        private void MoveWithSameDirection()
        {
            //  We have to protect our direction so just change the position
            switch (this.Direction)
            {
                case Directions.N:
                    this.Y += 1;
                    break;
                case Directions.S:
                    this.Y -= 1;
                    break;
                case Directions.E:
                    this.X += 1;
                    break;
                case Directions.W:
                    this.X -= 1;
                    break;
            }
        }
        #endregion

        #region Turn Operations
        private void Turn90DegreeLeft()
        {
            //  Positions are same. Only change the direction
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.W;
                    break;
                case Directions.S:
                    this.Direction = Directions.E;
                    break;
                case Directions.E:
                    this.Direction = Directions.N;
                    break;
                case Directions.W:
                    this.Direction = Directions.S;
                    break;
            }
        }

        private void Turn90DegreeRight()
        {
            //  Positions are same. Only change the direction
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.E;
                    break;
                case Directions.S:
                    this.Direction = Directions.W;
                    break;
                case Directions.E:
                    this.Direction = Directions.S;
                    break;
                case Directions.W:
                    this.Direction = Directions.N;
                    break;
            }
        }
        #endregion
    }
}
