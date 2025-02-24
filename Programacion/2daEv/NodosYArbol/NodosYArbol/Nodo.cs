using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NodosYArbol
{
    class Nodo<T>
    {
        public delegate bool FilterDelegate<T>(Nodo<T> filtro);

        private List<Nodo<T>> _listaNodos = new List<Nodo<T>>();
        private T _contenidoNodo;
        private WeakReference<Nodo<T>>? _weakNodoPadre;

        public Nodo(T contenidoNodo)
        {
            if (contenidoNodo == null)
                throw new ArgumentNullException(nameof(contenidoNodo), "El contenido no puede ser nulo.");

            _contenidoNodo = contenidoNodo;
        }

        public T Contenido
        {
            get => _contenidoNodo;
            set => _contenidoNodo = value ?? throw new ArgumentNullException(nameof(value), "El contenido no puede ser nulo.");
        }

        public Nodo<T>? Parent
        {
            get => _weakNodoPadre?.TryGetTarget(out var parent) == true ? parent : null;
            set => SetParent(value);
        }

        private int GetLevel()
        {
            //// Accede directamente al campo _weakNodoPadre en lugar de la propiedad Parent
            //if (_weakNodoPadre == null || !_weakNodoPadre.TryGetTarget(out var parent))
            //    return 0;
            //return parent.GetLevel() + 1;
             
            int level = 0;
            Nodo<T>? current = this;
            while (current != null)
            {
                if (current._weakNodoPadre?.TryGetTarget(out var parent) ?? false)
                {
                    level++;
                    current = parent;
                }
                else
                {
                    current = null;
                }
            }
            return level;
        }
        

        private Nodo<T> GetRoot()
        {
            //// Accede directamente al campo _weakNodoPadre
            //if (_weakNodoPadre == null || !_weakNodoPadre.TryGetTarget(out var parent))
            //    return this;
            //return parent.GetRoot();
            Nodo<T> current = this;
            while (true)
            {
                if (current._weakNodoPadre?.TryGetTarget(out var parent) ?? false)
                {
                    current = parent;
                }
                else
                {
                    return current;
                }
            }
        }

        public void SetParent(Nodo<T>? nuevoPadre)
        {
            // Obtener el padre actual directamente del campo, sin usar la propiedad Parent
            Nodo<T>? currentParent = null;
            bool tienePadreActual = _weakNodoPadre?.TryGetTarget(out currentParent) ?? false;

            // Si el nuevo padre es el mismo que el actual, no hacer nada
            if (tienePadreActual && currentParent == nuevoPadre)
                return;

            // Eliminar de la lista del padre actual (si existe)
            if (tienePadreActual)
            {
                // Aquí evitamos llamar a RemoveChild si el nuevo padre es null
                currentParent!._listaNodos.Remove(this);
            }

            // Actualizar la referencia débil al nuevo padre
            _weakNodoPadre = nuevoPadre != null ? new WeakReference<Nodo<T>>(nuevoPadre) : null;

            // Agregar al nuevo padre (si no es null)
            if (nuevoPadre != null)
            {
                nuevoPadre._listaNodos.Add(this);
            }
        }


        public bool IsRoot => _weakNodoPadre == null;
        public int ChildCount => _listaNodos.Count;


        public Nodo<T>? GetChildAt(int index)
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
            child._weakNodoPadre = null;
            _listaNodos.RemoveAt(index);
        }

        public void AddChild(Nodo<T> hijo)
        {
            if (hijo == null)
                throw new ArgumentNullException(nameof(hijo), "El hijo no puede ser nulo.");

            // Evitar que un nodo sea hijo de sí mismo
            if (hijo == this)
                throw new InvalidOperationException("Un nodo no puede ser hijo de sí mismo.");

            // Evitar ciclos (verificar si el hijo ya es un ancestro)
            var ancestro = this;
            while (ancestro != null)
            {
                if (ancestro == hijo)
                    throw new InvalidOperationException("Un nodo no puede ser hijo de sus descendientes.");
                ancestro = ancestro.Parent;
            }

            if (hijo.Parent != null)
                hijo.Parent.RemoveChild(hijo);

            _listaNodos.Add(hijo);
            hijo.SetParent(this);
        }

        public void RemoveChild(Nodo<T> hijo)
        {
            if (hijo == null)
                throw new ArgumentNullException(nameof(hijo), "El hijo no puede ser nulo.");

            // Eliminar el hijo de la lista
            _listaNodos.Remove(hijo);

            // Verificar si el hijo ya tiene un padre antes de llamar a SetParent
            Nodo<T>? currentParent = null;
            bool tienePadre = hijo._weakNodoPadre?.TryGetTarget(out currentParent) ?? false;

            if (tienePadre && currentParent == this)
            {
                hijo._weakNodoPadre = null; // Eliminar la referencia al padre directamente
            }
        }

        public int IndexOf(Nodo<T> nodo)
        {
            if (nodo == null)
                return -1;

            for (int i = 0; i < _listaNodos.Count; i++)
            {
                if (_listaNodos[i] == nodo)
                {
                    return i;
                }
            }
            return -1;
        }


        public bool Contains(Nodo<T> nodo)
        {
            if (nodo == null)
                return false;

            return IndexOf(nodo) != -1;
        }

        public void Clear()
        {
            while (_listaNodos.Count > 0)
            {
                var child = _listaNodos[0];
                child.SetParent(null);
                _listaNodos.RemoveAt(0);
            }
        }

        public List<Nodo<T>> Filtrar(FilterDelegate<T> filtro)
        {
            var result = new List<Nodo<T>>();

            if (filtro == null)
                return result;

            if (filtro(this))
                result.Add(this);

            foreach (var hijo in _listaNodos)
            {
                var nodosHijo = hijo.Filtrar(filtro);
                foreach (var nodo in nodosHijo)
                    result.Add(nodo);
            }

            return result;
        }
    }
}