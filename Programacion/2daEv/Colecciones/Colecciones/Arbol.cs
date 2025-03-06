using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones
{
    class Arbol<T> : IArbol<T>
    {

        public delegate bool FilterDelegate();
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

        public void AddChild(Nodo<T> padre, Nodo<T> hijo)
        {
            throw new NotImplementedException();
        }

        public void RemoveChild(Nodo<T> padre, Nodo<T> hijo)
        {
            throw new NotImplementedException();
        }

        public Nodo<T>? FindNode(Func<Nodo<T>, bool> filtro)
        {
            throw new NotImplementedException();
        }

        public List<T> Filter(Func<Nodo<T>, bool> filtro)
        {
            throw new NotImplementedException();
        }

        //List<T> Filter(FilterDelegate<T> filter)
        //{
        //    var result = new List<T>();
        //    foreach(var child in _children)
        //    {
        //        if (filter(child.Item))
        //            result.Add(childItem)
        //    }
        //    return result;
        //}

        //void Filter(FilterDelegate<T> filter, List<T> result)
        //{
        //    //primero me verifico a mi mismo
        //    if (filter(this.Item))
        //        result.Add(this.Item);
        //    //funcion filter se propaga hacia abajo
        //    foreach(var c in _children)
        //    {
        //        c.Filter(filter, result);
        //    }
        //}
        //la otra funcion filter llamas a esta, con la lista creada y return result o lista

        //funcion que le paso un delegado (filtro), se lo voy a pedir a un nodo. Lo que quiero que devuelva es el primer nodo que 
        //cumpla ese filtro
        //Nodo<T>? FindNode(Filter filter)
        //{
        //    if (filter(Item))
        //        return this;
        //    foreach(var c in _children)
        //    {
        //        var n = c.FindNode(filter);
        //        if (n != null)
        //            return n;
        //    }
        //    return null;
        //}
    }
}
