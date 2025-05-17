using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodosYArbol
{
    // The error CS0101 indicates that there is already another definition of the class `ExperimentoArbol`
    // in the same namespace `NodosYArbol`. To resolve this, ensure there is only one definition of the class
    // in the namespace. If the duplicate definition exists in another file, remove or rename it. 

    // If the duplicate definition is unintentional, you can rename this class or move it to a different namespace.
    // Below is an example of renaming the class to `ExperimentoArbolGenerico` to avoid the conflict.

    using System;
    using System.Collections.Generic;

    namespace NodosYArbol
    {
        public class ExperimentoArbolGenerico<T>
        {
            // The rest of the code remains unchanged, except for the class name.
            public delegate bool FilterDelegate<T>(ExperimentoArbolGenerico<T> nodo);

            private readonly List<ExperimentoArbolGenerico<T>> _listaNodos = new();
            private T _contenidoNodo;
            private WeakReference<ExperimentoArbolGenerico<T>>? _weakNodoPadre;

            public ExperimentoArbolGenerico(T contenidoNodo)
            {
                _contenidoNodo = contenidoNodo ?? throw new ArgumentNullException(nameof(contenidoNodo));
            }

            public T Contenido
            {
                get => _contenidoNodo;
                set => _contenidoNodo = value ?? throw new ArgumentNullException(nameof(value));
            }

            public ExperimentoArbolGenerico<T>? Parent
            {
                get
                {
                    ExperimentoArbolGenerico<T>? parent;
                    return _weakNodoPadre?.TryGetTarget(out parent) == true ? parent : null;
                }
            }

            public int GetLevel()
            {
                int level = 0;
                var actual = this;
                while (actual.Parent != null)
                {
                    actual = actual.Parent!;
                    level++;
                }
                return level;
            }

            public ExperimentoArbolGenerico<T> GetRoot()
            {
                var actual = this;
                while (actual.Parent != null)
                {
                    actual = actual.Parent!;
                }
                return actual;
            }

            public int ChildCount => _listaNodos.Count;

            public ExperimentoArbolGenerico<T>? GetChildAt(int index)
            {
                if (index < 0 || index >= _listaNodos.Count)
                    return null;
                return _listaNodos[index];
            }

            public void AddChild(ExperimentoArbolGenerico<T> hijo)
            {
                if (hijo == null)
                    throw new ArgumentNullException(nameof(hijo));
                if (hijo == this)
                    throw new InvalidOperationException("Un nodo no puede ser hijo de sí mismo.");
                if (ContainsChild(hijo))
                    return;
                if (hijo.ContainsAncestor(this))
                    throw new InvalidOperationException("Crear un ciclo en el árbol no está permitido.");

                if (hijo.Parent != null)
                {
                    hijo.Parent.RemoveChild(hijo);
                }

                _listaNodos.Add(hijo);
                hijo._weakNodoPadre = new WeakReference<ExperimentoArbolGenerico<T>>(this);
            }

            public void RemoveChild(ExperimentoArbolGenerico<T> hijo)
            {
                if (hijo == null)
                    throw new ArgumentNullException(nameof(hijo));

                if (_listaNodos.Remove(hijo))
                {
                    hijo._weakNodoPadre = null;
                }
            }

            public void RemoveAt(int index)
            {
                if (index < 0 || index >= _listaNodos.Count)
                    return;

                var hijo = _listaNodos[index];
                hijo._weakNodoPadre = null;
                _listaNodos.RemoveAt(index);
            }

            public void Clear()
            {
                foreach (var hijo in _listaNodos)
                {
                    hijo._weakNodoPadre = null;
                }
                _listaNodos.Clear();
            }

            public bool ContainsChild(ExperimentoArbolGenerico<T> nodo)
            {
                return _listaNodos.IndexOf(nodo) != -1;
            }

            public bool ContainsAncestor(ExperimentoArbolGenerico<T> posibleAncestro)
            {
                var actual = this.Parent;
                while (actual != null)
                {
                    if (actual == posibleAncestro)
                        return true;
                    actual = actual.Parent;
                }
                return false;
            }

            public List<ExperimentoArbolGenerico<T>> GetAncestors()
            {
                var result = new List<ExperimentoArbolGenerico<T>>();
                var actual = this.Parent;
                while (actual != null)
                {
                    result.Add(actual);
                    actual = actual.Parent;
                }
                return result;
            }

            public int IndexOf(ExperimentoArbolGenerico<T> nodo)
            {
                if (nodo == null)
                    return -1;

                var comparer = EqualityComparer<ExperimentoArbolGenerico<T>>.Default;

                for (int i = 0; i < _listaNodos.Count; i++)
                {
                    if (comparer.Equals(_listaNodos[i], nodo))
                        return i;
                }

                return -1;
            }

            public bool Contains(ExperimentoArbolGenerico<T> nodo)
            {
                return _listaNodos.IndexOf(nodo) != -1;
            }

            public List<ExperimentoArbolGenerico<T>> Filtrar(FilterDelegate<T> filtro)
            {
                var result = new List<ExperimentoArbolGenerico<T>>();

                if (filtro(this))
                    result.Add(this);

                foreach (var hijo in _listaNodos)
                {
                    result.AddRange(hijo.Filtrar(filtro));
                }

                return result;
            }

            public ExperimentoArbolGenerico<T> this[int index]
            {
                get => _listaNodos[index];
                set
                {
                    if (value == null)
                        throw new ArgumentNullException(nameof(value));
                    _listaNodos[index] = value;
                    value._weakNodoPadre = new WeakReference<ExperimentoArbolGenerico<T>>(this);
                }
            }
        }
    }
}
