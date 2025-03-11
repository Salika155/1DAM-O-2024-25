using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenList
{
    class ExCompleto
    {
       
        public delegate bool FilterDelegate<T>(T element);

        internal class ExList<T>
        {
            private T[] _array;
            private int _count;

            public ExList()
            {
                _array = new T[4]; // Tamaño inicial de 4 para optimización
                _count = 0;
            }

            public int Count => _count;
            public int Capacity => _array.Length;
            public bool Empty => _count == 0;

            public T First
            {
                get
                {
                    if (Empty)
                        throw new InvalidOperationException("No hay elementos en la lista.");
                    return _array[0];
                }
            }

            public T Last
            {
                get
                {
                    if (Empty)
                        throw new InvalidOperationException("No hay elementos en la lista.");
                    return _array[_count - 1];
                }
            }

            public void Add(T element)
            {
                if (_count == _array.Length)
                {
                    // Duplicamos el tamaño del array cuando está lleno
                    T[] newArray = new T[_array.Length * 2];
                    for (int i = 0; i < _count; i++)
                    {
                        newArray[i] = _array[i];
                    }
                    _array = newArray;
                }

                _array[_count] = element;
                _count++;
            }

            public void RemoveAt(int index)
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException("Índice fuera de rango.");

                for (int i = index; i < _count - 1; i++)
                {
                    _array[i] = _array[i + 1];
                }

                _count--;
                _array[_count] = default!; // Liberar referencia
            }


            public T GetElementAt(int index)
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException("Índice fuera de rango.");

                return _array[index];
            }

            public void SetElementAt(int index, T element)
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException("Índice fuera de rango.");

                _array[index] = element;
            }

            public int IndexOf(T element)
            {
                for (int i = 0; i < _count; i++)
                {
                    if (_array[i] != null && _array[i]!.Equals(element))
                        return i;
                }
                return -1;
            }

            public bool Contains(T element)
            {
                return IndexOf(element) != -1;
            }

            public ExList<T> Filter(FilterDelegate<T> filter)
            {
                ExList<T> result = new ExList<T>();

                for (int i = 0; i < _count; i++)
                {
                    if (filter(_array[i]))
                    {
                        result.Add(_array[i]);
                    }
                }

                return result;
            }

            public void Sort(Comparison<T> comparison)
            {
                for (int i = 0; i < _count - 1; i++)
                {
                    for (int j = 0; j < _count - i - 1; j++)
                    {
                        if (comparison(_array[j], _array[j + 1]) > 0)
                        {
                            // Intercambiamos los elementos
                            T temp = _array[j];
                            _array[j] = _array[j + 1];
                            _array[j + 1] = temp;
                        }
                    }
                }
            }

            public void Clear()
            {
                _count = 0;
                _array = new T[4]; // Restablecemos el array inicial
            }

        }
    }

}

