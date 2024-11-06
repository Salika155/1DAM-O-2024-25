using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoExamen
{
    public enum EstadoMaquina
    {
        PREPARADA, PROCESANDO, EJECUTANDO, TERMINANDO
    }
    //MQTT Gestor de servidores centralizado.
    internal class Funciones
    {
        //Crea una funcion que reciba como parametro 2 enteros y devuelva un real que sea el primer parametro mas 1. Todo entre el segundo.
        //1. (0,5) Crea una funcion que reciba como parametro 2 enteros y devuelva un real que sea el primer
        //parametro mas 1, todo ello entre el segundo.
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

            return a * x4 + b * x3 + c * x2 + d * x + e;
        }

        //ej3
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

        //ej 4
        //4. (1) Crea una funcion que se le pasen 3 enteros (no ordenados), y devuelva la distancia maxima
        //entre el numero que tiene el valor central, con respecto al minimo y al maximo de los otros dos.
        //Por ejemplo, si se le pasa (3, 1, 7) devolvera un 4, ya que la distancia de 3 y 1 es 2 y la distancia de
        //3 y 7 es 4.
        public static int GetDistancia(int a, int b, int c)
        {
            a = 3;
            b = 1;
            c = 7;
            int menor = GetMinor(a, GetMinor(b, c));
            int mayor = GetMayor(a, GetMayor(b, c));
            int medio = a + b + c - menor - mayor;
            //int dist1 = mayor - medio;
            //int dist2 = medio - menor;
            int dist1 = mayor > medio ? mayor - medio : medio - mayor;
            int dist2 = medio > menor ? medio - menor : menor - medio;
            return GetMayor(dist1, dist2); 
        }

        //public static int GetMiddle(int a, int b, int c)
        //{
        //    //if ((a <= b && b <= c) || (c <= b && b <= a))
        //    //    return b;
        //    //if ((b <= a && a <= c) || (c <= a && c <= b))
        //    //    return a;
        //    //return c;

        //    int result = 0;
        //    int central = 0;
        //    int minor = GetMinor(a, GetMinor(b, c));
        //    return minor;
        //}

        public static int GetMayor(int a, int b)
        {
            return (a > b) ? a : b;
        }

        //ej5
        //5. (0,5) Crea una funcion que devuelva el numero de digitos de un numero entero. Para hacer esta
        //funcion no se pueden usar strings.
        //Por ejemplo, el numero de digitos del 154 es 3, el de 75366 es 5. Para ello, puedes ir dividiendo el
        //numero por 10 hasta que…
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
                result++;
            }
            return result;
        }

        //8. (1) Crea una funcion que reciba como parametro un numero y devuelva la posicion de ese
        //numero dentro de los numeros primos.Si el numero no es primo, devolvera un -1.
        //Por ejemplo, sabemos que los numeros primos son: 2, 3, 5, 7, 11, 13, … Si a esta funcion se le pasa
        //un 7 devolvera un 4, ya que 7 es el cuarto numero primo.Si a esta funcion se le pasa un 6,
        //devolvera un -1, ya que este no es primo.
        public static int IndexOfPrime(int n)
        {
            if (!IsPrime(n))
                return -1;

            int index = 1;

            for (int i = 2; i < n; i++)
            {
                if (IsPrime(i))
                    index++;    
            }
            return index;
        }

        //public static List<int> GetPrimoNumbers()
        //{
        //    List<int> primos = new List<int>();

        //    int count = 1;

        //    for (int i = 0; i < primos.Count; i++)
        //    {
        //        if ((i % 1 == 0) && (i % count == 0))
        //        {
        //            primos.Add(i);
        //        }
        //    }
        //    return primos;
        //}

        public static bool IsPrime(int n)
        {
            for (int i = 2; i <= n; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        //11. (1.5) Crea una funcion que reciba como parametros los siguientes datos:
        //a.Los coeficientes a, b, c, d, y e de un polinomio del tipo a.x⁴ + b.x³ + c.x² + d.x¹ + e
        //b. Un intervalo de muestreo xmin, xmax
        //c. Un periodo de muestreo de Lambda x = 0,1
        //d.La funcion debe devolver el valor maximo que toma ese polinomio en el intervalo dado y dado el
        //tamaño del sampler.
        public static double Ex11(double a, double b, double c, double d, double e, double xmin, double xmax)
        {
            double maxValue = E2(a, b, c, d, e, xmin);
            double muestra = 0.1;

            for (double x = xmin; x <= xmax; x += muestra)
            {
                double value = E2(a, b, c, d, e, x);
                    if (value > maxValue)
                    maxValue = value;
            }
            return maxValue;
        }

        public static double GetMinorDouble(double a, double b)
        {
            if (a < b)
                return a;
            return b;
        }

        public static double GetMayorDouble(double a, double b)
        {
            return (a > b) ? a : b;
        }

        //6. (1) Realiza una funcion recursiva que, dado un numero n, devuelva:
        //1² + 2² + 3² + 4² +5² … n²
        //Consejo, recuerda que cuando hicimos el sumatorio o el productorio, la funcion recursiva devolvia
        //5 + 4 + 3 + 2 + 1 en vez de 1+2+3+4+5
        public static int SumaRecursiva(int n)
        {
            if (n == 1)
                return 1;
            return (n * n) + SumaRecursiva(n - 1);
        }

        //9. (1) Haz una funcion que se le pasen como parametros un enum y un booleano.El enum es el
        //estado de una maquina(PREPARADA, PROCESANDO, EJECUTANDO, TERMINANDO). Si el
        //booleano que se le pasa es false, devolvera justamente el enum que se le pasa como parametro, si es
        //true, devolvera el siguiente estado de la maquina.
        //Por ejemplo, si se le pasa PROCESANDO y un true, devolvera EJECUTANDO. Si se le pasa
        //TERMINANDO y un false, devolvera TERMINANDO.

        public static EstadoMaquina GetEstado(EstadoMaquina estado, bool proceso)
        {
            if (!proceso)
                return estado;

            if (estado == EstadoMaquina.PREPARADA)
                return EstadoMaquina.PROCESANDO;
            else if (estado == EstadoMaquina.PROCESANDO)
                return EstadoMaquina.EJECUTANDO;
            else if (estado == EstadoMaquina.EJECUTANDO)
                return EstadoMaquina.TERMINANDO;
            else // estado == EstadoMaquina.TERMINANDO
                return EstadoMaquina.TERMINANDO;
            #region oculto
            //switch (estado)
            //{
            //    case EstadoMaquina.PREPARADA:
            //        return EstadoMaquina.PROCESANDO;
            //    case EstadoMaquina.PROCESANDO:
            //        return EstadoMaquina.EJECUTANDO;
            //    case EstadoMaquina.EJECUTANDO:
            //        return EstadoMaquina.TERMINANDO;
            //    case EstadoMaquina.TERMINANDO:
            //        return EstadoMaquina.TERMINANDO;
            //    default:
            //        return estado;
            //}
            #endregion
        }

        //10. (1) Crea una funcion que se le pase un numero y devuelva la suma de todos sus divisores desde
        //1 hasta ese numero(sin contar ese numero)

        public static int SumaDivisore(int n)
        {
            int result = 0;
            for (int i = 1; i < n; i++)
            {
                if (n % i == 0)
                    result +=i;
            }
            return result;
        }


    }
}

