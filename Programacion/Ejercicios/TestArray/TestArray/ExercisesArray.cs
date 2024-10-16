using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TestArray
{
    internal class ExercisesArray
    {
        //funcion que le paso un array y le añado un numero
        public static int[] Append(int[] array, int value) //append es el add de las listas pero para arrays
        {
            if(array == null || array.Length == 0)
            {
                int[] aux = new int[1];
                aux[0] = value;
                return aux;
            }

            int lasPosit = array.Length;
            int[] result = new int[lasPosit + 1];

            for(int i = 0; i < lasPosit; i++)
            {
                result[i] = array[i];
            }
            result[lasPosit] = value;
            return result;
        }

        //RemoveAt -> quitar algo del array
        public static int[] RemoveAt(int[] array, int index)
        {
            if (array == null || index < 0 || index >= array.Length)
                return array;
            //return new int[0];

            int[] result = new int[array.Length - 1];
            //dos for: uno para copiar los bloques 
            for (int i = 0; i < index; i++)
                result[i] = array[i];

            for (int i = index + 1; i < array.Length; i++)
                result[i - 1] = array[i];

            return result;

            //for(int i = index + 1; j = index; i < array.Length; i++; j++)
            //result[j] = array[i];
            //}
            //a veces es mejor definir el i y j fuera del for para poder ser utilizados
            //Otro metodo:
            /*for (int i = 0; i < a.Lenght; i++)
             * if (i < ind)
             *  newArray[i] = a[i]
             * else if (i > ind)
             *  newArray[i - 1] = a[i];
             *  */
            //Otro metodo:
            //cuando hay que mirar un rango de un valor entre dos numeros hacerlo asi: 
            //if (0 < index && index < array.Length)
            /*for (int = 0; i < array.Length - 1; i++)
             * {
             * if (i < index)
             *  result[i] = array[i];
             * else
             *  result[i] = array[i + 1];
             *  */
        }
        //meter un elemento en la posicion index = 3
        //hacer una funcion que le paso un array y un valor y lo inserte en una posicion concreta

        public static int GetLength(int[] array)
        {
            if (array == null)
                return 0;
            return array.Length;
        }
        public static int[] Insert(int[] array, int index, int value)
        {
            if (index < 0)
                return array;
            
            if (array == null && index != 0)
                return array;
            if (array == null)
            {
                int[] result = new int[1];
                result[0] = value;
                return result;
            }
            if (index > GetLength(array))
                return array;

            int[] newArray = new int[array.Length + 1];

            for(int i = 0; i <index; i++)
                newArray[i] = array[i];
            
            newArray[index] = value;

            for (int i = index + 1; i < array.Length; i++)
                newArray[i + 1] = array[i];

            //otro ejemplo
            //for (; i < index; i++)
            //    newArray[i] = array[i];

            //newArray[i++] = value;

            //for (int j = index; j < array.Length; j++)
            //    newArray[i++] = array[j];

            return newArray;
        }
        //me van a pasar dos arrays, la premisa es que estos arrays estan ordenados, MergeSort. Tenemos que generar un array ordenado con todos estos valores
        //de los dos arrays -> mirar cual es mas pequeño de los dos valores, e ir añadiendo al nuevo array

        public static int[] MergeSortArray(int[] array1, int[] array2)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            int array1l = array1.Length;
            int array2l = array2.Length;
            int[] arraysmerge = new int[array1l + array2l];
            

            for (; i < array1l && j < array2l; k++)
            {
                if (array1[i] <= array2[j])
                {
                    arraysmerge[k] = array1[i];
                    i++;
                }
                else
                {
                    arraysmerge[k] = array2[j];
                    j++;
                }  
            }
            for (; i < array1l; i++, k++)
                arraysmerge[k] = array1[i];
            for (; j < array2l; j++, k++)
                arraysmerge[k] = array2[j];

            return arraysmerge;
        }
    }
}
