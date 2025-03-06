using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones
{
    interface IArbol<T>
    {
        #region codigo
        //Nodo<T> GetRoot();
        //void AddChild();
        //void RemoveChild(Nodo<T> hijo);
        //Nodo<T>? GetChildAt(int index); 
        //int ChildCount();
        //void Clear();
        //bool Contains(Nodo<T> nodo);
        //List<Nodo<T>> GetAncestors();
        //bool IsRoot();
        //void Detatch();
        //Nodo<T> Parent { get; set; }
        //T item { get; set; }
        #endregion

        Nodo<T> Root { get; set; }
        void AddChild(Nodo<T> padre, Nodo<T> hijo);
        void RemoveChild(Nodo<T> padre, Nodo<T> hijo);
        bool Contains(Nodo<T> nodo);
        void Clear();
        Nodo<T>? FindNode(Func<Nodo<T>, bool> filtro);
        List<T> Filter(Func<Nodo<T>, bool> filtro);
    }
}
