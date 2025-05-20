using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprint
{
    public delegate bool ShapeFilter(IShape shape);

        public class Blueprint : IBlueprint
        {
            private readonly List<IShape> _shapes = new();
            private readonly string _name;

            public string Name => _name;

            public Blueprint(string name)
            {
                _name = name;
            }

            public int GetShapeCount() => _shapes.Count;

            public IShape GetShapeAt(int index)
            {
                if (index < 0 || index >= _shapes.Count)
                    throw new IndexOutOfRangeException();

                return _shapes[index];
            }

            public void AddShape(IShape shape)
            {
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

        public void RemoveShape(ShapeFilter filter)
        {
                if (filter == null)
                    throw new ArgumentNullException();

                _shapes.RemoveAll(shape => filter(shape));
        }

        public void RemoveShape(IShape shape)
        {
            if (shape == null)
                throw new ArgumentNullException(nameof(shape));

            if (_shapes.Remove(shape))
            {
                shape.Owner = null;
            }
        }

        //public IShape GetShape(ShapeFilter filter)
        //{
        //    if (filter == null)
        //        throw new ArgumentNullException(nameof(filter));

        //    return _shapes.FirstOrDefault(shape => filter(shape));
        //}

        public IShape GetShape(ShapeFilter filter)
        {
            if (filter == null)
                throw new ArgumentNullException();

            foreach (var shape in _shapes)
            {
                if (filter(shape))
                {
                    return shape;
                }
            }
            return null;
        }


        public List<IShape> FilterShapes(ShapeFilter filter)
            {
                if (filter == null)
                    throw new ArgumentNullException();

                return _shapes.Where(shape => filter(shape)).ToList();
            }

            public void Draw(ICanvas canvas)
            {
                foreach (var shape in _shapes)
                    shape.Draw(canvas);
            }
        }
    
}
