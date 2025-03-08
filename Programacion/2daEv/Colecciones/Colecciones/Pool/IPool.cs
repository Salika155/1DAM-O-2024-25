using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones.Pool
{
    public interface IPool<T>
    {
        T Get(); // Obtener un objeto de la Pool.
        void Return(T item); // Devolver un objeto a la Pool.
        int Count { get; } // Cantidad de objetos disponibles en la Pool.
        bool IsEmpty { get; } // Verificar si la Pool está vacía.
    }
}
