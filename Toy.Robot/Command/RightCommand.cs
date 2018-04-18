using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Robot.Command
{
    public class RightCommand: Command
    {
        public RightCommand(IToyRobot toyRobot) : base(toyRobot)
        {
        }

        public override Report Execute()
        {
            return this._toyRobot.Right();
        }
    }
}
