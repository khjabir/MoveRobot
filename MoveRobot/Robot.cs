using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveRobot
{
    public class Robot
    {
        #region Constants

        private const int _north = 0;
        private const int _east = 1;
        private const int _south = 2;
        private const int _west = 3;

        public string[] directions = { "NORTH", "EAST", "SOUTH", "WEST" };

        #endregion

        #region Private Members

        private int robotXPosition;
        private int robotYPosition;
        private int robotDirection;

        #endregion

        #region Constructor

        public Robot()
        {
            Initialize();
        }

        #endregion

        #region Public Methods

        public void Placed(int xPosition, int yPosition, int direction)
        {
            robotXPosition = xPosition;
            robotYPosition = yPosition;
            robotDirection = direction;
        }

        public int GetDirectionIndex(string direction)
        {
            int index = Array.FindIndex(directions, value => value == direction);
            return index;
        }

        public void MoveForward(Table table)
        {
            switch(robotDirection)
            {
                case _north:
                    MoveTowardsNorth(table);
                    break;
                case _east:
                    MoveTowardsEast(table);
                    break;
                case _south:
                    MoveTowardsSouth(table);
                    break;
                case _west:
                    MoveTowardsWest(table);
                    break;
            }
        }

        public void RotateLeft()
        {
            robotDirection = (robotDirection == 0 ? 3 : robotDirection - 1);
        }

        public void RotateRight()
        {
            robotDirection = (robotDirection == 3 ? 0 : robotDirection + 1);
        }

        public void ReportPostion()
        {
            Console.WriteLine(robotXPosition + "," + robotYPosition + "," + directions[robotDirection]);
        }

        #endregion

        #region Private Methods

        private void Initialize()
        {
            robotXPosition = 0;
            robotYPosition = 0;
            robotDirection = 0;
        }

        private void MoveTowardsNorth(Table table)
        {
            if(robotYPosition + 1 < table.getRowValue())
            {
                robotYPosition++;
            }
        }

        private void MoveTowardsEast(Table table)
        {
            if (robotXPosition + 1 < table.getColumnValue())
            {
                robotXPosition++;
            }

        }

        private void MoveTowardsSouth(Table table)
        {
            if (robotYPosition > 0)
            {
                robotYPosition--;
            }
        }

        private void MoveTowardsWest(Table table)
        {
            if (robotXPosition > 0)
            {
                robotXPosition--;
            }
        }

        #endregion


    }
}
