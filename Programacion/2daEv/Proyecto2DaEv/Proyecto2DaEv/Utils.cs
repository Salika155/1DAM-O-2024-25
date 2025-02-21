using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2DaEv
{
    public static class Utils
    {
        /*
         *  Caso de uso:
            Cuando necesitas encadenar múltiples filtros sobre una lista. 
        */
        public delegate bool FilterDelegate<T>(T value);

        public static List<T> FilterProfundo<T>(this List<T> list, FilterDelegate<T> filter)
        {
            List<T> result = new List<T>();

            foreach (var item in list)
            {
                if (filter(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }

    public class FilterProfundoExample
    {
        public static void ProbarFilterProfundo()
        {
            List<int> numeros = new List<int> { 5, 10, 15, 20, 25 };

            // Encadenar múltiples filtros
            var resultado = numeros.FilterProfundo(valor => valor > 10)
                                    .FilterProfundo(valor => valor < 20)
                                    .ToList();

            Console.WriteLine("Números filtrados (10 < x < 20):");
            foreach (var numero in resultado)
            {
                Console.WriteLine(numero);
            }
        }
    }
    /*
     *  Explicación:
        FilterProfundo es un método de extensión que permite encadenar múltiples filtros.
        Primero filtra los valores mayores que 10 y luego los valores menores que 20.
     */
}
