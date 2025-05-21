using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueExamen
{
    public delegate bool FilterDelegate<T>(T element);
    public delegate void VisitDelegate<T>(T element);

    class ExQueue<T>
    {
        private T[] _arrayQueue = [];
        private int _count;

        public int Count => _count;

        public T Front
        {
            get
            {
                if (_count == 0)
                    throw new Exception();
                return _arrayQueue[0];
            }
            
        }
        public T Rear
        {
            get
            {
                if (_count == 0)
                    throw new Exception();
                return _arrayQueue[_count - 1];
            }
        }

        //public ExQueue(T[] arrayQueue)
        //{
        //    _arrayQueue = arrayQueue;
        //    Array.Copy(arrayQueue, _arrayQueue, arrayQueue.Length);
        //    _count = arrayQueue.Length;
        //}

        public T this[int index]
        {
            get 
            {
                if (index < 0 || index >= _count)
                    return default;
                return _arrayQueue[index];
            }
            set
            {
                _arrayQueue[index] = value;
            }
        }

       
        public void Enqueue(T element)
        {
            if (element == null)
                return;
            T[] result = new T[Count + 1];
            for(int i = 0; i < Count; i++)
            {
                result[i] = _arrayQueue[i];
            }
            result[Count] = element;

            _arrayQueue = result;
            _count++;
        }

        public T Dequeue()
        {
            if (_count == 0)
                throw new InvalidOperationException("Queue is empty.");

            T dequeuelement = _arrayQueue[0];
            T[] result = new T[Count - 1];
            for (int i = 1; i < Count; i++)
            {
                result[i - 1] = _arrayQueue[i];
            }
            _arrayQueue = result;
            _count--;
            return dequeuelement;
        }

        public int IndexOf(T element)
        {
            if (element == null)
                return -1;
            for (int i = 0; i < Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_arrayQueue[i], element))
                    return i;
            }
            return -1;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) >= 0;
        }

        public void Remove(T element)
        {
            if (element == null)
                return;
            int index = IndexOf(element);
            if (index == -1)
                return;

            T[] result = new T[Count - 1];

            for(int i = 0; i < index; i++)
            {
                result[i] = _arrayQueue[i];
            }
            for(int i = index + 1; i < Count; i++)
            {
                result[i - 1] = _arrayQueue[i];
            }
            _arrayQueue = result;
            _count--;
        }

        public void Clear()
        {
            _arrayQueue = Array.Empty<T>();
            _count = 0;        
        }

        public int IndexOf(FilterDelegate<T> del)
        {
            if (del == null)
                return -1;
            int index = 0;
            foreach(var c in _arrayQueue)
            {
                if (del(c))
                    return index;
                index++;
            }
            return -1;
        }

        public bool Contains(FilterDelegate<T> del)
        {
            return IndexOf(del) >= 0;
        }

        public Queue<T> Filter(FilterDelegate<T> del)
        {
            Queue<T> result = new Queue<T>();

            foreach(var c in _arrayQueue)
            {
                if (del(c))
                    result.Enqueue(c);
            }
            return result;
        }

        public T[] ToArray()
        {
            T[] copia = new T[Count];
            for(int i = 0; i < Count; i++)
            {
                copia[i] = _arrayQueue[i];
            }
            return copia;
            //o return clone;
            
        }

        //public ExQueue<T> CloneDeep() where T : ICloneable
        //{
        //    ExQueue<T> result = new ExQueue<T>();

        //    foreach (var item in _arrayQueue)
        //    {
        //        result.Enqueue((T)item.Clone()); // Solo si T implementa ICloneable
        //    }

        //    return result;
        //}

        public ExQueue<T> Clone()
        {
            ExQueue<T> result = new ExQueue<T>();

            foreach (var item in _arrayQueue)
            {
                result.Enqueue(item); // Copia superficial (shallow copy)
            }

            return result;
        }

        public ExQueue<T> Reverse()
        {
            ExQueue<T> result = new ExQueue<T>();
            for(int i = Count - 1; i >= 0; i--)
            {
                var a = _arrayQueue[i];
                result.Enqueue(a);
            }
            return result;
        }
    }
}
