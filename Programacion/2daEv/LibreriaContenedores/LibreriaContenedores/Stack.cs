using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaContenedores
{ 
    public class Stack<T>
    {
        private readonly List<T?> _stackList = new();

        public int Count => _stackList.Count;
        public bool Empty => _stackList.Count == 0;
        public T? Top => Empty ? default(T) : _stackList[Count - 1];
        public void Push(T? value)
        {
            _stackList.Add(value);
        }

        public T? Pop()
        {
            if (Empty)
                return default(T);

            var result = _stackList[Count - 1];
            _stackList.RemoveAt(Count - 1);
            return result;
        }

        public override string? ToString()
        {
            return _stackList.ToString();
        }
    }
}

//List<>, Stack, Queue, Set (lista sin duplicados), Dictionary<K,V>

//Dictionary<K,V>
//Count, Add(key, value) si la key existe, lo añado, si no peto,
//Set(key, value) -> si la key no existe la pongo con este valor, si existe la modifico con este valor
//Contains(key) compara y busca si esta esa key en el diccionario
//GetValue(k)
//Clear()

//Tree<T>
//Node<T>
//Element 
//Hijos
//Enlace a Padre
//GetParent
//GetChildCount
//GetChildAt
//AddChild
//Detach (RemoveNodoDePadre)
//GetRoot
