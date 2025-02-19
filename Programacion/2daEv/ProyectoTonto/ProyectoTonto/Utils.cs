using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoTonto.Utils;

namespace ProyectoTonto
{
    class Utils
    {
        public delegate T GenDelegate<T>(int index);
        public delegate bool FilterDelegate<T>(T value);
        //public static List<T> Gen<T>(int count, Func<int, T> generator)
        //{
        //    List<T> list = new List<T>();
        //    for (int i = 0; i < count; i++)
        //    {
        //        list.Add(generator(i));
        //    }
        //    return list;
        //}
        public static List<T> Gen<T>(int count, GenDelegate<T> gen)
        {
            List<T> result = new();

            for (int i = 0; i < count; i++)
            {
                result.Add(gen(i));
            }
            return result;
        }

        public static object FilterProfundo<T>(List<int> lenter, FilterDelegate<T> )
        {
            throw new NotImplementedException();
        }
    }
}
