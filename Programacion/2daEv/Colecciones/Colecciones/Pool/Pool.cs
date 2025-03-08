using Colecciones.Pool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Colecciones
{
    namespace Colecciones.Colecciones
    {
        // Clase genérica Pool<T> que implementa la interfaz IPool<T>.
        // Esta clase gestiona una reserva (pool) de objetos de tipo T.
        public class Pool<T> : IPool<T>
        {
            // Stack para almacenar los objetos disponibles en la pool.
            private readonly Stack<T> _availableObjects;

            // Función que define cómo crear nuevos objetos cuando la pool está vacía.
            private readonly Func<T> _createFunc;

            // Constructor de la Pool. Recibe una función que se usará para crear objetos cuando sea necesario.
            public Pool(Func<T> createFunc)
            {
                // Inicializa la pila que almacenará los objetos reutilizables.
                _availableObjects = new Stack<T>();

                // Guarda la función de creación, o lanza una excepción si es nula.
                _createFunc = createFunc ?? throw new Exception(nameof(createFunc));
            }

            // Método para obtener un objeto de la Pool.
            public T Get()
            {
                if (IsEmpty)
                {
                    // Si no hay objetos disponibles, crear uno nuevo.
                    return CreateObject();
                }
                else
                {
                    // Si hay objetos disponibles, extraer uno del stack.
                    return _availableObjects.Pop();
                }
            }

            // Método para devolver un objeto a la Pool.
            public void Return(T item)
            {
                if (item == null)
                    throw new ArgumentNullException(nameof(item), "El objeto no puede ser nulo.");

                // Agregar el objeto al stack para su reutilización.
                _availableObjects.Push(item);
            }

            // Método para crear un nuevo objeto (puede sobrescribirse en una clase derivada).
            protected virtual T CreateObject()
            {
                return _createFunc();
            }

            // Cantidad de objetos disponibles en la Pool.
            public int Count => _availableObjects.Count;

            // Verificar si la Pool está vacía.
            public bool IsEmpty => _availableObjects.Count == 0;
        }
    }
}
