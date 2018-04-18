using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Robot.Command
{
    public class MoveCommand: Command
    {
        public MoveCommand(IToyRobot toyRobot): base(toyRobot)
        {
        }

        public override void Execute()
        {
            this._toyRobot.Move();
        }
    }
}
