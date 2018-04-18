using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Robot.Command
{
    public interface IToyRobot
    {
        void Place(Point point, string face);

        void Move();

        void Left();
        void Right();

        void Report();
    }
}
