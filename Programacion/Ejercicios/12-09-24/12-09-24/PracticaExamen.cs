using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_09_24
{
    internal class PracticaExamen
    {
        //Area de rectangulo (b * a)
        public static int GetAreaRenctangle(int a, int b)
        {
            return a * b;
        }

        //perimetro de un rectangulo 2 * (b + a)
        public static double GetPerimeter(double a, double b)
        {
            return 2 * (a + b);
        }

        //calcula area de un circulo PiR2
        public static double AreaCirculo(double radio)
        {
            return Math.PI * (radio * radio);
        }

        //funcion que le paso un entero si ese numero es mayor que 0 me devuelve un 1, si es menor o igual un 0
        public static int MayorQue0(int n)
        {
            int result = 0;
            if (n > 0)
                result = 1;
            else if (n <= 0)
                result = 0;

            return result;
        }

        //funcion que me devuelva el valor absoluto de un numero entero

        public static int ValorAbsoluto(int n)
        {
            int aux;
            if (EsPositivo(n))
                aux = n;
            else
                aux = -n;
            return aux;
        }

        //funcion que te diga si un numero es positivo o no.

        public static bool EsPositivo(int n)
        {
            return (n > 0) ? true : false;
        }




        //hacer funcion pase dos numeros enteros y devuelva el mayor
        public static int ElMayorDeDos(int a, int b)
        {
            return (a > b) ? a : b;
        }

        //funcion que devuelva el mayor de 3 enteros
        public static int DevuelveMayorDeTres(int a, int b, int c)
        {
            return ElMayorDeDos(a, ElMayorDeDos(b, c));
        }
    }
        
}
