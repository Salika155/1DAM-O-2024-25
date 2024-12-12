using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaContenedores
{
    public class Set<T>
    {
        //comprobar que el elemento no exista, y añadirlo da igual la posicion
        //para remover es igual
        private readonly List<T?> _setList = new();

        public int Count => _setList.Count;
        public bool Empty => _setList.Count == 0;

        public void AddElement(T element)
        {
            if (!ContainsInSet(element))
                _setList.Add(element);
        }

        public void RemoveElement(T element)
        {
            for (int i = 0; i < _setList.Count; i++)
            {
                if (AreEquals(_setList[i], element))
                {
                    _setList.RemoveAt(i);
                    break;
                }   
            }
        }

        public int IndexOfSet(T element)
        {
            for (int i = 0; i < _setList.Count; i++)
            {
                if (AreEquals(_setList[i], element))
                    return i;
            }
            return -1;
        }

        public bool ContainsInSet(T element)
        {
            return IndexOfSet(element) != -1;
        }

        public bool AreEquals(T? a, T? b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (a == null || b == null)
                return false;
            return a.Equals(b);
        }


        //public bool AreEquals(object? obj)
        //{
        //    if (this == obj)
        //        return true;
        //    if (obj is not Set<T>)
        //        return false;
        //    Set<T> s = (Set<T>)obj;
        //}

    }
}
