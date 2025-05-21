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

        // Método privado que obtiene el propietario actual de la forma.
        private IBlueprint? GetOwner()
        {
            // Si la referencia débil es nula, no hay propietario.
            if (_blueprint == null)
                return null;

            // Intenta obtener el objeto referenciado.
            if (_blueprint.TryGetTarget(out var result))
                return result;

            // Si no se pudo obtener, significa que el objeto fue recolectado por el GC.
            return null;
        }

        // Método privado que establece un nuevo propietario para la forma.
        private void SetOwner(IBlueprint? newOwner)
        {
            // Obtiene el propietario actual.
            var oldOwner = GetOwner();

            // Si el nuevo propietario es el mismo que el actual, no se realiza ninguna acción.
            if (newOwner == oldOwner)
                return;

            // Si hay un propietario actual, elimina la forma de su lista.
            if (oldOwner != null)
            {
                oldOwner.RemoveShape(this);
            }

            // Si el nuevo propietario no es nulo, agrega la forma a su lista y actualiza la referencia débil.
            if (newOwner != null)
            {
                newOwner.AddShape(this);
                _blueprint = new WeakReference<IBlueprint>(newOwner);
            }
            else
            {
                // Si el nuevo propietario es nulo, elimina la referencia débil.
                _blueprint = null;
            }
        }

        // Método abstracto para dibujar la forma en un lienzo.
        public abstract void Draw(ICanvas canvas);
        // Método abstracto para desplazar la forma en una dirección específica.
        public abstract void Displace(Vector2D direction);

    }
}

//private void SetOwner(IBlueprint? newOwner)
//{
//    var currentOwner = GetOwner();

//    if (currentOwner == newOwner)
//        return;

//    if (currentOwner != null)
//    {
//        currentOwner.RemoveShape(this);
//    }

//    if (newOwner != null)
//    {
//        newOwner.AddShape(this);
//        _blueprint = new WeakReference<IBlueprint>(newOwner);
//    }
//    else
//    {
//        _blueprint = null;
//    }
//}

//public abstract double GetArea();
//public abstract IBlueprint GetOwner();
