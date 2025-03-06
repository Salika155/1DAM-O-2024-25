using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones
{
    public delegate int Comparator<T>(T a, T b);
    class Arbol<T> 
    {
        List<Nodo<T>> _children = new List<Nodo<T>>();
        public T item;
        private WeakReference<Nodo<T>>? _parent;
        public delegate void Visitor(Nodo<T> n);


        public int ChildCount
        {
            get { return _children.Count; }
        }
        public Nodo<T>? Parent
        {
            get { return GetParent(); }
            set { SetParent(value); }
        }



        public Arbol()
        {
        }

        public Arbol(Nodo<T> parent, List<Nodo<T>> children, T item)
        {
            _parent = new WeakReference<Nodo<T>>(parent);
            _children = children;
            this.item = item;
        }


        Nodo<T>? GetParent()
        {
            if (_parent == null)
                return null;
            Nodo<T>? result;
            _parent.TryGetTarget(out result);
            return result;
        }

        public void SetParent(Nodo<T>? newParent)
        {
            Unlink();
            if (newParent != null)
                newParent.AddChild(this);
        }
        public void AddChild(Nodo<T> child)
        {
            if (child == null)
                return;
            child._parent = new WeakReference<Nodo<T>>(this);
            _children.Add(child);
        }

        public void Unlink()
        {
            var p = GetParent();
            if (p == null)
                return;

            int index = GetIndexOf(this);
            p._children.RemoveAt(index);
            _parent = null;
        }

        int GetIndexOf(Nodo<T> value)
        {
            for (int i = 0; i < _children.Count; i++)
            {
                if (value == _children[i])
                    return i;
            }
            return -1;
        }
        public Nodo<T> GetRoot()
        {
            var p = Parent;
            if (p == null)
                return this;
            return p.GetRoot();
        }



        public void Visit(Visitor visitor)
        {
            visitor(this);

            foreach (Nodo<T> n in _children)
            {
                n.Visit(visitor);
            }
        }

        public Nodo<T>? FindNodeWithItem(T value, Comparator<T> c)
        {
            if (c(item, value) == 0)
                return this;

            foreach (var child in _children)
            {
                var ch = child.FindNodeWithItem(value, c);
                if (ch != null)
                    return ch;
            }

            return null;
        }

        public bool Contains(T value, Comparator<T> comp)
        {
            return FindNodeWithItem(value, comp) != null;
        }



        //public Arbol(Nodo<T> root)
        //{

        //}

        //public void AddChild(Nodo<T> hijo)
        //{
        //    if (hijo == null)
        //        return;


        //}

        //public int ChildCount()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Clear()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Contains(Nodo<T> nodo)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Detatch()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Nodo<T>> GetAncestors()
        //{
        //    throw new NotImplementedException();
        //}

        //public Nodo<T> GetChildAt(int index)
        //{
        //    throw new NotImplementedException();
        //}

        //public Nodo<T> GetRoot()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool IsRoot(Nodo<T> nodo)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemoveChild(Nodo<T> hijo)
        //{
        //    throw new NotImplementedException();
        //}

        //public void AddChild(Nodo<T> padre, Nodo<T> hijo)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemoveChild(Nodo<T> padre, Nodo<T> hijo)
        //{
        //    throw new NotImplementedException();
        //}

        //public Nodo<T>? FindNode(Func<Nodo<T>, bool> filtro)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<T> Filter(Func<Nodo<T>, bool> filtro)
        //{
        //    throw new NotImplementedException();
        //}

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
