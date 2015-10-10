using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uwarcraft.Game
{
    public class Point :IEquatable<Point>
    {
        public int x, y;
        public Point(int x = 0, int y = 0) { this.x = x; this.y = y; }

        public bool Equals(Point other)
        {
            return (this.x == other.x && this.y == other.y);
        }

        public override string ToString() { return "{" + x + ',' + y + "}"; }
        public static bool operator ==(Point A, Point B)
        {
            return (A.x == B.x && A.y == B.y);
        }
        public static bool operator !=(Point A, Point B)
        {
            return (A.x != B.x || A.y != B.y);
        }

    }
}
