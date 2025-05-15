using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenArrays
{
    interface IPool<T> where T : class // Restricción agregada para que T sea un tipo de referencia  
    {
        int Count { get; }
        T[] ToArray();
        IPool<T> Clone();

        static IPool<T> CreatePool(params T[] elements) => Pool<T>.Crear(elements);
    }
}
