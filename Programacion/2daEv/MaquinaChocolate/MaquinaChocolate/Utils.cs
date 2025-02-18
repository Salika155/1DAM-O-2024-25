using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaChocolate
{
    public static class Utils
    {
        // Método para calcular la interpolación lineal
        public static double GetInterpolacionLineal(double a, double b, double u)
        {
            double part2 = a * (1 - u);
            double part1 = b * u;
            double interpolation = part1 + part2;

            return interpolation;
        }

        // Método para saturar un valor dentro de un rango
        public static double GetSaturate(double limInf, double limSup, double value)
        {
            if (value < limInf)
                value = limInf;
            else if (value > limSup)
                value = limSup;
            return value;
        }
    }
}
