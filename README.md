# MoveRobot
C# Console Application

The application is a simulation of a toy robot moving on a square tabletop, of dimensions 5 units x 5 units.
There are no other obstructions on the table surface.
The robot is free to roam around the surface of the table, and is prevented from falling to destruction. Any movement that would result in the robot falling from the table is prevented, however further valid movement commands must still be
allowed.

Allowed Commands :

* PLACE X,Y,F
* MOVE
* LEFT
* RIGHT
* REPORT

In addition to these commands, EXIT and HELP Commands are also added so that user can quit the application or get an overview of the allowed commands at any time.

PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.
The origin (0,0) is considered to be the SOUTH WEST most corner.
The first valid command to the robot is a PLACE command, after that, any sequence of commands may be issued, in any order, including another PLACE command.
The application should discard all commands in the sequence until a valid PLACE command has been executed.

MOVE will move the toy robot one unit forward in the direction it is currently facing.

LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.

REPORT will announce the X,Y and F of the robot. For User experiance, a matrix representation of the position is also provided.

A robot that is not on the table will ignore the MOVE, LEFT, RIGHT and REPORT commands.

User can enter the input commands directly to the console application


Example Input and Output:

PLACE 0,1,NORTH

MOVE

RIGHT

REPORT

0,2,EAST

```
.       .       .       .       .

.       .       .       .       .

O       .       .       .       .

.       .       .       .       .

.       .       .       .       .
```

PLACE 4,3,EAST

RIGHT

RIGHT

MOVE

REPORT

3,3,WEST

```
.       .       .       .       .

.       .       .       O       .

.       .       .       .       .

.       .       .       .       .

.       .       .       .       .
```
