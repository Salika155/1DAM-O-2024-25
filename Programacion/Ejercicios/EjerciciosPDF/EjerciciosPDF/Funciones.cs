using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace EjerciciosPDF
{
    internal class Funciones
    {
        //1. Haz una función que, dado un real, te devuelva su valor absoluto. (No puede usar otra función dentro de esa función).
        public static int GetReal(int n)
        {
            if (n == 0)
                return 0;
            else if (n > 0)
                return n;
            else
                return n * (-1);
        }
        // 2. Haz una función que te diga si un número es par o no.
        public static bool IsPair(int n1)
        {
            return n1 % 2 == 0;
        }

        //3. Haz una función que te diga si un número es impar o no.
        public static bool IsNotPair(int n1)
        {
            return !IsPair(n1);
        }

        //4. Haz una función que te diga si dos números son parejos.
        public static bool SonParejos(int n1, int n2)
        {
            return (IsPair(n1) && IsPair(n2)) ? true : false;
        }
            
        //5. Haz una función que te diga si, dado dos números, uno es par y otro no.
        public static string EsParOImpar(int n1, int n2)
        {
            string result = string.Empty;

            if (IsPair(n1) && !IsPair(n2))
            {
                result = n1 + " Es par y " + n2 + "Es impar";
            }
            else if (IsPair(n2) && !IsPair(n1))
            {
                result += n2 + "Es par y " + n1 + "Es impar";
            }
            else if (SonParejos(n1, n2))
            {
                result = n1 + " y " + n2 + " son pares"; 
            }
            else
                result = "son impares";
            return result;
        }

        //6. Haz una función que, dado dos enteros, te diga si los dos números son múltiplos de 3 o múltiplos de 2.
        public enum Multiplos
        {
            NO_ES_MULTIPLO,
            MULTIPLO_DE_2,
            MULTIPLO_DE_3
        }
        public static Multiplos EsMultiplode3o2(int n1, int n2)
        {
            if (n1 % 2 == 0 && n2 % 2 == 0)
                return Multiplos.MULTIPLO_DE_2;
            else if (n1 % 3 == 0 && n2 % 3 == 0)
                return Multiplos.MULTIPLO_DE_3;
            else
                return Multiplos.NO_ES_MULTIPLO;
        }

        //7. Crea un programa que dado un número del 1 al 10, devuelva un string con la palabra que representa ese valor.
        public static string DevolverValorEnTexto(int n1)
        {
            switch(n1) 
            {
                case 1: 
                    return "Uno";
                case 2:
                    return "Dos";
                case 3:
                    return "Tres";
                case 4:
                    return "Cuatro";
                case 5:
                    return "Cinco";
                case 6:
                    return "Seis";
                case 7:
                    return "Siete";
                case 8:
                    return "Ocho";
                case 9:
                    return "Nueve";
                case 10:
                    return "Diez";
                default:
                    return "El numero tiene que ser entre 1 y 10";
            }
        }

        //8. Haz una función que, dado un carácter, te diga si es o no un número. No puedes utilizar ninguna función externa.
        public static bool IsNumberOrNot(int n)
        {
            if (n > int.MinValue && n < int.MaxValue)
                return true;
            return false;
        }

        //9. Haz una función que te devuelva el sumatorio de un número. Si el número es menor que cero, se devolverá el
        //sumatorio negativo.
        public static int GetSumatorioOfNumber(int n)
        {
            int result = 0;

            if (n > 0)
            {
               for(int i = 1; i < n; i++)
                {
                    result += i;
                }
            }
            else if (n < 0)
            {
                for (int i = -1; i > n; i--)
                {
                    result += i;
                }
            }
            return result;
        }

        //10. Haz una función que te devuelva el productorio de un número tanto si es positivo como negativo. Si es negativo se debe empezar por -1.
        public static int GetProductoryOfNumber(int n)
        {
            int result = 0;

            if (n > 0) 
            { 
                for (int i = 1; i <= n; i++)
                {
                    result *= i;
                }
            }
            else if (n < 0)
            {
                for (int i = -1; i >= n; i--)
                {
                    result *= i;
                    if (i > 0)
                    {
                        i *= -1;
                    }
                }
            }
            return result;
        }
        //11. Realiza una función que te diga si un número es primo o no.
        public static bool IsPrime(int n)
        {
            if (n <= 1)
                return false;

            for(int i = 2; i <= n; i++)
            {
                if (IsDivisible(n, i))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsDivisible(int a, int b)
        {
            return b != 0 && a % b == 0;
        }
        //12. Haz una función que, dado un entero, devuelva una cadena que contenga todos los números primos desde el 1 hasta ese número, separado por comas.
        public static string GetPrimos(int n)
        {
            string result = "";
            
            for(int i = 2; i <= n; i++)
            {
                if (IsPrime(i))
                {
                    if (result.Length > 0)
                    {
                        result += ", ";
                    }
                    result += i.ToString();
                }
            }
            return result;
        }

        //private static bool EsPrimo(int n)
        //{
        //    if (n< 2) return false;

        //    for (int i = 2; i <= n; i++)
        //    {
        //        if (n % i == 0)
        //            return false;
        //    }
        //    return true;
        //}

        //13. Haz una función que, dado un entero, te devuelva un string con el contenido de la serie de fibonacci por ese número separados por un guión. Este string comienza por un guión y
        //termina con un guión.
        public static string SerieFibbonacci(int n)
        {
            int aux = 0;
            int aux2 = 1;
            string result = "";

            while(aux <= n)
            {
                result += aux;
                if (aux2 <= n)
                    result += ", ";

                int aux3 = aux;
                aux = aux2;
                aux2 = aux3 + aux;
            }
            return result;
        }


        //14. Haz una función que, dado dos puntos 2D, te devuelva la distancia entre estos puntos.
        public static double GetDistanceBetween2Punto2D(Punto2D a, Punto2D b)
        {
            double distanceY = (b.y - a.y) * (b.y - a.y);
            double distanceX = (b.x - a.x) * (b.x - a.x);

            double result = Math.Sqrt(distanceX) + Math.Sqrt(distanceY);

            return result;
        }
        //15. Haz una función que te devuelva el determinante de una matriz 3x3.
        //16. Haz una función que te devuelva el área de un círculo.
        //17. Haz una función que te devuelva el volumen de una esfera.
        //18. Haz una función que te devuelva el área de un triángulo.
        //19. Haz una función que te devuelva el área de un rectángulo.
        //20. Haz una función que, dado los tres lados de un triángulo rectángulo, te devuelve el menor valor.
        //21. Realiza una función que imprima la tabla de multiplicar de un número hasta el 10.
        //22. Realiza una función que imprima la tabla de multiplicar de dos números. Es decir, dado un número n, imprimiría 1x1xn, 1x2xn, 1x3xn, .... 2x1xn, 2x2xn, ... hasta el 10x10.
        //23. Haz una función que devuelva, dado un string, ese mismo string pero escrito al revés. No se puede utilizar ninguna función dentro de esa función.
        //24. Haz una función que, dado un número, imprima por pantalla, el valor en binario de ese número.

    }
}
