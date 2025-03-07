using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones
{
    public delegate bool FilterDelegate<T>(T item);
    class Nodo<T>
    {
        private List<Nodo<T>> _children = new List<Nodo<T>>();
        private WeakReference<Nodo<T>>? _parent;
        private T? _item;

        public Nodo<T>? Parent
        {
            get => GetParent();
            set
            {
                if (value != null)
                {
                    SetParent(value);
                }
            }
        }

        public int ChildCount => _children.Count;
        
        public T? Item
        {
            get => _item;
            set => _item = value;
        }

        ////esto no se ni que es
        //public Nodo<T> this[int index] => _children[index];

        public Nodo(T item)
        {
            _item = item;
        }

        public Nodo<T>? GetParent()
        {
            if (_parent == null)
                return null;
            _parent.TryGetTarget(out Nodo<T>? result);
            return result;
        }

        public void SetParent(Nodo<T> newParent)
        {
            //if (newParent.Parent == null)
            //    return;
            Detach();
            if (newParent != null)
                newParent.AddChild(this);
        }

        private void AddChild(Nodo<T> child)
        {
            if (child == null /*|| *//*_children.Contains(child)*/)
                return;
            child._parent = new WeakReference<Nodo<T>>(this);
            _children.Add(child);
        }

        private void Detach()
        {
            var p = GetParent();
            if (p == null)
                return;
            //el remove no puedo usarlo, se tiene que remover de otra
            //manera pero un metodo remove como este esta prohibido
            p._children.Remove(this);
            _parent = null;
        }

        public Nodo<T> GetRoot()
        {
            var p = Parent;
            return p == null ? this : p.GetRoot();
        }

        public void Clear()
        {
            //esto estoy seguro que no puedo usarlo
            _children.Clear();
        }

        public Nodo<T>? FindNode(FilterDelegate<T> filter)
        {
            if (Item != null && filter(Item))
                return this;

            foreach (var c in _children)
            {
                var n = c.FindNode(filter);
                if (n != null)
                    return n;
            }
            return null;
        }

        public void Filter(FilterDelegate<T> filter, List<T> resultado)
        {
            if (Item != null && filter(Item))
                resultado.Add(Item);

            foreach (var c in _children)
            {
                c.Filter(filter, resultado);
            }
        }

        public Nodo<T>? GetChildAt(int index)
        {
            if (index < 0 || index >= _children.Count)
                return null;
            return _children[index];
        }

        

        
        


    }
}
