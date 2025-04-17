using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExDragonBallBienHecho
{
    class Utils
    {
        static Random r = new Random();

        public static int GetRandom(int a, int b)
        {
            return r.Next(a, b);  // Genera un número aleatorio entre a y b (b no incluido)
        }

        public static double GetRandomDouble(double v1, double v2)
        {
            return r.NextDouble() * (v2 - v1) + v1;  // Genera un número aleatorio entre v1 y v2
        }
    }
}
