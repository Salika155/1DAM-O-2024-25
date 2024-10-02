using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //6. Haz una función que, dado dos enteros, te diga si los dos números son múltiplos de 3 o múltiplos de 2.
        //7. Crea un programa que dado un número del 1 al 10, devuelva un string con la palabra que representa ese valor.
        //8. Haz una función que, dado un carácter, te diga si es o no un número. No puedes utilizar ninguna función externa.
        //9. Haz una función que te devuelva el sumatorio de un número. Si el número es menor que cero, se devolverá el sumatorio negativo.
        //10. Haz una función que te devuelva el productorio de un número tanto si es positivo como negativo. Si es negativo se debe empezar por -1.
        //11. Realiza una función que te diga si un número es primo o no.
        //12. Haz una función que, dado un entero, devuelva una cadena que contenga todos los números primos desde el 1 hasta ese número, separado por comas.
        //13. Haz una función que, dado un entero, te devuelva un string con el contenido de la serie de fibonacci por ese número separados por un guión. Este string comienza por un guión y
        //termina con un guión.
        //14. Haz una función que, dado dos puntos 2D, te devuelva la distancia entre estos puntos.
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
