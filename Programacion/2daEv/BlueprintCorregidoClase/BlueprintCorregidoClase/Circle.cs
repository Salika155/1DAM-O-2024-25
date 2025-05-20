using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintCorregidoClase
{
    class Circle : Shape
    {
        //al ser struct puedo hacer esto
        public Point2D Position;
        public double Radius;

        public override bool HasArea => true;
        public override double Area => Math.PI * Radius * Radius;
        public override double Perimeter => 2 * Math.PI * Radius;
        public override Point2D Center => Position;
        public override Rect2D Rect => GetRect();

        private Rect2D GetRect()
        {
            var min = new Point2D(Position.X - Radius, Positiones.Y - Radius);
            return new Rect2D(min, Radius * 2., Radius * 2.0 );
        }

        public override void Displace(Vector2D direction)
        {
            Position.X += direction.X;
            Position.Y += direction.Y;
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.DrawCircle(canvas);
        }
    }
}
