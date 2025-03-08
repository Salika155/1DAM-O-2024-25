using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones.Stack
{
    class Stack<T> : IStack<T>
    {
        /* El Stack<T> es una colección LIFO (Last In, First Out), 
         * lo que significa que el último elemento en entrar 
         * será el primero en salir.
         */
        private readonly List<T> _itemsList;
        //private T[] _stackArray = new T[0];

        public Stack()
        {
            _itemsList = new();
        }

        public bool IsEmpty()
        {
            return _itemsList.Count == 0;
        }

        //public bool IsEmptyA()
        //{
        //    return (_stackArray.Length == 0);
        //}

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("El Stack está vacío.");

            return _itemsList[_itemsList.Count - 1];
        }

        public T Pop()
        {
            if (_itemsList.Count == 0)
                throw new Exception("debe tener algo");

            T item = _itemsList[_itemsList.Count - 1];
            _itemsList.RemoveAt(_itemsList.Count - 1);
            return item;
        }

        public void Push(T item)
        {
            if (item == null)
                throw new Exception("debes introducir algo");
            _itemsList.Add(item);
        }

        //mejor empezar desde el final a eliminar
        public void Clear()
        {
            while (!IsEmpty())
            {
                _itemsList.RemoveAt(_itemsList.Count - 1);
            }
        }
            
    }
}
