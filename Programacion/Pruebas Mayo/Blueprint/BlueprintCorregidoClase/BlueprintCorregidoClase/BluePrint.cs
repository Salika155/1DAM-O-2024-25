using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintCorregidoClase
{
    public interface IBluePrint
    {
        public delegate void VisitDelegate(IShape shape);
        public delegate bool FilterDelegate(IShape shape);
        int GetShapeCount();
        IShape GetShapeAt(int index);
        void AddShape(IShape shape);
        void RemoveShape(FilterDelegate del);
        void RemoveShape(IShape shape);
        IShape GetShape(VisitDelegate del);




    }
    public class BluePrint : IBluePrint
    {
        private readonly List<IShape> _shapes = new();
        //ishape le he dado el permiso de tener un ishape -> funcion de abajo 
        //ajedrez genera sus propias fichas, aqui no se puede
        public void AddShape(IShape shape)
        {
            //Shape sp = (Shape)shape;
            //_shapes.Add(sp);
            if (!ContainsChild(shape))
            {
                _shapes.Add(shape);
                shape.Owner = this;
            }

        }

        private bool ContainsChild(IShape shape)
        {
            throw new NotImplementedException();
        }

        public IShape GetShape(IBluePrint.VisitDelegate del)
        {
            throw new NotImplementedException();
        }

        public IShape GetShapeAt(int index)
        {
            throw new NotImplementedException();
        }

        public int GetShapeCount()
        {
            throw new NotImplementedException();
        }

        public void RemoveShape(IBluePrint.FilterDelegate del)
        {
            throw new NotImplementedException();
        }

        public void RemoveShape(IShape shape)
        {
            for (int i = 0; i < _shapes.Count; i++)
            {
                if (_shapes[i] == shape)
                {
                    shape.Owner = null;
                    _shapes.RemoveAt(i);
                    return;

                }
            }
        }

        //hacer casting bien mediante un if para comprobar que sea
    }
}
