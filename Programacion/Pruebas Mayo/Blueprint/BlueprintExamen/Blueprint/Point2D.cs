using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprint
{
    public class Point2D
    {
        private int _x;
        private int _y;

        public int X => _x;
        public int Y => _y;

        public Point2D(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}
