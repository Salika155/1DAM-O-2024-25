using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class EjerciciosParaExamen
    {
        //funcion numero par
        public static bool IsEven(int number) => number % 2 == 0;

        //funcion que me diga si un numero es impar
        public static bool IsOdd(int number) => number % 2 != 0;

        //Funcion que me de una de las dos soluciones de la ecuacion de segundo grado
        public static (double, double) SolveSecondGradeEquation(double a, double b, double c)
        {
            if (a == 0 || b == 0 || c == 0)
                return (double.NaN, double.NaN);
            double x1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            double x2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            return (x1, x2);
            //comrpobar que raiz no sea 0, asi que mejor sacar las raices por separado
        }

        //funcion movimiento sexy, que le vais a pasar un numero, va a devolver void
        //tiene que imprimir en pantalla "..." hasta que el numero sea 0
        public static void MovimientoSexy(int number)
        {
            while (number > 0)
            {
                Console.WriteLine(". . .");
                number--;
            }
        }

        //funcion que le paso dos numeros y me devuelva si el primero es divisible por el segundo
        public static bool IsDivisible(int number1, int number2) => number1 % number2 == 0 && number2 != 0;

        //23/09/2024
        /*while -> cuando llegamos al final si no se cumple la condicion se sale
         *         * do while -> se ejecuta al menos una vez
         *                 * for -> se ejecuta un numero determinado de veces
         *                         * foreach -> se ejecuta un numero determinado de veces
         *                                 * goto -> salta a una etiqueta
         *                                         * break -> sale del bucle
         *                                                 * continue -> salta a la siguiente iteracion
         *                                                         * return -> sale de la funcion
         /for -> for (int i = 0; i < 10; i++)
         */
        //funcion que escribe 10 veces hola
        public static void WriteHola()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Hola");
                i--;
            }
        }


        //funcion que me diga si un numero entero es primo o no
        public static bool IsEven1(int n)
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
            if (n <= 0)
                return string.Empty;
            string result = string.Empty;

            for (int i = 0; i <= n; i++)
            {
                if (i < n)
                    result += i;
                else
                    result += i + ", ";
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
                aux += 2;
                if (i < n - 1)
                    result += ", ";
            }
            return result;
        }


        //Serie3 multiplos de 2 por el numero que me han pasado = 0, 2, 4, 8, 16, 32
        public static string Serie3(int n)
        {
            if (n <= 0)
                return string.Empty;
            string result = "";
            int aux = 1;

            for (int i = 1; i <= n; i++)
            {
                result += aux;
                aux *= 2;
                if (i < n)
                {
                    result += ", ";
                }
            }
            return result;
        }


        //Serie4 numero positivos y negativos le paso numero y saca los multiplos de tres alternando en positivo y negativo ej: 0, -3, 6, -9
        public static string Serie4(int n)
        {
            if (n <= 0)
                return string.Empty;

            string result = "";
            int aux = 0;

            for (int i = 0; i < n; i++)
            {
                aux += 3;
                if (aux % 2 == 0)
                    result += aux;
                else
                    result += -aux;

                if (i < n - 1)
                    result += ", ";
            }
            return result;
        }

        //Serie5 devuelve un string -> le paso un 30 y te hace fibonacci hasta el 30 -> while
        public static string Serie5(int n) 
        {
            if (n <= 0)
                return string.Empty;
            string result = "";
            int aux = 0;
            int aux1 = 1;
            int aux2 = 0;

            while(aux2 < n)
            {
                result += aux2;
                aux2 = aux + aux1;
                aux = aux1;
                aux1 = aux2;
                if (aux2 < n)
                    result += ", ";
            }
            return result;
        }


        //si es impar numero x 3 + 1, si el numero es par dividirlo entre 2 -> conjetura collatz
        public static string Serie6(int n)
        {
            if (n <= 0)
                return string.Empty;

            string result = "";
            int aux = n;

            while (aux > 1)
            {
                if (aux % 2 == 0)
                    aux /= 2;
                else
                    aux = aux * 3 + 1;
                while (aux > 1)
                {
                    result += aux;
                    if (aux > 1)
                        result += ", ";
                }
            }
            return result;
        }


        //factorial 5 = 5 + 4 + 3 + 2 + 1



        //productorio de 5 = 5 x 4 x 3 x 2 x 1 = 120



        //funcion que le paso un numero y me devuelve el sumatorio de todos los numeros pares



        //funcion que le paso un numero y devuelve el sumatorio de todos los numeros primos que hay desde el 1 hasta al numero que le paso


        //funcion para hacer el minimo comun multiplo de dos numeros



        //funcion para hacer el maximo comun divisor de dos numeros

    }
}


