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
