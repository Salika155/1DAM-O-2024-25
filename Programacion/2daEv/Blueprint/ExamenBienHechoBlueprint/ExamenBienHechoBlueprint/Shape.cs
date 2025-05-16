using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprint
{
    public abstract class Shape : IShape
    {
        private string? _name = string.Empty;
        private Color _color;
        private bool _hasArea;
        private double _area;
        private double _perimeter;
        private Point2D _center;
        private Rect2D _rect;
        private Blueprint _blueprint;

        public string Name
        {
            get
            {
                if (_name == null)
                    throw new Exception();
                return _name;
            }
            set => _name = value;
        }

        public Color Color { get => _color; set => _color = value; }

        public abstract bool HasArea { get; }

        public abstract double Area { get; }

        public abstract double Perimeter { get; }

        public abstract Point2D Center { get; }

        public abstract Rect2D Rect { get; set; }

        public abstract IBlueprint Owner { get; }

        public Shape(string name, Color color)
        {
            Name = name;
            Color = color;
        }

        public abstract void Draw(ICanvas canvas);
        public abstract void Displace(Vector2D direction);
        //public abstract double GetArea();
        //public abstract IBlueprint GetOwner();
    }
}
