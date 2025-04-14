using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSet
{
    public delegate bool ContainDelegate<T>(T element);
    public delegate void VisitDelegate<T>(T element);
    public delegate bool FilterDelegate<T>(T element);
    internal class ExSet<T>
    {
        private readonly T[] _arraySet = new T[0];
        private int _count;
        private T? item;


        

        public class Item()
        {
            private int _hash;
            private T? _item;
        }




        public int Count => _arraySet.Length;
        public bool IsEmpty => _arraySet.Length == 0;

        public void Add(T? element)
        {
            if (element == null)
                return;
            _arraySet[Count] = element;
        }

        public bool Contains(T? element)
        {
            if (IsEmpty)
                return false;
            return IndexOf(element) != -1;
            //return IndexOf() != -1;
        }

        public int IndexOf(T? element)
        {
            if (element == null)
                return -1;

            for (int i = 0; i < _arraySet.Length; i++)
            {
                var valor = _arraySet[i];
                if (Equals(valor, element))
                    return i;
            }
            return -1;
        }

        public T[] Remove(T? element)
        {
            T[] arraynuevo = new T[_arraySet.Length - 1];
            int index = IndexOf(element);
            if (element == null)
                return arraynuevo;

            for (int i = 0; i < index; i++)
            {
                arraynuevo[i] = _arraySet[index];
            }
            for (int i = index; i < _arraySet.Length; i++)
            {
                arraynuevo[i] = _arraySet[index + 1];
            }
            return arraynuevo;
        }

        public ExSet<T> Clear()
        {
            return new ExSet<T>();
        }

        public void Visit(VisitDelegate<T> visit)
        {
            foreach (var e in _arraySet)
            {
                visit(e);
            }
        }

        public bool Contains(ContainDelegate<T> element)
        {
            foreach(var c in _arraySet)
            {
                if (c.Equals(element))
                    return true;
            }
            return false;
        }

        public ExSet<T> Filter(FilterDelegate<T> filter)
        {
            ExSet<T> set = new ExSet<T>();

            foreach(var c in _arraySet)
            {
                if (filter(c))
                {
                    set.Add(c);
                }
            }
            return set;
        }

        public ExSet<T> Clone()
        {
            ExSet<T> clone = new ExSet<T>();

            return clone;
        }

    }
}
