using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoExamen
{
    public class ExamenJulioCO24
    {
        //(1 punto) (Nota mínima 7) Implementa la siguiente función: Implementa una función que, dado
        //un array de enteros, te devuelva, la posición del valor mínimo, la posición del valor máximo y la
        //mediana del array.La mediana de un array de enteros es el valor que se encuentra en el centro
        //del array cuando sus elementos están ordenados de menor a mayor; si el array tiene un número
        //par de elementos, la mediana es el promedio de los dos valores centrales.Puedes hacer trampas,
        //…, un poco
        public static List<int> GetMinMaxAndMidPositionInArray(int[] array)
        {
            List<int> result = new List<int>();

            int min = GetMinValuePositionInArray(array);
            int max = GetMaxValuePositionInArray(array);
            int mid = GetMedianaPositionInArray(array);
            
            result.Add(min);
            result.Add(max);
            result.Add(mid);
            
            return result;
        }

        public static int IndexOfArray(int[] array, int n)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == n)
                    return i;
            }
            return -1;
        }

        public static int GetMinValuePositionInArray(int[] array) 
        {
            if (array == null || array.Length == 0)
                return -1;
            int min = int.MaxValue;
            for(int i = 0; i < array.Length; i++) 
            {
                if (array[i] < min)
                    min = array[i];
            }
            return IndexOfArray(array, min);
        }

        public static int GetMaxValuePositionInArray(int[] array) 
        {
            if (array == null || array.Length == 0)
                return -1;
            int max = int.MinValue;
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }
            return IndexOfArray(array, max);
        }

        public static int GetMedianaPositionInArray(int[] array)
        {
            int[] sortedArray = SortArray(array);
            int midIndex = sortedArray.Length / 2;

            if (array == null || array.Length == 0)
                return 0;

            if (array.Length % 2 == 0)
            {
                return sortedArray[midIndex - 1] + sortedArray[midIndex] / 2;
            }
            return sortedArray[midIndex];
            
        }

        public static int[] SortArray(int[] array) 
        {
            int n = array.Length;
            if (array == null ||n == 0)
                return [];

            int[] result = (int[])array.Clone();

            for (int i = 0; i < n - 1; ++i) 
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++) 
                {
                   if (result[j] < result[minIndex])
                        minIndex = j;
                }
                int aux = result[minIndex];
                result[minIndex] = result[i];
                result[i] = aux;
            }
            return result;
        }

        //2 puntos) (Nota mínima 7) Implementa la siguiente función.
        //Escribe una función que reciba una lista de números enteros y devuelva una lista de pares de
        //números que sumen un número objetivo dado.Por ejemplo:
        //números = [2, 4, 3, 5, 7, 8, 9]
        //objetivo = 10
        //Resultado: [(2, 8), (3, 7)]

        public static List<(int, int)> GetParesSumables(List<int> list, int n)
        {
            if (list == null || list.Count == 0)
                return new List<(int, int)> ();

            List<(int, int)> result = new List<(int, int)>();

            for (int i = 0; i < list.Count; i++)
                for (int j = i + 1; j < list.Count; j++)
                {
                    int suma = list[i] + list[j];
                    if (suma % 2 == 0 && suma == n)
                        result.Add((list[i], list[j]));
                }
            return result;
        }

        //(1 punto) (Nota mínima 7) Implementa la siguiente función: Implementa una función que, dado
        //un número “n”, devuelve una lista con los n primeros números de la serie de fibonacci.
        
        public static List<int> SerieFibonacci(int n)
        {
            List<int> result = new List<int>();
            if (n <= 0) return result;

            result.Add(0); // F(0)
            if (n > 1) result.Add(1); // F(1)

            for (int i = 2; i < n; i++)
            {
                int nextFib = result[i - 1] + result[i - 2];
                result.Add(nextFib);
            }
            return result;
        }

        public static List<int> SerieFibonacci1(int n)
        {
            List<int> result = new List<int>();
            int a = 0, b = 1;

            for (int i = 0; i < n; i++)
            {
                result.Add(a);
                int temp = a + b;
                a = b;
                b = temp;
            }
            return result;
        }

        //(2 puntos) (Nota mínima 7) Implementa la siguiente función.
        //Una función llamada Merge, que reciba dos arrays de enteros que están ordenados y devuelva un
        //array ordenado con el contenido de los dos arrays de entrada.Prohibido usar algoritmos de
        //ordenación, ni de C#, ni tuyos. El algoritmo se explicará en la pizarra.

        public static int[] MergeArrays(int[] a, int[] b)
        {
            int[] result = new int[a.Length + b.Length];
            int i = 0, j = 0, k = 0;

            while (i < a.Length && j < b.Length)
            {
                if (a[i] <= b[j]) 
                    result[k++] = a[i++];
                else
                    result[k++] = b[j++];
            }

            // Agregar los elementos restantes del array `a`, si los hay
            while (i < a.Length)
                result[k++] = a[i++];

            // Agregar los elementos restantes del array `b`, si los hay
            while (j < b.Length)
                result[k++] = b[j++];

            return result;
        }
    }
}
