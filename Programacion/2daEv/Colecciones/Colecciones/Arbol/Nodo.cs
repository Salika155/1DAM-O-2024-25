using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones.Arbol
{
    // Definimos un delegado que servirá para filtrar elementos en ciertos métodos.
    public delegate bool FilterDelegate<T>(Nodo<T> filtro);
    // Delegado para el patrón Visitor.
    public delegate void Visitor<T>(Nodo<T> nodo);
    public class Nodo<T> // Cambiamos la clase Nodo a pública para resolver la incoherencia de accesibilidad.
    {
        // Lista de hijos del nodo. Aquí se almacenan los nodos hijos del nodo actual.
        private readonly List<Nodo<T>> _children = new List<Nodo<T>>();

        // Referencia débil al nodo padre para evitar referencias circulares y posibles pérdidas de memoria.
        private WeakReference<Nodo<T>>? _parent;

        // Valor que almacena el nodo.
        private T? _item;

        // Propiedad para obtener el padre del nodo. Solo permite establecerlo llamando a SetParent.
        public Nodo<T>? Parent
        {
            get => GetParent(); // Usa el método GetParent() para obtener la referencia del padre.
            set
            {
                if (value != null)
                {
                    SetParent(value); // Si se asigna un padre, se usa SetParent para establecerlo correctamente.
                }
            }
        }

        // Propiedad que devuelve la cantidad de hijos que tiene este nodo.
        public int ChildCount => _children.Count;

        // Propiedad para acceder o modificar el valor que almacena el nodo.
        public T? ValueNodo
        {
            get => _item;
            set => _item = value;
        }

        // Indexer para acceder a los hijos por índice.
        public Nodo<T> this[int index]
        {
            get
            {
                if (index < 0 || index >= _children.Count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                return _children[index];
            }
        }

        // Constructor que inicializa un nodo con un valor determinado.
        public Nodo(T item)
        {
            _item = item;
        }

        // Obtiene el nodo padre, si existe.
        public Nodo<T>? GetParent()
        {
            if (_parent == null) // Si la referencia al padre es nula, el nodo no tiene padre.
                return null;

            _parent.TryGetTarget(out Nodo<T>? result); // Intenta obtener el nodo al que apunta la referencia débil.
            return result; // Devuelve el nodo padre o null si la referencia ya no es válida.
        }

        // Método para establecer un nuevo padre al nodo.
        public void SetParent(Nodo<T> newParent)
        {
            // Evita asignarse como padre de sí mismo.
            // Evita duplicar un nodo en la jerarquía.
            if (newParent == this || newParent.Contains(this))
                return;
            // Desvincula del padre anterior si lo tenía.
            Detach(); // Primero, eliminamos la relación con el padre anterior si existía.
            /*if (newParent != null)*/ // Si el nuevo padre no es nulo, lo añadimos como hijo.
                                       // Agrega este nodo como hijo del nuevo padre.
            newParent.AddChild(this);
        }

        // Método privado para agregar un hijo a este nodo.
        private void AddChild(Nodo<T> child)
        {
            if (child == null) // Si el nodo hijo es nulo, no hacemos nada.
                return;
            // Evita duplicados en la lista de hijos.
            if (Contains(child))
                return;

            // Creamos una referencia débil del hijo hacia este nodo como su padre.
            child._parent = new WeakReference<Nodo<T>>(this);
            _children.Add(child); // Agregamos el hijo a la lista de hijos de este nodo.
        }


        // Método para eliminar la relación con el padre actual.
        private void Detach()
        {
            var parent = GetParent(); // Obtenemos el padre actual.
            if (parent != null) // Si no hay padre, no hacemos nada.
            {
                parent.RemoveChild(this); // Elimina este nodo de la lista de hijos del padre.
                _parent = null; // Limpia la referencia débil del padre.
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _children.Count)
                return;
            var child = _children[index];
            child._parent = null;
            _children.RemoveAt(index);
        }

        // Método para eliminar un hijo específico.
        //public void RemoveChild(Nodo<T> hijo)
        //{
        //    if (hijo == null)
        //        throw new ArgumentNullException(nameof(hijo), "El hijo no puede ser nulo.");

        //    // Eliminar el hijo de la lista
        //    //indexofChild RemoveAt
        //    bool removed = _children.Remove(hijo);

        //    // Verificar si el hijo ya tiene un padre antes de llamar a SetParent
        //    Nodo<T>? currentParent = null;
        //    bool tienePadre = hijo._parent?.TryGetTarget(out currentParent) ?? false;

        //    if (tienePadre && currentParent == this)
        //    {
        //        hijo._parent = null; // Eliminar la referencia al padre directamente
        //    }
        //}
        public void RemoveChild(Nodo<T> hijo)
        {
            if (hijo == null)
                throw new ArgumentNullException(nameof(hijo), "El hijo no puede ser nulo.");

            // Buscar el índice del hijo en la lista de hijos.
            int index = -1;
            for (int i = 0; i < _children.Count; i++)
            {
                if (_children[i] == hijo)
                {
                    index = i;
                    break;
                }
            }

            // Si se encontró el hijo, eliminarlo de la lista.
            if (index != -1)
            {
                // Eliminar el hijo de la lista manualmente.
                for (int i = index; i < _children.Count - 1; i++)
                {
                    _children[i] = _children[i + 1];
                }
                _children.RemoveAt(_children.Count - 1); // Eliminar el último elemento duplicado.

                // Eliminar la referencia al padre en el hijo.
                hijo._parent = null;
            }
        }

        public Nodo<T> Root => Parent == null ? this : Parent.Root;

        // Método para obtener la raíz del árbol al que pertenece este nodo.
        public Nodo<T> GetRoot()
        {
            var p = Parent;
            return p == null ? this : p.GetRoot(); // Si no tiene padre, es la raíz; si tiene, seguimos buscando recursivamente.
        }

        // Método para eliminar todos los hijos del nodo actual.
        public void Clear()
        {
            while (_children.Count > 0) // Mientras haya hijos...
            {
                _children[0].Detach(); // Eliminamos la relación con el primer hijo.
            }
        }

        // Método para buscar un nodo que cumpla con un criterio específico.
        public Nodo<T>? FindNode(FilterDelegate<T> filter)
        {
            if (ValueNodo != null && filter(this)) // Si este nodo cumple con el filtro, lo devolvemos.
                return this;

            foreach (var c in _children) // Buscamos recursivamente en los hijos.
            {
                var n = c.FindNode(filter);
                if (n != null)
                    return n; // Si encontramos un nodo que cumpla con el filtro, lo devolvemos.
            }
            return null; // Si no encontramos ninguno, devolvemos null.
        }


        // Método para filtrar elementos en el árbol y añadirlos a una lista dada.
        public void Filter(FilterDelegate<T> filter, List<T> resultado)
        {
            if (ValueNodo != null && filter(this)) // Si este nodo cumple con el filtro, lo agregamos a la lista.
                resultado.Add(ValueNodo);

            foreach (var c in _children) // Aplicamos el filtro recursivamente a los hijos.
            {
                c.Filter(filter, resultado);
            }
        }

        // Método para obtener un hijo en una posición específica.
        public Nodo<T>? GetChildAt(int index)
        {
            if (index < 0 || index >= _children.Count) // Verificamos que el índice esté dentro de los límites.
                return null;
            return _children[index]; // Devolvemos el hijo en la posición indicada.
        }

        public bool Contains(Nodo<T> nodo)
        {
            if (this == nodo)
                return true;

            foreach (var child in _children)
            {
                if (child.Contains(nodo))
                    return true;
            }
            return false;
        }

        public List<Nodo<T>> GetAncestors()
        {
            List<Nodo<T>> ancestors = new List<Nodo<T>>();
            Nodo<T>? current = GetParent();

            while (current != null)
            {
                ancestors.Add(current);
                current = current.GetParent();
            }
            return ancestors;
        }

        // Método para obtener todos los hijos del nodo actual, incluyendo los hijos de los hijos.
        public List<Nodo<T>> GetAllChildren()
        {
            List<Nodo<T>> allChildren = new List<Nodo<T>>();

            foreach (var child in _children)
            {
                allChildren.Add(child);
                var childChildren = child.GetAllChildren(); // Obtener los hijos del hijo actual.
                //allChildren.AddRange(child.GetAllChildren());
                foreach (var grandChild in childChildren)
                {
                    allChildren.Add(grandChild); // Agregar cada hijo del hijo actual.
                }
            }
            return allChildren;
        }

        // Método para aplicar un visitor a este nodo y a todos sus hijos.
        public void Visit(Visitor<T> visitor)
        {
            // Aplica el visitor al nodo actual.
            visitor(this);

            // Recorre todos los hijos y aplica el visitor recursivamente.
            foreach (Nodo<T> child in _children)
            {
                child.Visit(visitor);
            }
        }

        // Método para comparar dos elementos genéricos.
        public static bool AreEquals(T item1, T item2)
        {
            return EqualityComparer<T>.Default.Equals(item1, item2);
        }
    }
}
