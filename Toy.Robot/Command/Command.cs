using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Robot.Command
{
    public abstract class Command
    {
        protected readonly IToyRobot _toyRobot;

        public Command(IToyRobot toyRobot)
        {
            this._toyRobot = toyRobot;
        }

        public abstract Report Execute();
    }
}
