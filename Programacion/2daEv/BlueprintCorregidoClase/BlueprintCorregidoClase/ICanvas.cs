using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintCorregidoClase
{
    interface ICanvas
    {
        void DrawCircle(ICanvas canvas);
    }

    public struct Point2D
    {

    }

    public struct Vector2D
    {

    }

    public struct Rect2D
    {
        public Point2D Position;
        public double Width;
        public double Height;

        public Point2D MaxPosition => new Point2D(Position.X + Width, Position.Y + Height);

        public Point2D MinPosition => Position;

        public Rect2D(Point2D position, double width, double height);

        public override string ToString()
        {
            return $"X: {Position.X} Y, {Position.Y}";

        }
    }

    public struct Color
    {
        public double R;
        public double G;
        public double B;
    }
}
