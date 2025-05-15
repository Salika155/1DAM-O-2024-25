using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using ExListaEV2Ex1BienHecho;

namespace ExListaEV2Ex1BienHecho
{
    class Texto
    {
        //Implementa una clase que sea una lista hecha con genéricos.
        //● La clase se llamará ExList
        //● (A) La lista se implementará usando un array. 

        //El número de elementos que tiene el array no tiene por qué coincidir con el
        // número de elementos de la lista.
        //● Las properties que hay que implementar son: 
        //	○ (A) Count → Devuelve el número de elementos que hay en la lista. 
        //	○ (A) Capacity → Devuelve la capacidad interna de la lista.
        //	○ (A) First → Devuelve el primer elemento de la lista, si no se
        //    puede, hay que lanzar una excepción.
        //	○ (A) Last → Devuelve el último elemento de la lista, si no se
        //    puede, hay que lanzar una excepción.
        //	○ (D) Reversed → Devuelve una copia de la lista pero con los
        //    elementos en el orden inverso.
        //● Los métodos a implementar son: 
        //	○ (A) GetElementAt(index) → Devuelve el elemento que está en la
        //    posición “index”. En caso de que no se pueda, se debe devolver un
        //    valor por defecto.
        //	○ (A) SetElementAt(index, element) → Pone (remplaza) el elemento
        //    en la posición “index”. 
        //	○ (A) Add(element) → Añade un elemento al final de la lista. 
        //	○ (B) RemoveAt(index) → Quita de la lista el elemento que está
        //    en la posición “index”. Esta función no crea un array nuevo.
        //	○ (A) Clear() → Quita todos los elementos de la lista.
        //    Esta función no crea un array nuevo.
        //	○ (A) Insert(index, element) → Inserta el nuevo elemento en
        //    la posición especificada. Por ejemplo, si inserto “hola” en la
        //    posición 2, y luego llamo a GetElementAt(2) me devolverá hola.
        //    Esta función hará que la lista tenga un elemento más.
        //	○ (C) IndexOf(element) → Devuelve la posición en la que se
        //    encuentra un elemento. 
        //	○ (C) Contains(element) → Dice si un elemento está en la lista. 
        //	○ (C) IndexOf(delegate) → Devuelve la posición en la que se
        //    encuentra un elemento.
        //	○ (C) Contains(delegate) → Dice si un elemento está en la lista.
        //	○ (C) Visit(delegate) → Pasa por todos los elementos de la
        //    lista invocando a una lambda que se le pasa como parámetro con
        //    cada elemento recorrido.
        //	○ (D) Sort(delegate) → Ordena la lista con el criterio de un
        //    delegado que se le tiene que pasar como parámetro.
        //	○ (B) Filter(delegate) → Devuelve una ExList con los elementos
        //    que superen el filtro que es un delegado.
        //	○ (D) Reverse() → Le da la vuelta a la lista.
        //	○ (D) Clone() → Devuelve una copia de la lista. 
        //	○ (A) ToArray() → Devuelve un array (una copia, no el array
        //    interno) con todos los elementos de la lista y sólo con los
        //    elementos de la lista.

       
    }
}

//public delegate void Visit<T>(T element);
//public delegate bool FilterDelegate<T>(T element);
//public delegate bool SortDelegate<T>(T el1, T el2);

//class ExList1<T>
//{
//    private T[] _arrayList = [];
//    private int _count = 0;

//    public int Count => _count;
//    public int Capacity => _arrayList.Length;

//    public T First
//    {
//        get
//        {
//            if (Count == 0)
//                throw new Exception();
//            return _arrayList[0];
//        }
//    }

//    public T Last
//    {
//        get
//        {
//            if (Count == 0)
//                throw new Exception();
//            return _arrayList[Count - 1];

//        }
//    }

//    public T this[int index]
//    {
//        get
//        {
//            if (0 > index || index >= Count)
//                return default(T);
//            return _arrayList[index];
//        }
//        set
//        {
//            _arrayList[index] = value;
//        }
//    }

//    public void Add(T value)
//    {
//        //if (Capacity == Count)
//        //{
//        //    T[] array = new T[Count + 1];
//        //    for(int i = 0; i < Count; i++)
//        //    {
//        //        array[i] = _arrayList[i];
//        //    }
//        //    array[Count] = value;
//        //    _arrayList = array;
//        //}
//        //else
//        //{
//        //    _arrayList[Count] = value;
//        //}
//        //_count++;
//        if (Capacity == Count)
//        {
//            T[] array = new T[Count + 1];
//            for (int i = 0; i < Count; i++)
//            {
//                array[i] = _arrayList[i];
//            }
//            array[Count] = value;
//            _arrayList = array;
//        }
//        else
//        {
//            _arrayList[Count] = value;
//        }
//        _count++;
//    }

//    public void Clear()
//    {
//        _count = 0;
//    }

