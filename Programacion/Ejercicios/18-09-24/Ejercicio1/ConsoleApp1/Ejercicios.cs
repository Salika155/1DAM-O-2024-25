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
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
    }
}
