using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprint
{
    public interface ICanvas
    {
        void SetCurrentColor(Color color);
        void DrawPolygon(Point2D[] points);
        void DrawCircle(Rect2D rect);
    }
}
