

namespace ConsoleApp2
{
    public interface IShape
    {
        string Name { get; set; }
        Color Color { get; }
        bool HasArea { get; }
        double Area { get; }
        double Perimeter { get; }
        Point2D Center { get; }
        Rect2D Rect { get; }

        /// <summary>
        /// A alguien de esta clase le gusta meterse
        /// cosas por el c....
        /// </summary>
        IBlueprint? Owner { get; set; }

        void Draw(ICanvas canvas); 
        void Displace(Vector2D direction);
    }



    public abstract class Shape : IShape
    {
        private string _name;
        private readonly Color _color;
        private WeakReference<IBlueprint>? _blueprint = null;

        public IBlueprint? Owner { get => GetOwner(); set => SetOwner(value); }

        private void SetOwner(IBlueprint? newParent)
        {
            var oldParent = GetOwner();
            if (newParent == oldParent)
                return;

            if (newParent == null)
            {
                _blueprint = null;
                oldParent!.RemoveShape(this);
            }
            else
            {
                if (oldParent != null)
                    oldParent.RemoveShape(this);

                // mi nuevo padre no es null
                if (newParent != null)
                {
                    newParent.AddShape(this);
                    _blueprint = new WeakReference<IBlueprint>(newParent);
                }
            }
        }

        private IBlueprint? GetOwner()
        {
            if (_blueprint == null)
                return null;
            if (_blueprint.TryGetTarget(out var result))
                return result;
            return null;
        }

        public string Name { get => _name; set => _name = value; }

        public Color Color => _color;

        public abstract bool HasArea { get; }

        public abstract double Area { get; }

        public abstract double Perimeter { get; }

        public abstract Point2D Center { get; }

        public abstract Rect2D Rect { get; }

        public Shape(string name, Color color)
        {
            _name = name;
            _color = color;
        }

        public abstract void Displace(Vector2D direction);

        public abstract void Draw(ICanvas canvas);
    }



    public class Circle : Shape
    {
        public Point2D Position;
        public double Redius;

        public Circle(string name, Color color) : base(name, color)
        {
        }

        public override bool HasArea => true;

        public override double Area => Math.PI * Redius * Redius;

        public override double Perimeter => 2 * Math.PI * Redius;

        public override Point2D Center => Position;

        public override Rect2D Rect => GetRect();

        private Rect2D GetRect()
        {
            var min = new Point2D(Position.X - Redius, Position.Y - Redius);
            return new Rect2D(min, Redius * 2.0, Redius * 2.0);
        }

        public override void Displace(Vector2D direction)
        {
            Position.X += direction.X;
            Position.Y += direction.Y;
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.DrawCircle(Rect);
        }
    }

}
