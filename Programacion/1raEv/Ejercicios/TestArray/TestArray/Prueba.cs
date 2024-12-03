using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestArray
{
    internal class Prueba
    {
        //funcion que le paso un array y le añado un numero
        public static int[] Append(int[] array, int n)
        {
            int lastp = array.Length;
            int[] arrayn = new int[lastp + 1];

            for(int i = 0; i < array.Length; i++)
            {
                arrayn[i] = array[i];
            }
            arrayn[lastp] = n;
            return arrayn;
        }

        //RemoveAt -> quitar algo del array

        public static int[] RemoveAt(int[] array, int index)
        {
            int[] result = new int[array.Length - 1];
            for(int i = 0; i < index; i++)
            {
                result[i] = array[i];
            }
            for(int i = index + 1; i < array.Length - 1; i++)
            {
                result[i - 1] = array[i];
            }
            return result;
        }

        //meter un elemento en la posicion index = 3
        //hacer una funcion que le paso un array y un valor y lo inserte en una posicion concreta

        public static int[] Insert(int[] array, int index, int value)
        {
            int[] result = new int[array.Length + 1];

            for(int i = 0; i < index; i++)
            {
                result[i] = array[i];
            }
            result[index] = value;
            for(int i = index + 1; i < array.Length + 1; i++)
            {
                result[i + 1] = array[i];
            }

            return result;
        }

        //me van a pasar dos arrays, la premisa es que estos arrays estan ordenados, MergeSort. Tenemos que generar un array ordenado con todos estos valores
        //de los dos arrays -> mirar cual es mas pequeño de los dos valores, e ir añadiendo al nuevo array

        public static int[] MergeSortArray(int[] array1, int[] array2)
        {
            int[] result = new int[array1.Length + array2.Length];

            return result;
        }
    }
}
