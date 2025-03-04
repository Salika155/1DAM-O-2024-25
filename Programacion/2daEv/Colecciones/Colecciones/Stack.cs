using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones
{
    class Stack<T> : IStack<T>
    {
        /* El Stack<T> es una colección LIFO (Last In, First Out), 
         * lo que significa que el último elemento en entrar 
         * será el primero en salir.
         */
        private readonly List<T> _itemsList;

        public Stack()
        {
            _itemsList = new();
        }
        public bool IsEmpty()
        {
            return (_itemsList.Count == 0);
        }

        public T Peek()
        {
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
    }
}
