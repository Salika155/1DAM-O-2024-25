using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprint
{
    public class Rect2D
    {
        public Point2D Origin { get; }
        public double Width { get; }
        public double Height { get; }

        public Rect2D(Point2D origin, double width, double height)
        {
            if (width < 0 || height < 0)
                throw new ArgumentException("Width and height must be non-negative");

            Origin = origin;
            Width = width;
            Height = height;
        }

        public override string ToString() => $"({Origin}, {Width}), {Height}";
    }
}
