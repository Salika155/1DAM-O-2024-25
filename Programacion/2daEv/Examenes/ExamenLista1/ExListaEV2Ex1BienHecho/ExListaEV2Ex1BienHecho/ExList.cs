using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ExListaEV2Ex1BienHecho
{
    // Definición de clase genérica ExList que representa una lista de elementos de tipo T
    class ExList<T>
    {
        public delegate bool FilterDelegate<T>(T item);
        public delegate void ActionDelegate<T>(T item);
        public delegate bool SortDelegate<T>(T item1, T item2);

        // Array interno que almacena los elementos de la lista
        private T[] _arrayList = []; // Esto es válido en C# 12+, crea un array vacío de tipo T

        // Variable que indica cuántos elementos tiene actualmente la lista
        private int _count = 0;

        // Propiedad que devuelve el número de elementos actuales en la lista
        public int Count => _count;

        // Propiedad que devuelve la capacidad interna del array (cuántos elementos puede almacenar sin redimensionar)
        public int Capacity => _arrayList.Length;

        // Propiedad que devuelve el primer elemento de la lista
        public T First
        {
            get
            {
                if (Count == 0)
                    throw new Exception(); // Lanza una excepción si la lista está vacía
                return _arrayList[0]; // Devuelve el primer elemento del array
            }
        }

        // Propiedad que devuelve el último elemento de la lista
        public T Last
        {
            get
            {
                if (Count == 0)
                    throw new Exception(); // Lanza una excepción si la lista está vacía
                return _arrayList[Count - 1]; // Devuelve el último elemento (posición = Count - 1)
            }
        }

        // Propiedad que devuelve una nueva lista con los elementos en orden inverso
        public ExList<T> Reverse
        {
            get
            {
                if (Count == 0)
                    throw new Exception(); // Lanza excepción si la lista está vacía
                return ReverseArray(); // Llama a un método privado que invierte los elementos
            }
        }

        // Método privado que devuelve una nueva lista con los elementos en orden inverso
        public ExList<T> ReverseArray()
        {
            var result = Clone();    // Crea una copia de la lista actual
            result.Reversed();       // Invierte los elementos de la copia
            return result;           // Devuelve la lista invertida
        }

        // Método público que invierte el orden de los elementos del array actual
        public void Reversed()
        {
            T[] reversed = new T[Count]; // Crea un nuevo array del mismo tamaño

            // Recorre desde el final del array original hacia el principio
            // y copia los elementos en orden inverso al nuevo array
            for (int i = 0, j = Count - 1; i < Count; i++, j--)
            {
                reversed[i] = _arrayList[j];
            }

            // Sustituye el array original por el invertido
            _arrayList = reversed;
        }

        // Método privado que crea una copia (clon) exacta de la lista actual
        public ExList<T> Clone()
        {
            ExList<T> clone = new(); // Crea una nueva instancia de ExList<T>

            // Copia cada elemento actual al nuevo array usando Add()
            for (int i = 0; i < Count; i++)
            {
                clone.Add(_arrayList[i]);
            }

            return clone; // Devuelve la lista clonada
        }

        public T? GetElementAt(int index)
        {
            if (index < 0 || index >= Count)
                return default;
            return _arrayList[index];
        }

        public void SetElementAt(int index, T value)
        {
            if (index < 0 || index >= Count)
                throw new Exception();
            _arrayList[index] = value;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    return default(T);
                return _arrayList[index];
            }
            set
            {
                _arrayList[index] = value;
            }
        }

        public void Add(T value)
        {
           if (Capacity == Count)
           {
                T[] array = new T[Count + 1];
                for (int i = 0; i < Count; i++)
                {
                    array[i] = _arrayList[i];
                }
                array[Count] = value;
                _arrayList = array;
           }
            else
            {
                _arrayList[Count] = value;
            }
            _count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                return; // No hace nada si el índice está fuera de rango

            // Desplazar todos los elementos a la izquierda desde 'index + 1'
            for (int i = index; i < Count - 1; i++)
            {
                _arrayList[i] = _arrayList[i + 1];
            }

            // Opcional: limpiar la última posición (no afecta Count)
            _arrayList[Count - 1] = default!;

            _count--; // Reducir el número de elementos
        }

        public void Clear()
        {
            _count = 0;
        }

        public void Insert(int index, T element)
        {
            // Si la capacidad actual del array es igual al número de elementos que tiene,
            // necesitamos redimensionar el array para poder insertar un nuevo elemento
            if (Capacity == Count)
            {
                // Crear un nuevo array con una posición adicional
                T[] array = new T[Count + 1];

                // Copiar los elementos desde el principio hasta antes del índice donde insertaremos
                for (int i = 0; i < index; i++)
                {
                    array[i] = _arrayList[i];
                }

                // Insertar el nuevo elemento en la posición indicada
                array[index] = element;

                // Copiar el resto de los elementos, desplazados una posición a la derecha
                for (int i = index; i < Count; i++)
                {
                    array[i + 1] = _arrayList[i];
                }

                // Sustituir el array original con el nuevo que incluye el nuevo elemento
                _arrayList = array;
            }
            else
            {
                // Si no necesitamos redimensionar, primero mover los elementos existentes
                // desde el final hacia adelante para hacer espacio para el nuevo elemento
                for (int i = Count; i > index; i--)
                {
                    _arrayList[i] = _arrayList[i - 1];
                }

                // Insertar el nuevo elemento en la posición indicada
                _arrayList[index] = element;
            }

            // Incrementar el contador de elementos
            _count++;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_arrayList[i], element))
                    return i;
            }
            return -1;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(FilterDelegate<T> del)
        {
            if (del == null)
                return -1;
            foreach(var element in _arrayList)
            {
                if (del(element))
                    return IndexOf(element);
            }
            return -1;
        }

        public bool Contains(FilterDelegate<T> del)
        {
            return IndexOf(del) != -1;
        }

        public void Visit(ActionDelegate<T> del)
        {
            if (del == null)
                return;

            foreach(var element in _arrayList)
            {
                del(element);
            }
        }

        public void Sort(SortDelegate<T> del)
        {
            for (int i = 0; i < Count; i++)
            {
                for(int j = i  + 1; j < Count; j++)
                {
                    T aux;
                    if (del(_arrayList[i], _arrayList[j]))
                    {
                        aux = _arrayList[i];
                        _arrayList[i] = _arrayList[j];
                        _arrayList[j] = aux;
                    }
                }
            }
        }

        public ExList<T> Filter(FilterDelegate<T> del)
        {
            ExList<T> result = new();
            if (del == null)
                return result;
            foreach(var element in _arrayList)
            {
                if (del(element))
                   
                    result.Add(element);
            }
            return result;
        }

        public T[] ToArray()
        {
            T[] result = [];
            for (int i = 0; i < Count; i++)
            {
                result[i] = _arrayList[i];
            }
            return result;
        }
    }
}




