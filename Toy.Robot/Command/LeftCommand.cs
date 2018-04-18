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

        public override void Execute()
        {
            this._toyRobot.Left();
        }
    }
}
