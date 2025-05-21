using Blueprint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Rectangle : Shape
{
    private Point2D _origin;
    public double Width { get; private set; }
    public double Height { get; private set; }
    private IBlueprint _owner;

    public Rectangle(string name, Color color, Point2D origin, double width, double height, IBlueprint owner)
        : base(name, color)
    {
        _origin = origin;
        Width = width;
        Height = height;
        _owner = owner;
    }

    public override bool HasArea => true;
    public override double Area => Width * Height;
    public override double Perimeter => 2 * (Width + Height);
    public override Point2D Point => new Point2D(_origin.X + Width / 2, _origin.Y + Height / 2);
    public override Rect2D Rect
    {
        get => new Rect2D(_origin, Width, Height);
        set
        {
            _origin = value.Origin;
            Width = value.Width;
            Height = value.Height;
        }
    }

    public override IBlueprint Owner => _owner;

    public override void Displace(Vector2D direction)
    {
        _origin = direction.Displace(_origin);
    }

    public Point2D GetCorner(int index)
    {
        return index switch
        {
            0 => _origin,
            1 => new Point2D(_origin.X + Width, _origin.Y),
            2 => new Point2D(_origin.X + Width, _origin.Y + Height),
            3 => new Point2D(_origin.X, _origin.Y + Height),
            _ => throw new ArgumentOutOfRangeException(nameof(index), "Índice debe estar entre 0 y 3")
        };
    }

    public override void Draw(ICanvas canvas)
    {
        canvas.SetCurrentColor(Color);
        var points = new[]
        {
            GetCorner(0),
            GetCorner(1),
            GetCorner(2),
            GetCorner(3)
        };
        canvas.DrawPolygon(points);
    }
}