using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Robot
{
    public class Point
    {
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point()
        {
        }
        public int x { get; set; } = 0;
        public int y { get; set; } = 0;

    }
}
