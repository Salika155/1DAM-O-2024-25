using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2DaEv
{
    public class OutExample
    {
        // Método que usa 'out' para devolver un valor adicional
        /*
         * Caso de uso:
            Cuando necesitas que un método devuelva más de un valor (por ejemplo, 
            un valor principal y un valor adicional).
         */
        public static bool Dividir(int dividendo, int divisor, out int resultado)
        {
            if (divisor == 0)
            {
                resultado = 0; // Asignamos un valor por defecto
                return false; // División no válida
            }

            resultado = dividendo / divisor; // Asignamos el resultado
            return true; // División válida
        }

        public static void ProbarOut()
        {
            int resultado;
            bool exito = Dividir(10, 2, out resultado);

            if (exito)
            {
                Console.WriteLine("Resultado de la división: " + resultado);
            }
            else
            {
                Console.WriteLine("División no válida.");
            }
        }
        /*
         * Explicación:
            Dividir(int dividendo, int divisor, out int resultado) devuelve un 
            valor booleano (true si la división es válida) y asigna el resultado de la 
            división a la variable resultado.

            Si el divisor es 0, el método devuelve false y asigna 0 a resultado.
        */
    }
}
