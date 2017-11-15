using System;
using System.Text.RegularExpressions;

namespace MoveRobot
{

    class Program
    {
        private const string _initializePattern = @"\bPLACE [0-4],[0-4],(NORTH|EAST|WEST|SOUTH)$";

        static void Main(string[] args)
        {
            Robot robot = new Robot();
            Table table = new Table();

            InitializeInstructions();

            if (RobotIsPlaced(robot, table))
            {
                StartMoving(robot, table);
            }

        }

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
                    robot.Placed(xPosition, yPosition, direction);
                    return true;
                }
            }
            return false;
        }

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
                        robot.ReportPostion();
                        break;
                    default:
                        CheckReplaced(table, robot, inputCommand);
                        break;
                }
            }
        }

        private static void CheckReplaced(Table table, Robot robot, string inputCommand)
        {
            if(Regex.IsMatch(inputCommand, _initializePattern))
            {
                PlaceRobotOnTable(table, robot, inputCommand);
            }
        }

        private static void InitializeInstructions()
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
