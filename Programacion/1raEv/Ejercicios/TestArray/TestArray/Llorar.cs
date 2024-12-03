using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestArray
{
    internal class Llorar
    {
        //funcion que le paso un array y le añado un numero
        public static int[] AddArray(int[] array, int n)
        {
            if (array.Length == 0 || array == null)
                return new int[] {n};

            int lasPosit = array.Length;
            int[] result = new int[lasPosit + 1];

            for (int i = 0; i < lasPosit; i++)
            {
                result[i] = array[i];
            }
            result[lasPosit] = n;
            return result;
            
        }

        //RemoveAt -> quitar algo del array
        public static int[] RemoveAt(int[] array, int index)
        {
            if (array == null || array.Length == 0 || index < 0 || index >= array.Length)
                return array;

            int[] newarr = new int[array.Length - 1];

            for (int i = 0; i < index; i++)
            {
                newarr[i] = array[i];
            }

            for (int j = index + 1; j < array.Length; j++)
            {
                newarr[j - 1] = array[j];
            }
            return newarr;
        }

        //meter un elemento en la posicion index = 3
        //hacer una funcion que le paso un array y un valor y lo inserte en una posicion concreta
        public static int[] InsertIntoPosition(int[] array, int index)
        {
            if (array == null || array.Length == 0 || index < 0 || index >= array.Length)
                return [];

            int[] newarray = new int[array.Length + 1];

            for(int i = 0; i < index; i++)
            {
                newarray[i] = array[i];
            }
            newarray[index] = index;

            for (int i = index + 1; i < array.Length; i++)
            {
                newarray[i + 1] = array[i];
            }
            return newarray;
        }
        

        //me van a pasar dos arrays, la premisa es que estos arrays estan ordenados, MergeSort. Tenemos que generar un array ordenado con todos estos valores
        //de los dos arrays -> mirar cual es mas pequeño de los dos valores, e ir añadiendo al nuevo array
        public static int[] MergeSortArray(int[] array1, int[] array2)
        {
            if (array1 == null || array2 == null || array1.Length == 0 || array2.Length == 0)
                return [];

            int[] newarray = new int[array1.Length + array2.Length];
            int i, j, k;

            for (i = 0, j = 0, k = 0; i < array1.Length && j < array2.Length; k++)
            {
                if (array1[i] <= array2[j])
                {
                    newarray[k] = array1[i];
                    i++;
                }
                else
                {
                    newarray[k] = array2[j];
                    j++;
                }
            }

            for (; i < array1.Length; i++, k++)
            {
                newarray[k] = array1[i];
            }
            for (; j < array2.Length; j++, k++)
            {
                newarray[k] = array2[j];
            }
            return newarray;
        }
        
        
    }
}
