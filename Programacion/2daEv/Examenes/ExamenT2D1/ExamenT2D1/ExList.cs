

namespace ExamenT2D1
{
    public class ExList<T>
    {
        public delegate bool FilterDelegate<T>(T item);
        public delegate void ActionDelegate<T>(T item);
        public delegate bool SortDelegate<T>(T item1, T item2);

        private T[] _array = [];
        private int _count = 0;

        public int Capacity => _array.Length;
        public int Count => _count;
        public T First
        {
            get
            {
                if (Count == 0)
                    throw new Exception("There aren't elements");
                return _array[0];
            }
        }
        public T Last
        {
            get
            {
                if (Count == 0)
                    throw new Exception("There aren't elements");
                return _array[Count - 1];
            }
        }
        public T this[int index]
        {
            get
            {
                if (0 > index || index >= Count)
                    return default(T);
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }

        public void Add(T value)
        {
            if (Capacity == Count)
            {
                T[] array = new T[Count + 1];
                for(int i = 0; i < Count; i++)
                {
                    array[i] = _array[i];
                }
                array[Count] = value;
                _array = array;
            }
            else
            {
                _array[Count] = value;
            }
            _count++;
        }
        public void Insert(int index, T value)
        {
            if (Capacity == Count)
            {
                T[] array = new T[Count + 1];
                for (int i = 0; i < index; i++)
                {
                    array[i] = _array[i];
                }
                array[index] = value;
                for (int i = index + 1; i < Count + 1; i++)
                {
                    array[i] = _array[i - 1];
                }
                _array = array;
            }
            else
            {
                _array[index] = value;
                for (int i = index + 1; i < Count + 1; i++)
                {
                    _array[i] = _array[i - 1];
                }
            }
            _count++;
        }
        public void RemoveAt(int index)
        {
            if (0 > index || index >= Count)
                return;
            for(int i = index; i < Count - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            _count--;
        }
        public void Clear()
        {
            _count = 0;
        }
        public int IndexOf(T value)
        {
            for(int i = 0; i < Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_array[i], value))
                    return i;
            }
            return -1;
        }
        public bool Contains(T value)
        {
            return IndexOf(value) != -1;
        }
        public ExList<T> Clone()
        {
            ExList<T> result = new();
            for(int i = 0; i < Count; i++)
            {
                result.Add(_array[i]);
            }
            return result;
        }
        public T[] ToArray()
        {
            T[] result = [];
            for(int i = 0; i < Count; i++)
            {
                result[i] = _array[i];
            }
            return result;
        }
        public int IndexOf(FilterDelegate<T> del)
        {
            if (del == null)
                return -1;
            foreach (var element in _array)
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
            foreach (var element in _array)
            {
                del(element);
            }
        }
        public void Sort(SortDelegate<T> del)
        {
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    T aux;
                    if (del(_array[i], _array[j]))
                    {
                        aux = _array[i];
                        _array[i] = _array[j];
                        _array[j] = aux;
                    }
                }
            }
        }
        public ExList<T> Filter(FilterDelegate<T> del)
        {
            ExList<T> result = new();
            if (del == null)
                return result;
            foreach (var element in _array)
            {
                if (del(element))
                    result.Add(element);
            }
            return result;
        }
        public void Reverse()
        {
            T[] array = new T[Count];
            for(int i = 0, j = Count - 1; i < Count; i++, j--)
            {
                array[i] = _array[j];
            }
            _array = array;
        }
        public ExList<T> Reversed()
        {
            ExList<T> result = Clone();
            result.Reverse();
            return result;
        }
    }
}
