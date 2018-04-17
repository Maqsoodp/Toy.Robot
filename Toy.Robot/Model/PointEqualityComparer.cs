using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Robot
{
    public class PointEqualityComparer : IEqualityComparer<Point>
    {
        public bool Equals(Point p1, Point p2)
        {
            if (p2 == null && p1 == null)
                return true;
            else if (p1 == null | p2 == null)
                return false;
            else if (p1.y == p2.y && p1.x == p2.x)
                return true;
            else
                return false;
        }

        public int GetHashCode(Point p)
        {
            int hCode = p.y ^ p.x;
            return hCode.GetHashCode();
        }
    }
}
