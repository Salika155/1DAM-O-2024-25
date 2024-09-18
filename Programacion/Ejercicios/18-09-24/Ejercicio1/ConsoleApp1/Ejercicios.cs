using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Ejercicios
    {
        //Funcion que me diga si un numero es par o no

        public static bool IsEven(int numero)
        {
            if (numero % 2 == 0)
                return true;
            return false;
            //return numero % 2 == 0;
        }

        //funcion que me diga si un numero es impar
        public static bool IsOdd(int a)
        {
            return a % 2 != 0;
        }

        //Funcion que me de una de las dos soluciones de la ecuacion de segundo grado
        public static double SolveSecondGradeEquation(double a, double b, double c)
        {
            double discriminante = (b * b) - 4 * (a * c);
            double sqrt = Math.Sqrt(discriminante) / 2 * a;

            double result1 = -b + sqrt;
            double result2 = -b - sqrt;

            if (sqrt == 0)
            {
                return double.NaN;
            }
            return result2;
            //a = 1, b = -4, c = 3;
            // - b +- (raiz(b^2 - 4 + a + c)/ 2 * a)

        }
    }
}
