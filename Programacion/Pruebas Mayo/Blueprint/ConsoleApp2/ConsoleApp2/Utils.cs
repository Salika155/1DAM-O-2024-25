namespace ConsoleApp2
{
    public class Utils
    {
        public static double GetDistance(Point2D a, Point2D b)
        {
            double dx = a.X - b.X;
            double dy = a.Y - b.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static Rect2D GetBoundingBox(Point2D[] points)
        {
            if (points == null || points.Length == 0)
                return new Rect2D();

            Rect2D result = new Rect2D();
            result.Position = new Point2D(points[0].X, points[0].Y);

            for (int i = 1; i < points.Length; i++)
            { 
                var p = points[i];

                if (p.X < result.Position.X)
                    result.Position.X = p.X;
                else if (p.X > result.Max.X)
                    result.Max.X = p.X;
            }
            return result;
        }

    }
}
