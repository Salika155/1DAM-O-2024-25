using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprint
{
    public class Vector2D
    {
        private List<Point2D> _points;
        private Point2D? _min;
        private Point2D? _max;

        public Point2D? Min => _min;
        public Point2D? Max => _max;

        public Vector2D(Point2D? point1, Point2D? point2)
        {
            if (point1 == null || point2 == null)
                throw new Exception();
            _min = point1;
            _max = point2;
        }


    }
}
