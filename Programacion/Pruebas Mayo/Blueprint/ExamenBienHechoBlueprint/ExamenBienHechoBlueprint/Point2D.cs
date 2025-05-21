using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprint
{
    public class Point2D
    {
        private double _x;
        private double _y;

        public double X => _x;
        public double Y => _y;

        public Point2D(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            return ("valor x: " + _x + " valor y: " + _y);
        }
    }
}
