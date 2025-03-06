using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones
{
    class Nodo<T>
    {
        private WeakReference<Nodo<T>> _parent;
        private List<Nodo<T>> _childList = new();

        public T Item { get; set; }

        public Nodo<T>? Parent
        {
            get
            {
                if (_parent == null)
                    return null;
                _parent.TryGetTarget(out Nodo<T>? parent);
                return parent;
            }
            
        }
    }
}
