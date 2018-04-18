using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Robot.Command
{
    public class ReportCommand: Command
    {
        public ReportCommand(IToyRobot toyRobot) : base(toyRobot)
        {
        }

        public override void Execute()
        {
            this._toyRobot.Report();
        }
    }
}