//    public void Insert(int index, T element)
//    {
//        //// Si la capacidad actual del array es igual al número de elementos que tiene,
//        //// necesitamos redimensionar el array para poder insertar un nuevo elemento
//        //if (Capacity == Count)
//        //{
//        //    // Crear un nuevo array con una posición adicional
//        //    // Copiar los elementos desde el principio hasta antes del índice donde insertaremos

//        //    T[] array = new T[Count + 1];
//        //    for (int i = 0; i < Count; i++)
//        //    {
//        //        array[i] = _arrayList[i];
//        //    }
//        //    // Insertar el nuevo elemento en la posición indicada
//        //    array[index] = element;
//        //    for (int i = index + 1; i < Count + 1; i++)
//        //    {
//        //        // Copiar el resto de los elementos, desplazados una posición a la derecha
//        //        // Sustituir el array original con el nuevo que incluye el nuevo elemento
//        //        array[i] = _arrayList[i - 1];
//        //    }
//        //    _arrayList = array;
//        //}
//        //else
//        //// Si no necesitamos redimensionar, primero mover los elementos existentes
//        //// desde el final hacia adelante para hacer espacio para el nuevo elemento

//        //// Insertar el nuevo elemento en la posición indicada
//        //// Incrementar el contador de elementos
//        //{
//        //    _arrayList[index] = element;
//        //    for(int i = index + 1; i < Count + 1; i++)
//        //    {
//        //        _arrayList[i] = _arrayList[i - 1];
//        //    }
//        //    _count++;
//        //}   
//        if (Capacity == Count)
//        {
//            T[] array = new T[Count + 1];
//            for (int i = 0; i < Count; i++)
//            {
//                array[i] = _arrayList[i];
//            }
//            array[index] = element;
//            for (int i = index + 1; i < Count + 1; i++)
//            {
//                array[i] = _arrayList[i - 1];
//            }
//            _arrayList = array;
//        }
//        else
//        {
//            _arrayList[index] = element;
//            for (int i = index + 1; i < Count + 1; i++)
//            {
//                _arrayList[i] = _arrayList[i - 1];
//            }
//        }
//        _count++;
//    }


//    public void RemoveAt(int index)
//    {
//        if (index < 0 || index >= Count)
//            return;
//        for (int i = 0; i < Count - 1; i++)
//        {
//            _arrayList[i] = _arrayList[i + 1];
//        }
//        _count--;
//    }

//    public int IndexOf(T value)
//    {
//        for (int i = 0; i < Count; i++)
//        {
//            if (EqualityComparer<T>.Default.Equals(_arrayList[i], value))
//                return i;
//        }
//        return -1;
//    }
//    public bool Contains(T value)
//    {
//        return IndexOf(value) != -1;
//    }
//    public ExList<T> Clone()
//    {
//        ExList<T> result = new();
//        for (int i = 0; i < Count; i++)
//        {
//            result.Add(_arrayList[i]);
//        }
//        return result;
//    }
//    public T[] ToArray()
//    {
//        T[] array = [];
//        for (int i = 0; i < Count; i++)
//        {
//            array[i] = _arrayList[i];
//        }
//        return array;
//    }
//    public int IndexOf(FilterDelegate<T> del)
//    {
//        if (del == null)
//            return -1;

//        foreach (var c in _arrayList)
//        {
//            if (del(c))
//                return IndexOf(c);
//        }
//        return -1;
//    }
//    public bool Contains(FilterDelegate<T> del)
//    {
//        return IndexOf(del) != -1;
//    }
//    public void Visit(Visit<T> del)
//    {
//        if (del == null)
//            return;
//        foreach (var c in _arrayList)
//        {
//            del(c);
//        }
//    }
//    public void Sort(SortDelegate<T> del)
//    {
//        for (int i = 0; i < Count; i++)
//        {
//            for (int j = i + 1; j < Count; j++)
//            {
//                T aux;
//                if (del(_arrayList[i], _arrayList[j]))
//                {
//                    aux = _arrayList[i];
//                    _arrayList[i] = _arrayList[j];
//                    _arrayList[j] = aux;
//                }
//            }
//        }
//    }
//    public ExList<T> Filter(FilterDelegate<T> del)
//    {
//        ExList<T> result = new();
//        if (del == null)
//            return result;
//        foreach (var c in _arrayList)
//        {
//            if (del(c))
//                result.Add(c);
//        }
//        return result;
//    }
//    public void Reverse()
//    {
//        T[] array = new T[Count];
//        for (int i = 0, j = Count - 1; i < Count; i++, j--)
//        {
//            array[i] = _arrayList[j];
//        }
//        _arrayList = array;
//    }
//    public ExList<T> Reversed()
//    {
//        ExList<T> result = Clone();
//        _arrayList.Reverse();
//        return result;

//    }



//}
