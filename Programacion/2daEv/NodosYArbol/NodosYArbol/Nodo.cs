using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodosYArbol
{
    class Nodo<T>
    {
        private List<Nodo<T>> _listaNodos = new List<Nodo<T>>();
        private T _contenidoNodo;
        private WeakReference<Nodo<T>>? _weakNodoPadre;

        public Nodo(T contenidoNodo)
        {
            if (contenidoNodo == null)
                throw new Exception("el contenido no puede ser nulo");
            _contenidoNodo = contenidoNodo;
        }

        public T Contenido
        {
            get => _contenidoNodo;
            set => _contenidoNodo = value ?? throw new Exception("");
        }
        
        

        public Nodo<T>? Parent
        {
            get => _weakNodoPadre?.TryGetTarget(out var parent) == true ? parent : null;
            set => SetParent(value);
        }

        public void SetParent(Nodo<T>? nuevoPadre)
        {
            if (Parent != null)
                Parent.RemoveChild(this);

            _weakNodoPadre = nuevoPadre != null ? new WeakReference<Nodo<T>>(nuevoPadre) : null;

            if (nuevoPadre != null)
                nuevoPadre.AddChild(this);
        }

        public bool IsRoot => Parent == null;
        public bool ChildCount => _listaNodos.Count == 0;
        public int Count => _listaNodos.Count;
        public int Level => GetLevel();

        private int GetLevel()
        {
            return Parent == null ? 0 : Parent.GetLevel() + 1;
        }

        public Nodo<T> Root => GetRoot();
        private Nodo<T> GetRoot()
        {
            return Parent == null ? this : Parent.GetRoot();
        }

        public Nodo<T> GetChildrenAt(int index)
        {
            if (index < 0 || index >= _listaNodos.Count)
                return null;
            return _listaNodos[index];
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _listaNodos.Count)
                return;
            var child = _listaNodos[index];
            _listaNodos.RemoveAt(index);
        }

        private void AddChild(Nodo<T> hijo)
        {
            if (hijo == null)
                return;
            hijo.Parent = this; // -> el nodo al que añadimos el nuevo pasa a ser padre, del hijo que añadimos.
            _listaNodos.Add(hijo);
        }

        private void RemoveChild(Nodo<T> hijo)
        {
            if (hijo == null)
                return;
            _listaNodos.Remove(hijo);
        }

        
    }
}
