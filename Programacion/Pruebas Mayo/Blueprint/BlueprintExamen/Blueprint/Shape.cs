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
        private Color? _color;
        private bool _hasArea;
        private double _area;
        private double _perimeter;
        private Point2D _center;
        private Rect2D _rect;
        private Blueprint _blueprint;

        public string? Name
        {
            get
            {
                if (_name == null)
                    throw new Exception();
                return _name;
            }
            set => _name = value;
        }

        public Color? Color { get => _color; }

        public bool HasArea { get => _hasArea; }

        public double Area { get => _area; }

        public double Perimeter { get => _perimeter; }

        public Point2D Center { get => _center; }

        public Rect2D Rect { get => _rect; set => _rect = value; }

        public IBlueprint Owner { get => _blueprint; }

        public abstract double GetArea();
        public abstract IBlueprint GetOwner();
    }
}
