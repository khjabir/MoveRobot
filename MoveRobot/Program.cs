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
            Table table = new Table(5,5);

            DisplayInstructions();

            if (IsValidPlaceCommand(robot, table))
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
        private static bool IsValidPlaceCommand(Robot robot, Table table)
        {
            string inputCommand = null;
            while (inputCommand != "EXIT")
            {
                inputCommand = Console.ReadLine();
                if (PlaceCommandRegexMatches(inputCommand))
                {
                   return PlaceRobotOnTable(table, robot, inputCommand);
                }
                else if(inputCommand.Equals("HELP"))
                {
                    DisplayInstructions();
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
            string[] placeArgs = inputCommand.Split(' ')[1].Split(',');
            int xPosition = Convert.ToInt16(placeArgs[0]);
            int yPosition = Convert.ToInt16(placeArgs[1]);
            int direction = GetDirectionIndex(placeArgs[2]);

            if (table.IsPositionExists(xPosition, yPosition))
            {
                robot.PlaceRobot(xPosition, yPosition, direction);
                return true;
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
                        robot.Rotate(inputCommand);
                        break;
                    case "RIGHT":
                        robot.Rotate(inputCommand);
                        break;
                    case "REPORT":
                        robot.ReportPostion(table);
                        break;
                    case "HELP":
                        DisplayInstructions();
                        break;
                    default:
                        CheckForValidPlaceCommand(table, robot, inputCommand);
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
        private static void CheckForValidPlaceCommand(Table table, Robot robot, string inputCommand)
        {
            if(PlaceCommandRegexMatches(inputCommand))
            {
                PlaceRobotOnTable(table, robot, inputCommand);
            }
        }

        /// <summary>
        /// Checks whether PLACE command is in proper format or not.
        /// </summary>
        /// <param name="inputCommand">The input command.</param>
        /// <returns></returns>
        private static bool PlaceCommandRegexMatches(string inputCommand)
        {
            return Regex.IsMatch(inputCommand, _initializePattern);
        }

        /// <summary>
        /// Gets the index of the direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        private static int GetDirectionIndex(string direction)
        {
            return (int)Enum.Parse(typeof(Robot.Directions), direction);
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
                "6) HELP \t=> List the commands\n" +
                "7) EXIT \t=> Exit from the application\n" +
                "******************************************************************\n";
            Console.WriteLine(instructions);
        }
    }
}
