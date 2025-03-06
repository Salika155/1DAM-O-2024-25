using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones
{
    public delegate bool DelegadoFiltro<T>(T item);
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

        Nodo<T>? Root { get; }
        //bool Contains(T item);
        void Clear();
        Nodo<T>? FindNode(DelegadoFiltro<T> filtro);
        List<T> Filter(DelegadoFiltro<T> filtro);
    }
}
