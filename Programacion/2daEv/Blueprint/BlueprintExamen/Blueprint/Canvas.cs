using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprint
{
    class Canvas : ICanvas
    {
        public void DrawCircle(Rect2D rect)
        {
            Console.WriteLine("Dibujando Circulo con el centro:" + rect.ToString());
        }

        public void DrawPolygon(Point2D[] points)
        {
            Console.WriteLine("Dibujando poligono con puntos: " + points.Length);
            for(int i = 0; i < points.Length; i++)
            {
                Console.WriteLine("el punto" + i + "tiene las coordenadas:" + points[i]);
            }
        }

        public void SetCurrentColor(Color color)
        {
            Console.WriteLine("El color actual es: " + color.R, color.G, color.B, color.A);
        }
    }
}
