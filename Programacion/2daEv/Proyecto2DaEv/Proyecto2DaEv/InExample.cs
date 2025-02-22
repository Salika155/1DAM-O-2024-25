using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2DaEv
{
    /*
     *  Caso de uso:
        Cuando necesitas pasar un parámetro de solo lectura (especialmente útil para 
        estructuras grandes para evitar copias innecesarias).
     */
    public struct Punto
    {
        public int X;
        public int Y;
    }

    public class InExample
    {

        // Método que calcula la distancia entre dos puntos usando 'in'
        public static double Distancia(in Punto p1, in Punto p2)
        {
            // p1.X = 20; // Error: 'in' hace que la variable sea de solo lectura
            int dx = p2.X - p1.X;
            int dy = p2.Y - p1.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static void ProbarIn()
        {
            Punto puntoA = new Punto { X = 0, Y = 0 };
            Punto puntoB = new Punto { X = 3, Y = 4 };

            double distancia = Distancia(in puntoA, in puntoB);
            Console.WriteLine($"Distancia: {distancia}"); // Distancia: 5
        }

        /*
         *  in Punto p1 → Recibe la estructura como solo lectura.
            Math.Sqrt(...) → Calcula la distancia sin modificar p1 o p2.
         */

        // Método que usa 'in' para recibir un parámetro de solo lectura
        public static double CalcularDistancia(in Punto p1, in Punto p2)
        {
            int dx = p2.X - p1.X;
            int dy = p2.Y - p1.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static void ProbarIn1()
        {
            Punto punto1 = new Punto { X = 0, Y = 0 };
            Punto punto2 = new Punto { X = 3, Y = 4 };

            double distancia = CalcularDistancia(in punto1, in punto2);
            Console.WriteLine("Distancia entre los puntos: " + distancia);
        }
    }

    /*
     *  Explicación:
        CalcularDistancia(in Punto p1, in Punto p2) recibe dos estructuras 
        Punto de solo lectura (in).

        Esto evita copias innecesarias de las estructuras y garantiza que no se 
        modifiquen dentro del método 
     */
}
