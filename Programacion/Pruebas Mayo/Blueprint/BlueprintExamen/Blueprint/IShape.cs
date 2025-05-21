using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprint
{
    interface IShape
    {
        string Name { get; set; }
        Color Color { get; }
        bool HasArea { get; }
        double Area { get; }
        double Perimeter { get; }
        Point2D Center { get; }
        Rect2D Rect { get; set; }
        IBlueprint Owner { get; }

    }
}
