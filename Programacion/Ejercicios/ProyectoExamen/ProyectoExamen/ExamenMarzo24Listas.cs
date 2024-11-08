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

namespace ProyectoExamen
{
    public class ExamenMarzo24Listas<T>
    {
        private T[] _items;
        private int _count;

        public ExamenMarzo24Listas()
        {
            _items = new T[0];
            _count = 0;
        }

        public int Count => _count;

        public T First
        {
            get
            {
                if (_count == 0) throw new Exception();
                return _items[0];
            }
        }

        public T Last
        {
            get
            {
                if (_count == 0) throw new Exception();
                return _items[Count - 1];
            }
        }

        #region oculto
        //Implementa una clase que sea una lista hecha con genéricos.
        //● La clase se llamará ExList
        //● (A) La lista se implementará usando un array.

        //● Las properties que hay que implementar son:
        //○ (A) Count → Devuelve el número de elementos que hay en la lista.
        //○ (A) First → Devuelve el primer elemento de la lista, si no se puede, hay que lanzar
        //una excepción.
        //○ (A) Last → Devuelve el último elemento de la lista, si no se puede, hay que lanzar
        //        una excepción.
        //○ (D) Reversed → Devuelve una copia de la lista pero con los elementos en el orden
        //inverso.
        #endregion
        //● Los métodos a implementar son:
        //○ (A) GetElementAt(index) → Devuelve el elemento que está en la posición “index”.
        //En caso de que no se pueda, se debe devolver un valor por defecto.
        public T GetElementAt(int index)
        {
            if (index < 0 || index >= _count)
                return default;
            return _items[index];
        }
        
        //○ (A) SetElementAt(index, element) → Pone (remplaza) el elemento en la posición “index”.
        public void SetElementAt(int index, T value)
        {

        }
        //○ (A) Add(element) → Añade un elemento al final de la lista.
        public void Add(T element)
        {
            if (_count == _items.Length)
            {
                T[] newArray = new T[_items.Length * 2];
                Array.Copy(_items, newArray, _count);
                _items = newArray;
            }
            _items[_count++] = element;
        }
        //○ (B) RemoveAt(index) → Quita de la lista el elemento que está en la posición “index”.
        //○ (A) Clear() → Quita todos los elementos de la lista.
        //○ (A) Insert(index, element) → Inserta el nuevo elemento en la posición especificada.
        //Por ejemplo, si inserto “hola” en la posición 2, y luego llamo a GetElementAt(2) me
        //devolverá hola.Esta función hará que la lista tenga un elemento más.
        //○ (C) IndexOf(element) → Devuelve la posición en la que se encuentra un elemento.
        //○ (C) Contains(element) → Dice si un elemento está en la lista.
        //○ (C) Visit(delegate) → Pasa por todos los elementos de la lista invocando a una
        //lambda que se le pasa como parámetro con cada elemento recorrido.
        //○ (D) Sort(delegate) → Ordena la lista con el criterio de un delegado que se le tiene
        //que pasar como parámetro.
        //○ (B) Filter(delegate) → Devuelve un array con los elementos que superen el filtro
        //que es un delegado.
        //○ (D) Reverse() → Le da la vuelta a la lista.
        //○ (D) Clone() → Devuelve una copia de la lista.
        //○ (A) ToArray() → Devuelve un array (una copia, no el array interno) con todos los
        //elementos de la lista.

    }
}
