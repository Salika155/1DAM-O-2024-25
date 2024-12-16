using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstract
{
    internal class ArrayUtils <T>
    {
        private T[] elements = new T[0];

        public void ShiftLeft<T>(T[] element)
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

        public bool ContainsElement(T[] elements, T element)
        {
            return IndexOfElement(elements, element) != -1;
        }

        public int IndexOfElement(T[] elements, T index)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements.Equals(index))
                    return i;
            }
            return -1;
        }

        public bool ContainsElements(T[] elements, T element)
        {
            foreach(var e in elements)
            {
                if (e.Equals(element))
                    return true;
            }
            return false;
        }

        //funcion que le paso array de enteros y lo ordena
        public void OrdenaArrayEntero(int[] array)
        {
            int min = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                //otro for
                if (array[i] < min)
                {
                    min = array[i];
                    array[i] = 
                }
            }

        }


    }
}
