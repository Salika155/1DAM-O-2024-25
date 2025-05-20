using Blueprint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Segment : Shape
{
    public Point2D A { get; private set; }
    public Point2D B { get; private set; }
    private IBlueprint _owner;

    public Segment(string name, Color color, Point2D a, Point2D b, IBlueprint owner)
        : base(name, color)
    {
        A = a;
        B = b;
        _owner = owner;
    }

    public override bool HasArea => false;
    public override double Area => 0;
    public override double Perimeter => Utils.GetDistance(A, B);
    public override Point2D Point => new Point2D((A.X + B.X) / 2, (A.Y + B.Y) / 2);

    public override Rect2D Rect
    {
        get => Utils.GetBoundingBox(new[] { A, B });
        set
        {
            // No implementación necesaria para segmentos
        }
    }

    public override IBlueprint Owner => _owner;

    public override void Displace(Vector2D direction)
    {
        A = direction.Displace(A);
        B = direction.Displace(B);
    }

    public override void Draw(ICanvas canvas)
    {
        canvas.SetCurrentColor(Color);
        canvas.DrawPolygon(new[] { A, B });
    }
}
