# Toy Robot Simulator

### Description
-----------

- The application is a simulation of a toy robot moving on a square tabletop,
  of dimensions 5 units x 5 units.
- There are no other obstructions on the table surface.
- The robot is free to roam around the surface of the table, but must be
  prevented from falling to destruction. Any movement that would result in the
  robot falling from the table must be prevented, however further valid
  movement commands must still be allowed.

### Table

The table top size can be of any rows and columns, for E.g. 3,4 or 4,4 or 5,5. 

##### Direction assumptions  -

* 0,0 is North West
* 0,4 is North East
* 4,0 is South West
* 4,4 is South East

##### For E.g. Table of 5X5 with (x,y) denoting cell postions

| (0,0) | (0,1) | (0,2) | (0,3) | (0,4) |
| ------ | ------ | ------ | ------ | ------ |
| (1,0) | (1,1) | (1,2) | (1,3) | (1,4) |
| (2,0) | (2,1) | (2,2) | (2,3) | (2,4) |
| (3,0) | (3,1) | (3,2) | (3,3) | (3,4) |
| (4,0) | (4,1) | (4,2) | (4,3) | (4,4) |



### Development
The solution contains two projects -

* Toy.Robot is coded in using c# as a .Net Framework Console application. 
* Toy.Robot.UniTest is another project contains unit testing using Nunit Framework.


### Build and run code

Open the solution in visual studio IDE and press F5. this will launch a console with instructions.

Provide table size:
```sh
5,5
```
Place the robot with following command:
```sh
place 0 0 north
```
use other commands to move the Toy robot as many times as you wish. To exit from the code type exit and enter.

```sh
move
right
left
report
exit
```


