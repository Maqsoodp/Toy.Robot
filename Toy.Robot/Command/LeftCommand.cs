using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Robot.Command
{
    public class LeftCommand: Command
    {
        public LeftCommand(IToyRobot toyRobot): base(toyRobot)
        {
        }

        public override Report Execute()
        {
            return this._toyRobot.Left();
        }
    }
}
