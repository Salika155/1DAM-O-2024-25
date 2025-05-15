
namespace ExListaEV2Ex1BienHecho
{
    public delegate bool FilterDelegate<T>(T? el);
    public delegate void VisitDelegate<T>(T? el);
    public delegate bool SortDelegate<T>(T? el1, T? el2);

  public class ExList1<T>
  {
        private T[] _arrayL = [];
        private int _count = 0;

        public int Count => _count;

        public int Capacity => _arrayL.Length;

        public T First
        {
            get
            {
                if (Count == 0)
                    throw new Exception();
                return _arrayL[0];
            }
        }

        public T Last
        {
            get
            {
                if (Count == 0)
                    throw new Exception();
                return _arrayL[Count - 1];
            }
        }

        public T? GetElementAt(int index)
        {
            if (index < 0 || index > Count)
                return default;
            return _arrayL[index];
        }

        public void SetElementAt(int index, T el)
        {
            if (index < 0 || index > Count)
                return;
            _arrayL[index] = el;
        }

        //aqui tengo problemas
        public void Add(T element)
        {
            if (Capacity == Count)
            {
                T[] result = new T[Count + 1];
                for (int i = 0; i < Count; i++)
                {
                    result[i] = _arrayL[i];
                }
                result[Count] = element;
                _arrayL = result;
            }
            else
            {
                _arrayL[Count] = element;
            }
            _count++;
        }

        public void Clear()
        {
            _count = 0;
        }

        //aqui tengo problemas
        public void Insert(int index, T element)
        {
            if (Capacity == Count)
            {
                T[] array = new T[Count + 1];
                for (int i = 0; i < Count; i++)
                {
                    array[i] = _arrayL[i];
                }
                array[index] = element;
                for (int i = index; i < Count; i++)
                {
                    array[i + 1] = _arrayL[i];
                }
                _arrayL = array;
            }
            else
            {
                for(int i = 0; i < Count; i--)
                {
                    _arrayL[i] = _arrayL[i - 1];
                }
                _arrayL[index] = element;
            }
            _count++;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > Count)
                    return default;
                return _arrayL[index];
            }
            set
            {
                _arrayL[index] = value;
            }
        }

        public int IndexOf(T element)
        {
            if (element == null)
                return -1;
            for(int i = 0; i < Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_arrayL[i], element))
                    return i;
            }
            return -1;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(FilterDelegate<T>? del)
        {
            if (del == null)
                return -1;
           foreach(var c in _arrayL)
            {
                if (del(c))
                    return IndexOf(del);
            }
            return -1;
        }

        public bool Contains(FilterDelegate<T>? del)
        {
            return IndexOf(del) != -1;
        }

        public void Visit(VisitDelegate<T>? del)
        {
            if (del == null)
                return;
            foreach(var c in _arrayL)
            {
                del(c);
            }
        }

        public void Sort(SortDelegate<T>? del)
        {
            for(int i = 0; i < Count; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    T aux;
                    aux = _arrayL[i];
                    _arrayL[i] = _arrayL[j];
                    _arrayL[j] = aux;
                }
            }
        }

        public ExList1<T> Filter(FilterDelegate<T>? del)
        {
            ExList1<T> result = new();
            if (del == null)
                return result;
            foreach(var c in _arrayL)
            {
                if (del(c))
                    result.Add(c);
            }
            return result;
        }

        public T[] ToArray()
        {
            T[] result = [];
            for(int i = 0; i < Count; i++)
            {
                result[i] = _arrayL[i];
            }
            return result;
        }

        public ExList1<T> Clone()
        {
            ExList1<T> result = new();
            for(int i = 0; i < Count; i++)
            {
                result.Add(_arrayL[i]);
            }
            return result;
        }

        public void Reversed()
        {
            T[] reversed = new T[Count];
            for(int i = 0, j = Count - 1; i < Count; i++, j--)
            {
                reversed[i] = _arrayL[i];
            }
            _arrayL = reversed;
        }

        public void RemoveAt(int index)
        {
            for(int i = index; i < Count - 1; i++)
            {
                _arrayL[i] = _arrayL[i + 1];
            }
            _arrayL[Count - 1] = default!;
            _count--;
        }

        public ExList1<T> Reverse
        {
            get
            {
                if (Count == 0)
                    throw new Exception();
                return ReversedArray();
            }
        }

        public ExList1<T> ReversedArray()
        {
            var result = Clone();
            result.Reversed();
            return result;
        }
    }
}
