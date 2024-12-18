using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstract
{
    public delegate bool FilterDelegate<T>(T obj);
    public class ArrayUtils
    {
        //private T[]? _elements = new T[0];

        public static void ShuftLeft<T>(T[] element)
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

        public static bool ContainsElement<T>(T[] elements, T element)
        {
            return IndexOfElement(elements, element) != -1;
        }

        public static int IndexOfElement<T>(T[] elements, T index)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements.Equals(index))
                    return i;
            }
            return -1;
        }

        public static bool ContainsElements<T>(T?[] elements, T? element)
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

        //delegados 
        public static void OrdenaArrayEntero1(int[] array, IComparator comparator)
        {
            if (array == null)
                return;

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (comparator.IsMayor(array[i], array[j]))
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        //devuelve array nuevo para cada elemento del array generico, le pregunta al filtro si lo pone o no lo pone
        public static T[] Filter<T>(T[] array, FilterDelegate<T> del)
        {
            if (array == null || del == null)
                return new T[0];
            //arrayutils.filter (null, null)
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (del(array[i]))
                    count++;
            }
            T[] result = new T[count];
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (del(array[i]))
                {
                    //añadir al nuevo array
                    result[index] = array[i];
                    index++;
                }
            }
            return result;
        }
    }

    //hasta poner interface era una clase abstract
    public /*abstract class */ interface IComparator
    {
        //public bool IsMayor(int a, int b) => a > b;
        //Este podria ser valido con virtual
        //public virtual bool IsMayor(int a, int b) => a > b;
        public abstract bool IsMayor(int a, int b);
    }
    public class MyComparator : IComparator
    {
        //public override bool IsMayor(int a, int b)
        //{
        //    //podria tener un constructor?

        //}
        public bool IsMayor(int a, int b)
        {
            return a > b;
        }
    }

    /*public delegate bool IComparator (int a, int b)*/ // -> IComparator que es el que le dara el tipo a la funcion de abajo OrdenarArrayEntero1
                                                        //var c = new MyComparator(3, 4);
                                                        //OrdenarArrayEntero1(array, c)

    //OrdenarArrayEntero1(array, (a, b) =>
    /*
     * {
     * return a > b;
     * })
     * */

    //OrdenarArrayEntero1(array, (a, b) => a < b);

    //if (comparator.(array[i], array[j]))
    //               {
    //                   int temp = array[i];
    //                   array[i] = array[j];
    //                   array[j] = temp;
    //               }


    //public static void OrdenaArrayEntero1(T[] array, IComparator comparator)
    //{
    //    if (array == null)
    //        return;

    //    for (int i = 0; i < array.Length - 1; i++)
    //    {
    //        for (int j = i + 1; j < array.Length; j++)
    //        {
    //            if (comparator.IsMayor(array[i], array[j]))
    //            {
    //                int temp = array[i];
    //                array[i] = array[j];
    //                array[j] = temp;
    //            }
    //        }
    //    }
    //}
    /*public delegate bool IComparator<T> (T a, T b)*/

    //uso de lambdas para capturar eventos de un boton en una app, recivas evento de no tener internet se llame a una lambda.

    //bool berberecho
    // //OrdenarArrayEntero1(array, (a, b) => berberecho ? a < b : b < a);
    //berberecho de la lambda es una copia por constructor de la clase berberecho

    /*public delegate int IComparator<T> (T a, T b)*/
    //-1 mayor b, 0 iguales, 1 mayor a
    //if (comparator(array[i], array[j]) > 0)
}
