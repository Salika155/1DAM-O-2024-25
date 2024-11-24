using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MasPractica
    {
        //funcion numero par
        public static bool IsPair(int n) => n % 2 == 0;

        //funcion que me diga si un numero es impar
        public static bool IsNotPair(int n) => n % 2 != 0;

        //Funcion que me de una de las dos soluciones de la ecuacion de segundo grado
        public static (double, double) Ecuation2Degree(double a, double b, double c)
        {
            if (a == 0 || b == 0 || c == 0)
                return (double.NaN, double.NaN);

            double p1 = (b * b);
            double p2 = - (4 * a * c);
            double p3 = Math.Sqrt(p1 + p2);
            double p4 = p3 / (2 * a);
            double res1 = -b + p3;
            double res2 = -b - p3;

            if (p4 == 0)
                return (double.NaN, double.NaN);
            return (res1, res2);
        }

        //funcion movimiento sexy, que le vais a pasar un numero, va a devolver void
        //tiene que imprimir en pantalla "..." hasta que el numero sea 0

        public static void ChocolateSexy(int n)
        {
            while (n > 0)
            {
                Console.WriteLine(". . .");
                n--;
            }
        }

        //funcion que le paso dos numeros y me devuelva si el primero es divisible por el segundo
        public static bool IsDivisible(int a, int b) => (a % b == 0 && b != 0);

        //funcion que escribe 10 veces hola
        public static void EscribeHola(int n)
        {
            while(n > 0)
            {
                Console.Write("Hola");
                n--;
            }
        }


        //funcion que me diga si un numero entero es primo o no
        public static bool IsPrime(int n)
        {
            if (n <= 1)
                return false;

            for (int i = 2; i < n; i++)
            {
                if (IsDivisible(n, i))
                    return false;
            }
            return true;
        }

        //serie 1 que devuelve un string que le paso por un entero, devuelve tantos numeros como el numero de n 

        public static string Serie1(int n)
        {
            string result = "";

            if (n <= 0)
                return string.Empty;

            for (int i = 1; i <= n; i++)
            {
                result += i;
                if (i < n)
                    result += ", ";
            }
            return result;
        }

        //serie de numero, paso un numero y devuelvo sumas de 2 las veces que el numero que me han pasado
        public static string Serie2(int n)
        {
            if (n < 0)
                return string.Empty;

            string result = "";
            int aux = 0;

            for (int i = 0; i < n; i++)
            {
                result += aux;
                if (i < n - 1)
                    result += ", ";
                aux += 2;
            }
            return result;
        }

        //Serie3 multiplos de 2 por el numero que me han pasado = 0, 2, 4, 8, 16, 32
        public static string Serie3(int n)
        {
            string result = "";
            int aux = 1;

            if (n < 0)
                return result;
            
            for (int i = 0; i < n; i++)
            {
                result += aux;
                if (i < n - 1)
                {
                    result += ", ";
                }
                aux *= 2;
            }
            return result;
        }

        //Serie4 numero positivos y negativos le paso numero y saca los multiplos de tres alternando en positivo y negativo ej: 0, -3, 6, -9
        public static string Serie4(int n)
        {

        }

        //Serie5 devuelve un string -> le paso un 30 y te hace fibonacci hasta el 30 -> while


        //si es impar numero x 3 + 1, si el numero es par dividirlo entre 2 -> conjetura collatz


        //factorial 5 = 5 + 4 + 3 + 2 + 1

        //productorio de 5 = 5 x 4 x 3 x 2 x 1 = 120

        //funcion que le paso un numero y me devuelve el sumatorio de todos los numeros pares


        //funcion que le paso un numero y devuelve el sumatorio de todos los numeros primos que hay desde el 1 hasta al numero que le paso

        //funcion para hacer el minimo comun multiplo de dos numeros

        //funcion para hacer el maximo comun divisor de dos numeros
    }
}
