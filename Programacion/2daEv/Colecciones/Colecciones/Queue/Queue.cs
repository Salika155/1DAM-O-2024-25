using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones.Queue
{
    class Queue<T> : IQueue<T>
    {
        private List<T> _itemList = new List<T>();
        public bool Empty => IsEmpty();
        public T First => FirstElement();
        public int Count => CountElement();
        //public void Clear()
        //{
        //    while (_itemList.Count > 0)
        //    {
        //        _itemList.RemoveAt(_itemList.Count - 1);
        //    }
        //}
        public void Clear()
        {
            _itemList = new List<T>(); // Nueva lista vacía
        }

        public int CountElement()
        {
            return _itemList.Count;
        }

        public T Dequeue()
        {
            if (Empty)
                throw new InvalidOperationException("La cola está vacía.");
            T item = _itemList[0];
            _itemList.RemoveAt(0);
            return item;
        }

        public void Enqueue(T item)
        {
            _itemList.Add(item);
        }

        public T FirstElement()
        {
            if (Empty)
                throw new InvalidOperationException("La cola está vacía.");
            T first = _itemList[0];
            return first;
        }

        public bool IsEmpty()
        {
            return _itemList.Count == 0; 
        }

        public T Last()
        {
            if (Empty)
                throw new InvalidOperationException("La cola está vacía.");
            T last = _itemList[_itemList.Count - 1];
            return last;
        }
    }
}
