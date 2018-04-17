using System;
using System.Collections;
using System.Collections.Generic;

namespace Toy.Robot
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var robot = new ToyRobot(5, 5);
            robot.Place(new Point(), "North");
            robot.Right();
            robot.Move();
            robot.Left();
            robot.Report();

            robot.Place(new Point(4, 4), "North");
            robot.Right();
            robot.Left();
            robot.Move();
            robot.Left();
            robot.Move();
            robot.Report();

            robot.Place(new Point(0, 4), "South");
            robot.Right();
            robot.Move();
            robot.Left();
            robot.Move();
            robot.Report();

            robot.Place(new Point(5, 5), "South");
            robot.Report();

            Console.ReadKey();
        }
    }
}
