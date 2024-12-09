using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    internal class Contenedores<T>
    {
        //interrogante en T? permite nulls
        private readonly List<T?> _stack = new();
        public int Count => _stack.Count;
        public T? Top => Empty ? default(T) : _stack[Count - 1];
        public bool Empty => _stack.Count <= 0;
        public void Push(T? value)
        {
            _stack.Add(value);
        }

        public T? Pop()
        {
            if (Empty)
                return default(T);

            var result = _stack[Count - 1];
            _stack.RemoveAt(Count - 1);
            return result;
        }

        //para debugear le puedes meter lo que creas
        public override string? ToString()
        {
            return "<<<<<" + _stack.ToString() + ">>>>>>";
            return JSONSerializer.Serialize(_stack);
        }

        //List<>, Stack, Queue, Set (lista sin duplicados), Dictionary<K,V>

        //Dictionary<K,V>
            //Count, Add(key, value) si la key existe, lo añado, si no peto,
            //Set(key, value) -> si la key no existe la pongo con este valor, si existe la modifico con este valor
            //Contains(key) compara y busca si esta esa key en el diccionario
            //GetValue(k)
            //Clear()
    }
}
