using Blueprint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blueprint.IBlueprint;

namespace Blueprint
{
    // Clase BluePrint que implementa la interfaz IBluePrint.
    public class BluePrint : IBlueprint
    {
        public delegate void VisitDelegate(IShape shape);
        public delegate bool FilterDelegate(IShape shape);
        // Lista privada que almacena las formas contenidas en el plano.
        private readonly List<IShape> _shapes = new();

        // Método para agregar una nueva forma al plano.
        public void AddShape(IShape shape)
        {
            // Verifica si la forma ya está contenida en el plano.
            if (!ContainsShape(shape))
            {
                // Agrega la forma a la lista.
                _shapes.Add(shape);

                // Establece el propietario de la forma como este plano.
                shape.Owner = this;
            }
        }

        // Método privado que verifica si una forma ya está contenida en el plano.
        private bool ContainsShape(IShape shape)
        {
            // Recorre la lista de formas.
            foreach (var s in _shapes)
            {
                // Si encuentra la forma, devuelve true.
                if (s == shape)
                    return true;
            }
            // Si no encuentra la forma, devuelve false.
            return false;
        }

        // Método que obtiene el número total de formas en el plano.
        public int GetShapeCount()
        {
            return _shapes.Count;
        }

        // Método que obtiene la forma en una posición específica.
        public IShape GetShapeAt(int index)
        {
            // Verifica si el índice está dentro de los límites de la lista.
            if (index >= 0 && index < _shapes.Count)
                return _shapes[index];

            // Si el índice es inválido, lanza una excepción.
            throw new ArgumentOutOfRangeException(nameof(index), "Índice fuera de rango.");
        }
    }
}


//public delegate bool ShapeFilter(IShape shape);

//public class Blueprint : IBlueprint
//{
//    private readonly List<IShape> _shapes = new();
//    private readonly string _name;

//    public string Name => _name;

//    public Blueprint(string name)
//    {
//        _name = name;
//    }

//    public int GetShapeCount() => _shapes.Count;

//    public IShape GetShapeAt(int index)
//    {
//        if (index < 0 || index >= _shapes.Count)
//            throw new IndexOutOfRangeException();

//        return _shapes[index];
//    }

//    public void AddShape(IShape shape)
//    {
//        if (!ContainsChild(shape))
//        {
//            _shapes.Add(shape);
//            shape.Owner = this;
//        }
//        //es lo mismo que esto, pero el orden es importante, mejor la otra opcion
//        //if (shape.Owner != this)
//        //{
//        //    shape.Owner = this;
//        //    _shapes.Add(shape);
//        //}
//    }

//    private bool ContainsChild(IShape shape)
//    {
//        throw new NotImplementedException();
//    }

//    public void RemoveShape(ShapeFilter filter)
//    {
//        if (filter == null)
//            throw new ArgumentNullException();

//        _shapes.RemoveAll(shape => filter(shape));
//    }

//    public void RemoveShape(IShape shape)
//    {
//        if (shape == null)
//            throw new ArgumentNullException(nameof(shape));

//        if (_shapes.Remove(shape))
//        {
//            shape.Owner = null;
//        }
//    }

//    //public IShape GetShape(ShapeFilter filter)
//    //{
//    //    if (filter == null)
//    //        throw new ArgumentNullException(nameof(filter));

//    //    return _shapes.FirstOrDefault(shape => filter(shape));
//    //}

//    public IShape GetShape(ShapeFilter filter)
//    {
//        if (filter == null)
//            throw new ArgumentNullException();

//        foreach (var shape in _shapes)
//        {
//            if (filter(shape))
//            {
//                return shape;
//            }
//        }
//        return null;
//    }


//    public List<IShape> FilterShapes(ShapeFilter filter)
//    {
//        if (filter == null)
//            throw new ArgumentNullException();

//        return _shapes.Where(shape => filter(shape)).ToList();
//    }

//    public void Draw(ICanvas canvas)
//    {
//        foreach (var shape in _shapes)
//            shape.Draw(canvas);
//    }
//}
