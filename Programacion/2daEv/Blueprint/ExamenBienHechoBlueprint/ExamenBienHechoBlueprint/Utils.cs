using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprint
{
    class Utils
    {
        public static double GetDistance(Point2D a, Point2D b)
        {
            double dx = a.X - b.X;
            double dy = a.Y - b.Y;
            return Math.Sqrt((dx * dx) + (dy * dy));
        }

        public static Rect2D GetBoundingBox(Point2D[] points)
        {
            if (points == null)
                throw new Exception();
            double minX = points[0].X, maxX = points[0].X;
            double minY = points[0].Y, maxY = points[0].Y;

            foreach(var p in points)
            {
                if (p.X < minX) minX = p.X;
                if (p.X > maxX) maxX = p.X;
                if (p.Y < minY) minY = p.Y;
                if (p.Y > maxY) maxY = p.Y;
            }
            return new Rect2D(new Point2D(minX, minY), maxX - minX, maxY - minY);
        }

        public static double GetArea(Point2D[] points)
        {
            if (points == null || points.Length < 3)
                return 0;

            double area = 0;
            int n = points.Length;
            for(int i = 0; i < n; i++)
            {
                Point2D actual = points[i];
                Point2D siguiente = points[(i + 1) % n];
                area += ((actual.Y + siguiente.Y) * (actual.X - siguiente.X));
            }
            return Math.Abs(area) / 2.0;
        }

        public static double GetPerimeter(Point2D[] points)
        {
            if (points == null || points.Length < 2)
                return 0;
            double perimeter = 0;
            int n = points.Length;

            for(int i = 0; i < n; i++)
            {
                Point2D current = points[i];
                Point2D next = points[(i + 1) % n];
                perimeter += GetDistance(current, next);
            }
            return perimeter;
        }
    }
}
