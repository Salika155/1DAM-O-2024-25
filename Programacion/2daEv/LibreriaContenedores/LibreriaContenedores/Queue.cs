using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaContenedores
{
    public class Queue<T>
    {
        private readonly List<T?> _queueList = new();

        public int Count => _queueList.Count;
        public bool Empty => _queueList.Count == 0;
        public T? First => Empty ? default(T) : _queueList[0];
        public T? Last => Empty ? default(T) : _queueList[Count - 1];

        public void EnQueue(T element)
        {
            if (element == null)
                return;
            _queueList.Add(element);
        }

        public T? DeQueue()
        {
            if (Empty)
                return default(T);

            var deQueueElement = First;
            _queueList.RemoveAt(0);
            return deQueueElement;
        }

        

        public void Clear()
        {
            while (Count > 0)
            {
                _queueList.RemoveAt(0);
            }
        }

        public override string? ToString()
        {
            return _queueList.ToString();
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
