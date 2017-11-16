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

        /// <summary>
        /// Initializes a new instance of the <see cref="Robot"/> class.
        /// </summary>
        public Robot()
        {
            Initialize();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Places the robot in the specified position.
        /// </summary>
        /// <param name="xPosition">The x position.</param>
        /// <param name="yPosition">The y position.</param>
        /// <param name="direction">The direction.</param>
        public void PlaceRobot(int xPosition, int yPosition, int direction)
        {
            robotXPosition = xPosition;
            robotYPosition = yPosition;
            robotDirection = direction;
        }

        /// <summary>
        /// Gets the robot's position index in direction array.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        public int GetDirectionIndex(string direction)
        {
            int index = Array.FindIndex(directions, value => value == direction);
            return index;
        }

        /// <summary>
        /// Moves the robot forward.
        /// </summary>
        /// <param name="table">The table.</param>
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

        /// <summary>
        /// Rotates the robot left.
        /// </summary>
        public void RotateLeft()
        {
            robotDirection = (robotDirection == 0 ? 3 : robotDirection - 1);
        }

        /// <summary>
        /// Rotates the robot right.
        /// </summary>
        public void RotateRight()
        {
            robotDirection = (robotDirection == 3 ? 0 : robotDirection + 1);
        }

        /// <summary>
        /// Reports the postion of the robot on table.
        /// </summary>
        /// <param name="table">The table.</param>
        public void ReportPostion(Table table)
        {
            Console.WriteLine(robotXPosition + "," + robotYPosition + "," + directions[robotDirection]);
            DrawPosition(table, robotXPosition, robotYPosition, robotDirection);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            robotXPosition = 0;
            robotYPosition = 0;
            robotDirection = 0;
        }

        /// <summary>
        /// Moves the robot towards north direction.
        /// </summary>
        /// <param name="table">The table.</param>
        private void MoveTowardsNorth(Table table)
        {
            if(robotYPosition + 1 < table.GetRowCount())
            {
                robotYPosition++;
            }
        }

        /// <summary>
        /// Moves the robot towards east direction.
        /// </summary>
        /// <param name="table">The table.</param>
        private void MoveTowardsEast(Table table)
        {
            if (robotXPosition + 1 < table.GetColumnCount())
            {
                robotXPosition++;
            }

        }

        /// <summary>
        /// Moves the towards south direction.
        /// </summary>
        /// <param name="table">The table.</param>
        private void MoveTowardsSouth(Table table)
        {
            if (robotYPosition > 0)
            {
                robotYPosition--;
            }
        }

        /// <summary>
        /// Moves the towards west direction.
        /// </summary>
        /// <param name="table">The table.</param>
        private void MoveTowardsWest(Table table)
        {
            if (robotXPosition > 0)
            {
                robotXPosition--;
            }
        }

        /// <summary>
        /// Draws the position.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="robotXPosition">The robot x position.</param>
        /// <param name="robotYPosition">The robot y position.</param>
        /// <param name="robotDirection">The robot direction.</param>
        private void DrawPosition(Table table, int robotXPosition, int robotYPosition, int robotDirection)
        {
            int rowCount = table.GetRowCount();
            int columnCount = table.GetColumnCount();
            Console.WriteLine();

            for (int i = rowCount - 1; i >= 0; i--)
            {
                for(int j = 0 ; j < columnCount; j++)
                {
                    if(robotXPosition == j && robotYPosition == i)
                    {
                        Console.Write("O\t");
                    }
                    else
                    {
                        Console.Write(".\t");
                    }
                }
                Console.WriteLine();
            }
        }

        #endregion


    }
}
