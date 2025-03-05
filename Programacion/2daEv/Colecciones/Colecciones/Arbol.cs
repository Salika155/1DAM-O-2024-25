using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones
{
    class Arbol<T> : IArbol<T>
    {
        public Nodo<T> Root { get; set; }
        private List<T> _nodoList = new();

        public Arbol(Nodo<T> root)
        {
            Root = root;
        }

        public void AddChild(Nodo<T> hijo)
        {
            if (hijo == null)
                return;
            if (_nodoList[i] == hijo)
            _nodoList.Add(hijo);
        }

        public int ChildCount()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Nodo<T> nodo)
        {
            throw new NotImplementedException();
        }

        public void Detatch()
        {
            throw new NotImplementedException();
        }

        public List<Nodo<T>> GetAncestors()
        {
            throw new NotImplementedException();
        }

        public Nodo<T> GetChildAt(int index)
        {
            throw new NotImplementedException();
        }

        public Nodo<T> GetRoot()
        {
            throw new NotImplementedException();
        }

        public bool IsRoot(Nodo<T> nodo)
        {
            throw new NotImplementedException();
        }

        public void RemoveChild(Nodo<T> hijo)
        {
            throw new NotImplementedException();
        }
    }
}
