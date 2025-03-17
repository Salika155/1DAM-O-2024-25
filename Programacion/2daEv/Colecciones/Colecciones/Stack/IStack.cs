using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones.Stack
{
    public interface IStack<T>
    {
        void Push(T item); // Agregar un elemento al stack.
        T Pop(); // Eliminar y devolver el elemento en la cima del stack.
        T Peek(); // Devolver el elemento en la cima del stack sin eliminarlo.
        bool IsEmpty(); // Verificar si el stack está vacío.
    }
}
