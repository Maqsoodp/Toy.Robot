using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Robot
{
    public class Report
    {
        public Report()
        {
            this.Point = new Point();
            this.Face = "North";
        }

        public Report(Point point, string face)
        {
            this.Point = point;
            this.Face = face;
        }

        public Point Point { get; set; }
        public string Face { get; set; }
    }
}
