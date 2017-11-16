using System;
using System.Text.RegularExpressions;

namespace MoveRobot
{

    class Program
    {
        private const string _initializePattern = @"\bPLACE [0-4],[0-4],(NORTH|EAST|WEST|SOUTH)$";

        /// <summary>
        /// Program enters here
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Robot robot = new Robot();
            Table table = new Table();

            DisplayInstructions();

            if (RobotIsPlaced(robot, table))
            {
                StartMoving(robot, table);
            }

        }

        /// <summary>
        /// CHeck whether robot is placed or not
        /// </summary>
        /// <param name="robot"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        private static bool RobotIsPlaced(Robot robot, Table table)
        {
            string inputCommand = null;
            while (inputCommand != "EXIT")
            {
                inputCommand = Console.ReadLine();
                if (Regex.IsMatch(inputCommand, _initializePattern))
                {
                   return PlaceRobotOnTable(table, robot, inputCommand);
                }
            }

            return false;
        }

        /// <summary>
        /// Places the robot on table in the specified position in input command
        /// </summary>
        /// <param name="table"></param>
        /// <param name="robot"></param>
        /// <param name="inputCommand"></param>
        /// <returns></returns>
        private static bool PlaceRobotOnTable(Table table, Robot robot, string inputCommand)
        {
            string PlaceArgs = inputCommand.Split(' ')[1];
            int xPosition = Convert.ToInt16(PlaceArgs.Split(',')[0]);
            int yPosition = Convert.ToInt16(PlaceArgs.Split(',')[1]);
            int direction = robot.GetDirectionIndex(PlaceArgs.Split(',')[2]);
            if (direction >= 0)
            {
                if (table.IsPositionExists(xPosition, yPosition))
                {
                    robot.PlaceRobot(xPosition, yPosition, direction);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Robot starts moving on the table
        /// </summary>
        /// <param name="robot"></param>
        /// <param name="table"></param>
        private static void StartMoving(Robot robot, Table table)
        {
            string inputCommand = null;

            while (inputCommand != "EXIT")
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
                        robot.ReportPostion(table);
                        break;
                    default:
                        CheckAndReplace(table, robot, inputCommand);
                        break;
                }
            }
        }

        /// <summary>
        /// Handles all other commands and replaces if PLACE command issued while moving
        /// </summary>
        /// <param name="table"></param>
        /// <param name="robot"></param>
        /// <param name="inputCommand"></param>
        private static void CheckAndReplace(Table table, Robot robot, string inputCommand)
        {
            if(Regex.IsMatch(inputCommand, _initializePattern))
            {
                PlaceRobotOnTable(table, robot, inputCommand);
            }
        }

        /// <summary>
        /// Displays the instructions to user
        /// </summary>
        private static void DisplayInstructions()
        {
            string instructions =
                "******************************************************************\n" +
                "\t\t\t COMMANDS \n" +
                "\t\t\t----------\n" +
                "1) PLACE X,Y,F \t=> Places Robot on table in (X,Y) facing towards F.\n\n" +
                "\t\t\t (0,0) <= (X,Y) <= (4,4)\n" +
                "\t\t\t F => 'NORTH | EAST | WEST | SOUTH' \n" +
                "\t\t\t (0,0) => SOUTH WEST most corner\n\n" +
                "2) MOVE \t=> Move one unit forward \n" +
                "3) RIGHT \t=> Rotates 90 degree right\n" +
                "4) LEFT \t=> Rotates 90 degree left\n" +
                "5) REPORT \t=> Announces X, Y and F\n" +
                "6) EXIT \t=> Exit from the application\n" +
                "******************************************************************\n";
            Console.WriteLine(instructions);
        }
    }
}
