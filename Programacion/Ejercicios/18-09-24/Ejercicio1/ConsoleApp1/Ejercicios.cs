using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
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
            if (a == 0 || b == 0 || c == 0)
                return double.NaN;

            double discriminante = (b * b) - 4 * (a * c);
            double sqrt = Math.Sqrt(discriminante) / 2 * a;

            double result1 = -b + sqrt;
            double result2 = -b - sqrt;

            if (sqrt == 0)
            {
                return double.NaN;
            }
            return result1;
            //a = 1, b = -4, c = 3;
            // - b +- (raiz(b^2 - 4 + a + c)/ 2 * a)
        }

        public static double SolveSecondGradeEquation1(double a, double b, double c)
        {
            if (a == 0)
                return double.NaN;

            double paso1 = 2.0 * a;
            double paso2 = (b * b);
            double paso3 = 4.0 * a * c;
            double paso4 = paso2 - paso3;
            if (paso4 < 0)
                return double.NaN;

            double paso5 = Math.Sqrt(paso4);
            double paso6 = -b + paso5;
            double paso7 = paso6 / paso1;
            return paso7;

        }

        //funcion movimiento sexy, que le vais a pasar un numero, va a devolver void
        //tiene que imprimir en pantalla "..." hasta que el numero sea 0
        public static void MovimientoSexy(int n)
        {
            //if (n == 0)
            //    goto Movimiento;
            //else
            //    goto Fin;

            Console.WriteLine("Inicio");
        Inicio:
            if (n > 0)
                goto Movimiento;
            else
                goto Fin;

        Movimiento:
            Console.WriteLine("...");
            n--;
            goto Inicio;
        Fin:
            Console.WriteLine("Fin");
        }

        //funcion que le paso dos numeros y me devuelva si el primero es divisible por el segundo
        public static bool IsDivisible(int a, int b)
        {
            return b != 0 && a % b == 0;
        }
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
        public static void WriteHello10Times()
        {
            int i = 0;

            while (i < 10)
            {
                Console.WriteLine("hola");
                i++;
            }
        }

        public static void WriteHello10Times1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("hola");
            }
        }

        public static void WriteHello10Times2()
        {
            int n = 0;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("hola" + n);
                n++;
            }
        }

        public static void WriteHello10Times3(double n)
        {
            //if (n <= 0.1)
            //    return;

            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine("Numero " + n);
                
            //}
            while (n > 0.1)
            {
                Console.WriteLine("Numero " + n);
                n *= 0.5;
            }
            /*
             double aux = n;
            while (aux > 0.1)
            {
                Console.WriteLine("Numero " + aux);
                aux *= 0.5;
             */
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
            //salida de bucle por poner return dentro de un if dos veces, es suspenso directo, y return al inicio de la funcion
        }

        //serie 1 que devuelve un string que le paso por un entero, devuelve tantos numeros como el numero de n 
        public static string Serie1(int n)
        {
            if (n < 0)
                return "";
            //int aux = n;
            string result = "";

            //for (int i = 1; i <= n; i++)
            //{
            //    if (aux > 0)
            //    result += i + ", ";
            //    aux--;
            //    if (aux == 0)
            //        result += i;
            //}
            //return result;
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
                return "";

            string result2 = "";
            int aux = 0;

            #region pruebas
            //for (int i = 0; i < n; i++)
            //{
            //    if (aux > 1)
            //    result2 += aux + ", ";
            //    aux += 2;
            //    if (aux == 0)
            //        result2 += aux;
            //}
            //return result2;
            #endregion

            for (int i = 0; i < n; i++)
            {
                result2 += aux;
               
                if (i < n - 1)
                    result2 += ", ";
                aux += 2;
            }
            return result2;

            /*for (int i = 1; i <= n; i++)
             * if (i < n)
             */
        }

        //Serie3 multiplos de 2 por el numero que me han pasado = 0, 2, 4, 8, 16, 32
        public static string Serie3(int n)
        {
            //para empezar por 0 puedes poner el string directamente con el valor 0,
            if (n < 0)
                return "";

            string result3 = "";
            int aux = 0;

            for (int i = 0; i < n; i++)
            {
                result3 += aux;

                if (i < n - 1)
                    result3 += ", ";
                if (i == 0)
                    aux = 2;
                else
                //aux <<= 1;
                aux *= 2;
            }
            return result3;
        }

        //Serie4 numero positivos y negativos le paso numero y saca los multiplos de tres alternando en positivo y negativo ej: 0, -3, 6, -9
        public static string Serie4(int n) 
        {
            string result4 = "";
            int aux = 0;

            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 1)
                    result4 += -aux;
                else
                    result4 += aux;

                if (i < n - 1)
                    result4 += ", ";
         
                aux += 3;
            }
            return result4;
        }

        //Serie5 devuelve un string -> le paso un 30 y te hace fibonacci hasta el 30 -> while
        public static string Serie5(int n)
        {
            string result5 = "";
            int aux = 0;
            int aux2 = 1;

            while (aux <= n)
            {
                result5 += aux;
                if (aux2 <= n)
                    result5 += ", ";

                int aux3 = aux;
                aux = aux2;
                aux2 = aux3 + aux;
            }
            return result5;
        }

        /*
         string result = ""
        int n0 = 0;
        int n1 = 1;
        int temp = 0;

        while (temp < n)
        {
        temp = n0 + n1;
        n0 = n1;
        n1 = temp;
        --------------------

        while (n1 <= n || n2 <= n)
        {
        if (n1 < n2)
            n1 += n2;
        result5 += n1;
        else
            n2 += n1;
        result5 += n2;
             
         */

        //si es impar numero x 3 + 1, si el numero es par dividirlo entre 2 -> conjetura collatz

        public static string Serie6(int n)
        {
            string result6 = "";

            while (n != 1)
            {
                if (n % 2 == 0)
                    n /= 2;

                else if (n % 2 == 1)
                {
                    n = (n * 3) + 1;
                }
                if (n == 1)
                {
                    result6 += n;
                }
                else if (n != 1)
                    result6 += n + ", ";
            }

            return result6;
        }

        //factorial 5 = 5 + 4 + 3 + 2 + 1

        public static int Serie7(int n)
        {
            int result7 = 0;

            for (int i = n; i > 0; i--)
            {
                result7 += i;
            }
            return result7;
        }

        //productorio de 5 = 5 x 4 x 3 x 2 x 1 = 120

        public static int Serie8(int n)
        {
            int result8 = n;

            for (int i = n - 1; i > 0; i--)
            {
                result8 *= i;
            }
            return result8;
        }

        //funcion que le paso un numero y me devuelve el sumatorio de todos los numeros pares

        public static int Serie9(int n)
        {
            int result9 = 0;

            for (int i = n; i >= 0; i--)
            {
                if (IsEven(i) == true)
                    result9 += i;
            }

            return result9;
        }

        //funcion que le paso un numero y devuelve el sumatorio de todos los numeros primos que hay desde el 1 hasta al numero que le paso

        public static int Serie10(int n)
        {
            int result10 = 0;
            
            for (int i = n; i > 0; i--)
            {
                if (IsPrime(i) == true)
                    result10 += i;
            }
            return result10;
        }
    }
}
