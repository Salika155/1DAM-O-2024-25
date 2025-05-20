using Blueprint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Point : Shape
{
    private Point2D _position;
    private IBlueprint _owner;

    public Point(string name, Color color, Point2D position, IBlueprint owner)
        : base(name, color)
    {
        _position = position;
        _owner = owner;
    }

    public override bool HasArea => false;
    public override double Area => 0;
    public override double Perimeter => 0;
    public override Point2D Point => _position;

    public override Rect2D Rect
    {
        get => new Rect2D(_position, 0, 0);
        set => _position = value.Origin;
    }

    public override IBlueprint Owner => _owner;

    public override void Displace(Vector2D direction)
    {
        _position = direction.Displace(_position);
    }

    public override void Draw(ICanvas canvas)
    {
        canvas.SetCurrentColor(Color);
        canvas.DrawPolygon(new[] { _position }); // O simular un punto
    }
}
