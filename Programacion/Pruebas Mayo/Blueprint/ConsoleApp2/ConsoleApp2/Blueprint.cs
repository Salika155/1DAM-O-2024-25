using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public delegate void VisitDelegate(IShape shape);
    public delegate bool FilterDelegate(IShape shape);

    public interface IBlueprint
    {
        int GetShapeCount();
        IShape GetShapeAt(int index);
        void AddShape(IShape shape);
        void RemoveShape(IShape shape);
        void RemoveShape(FilterDelegate del); 
        IShape? GetShape(FilterDelegate del); 
        List<IShape> FilterShapes(FilterDelegate del); 
        void Draw(ICanvas canvas);
    }

    public class Blueprint : IBlueprint
    {
        private readonly List<IShape> _shapes = new();

        public void AddShape(IShape shape)
        {
            if (shape == null)
                return;

            if (!ContainsChild(shape))
            { 
                _shapes.Add(shape);
                shape.Owner = this;
            }
        }

        private int IndexOf(IShape shape)
        {
            for (int i = 0; i < _shapes.Count; i++)
                if (_shapes[i] == shape)
                    return i;
            return -1;
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

            for (int i = 0; i < _shapes.Count; i++)
                if (del(_shapes[i]))
                    result.Add(_shapes[i]);
            return result;
        }

        public IShape? GetShape(FilterDelegate del)
        {
            if (del == null)
                return null;

            for (int i = 0; i < _shapes.Count; i++)
                if (del(_shapes[i]))
                    return _shapes[i];
            return null;
        }

        public IShape GetShapeAt(int index)
        {
            throw new NotImplementedException();
        }

        public int GetShapeCount()
        {
            throw new NotImplementedException();
        }

        public void RemoveShape(FilterDelegate del)
        {
            if (del == null)
                return;

            for (int i = _shapes.Count; i >= 0; i--)
                if (del(_shapes[i]))
                    _shapes.RemoveAt(i);
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
    }
}
