
namespace ConsoleApp2
{
    public struct Point2D
    {
        public double X;
        public double Y;

        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    public struct Vector2D
    {
        public double X;
        public double Y;

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    public struct Rect2D
    {
        public Point2D Position;
        public double Width;
        public double Height;

        public Point2D MinPosition => Position;
        public Point2D MaxPosition => new Point2D(Position.X + Width, Position.Y + Height);

        public Rect2D(Point2D position, double width, double height)
        {
            Position = position;
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"X: {Position.X}, Y: {Position.Y}, W: {Width}, H: {Height}";
        }
    }

    public struct Color
    {
        public double R;
        public double G;
        public double B;

        public Color(double r, double g, double b)
        {
            R = r;
            G = g;
            B = b;
        }
    }

    public interface ICanvas
    {
        void SetCurrentColor(Color color);
        void DrawPolygon(Point2D[] points);
        void DrawCircle(Rect2D rect);
    }

    public class Canvas : ICanvas
    {
        public void DrawCircle(Rect2D rect)
        {
            Console.WriteLine($"Dibujando círculo en {rect.ToString()}");
        }

        public void DrawPolygon(Point2D[] points)
        {
        }

        public void SetCurrentColor(Color color)
        {
        }
    }
}
