using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTonto
{
    class Funciones
    {
        public delegate bool FilterDelegate<T> (T value);
        

        //public delegate TResult Func<in T, out TResult>(T arg);

        //public readonly List<T> listaAFiltrar = new List<string>();

        public static List<T> Filter<T>(List<T> lista, FilterDelegate<T> filter)
        {
            List<T> ret = new List<T>();
            if (filter == null || lista.Count == 0)
                return ret;
            foreach(var value in lista)
            {
                if (filter(value))
                    ret.Add(value);
            }
            return ret;

        }
        
        //Funcion que le paso una lista y filtra varios valores


    }
}
