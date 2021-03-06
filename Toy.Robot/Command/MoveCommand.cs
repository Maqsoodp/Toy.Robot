﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Robot.Command
{
    public class MoveCommand: Command
    {
        public MoveCommand(IToyRobot toyRobot): base(toyRobot)
        {
        }

        public override Report Execute()
        {
            return this._toyRobot.Move();
        }
    }
}
