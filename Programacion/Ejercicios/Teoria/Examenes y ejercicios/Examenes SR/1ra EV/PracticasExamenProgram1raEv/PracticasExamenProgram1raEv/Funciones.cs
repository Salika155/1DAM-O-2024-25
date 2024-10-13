using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticasExamenProgram1raEv
{
    internal class Funciones
    {
        //menor de 2 numeros
       public static int MenorQue(int a, int b)
        {
            return (a <= b) ? a : b;
        }

        //numero es par
        public static bool EsPar(int a)
        {
            return (a % 2 == 0);
        }
       

        //menor de 3 numeros(2 versiones)
        public static int MenorQueTres(int a, int b, int c) 
        {
            if (a <= b && b >= c)
                return a;
            else if (b <= c && b <= a)
                return b;
            return c;
        }
       
        public static int MenorQueTres2(int a, int b, int c)
        {
            return MenorQue(a, MenorQue(b, c));
        }


        //serie 0, -2, 4, -6, 8 imprimen
        
        public static void Serie1(int s)
        {
            int valor = 0;

            for (int i = 0; i < s; i++)
            {
                if (valor == 1)
                {
                    valor = 0;
                    Console.WriteLine(-i);
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

        // Primo

        public static bool EsPrimo(int n)
        {
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        

        //Serie 0, 5, 3, 8, 6, 11 
       
        public static void Serie2(int num)
        {
            int n = 0;
            int a = 1;

            Console.WriteLine(n);
            for (int i = 0; i < num; i++)
            {
                if (a >= 0)
                    n += 5;
                else
                    n -= 2;

                Console.WriteLine(n);
                a *= -1;
            }
        }

        //Sumatorio

        public static int Sumatorio(int n)
        {
            int result = 0;
            for (int i = 0; i < n; i++)
                result += i;
            return result;

        }


        //Productorio

        public static int Productorio(int n)
        {
            int result = 1;
            for (int i = 1; i < n; i++)
                result *= i;
            return result;
            
        }

        //funcion que concatene dos strings

        public static string ConcatenacionStrings(string a, string b)
        {
            return a + b;
        }


        //0, 1, 2, 3, 4, 5, 6, 7

        public static string Serie3(int n)
        {
            string res = "";

            for (int i = 0; i <= n; i++)
            {
                res += i + ", ";
            }
            return res;
        }


        //1, 2, 4, 8, 16, 32, 64

        public static string Serie4(int n)
        {
            string res = "";
            int valor = 1;

            for (int i = 0; i < n; i++)
            {
                if (i < n - 1)
                    res += valor + ", ";
                else 
                    res += valor;

                valor *= 2;
            }
            return res;
        }


        //serie de fibonacci 0, 1, 1, 2, 3, 5, 8, 13, 21

        public static string Fibonacci(int n)
        {
            string serie = "";
            int aux = 0;
            int auxb = 1;
            int auxc = 0;
            

            for (int i = 0; i < n; i++)
            {
                serie += " " + aux + ", ";
                auxc = aux + auxb;
                aux = auxb;
                auxb = auxc;
            }
            return serie;
        }

        //--------------------------------------------------


        //Funcion numero de valores mayor que cero lista
        


        //Cuantos elementos tiene la lista
       

        //internal static int GreatLesserThanZero(List<string> l2)
        //{
        //    throw new NotImplementedException();
        //}

        //Cuantos elementos tiene el array
        

        //quiero una funcion que le paso una lista de enteros y un numero, y me tiene que decir si ese numero esta en la lista o no


       

        //public static bool ContainsInList(List<double> listaenteros, int n)
        //{
        //    if (listaenteros != null)
        //    {
        //    for (int i = 0; i < listaenteros.Count; i++)
        //    {
        //        if (listaenteros[i] == n)
        //            return true;
        //    }
        //}
        //return false;
        //}

        // #Region comprobacion de parametros -> titulo dado a una seccion desplegable para comprimir codigo.
        //#endregion

        //Me pasan una lista de enteros y me dice el numero mayor que hay en esa lista de enteros


        /// <summary>
        /// Funcion que devuelve el valor mayor de una lista de enteros
        /// </summary>
        /// <param name="listamayor">lista de enteros</param>
        /// <returns>numero mas alto, si n es null devuelve int.MinValue</returns>
        


        //Pasar una lista de enteros, quiero devolver la posicion donde se encuentra el valor mas alto de la lista.

       

        //Funcion que le paso una lista de enteros y me dice si esta ordenada o no de manera ascendente

       

        //lista ordenada de otra manera
       

        //Contiene elemento dentro del array
        

        //punto medio, comparo y muevo valores

        

        //funcion que se le pasa un array de dobles y devuelve la media de todos los valores que hay ahi

        

        //Funcion que le pasas un array y un umbral y tiene que devolver la media de todos estos valores pero solamente de aquellos que superen este numero

        

        // Funcion que le paso una lista de enteros y me devuelve un entero. Devuelve numero de veces que se repite el numero mas alto



        // Funcion que necesita como parametro una lista de enteros, y me tiene que devolver una lista de enteros pero al reves de la lista que le he metido
        // [0, 7, -1, 8] -> [8, -1, 7, 0]

        

        //Funcion que le paso una lista de enteros y los imprime por pantalla

        


        //Funcion que necesita como parametro un array de enteros, y me tiene que devolver un array de enteros pero al reves del array que le he metido

       

        //Funcion que le paso un array de enteros, y un entero, y quiero que esa funcion añada el entero que se le pasa al array

        

        //algoritmo de la burbuja

        //l, i, j

        //swap
        //int aux;
        //aux = l[i];
        //l[i[ = l[j];
        //l[j] == aux;

        //sort array

        //public static Array SortArray(int[] arraysort)
        //{
           
        //}

        //sortlista

        //public static List<int> SortLista(List<int> listashort)
        //{

            
        //}

        //collatz serie 3n + 1
        //Funcion que le paso un numero y me devuelva la serie de collatz de ese numero
        //si es par divida entre 2
        //si es impar multiplique por 3 y le sume 1

        //public static List<int> SerieCollatz(int n)
        //{

        //}

        // Funcion que le pase una lista y me devuelva una lista con los dos elementos mayores



        //Funcion que le pasas una lista de enteros y quiero que me devuelvas otra lista pero solo con los numeros pares que haya en esa lista

        //public static List<int> GetElementosParesLista(List<int> l)
        //{
           
        //}

        //hallar los numeros pares de un array
        //public static int[] GetPairsArray(List<int> l)
        //{
           
        //}



        // Funcion que le paso una lista de enteros y le paso una posicion. Lo que tiene que hacer esta funcion es borrar el elemento de esa posicion en la lista

        //public static void RemovePositionInList(List<int> list, int index)
        //{
            
        //}

        //[0, 7, 1, 8, 4]
        // Funcion paso una lista y un valor. Tiene que borrar de la lista el numero 8 sin usar el Remove.

        //public static void RemovePositionList(List<int> list1, int value)
        //{
           
        //}

        //Funcion igual con array

        //public static int[]? RemovePositionArray(int[] arrayremove, int value1)
        //{
            
        //}

        //crear funcion countelements para que funcione

        //public static int CountElements(int[] array, int value)
        //{
            
        //}


        //todolo que potencialmente pueda valer null, se le puede poner la interrogacion ? al final del elemento int[]?

        //RemoveValues que estan en una lista 
        //public static void RemoveValues(List<int> l1, List<int> values)
        //{

        //}

        //removevalues para array

        //public static void RemoveValues1(List<int> l1, List<int> values1)
        //{
            

        //}





    }
}
