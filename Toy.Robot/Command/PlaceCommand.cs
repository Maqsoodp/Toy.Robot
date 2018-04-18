using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Robot.Command
{
    public class PlaceCommand : Command
    {
        private Point _point;
        private string _face;

        public PlaceCommand(IToyRobot toyRobot, Point point, string face): base(toyRobot)
        {
            this._point = point;
            this._face = face;
        }

        public override Report Execute()
        {
            return this._toyRobot.Place(this._point, this._face);
        }
    }
}
