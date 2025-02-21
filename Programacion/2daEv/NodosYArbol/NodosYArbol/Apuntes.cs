using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodosYArbol
{
    class Apuntes
    {
        /*
         * Node<T>
         * {
         *  parent
         *  ChildCount list<node<T>>
         *  T item
         *  
         *  Parent => Metodo SetParent -> propertie que llamara al metodo
         *  AddChild(n)
         *  GetChildAt(index) -> puede ser una property llamada indexer
         *  Detach()
         *  Clear()
         *  GetRoot -> property
         *  
         *  
         *  Node<string> root;
         *  root = new Node();
         *  var child = new node
         *  root.AddChild(child1)
         *  root.Item = "hola"
         *  
         *  para evitar referencia circular hacer una weak reference en la clase Node
         *  WeakReference es un objeto que contiene la verdadera referencia al objeto
         *  se tiene una referencia strong a un objeto intermedio, y este objeto intermedio dentro 
         *  tiene una referencia a otra que es la debil, que no aumentara el referencecount.
         *  
         *  Para leer un dato de una weak, hay que pasarlo primero a strong
         *  GetParent()
         *      Node<T> prent
         *      if (parent != null)
         *          parent = _parent.Target;
         *          
         *      if (_parent.TryGetValue(out parent)
         *      {
         *      }
         * 
         */
    }
}
