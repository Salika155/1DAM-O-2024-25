using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprint
{
    public class Vector2D
    {
        public double DX { get; }
        public double DY { get; }

        public Vector2D(double dx, double dy)
        {
            DX = dx;
            DY = dy;
        }

        public Point2D Displace(Point2D point) =>
            new Point2D(point.X + DX, point.Y + DY);

        public override string ToString() => $"({DX}, {DY})";

    }
}
