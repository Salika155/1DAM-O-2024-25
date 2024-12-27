using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoSwapNLetrasDePalabra
{
    internal class ArrayAlgoritmo
    {
        //cambiar la posicion de dos letras seguidas en una palabra, o mas
        //sin hacer un nuevo array

        public static void E1(string[] array, int n)
        {
            if (array == null || n <= 0)
                return;

            int lenght = array.Length;

            for(int i = 0; i < lenght - (lenght - i); i++)
            {
                if (array.Length % 2 == 0)
                {
                    string aux1 = array[lenght - (lenght - i)];
                    string auxarray0 = array[0 + lenght - i];
                    string swapvar = aux1;
                    aux1 = auxarray0;
                    auxarray0 = swapvar;
                    swapvar = aux1;
                }
                else
                {

                }
            }
        }
    }

    public static void E2(string[] array, int n)
    {
        int inicio = 0;
        int fin = array.Length - 1;

        while(inicio < fin)
        {
            string aux = array[inicio];
            array[inicio] = array[fin];
            array[fin] = aux;
            inicio++;
            fin--;
        }

        //aqui rotarias todo el array
        //ahora falta rotar sof otra vez e ia otra vez
        inicio = 0;
        fin = n - 1;
        while (inicio < fin)
        {
            string aux = array[inicio];
            array[inicio] = array[fin];
            array[fin] = aux;
            inicio++;
            fin--;
        }
        // con esto se resuelve
        inicio = n;
        fin = array.Length - 1;
        while(inicio < fin)
        {
            string aux = array[inicio];
            array[inicio] = array[fin];
            array[fin] = aux;
            inicio++;
            fin--;
        }
    }

    using System;

namespace AlgoritmoSwapNLetrasDePalabra
    {
        internal class ArrayAlgoritmo
        {
            public static void Main(string[] args)
            {
                // Ejemplo: array que representa la palabra "sofia".
                string[] array = { "s", "o", "f", "i", "a" };
                int n = 2;

                Console.Write("Array original: ");
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i]);
                }
                Console.WriteLine();

                // Realizar la rotación directamente en la misma función.
                int length = array.Length;
                n %= length; // Asegurar que n no exceda la longitud del array.
                int count = 0; // Contador de elementos movidos.

                for (int start = 0; count < length; start++)
                {
                    int current = start;
                    string prev = array[start];

                    do
                    {
                        int next = (current + n) % length; // Calcular el siguiente índice.
                        string temp = array[next]; // Guardar temporalmente el siguiente elemento.
                        array[next] = prev; // Mover el elemento previo al índice actual.
                        prev = temp; // Actualizar el elemento previo.
                        current = next; // Avanzar al siguiente índice.
                        count++; // Incrementar el contador de elementos movidos.
                    } while (start != current); // Terminar cuando se regrese al índice inicial.
                }

                Console.Write("Array tras rotar a la izquierda " + n + " posiciones: ");
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i]);
                }
                Console.WriteLine();
            }
        }
    }

}
