using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class FuncEj1
    {
        //public int PositionInArray(int[] array1)
        //{

        //}

        //seria mejor implementar una funcion para hallar el minimo, otra 
        //para el maximo, y otra para la mediana.

        public static int MinValueInArray(int[] arrray)
        {
            if (arrray == null || arrray.Length == 0)
                return -1;
            //SortArray(arrray);
            //int num = 0;
            //for (int i = 0; i < arrray.Length -1; i++) 
            //{
            //    num = arrray[i];
            //}
            //return num;
            int minValue = arrray[0];
            for (int i = 0; i < arrray.Length; i++)
            {
                if (arrray[i] == minValue)
                    minValue = arrray[i];
            }
            return minValue;
        }

        public static int MaxValueInArray(int[] array)
        {
            //if (array == null)
            //    return -1;
            //SortArray(array);
            //int num = 0;
            //for (int i = array.Length - 1; i > 0; i--)
            //{
            //    num = array[i];
            //}
            //return num;
            if (array == null || array.Length == 0)
                return -1;

            int maxValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                    maxValue = array[i];
            }
            return maxValue;
        }

        public static double MidValueInArray(int[] array)
        {
            //if (array == null)
            //    return -1;
            //SortArray(array);
            //int midvalue = 0;
            //for (int i = 0; i < array.Length; i++)
            //{
            //    midvalue = array[i];
            //}
            //return midvalue / (array.Length/2 + 1);

            if (array == null || array.Length == 0)
                return -1;

            int[] sortedArray = (int[])array.Clone();
            Array.Sort(sortedArray);

            int midIndex = sortedArray.Length / 2;

            if (sortedArray.Length % 2 == 0)
            {
                return (sortedArray[midIndex - 1] + sortedArray[midIndex]) / 2.0;
            }
            else
            {
                return sortedArray[midIndex];
            }


        }

        public static int IndexOfArray(int[] array, int n)
        {
            if (array == null || n == 0)
                return -1;
            SortArray(array);
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == n)
                    return i;
            }
            return -1;
        }

        public static int[] SortArray(int[] array)
        {
            if (array == null || array.Length == 0)
            //int[] arrayord = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    int aux = array[i];
                    array[i] = array[j];
                    array[j] = aux;
                }
            }
            return array;
        }

        public static (int, int, double) GetMinMaxAndAvgArrayValors(int[] array)
        {
            //int min = MinValueInArray(array);
            //int max = MaxValueInArray(array);
            //int avg = MidValueInArray(array);
            //return (min, max, avg);

            if (array == null || array.Length == 0)
                return (-1, -1, -1);

            int minValue = MinValueInArray(array);
            int maxValue = MaxValueInArray(array);
            double medianValue = MidValueInArray(array);

            int minPos = Array.IndexOf(array, minValue);
            int maxPos = Array.IndexOf(array, maxValue);

            return (minPos, maxPos, medianValue);
        }
    }
}
