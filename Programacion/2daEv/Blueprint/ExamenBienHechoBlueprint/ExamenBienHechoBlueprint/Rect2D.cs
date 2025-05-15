using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprint
{
    public class Rect2D
    {
        private double _minX;
        private double _minY;
        private double _maxX;
        private double _maxY;

        public double MinX => _minX;
        public double MinY => _minY;
        public double MaxX => _maxX;
        public double MaxY => _maxY;

        public Rect2D(double minx, double miny, double maxx, double maxy)
        {
            _minX = minx;
            _minY = miny;
            _maxX = maxx;
            _maxY = maxy;
        }

    }
}
