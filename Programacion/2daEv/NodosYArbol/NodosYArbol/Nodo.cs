using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NodosYArbol
{
    class NodoArbol<T>
    {
        public delegate bool FilterDelegate<T>(NodoArbol<T> filtro);

        private readonly List<NodoArbol<T>> _listaNodos = new List<NodoArbol<T>>();
        private T _contenidoNodo;
        private WeakReference<NodoArbol<T>>? _weakNodoPadre;

        public NodoArbol(T contenidoNodo)
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

        public NodoArbol<T>? Parent
        {
            get => _weakNodoPadre?.TryGetTarget(out var parent) == true ? parent : null;
            set => SetParent(value);
        }

        public int GetLevel()
        {
            //// Accede directamente al campo _weakNodoPadre en lugar de la propiedad Parent
            //if (_weakNodoPadre == null || !_weakNodoPadre.TryGetTarget(out var parent))
            //    return 0;
            //return parent.GetLevel() + 1;
             
            int level = 0;
            NodoArbol<T>? current = this;
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

        //node GetParent()
        

        public NodoArbol<T> GetRoot()
        {
            //Accede directamente al campo _weakNodoPadre
            if (_weakNodoPadre == null || !_weakNodoPadre.TryGetTarget(out var parent))
                return this;
            //return parent.GetRoot();
            NodoArbol<T> current = this;
            while (true)
            {
                
                if (current._weakNodoPadre?.TryGetTarget(out parent) ?? false)
                {
                    current = parent;
                    parent = this.Parent;
                }
                else
                {
                    return current;
                }
            }
        }
        public NodoArbol<T> GetParent()
        {
            NodoArbol<T>? parent = null;
            if (parent != null)
                _weakNodoPadre.TryGetTarget(out parent);
            return parent;

        }

        public void SetParent(NodoArbol<T>? nuevoPadre)
        {
            // Obtener el padre actual directamente del campo, sin usar la propiedad Parent
            NodoArbol<T>? currentParent = null;
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
            _weakNodoPadre = nuevoPadre != null ? new WeakReference<NodoArbol<T>>(nuevoPadre) : null;

            // Agregar al nuevo padre (si no es null)
            if (nuevoPadre != null)
            {
                nuevoPadre._listaNodos.Add(this);
            }
            if (nuevoPadre == null)
                Detach();
            else
                nuevoPadre.AddChild(this);
        }

        private void Detach()
        {
            throw new NotImplementedException();
        }

        public bool IsRoot => Parent == null;
        public int ChildCount => _listaNodos.Count;


        public NodoArbol<T>? GetChildAt(int index)
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

        public void AddChild(NodoArbol<T> hijo)
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

            //que el nodo no sea this y que no tenga ya

            if (hijo == null)
                return;
            if (hijo == this)
                return;
            if (ContainsChild(hijo))
                return;
            if (ContainsAncestor(hijo))
                return;
            //var oldParent = hijo.Parent;

            //if (oldParent != null)
            //{
            //    oldParent.RemoveChild(hijo); //esto puede ser el detach
            //}
            //hijo.Parent = new WeakReference<T>(this);
            //this._listaNodos.Add(hijo);

            //tengo que comprobar que el nodo que me añaden no sea ni mi padre, ni un hijo
        }

        private bool ContainsChild(object n)
        {
            throw new NotImplementedException();
        }

        public void RemoveChild(NodoArbol<T> hijo)
        {
            if (hijo == null)
                throw new ArgumentNullException(nameof(hijo), "El hijo no puede ser nulo.");
                //return;

            // Eliminar el hijo de la lista
            //indexofChild RemoveAt
            if (_listaNodos.Remove(hijo))
            {
                hijo._weakNodoPadre = null;
            }
                

            // Verificar si el hijo ya tiene un padre antes de llamar a SetParent
            NodoArbol<T>? currentParent = null;
            bool tienePadre = hijo._weakNodoPadre?.TryGetTarget(out currentParent) ?? false;

            if (tienePadre && currentParent == this)
            {
                hijo._weakNodoPadre = null; // Eliminar la referencia al padre directamente
            }
        }

        public int IndexOf(NodoArbol<T> nodo)
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


        public bool Contains(NodoArbol<T> nodo)
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

        public List<NodoArbol<T>> Filtrar(FilterDelegate<T> filtro)
        {
            var result = new List<NodoArbol<T>>();

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

        public bool ContainsAncestor(NodoArbol<T> n)
        {
            //var parent = Parent;
            //if (parent == n)
            //    return true;
            //if (parent == null)
            //    return false;
            //return parent.ContainsAncestor(n);
            var current = Parent;
            while(current != null)
            {
                if (current == n)
                    return true;
                current = current.Parent;
            }
            return false;
        }

        //devolver una lista de todos los ancestros;
        public List<NodoArbol<T>> GetListaNodosAncestros()
        {
            List<NodoArbol<T>> result = new();
            GetAncestors(result);
            return result;
        }

        private void GetAncestors(List<NodoArbol<T>> l)
        {
            var current = this.Parent;
            //hacer var parent strong
           while(current != null)
            {
                l.Add(current);
                current = current.Parent;
            }

        }
        //la forma facil es como el containsancestor
    }
}