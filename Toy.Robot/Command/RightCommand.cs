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

        public override void Execute()
        {
            this._toyRobot.Right();
        }
    }
}
