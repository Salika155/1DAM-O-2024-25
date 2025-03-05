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

        T item { get; set; }
        IArbol<T> Parent { get; set; }
        int ChildCount();


        Nodo<T> GetRoot();
        void AddChild(Nodo<T> hijo);
        void Detatch();
        bool IsRoot(Nodo<T> nodo);
        Nodo<T> GetChildAt(int index);
        bool Contains(Nodo<T> nodo);
        void Clear();
        
        void RemoveChild(Nodo<T> hijo);
        List<Nodo<T>> GetAncestors(); 
    }
}
