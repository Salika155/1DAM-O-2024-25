


namespace ProyectoTonto
{
    public static class Utils
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

        //public static List<T> FilterProfundo<T>(this List<T> list, FilterDelegate<T> filter)
        //{
        //    List<T> result = new List<T>();

        //    foreach (var item in list)
        //    {
        //        if (filter(item))
        //        {
        //            result.Add(item);
        //        }
        //    }

        //    return result;
        //}

        //public static List<T> FilterProfundo<T>(this List<T> list, FilterDelegate<T> filter)
        //{
        //    list = list.Where(item => filter(item)).ToList(); // Filtra la lista actual y la actualiza
        //    return list; // Devuelve la misma lista para permitir el encadenamiento
        //}

        public class FilterClass<T>
        {
            private List<T> filteringList;

            public FilterClass(List<T> filteringList)
            {
                this.filteringList = filteringList;
            }

            public FilterClass<T> FilterProfundo(FilterDelegate<T> filter)
            {
                return new FilterClass<T>(null);
            }

            //objetivo hacer objetos efimeros, se puede devolver la list
            public FilterClass<T> FilterProfundo1(FilterDelegate<T> filter)
            {
                List<T> list = new List<T>();

                foreach (T item in filteringList)
                    if (filter(item))
                        list.Add(item);
                return new FilterClass<T>(list);
            }

            public List<T> ToList()
            {
                return new List<T>(filteringList);
            }
        }

        public static FilterClass<T> FilterProfundo1<T>(List<T> list, FilterDelegate<T> filter)
        {
            return new FilterClass<T>(list).FilterProfundo1(filter);
        }

        public static FilterClass<T> FilterProfundo<T>(List<T> list, FilterDelegate<T> filter)
        {
            List<T> l = new List<T>();
            var f = new FilterClass<T>(list);

            return f;
        }
    }
}
