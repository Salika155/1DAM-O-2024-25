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
    }
}
