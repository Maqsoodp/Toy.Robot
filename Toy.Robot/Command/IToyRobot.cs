using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Robot.Command
{
    public interface IToyRobot
    {
        Report Place(Point point, string face);

        Report Move();

        Report Left();
        Report Right();

        Report Report();
    }
}
