using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstract
{
    internal class ArrayUtils <T>
    {
        private T[]? _elements = new T[0];

        public static void ShuftLeft(T[] element)
        {
            if (element == null)
                return;

            T[] sufflelements = new T[element.Length + 1];
            T parte = element[0];

            for (int i = 1; i < element.Length; i++)
            {
                element[i] = element[i + 1];
            }
            element[element.Length - 1] = parte;
        }

        //quiero una funcion que le paso un array de elementos y me diga si hay un elemento en concreto ahi

        public static bool ContainsElement(T[] elements, T element)
        {
            return IndexOfElement(elements, element) != -1;
        }

        public static int IndexOfElement(T[] elements, T index)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements.Equals(index))
                    return i;
            }
            return -1;
        }

        public static bool ContainsElements(T?[] elements, T? element)
        {
            if (elements == null || element == null)
                return false;

            foreach(var e in elements)
            {
                if (e.Equals(element))
                    return true;
            }
            return false;
        }

        //funcion que le paso array de enteros y lo ordena
        public static void OrdenaArrayEntero(int[] array)
        {
            if (array == null)
                return;

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
}
