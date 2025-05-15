using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenArrays
{
    class Pool<T> : IPool<T> where T : class
    {
        private T[] _elementos;
        private int _count;

        private Pool(int capacidad)
        {
            _elementos = new T[capacidad];
            _count = 0;
        }

        private Pool(T[] items)
        {
            _elementos = new T[items.Length];
            for(int i = 0; i < items.Length; i++)
            {
                _elementos[i] = items[i];
            }
            _count = items.Length;
        }

        public int Count => _count;
        public static IPool<T> Crear(params T[] elements)
        {
            return new Pool<T>(elements);
        }

        public IPool<T> Clone()
        {
            T[] result = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                result[i] = _elementos[i];
            }
            return new Pool<T>(result);
        }

        public T[] ToArray()
        {
            T[] result = new T[Count];
            for(int i = 0; i < Count; i++)
            {
                result[i] = _elementos[i];
            }
            return result;

        }

        public void Add(T element)
        {
            if (Count == _elementos.Length)
            {
                T[] nuevo = new T[_elementos.Length + 10];
                for(int i = 0; i < _elementos.Length; i++)
                {
                    nuevo[i] = _elementos[i];
                }
                _elementos = nuevo;
            }
            _elementos[Count] = element;
            _count++;
        }

        public bool Remove(T item)
        {
            if (item == null)
                return false;

            for (int i = 0; i < Count; i++)
            {
                if (_elementos[i] == item)
                {
                    // Mover todos los elementos a la izquierda desde i+1
                    for (int j = i; j < Count - 1; j++)
                    {
                        _elementos[j] = _elementos[j + 1];
                    }
                    _elementos[Count - 1] = null;
                    _count--;
                    return true;
                }
            }
            return false;
        }
    }
}
