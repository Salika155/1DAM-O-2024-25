using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprint
{
    // Definición de la interfaz IShape que representa una forma geométrica.
    public interface IShape
    {
        // Propiedad que obtiene o establece el propietario (Blueprint) de la forma.
        IBlueprint? Owner { get; set; }

        // Propiedad que obtiene el nombre de la forma.
        string Name { get; set; }

        // Propiedad que indica si la forma tiene un área definida.
        bool HasArea { get; }

        // Propiedad que obtiene el área de la forma.
        double Area { get; }

        // Propiedad que obtiene el perímetro de la forma.
        double Perimeter { get; }

        // Propiedad que obtiene el punto de referencia de la forma.
        Point2D Point { get; }

        // Método para dibujar la forma en un lienzo.
        void Draw(ICanvas canvas);

        // Método para desplazar la forma en una dirección específica.
        void Displace(Vector2D direction);
    }
}

//string Name { get; set; }
//Color Color { get; }
//bool HasArea { get; }
//double Area { get; }
//double Perimeter { get; }
//Point2D Center { get; }
//Rect2D Rect { get; set; }
//IBlueprint? Owner { get; set; }

//void Draw(ICanvas canvas); // <- Este faltaba
//void Displace(Vector2D direction);
