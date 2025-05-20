using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprint
{
    class Utils
    {
        public double GetDistance(Point2D a, Point2D b)
        {
            double distance = 0;

            return distance;
        }

        public Rect2D GetBoundingBox(Point2D[] points)
        {
            Rect2D rect = new Rect2D(1, 2, 4, 2);

            return rect;
        }

        public double GetArea(Point2D[] points)
        {
            double area = 0;

            return area;
        }

        public double GetPerimeter(Point2D[] points)
        {
            if (points == null)
                throw new Exception();
            double perimeter = 0;
            for(int i = 0; i < points.Length; i++)
            {
                
            }
            return perimeter;
        }
    }
}
