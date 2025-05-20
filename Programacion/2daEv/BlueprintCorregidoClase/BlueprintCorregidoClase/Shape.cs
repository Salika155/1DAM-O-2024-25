using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintCorregidoClase
{
    public interface IShape
    {
        string Name;

        BluePrint Owner { get; set; }
    }
    class Shape : IShape
    {
        public string _name;
        private readonly Color _color;
        //la tengo que hacer debil
        private WeakReference<IBluePrint>? _blueprint;

        

        public IBluePrint? Owner
        { get => GetOwner(); 
            set => SetOwner(value); }
        public string Name { get => _name; set => _name = value; }
        public Color Color => _color;
        public bool HasArea { get; }
        public double Area { get; }
        public double Perimeter { get; }
        public Point2D Point { get; set;}

        public void AddShape(IShape shape)
        {
            if (shape == null)
                return;
            if(!ContainsChild(shape))
            {
                _shapes.Add(shape);
                shape.Owner = this;
            }
        }

        public void RemoveShape(FilterDelegate del)
        {
            if (del == null)
                return;
            for (int i = 0; i < _shapes.Count; i >= 0; i--)
        }

        private int IndexOf(IShape shape)
        {

        }
        private bool ContainsChild(IShape shape)
        {
            return IndexOf(shape) >= 0;
        }

        public void Draw(ICanvas canvas)
        {
            if (canvas == null)
                return;
            for (int i = 0; i < _shapes.Count; i++)
                _shapes[i].Draw(canvas);
        }

        public List<IShape> FilterShapes(FilterDelegate del)
        {
            List<IShape> result = new();
            if (del == null)
                return result;
            for(int i = 0; i < _shapes.Count; i++)
            {
                if (del(_shapes[i]))
                    result.Add(_shapes[i]);

            }
            return result;
        }

        public IShape GetShape(FilterDelegate del)
        {
            if (del == null)
                return null;
            for (int i = 0; i < _shapes.Count; i++)
            {
                if (del(_shapes[i]))
                    result _shapes[i]);

            }
            return null;
        }
        private static IBluePrint GetOwner()
        {
            if (_blueprint == null)
                return null;
            if (_blueprint.TryGetTarget(out var result))
                return result;
            return null;
        }

        public void SetOwner(IBluePrint? newparent)
        {
            if (newparent == null)
            {
                //voy a conseguir a mi padre actual
                var oldparent = GetOwner();

                if (newparent== oldparent)
                    return;

                //mi nuevo padre es null, pero mi antiguo padre no
                if (newparent == null)
                {
                    _blueprint == null;
                    oldparent!.RemoveShape(this);
                }
                else
                {
                    //mi nuevo padre no es null
                    if(oldparent != null)
                    {
                        oldparent.RemoveShape(this);
                    }
                    if (newparent != null)
                    {
                        oldparent.AddShape(this);
                        _blueprint = new WeakReference<IBluePrint>(newparent);
                    }
                }

                
            }
        }

        public Shape(string name, Color color)
        {
            _name = name;
            _color = color;
        }

        //public void RemoveShape(IShape shape)
        //{
        //    for( int i = 0; i < _shapes.Count; i++)
        //    {
        //        if (_shapes[i] == shape)
        //        {
        //            shape.Owner = null;
        //            _shapes.RemoveAt(i);
        //            return;

        //        }
        //    }
        //}

    }
}
