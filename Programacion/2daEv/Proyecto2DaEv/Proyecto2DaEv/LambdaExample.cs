using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2DaEv
{
    public class LambdaExample
    {
        /*
         *  Caso de uso:
            Cuando necesitas definir funciones anónimas de manera concisa 
            (por ejemplo, para filtrar una lista).
        */
        public static void ProbarLambda()
        {
            List<string> nombres = new List<string> { "Ana", "Carlos", "Beatriz", "David" };

            // Filtrar nombres que contienen la letra 'a'
            var nombresConA = nombres.Where(nombre => nombre.Contains("a", StringComparison.OrdinalIgnoreCase)).ToList();

            Console.WriteLine("Nombres que contienen 'a':");
            foreach (var nombre in nombresConA)
            {
                Console.WriteLine(nombre);
            }
        }

        /*
         * Explicación:
            nombre => nombre.Contains("a") es una función lambda que filtra los 
            nombres que contienen la letra "a".

            Where es un método de LINQ que aplica el filtro.
         */

        public static void ProbarLambda1()
        {
            List<int> numeros = new List<int> { 1, 2, 3, 4, 5 };

            // Filtrar números pares usando una lambda
            var pares = numeros.Where(n => n % 2 == 0).ToList();

            Console.WriteLine("Números pares:");
            foreach (int num in pares)
            {
                Console.WriteLine(num); // 2, 4
            }
        }
        /*
         *  Línea 10: n => n % 2 == 0 → Función lambda que retorna true si n es par.
            Línea 10: Where(...) → Filtra la lista según la condición.
         */
    }
}
