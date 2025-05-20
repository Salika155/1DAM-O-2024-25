using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprint
{
    // Clase abstracta Shape que implementa la interfaz IShape.
    public abstract class Shape : IShape
    {
        private string? _name = string.Empty;
        private readonly Color _color;
        private bool _hasArea;
        private double _area;
        private double _perimeter;
        private Point2D _center;
        private Rect2D _rect;
        // Campo que almacena una referencia débil al propietario (Blueprint) de la forma.
        private WeakReference<IBlueprint>? _blueprint;

        public string? Name { get => _name; set => _name = value; }
        public Color Color { get; }
        public abstract bool HasArea { get; }
        public abstract double Area { get; }
        public abstract double Perimeter { get; }
        public abstract Point2D Point { get; }
        public abstract Rect2D Rect { get; }

        // Propiedad que obtiene o establece el propietario (Blueprint) de la forma.
        public IBlueprint? Owner
        {
            get => GetOwner();
            set => SetOwner(value);
        }
        //esto esta por hacer

        public Shape(string name, Color color)
        {
            Name = name;
            Color = color;
        }

        public abstract void Draw(ICanvas canvas);
        public abstract void Displace(Vector2D direction);
        //public abstract double GetArea();
        //public abstract IBlueprint GetOwner();

        
        private IBlueprint? GetOwner()
        {
            if (_blueprint == null)
                return null;
            if (_blueprint.TryGetTarget(out var result))
                return result;
            return null;
        }

        private void SetOwner(IBlueprint? newOwner)
        {
            var currentOwner = GetOwner();

            if (currentOwner == newOwner)
                return;

            if (currentOwner != null)
            {
                currentOwner.RemoveShape(this);
            }

            if (newOwner != null)
            {
                newOwner.AddShape(this);
                _blueprint = new WeakReference<IBlueprint>(newOwner);
            }
            else
            {
                _blueprint = null;
            }
        }

    }
}
