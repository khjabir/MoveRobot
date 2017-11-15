using System;
using System.Text.RegularExpressions;

namespace MoveRobot
{

    class Program
    {
        static void Main(string[] args)
        {
            Robot robot = new Robot();
            Table table = new Table();

            if (RobotIsPlaced(robot, table))
            {
                StartMoving(robot, table);
            }

        }

        private static bool RobotIsPlaced(Robot robot, Table table)
        {
            string inputCommand = null;
            string pattern = @"\bPLACE \d,\d,[NEWS]\b";
            Regex regex = new Regex(pattern);

            while (true)
            {
                inputCommand = Console.ReadLine();
                if (regex.IsMatch(inputCommand))
                {
                    string PlaceArgs = inputCommand.Split(' ')[1];
                    int xPosition = Convert.ToInt16(PlaceArgs.Split(',')[0]);
                    int yPosition = Convert.ToInt16(PlaceArgs.Split(',')[1]);
                    int direction = Array.FindIndex(robot.directions, value => value == PlaceArgs.Split(',')[2]);
                    if(table.IsPositionExists(xPosition, yPosition))
                    {
                        robot.Placed(xPosition, yPosition, direction);
                        return true;
                    }
                }
            }
        }

        private static void StartMoving(Robot robot, Table table)
        {
            string inputCommand = null;

            while (true)
            {
                inputCommand = Console.ReadLine();
                switch(inputCommand)
                {
                    case "MOVE":
                        robot.MoveForward(table);
                        break;
                    case "LEFT":
                        robot.RotateLeft();
                        break;
                    case "RIGHT":
                        robot.RotateRight();
                        break;
                    case "REPORT":
                        robot.ReportPostion();
                        break;
                }
            }
        }
    }
}
