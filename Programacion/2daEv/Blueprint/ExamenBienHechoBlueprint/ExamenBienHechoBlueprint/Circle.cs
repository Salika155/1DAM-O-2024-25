using Blueprint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Circle : Shape
{
    public Point2D CenterPoint { get; private set; }
    public double Radius { get; set; }
    private IBlueprint _owner;

    public Circle(string name, Color color, Point2D center, double radius, IBlueprint owner)
        : base(name, color)
    {
        CenterPoint = center;
        Radius = radius;
        _owner = owner;
    }

    public override bool HasArea => true;
    public override double Area => Math.PI * Radius * Radius;
    public override double Perimeter => 2 * Math.PI * Radius;
    public override Point2D Center => CenterPoint;
    public override Rect2D Rect
    {
        get => new Rect2D(
            new Point2D(CenterPoint.X - Radius, CenterPoint.Y - Radius),
            Radius * 2, Radius * 2);
        set => CenterPoint = new Point2D(value.Origin.X + Radius, value.Origin.Y + Radius);
    }

    public override IBlueprint Owner => _owner;

    public override void Displace(Vector2D direction)
    {
        CenterPoint = direction.Displace(CenterPoint);
    }

    public override void Draw(ICanvas canvas)
    {
        canvas.SetCurrentColor(Color);
        canvas.DrawCircle(Rect);
    }
}
