using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoExamen
{
    internal class Funciones
    {
        //Crea una funcion que reciba como parametro 2 enteros y devuelva un real que sea el primer parametro mas 1. Todo entre el segundo.
        public static double E1(int a, int b)
        {
            if (b == 0)
                return double.NaN;
            return (a + 1.0) / b;
        }

        //Crea una funcion que se le pasen 5 reales mas otro real que se le llama x. La funcion devuelve un real representado por el siguiente polinomio:
        //a * x ^4 + b * x ^3 ... + e.
        public static double E2(double a, double b, double c, double d, double e, double x)
        {
            double x2 = x * x;
            double x3 = x2 * x;
            double x4 = x2 * x2;

            return a * x4 + b * x2 + c * x3 + d * x + e;
        }

        //Crea una funcion que se le pasen 10 enteros y devuelva el menor de ellos.
        public static int GetMinorOfTen(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j)
        {
            return GetMinor(a, GetMinor(b, GetMinor(c, GetMinor(d, GetMinor(e, GetMinor(f, GetMinor(g, GetMinor(h, GetMinor(i, j)))))))));
            //int r = a;
            //if (b < r)
            //r = b;
            //if(c < r)
            //r = c;
            //...
        }

        public static int GetMinor(int a, int b)
        {
            if (a < b)
                return a;
            return b;
        }

        public static int GetDistancia(int a, int b, int c)
        {
            a = 3;
            b = 1;
            c = 7;
            int menor = GetMinor(a, GetMinor(b, c));
            int mayor = GetMayor(a, GetMayor(b, c));
            int medio = GetMiddle(a, b, c);
            int dist1 = mayor - medio;
            int dist2 = medio - menor;
            return GetMayor(dist1, dist2);
            
            
        }

        public static int GetMiddle(int a, int b, int c)
        {
            //if ((a <= b && b <= c) || (c <= b && b <= a))
            //    return b;
            //if ((b <= a && a <= c) || (c <= a && c <= b))
            //    return a;
            //return c;

            int result = 0;
            int central = 0;
            int minor = GetMinor(a, GetMinor(b, c));
            return minor;
        }

        public static int GetMayor(int a, int b)
        {
            return (a > b) ? a : b;
        }

        public static int DevuelveDigitos(int a)
        {
            if (a < 0)
                return 1 + DevuelveDigitos(-a);
            if (a == 0)
                return 1;
            int result = 0;

            while(a >= 1 || a <= -1)
            {
                a /= 10;
                result += 1;
            }
            return result;
        }

    }
}

