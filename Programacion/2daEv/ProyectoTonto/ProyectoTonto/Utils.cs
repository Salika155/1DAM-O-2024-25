
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

        public static List<T> FilterProfundo<T>(this List<T> list, FilterDelegate<T> filter)
        {
            list = list.Where(item => filter(item)).ToList(); // Filtra la lista actual y la actualiza
            return list; // Devuelve la misma lista para permitir el encadenamiento
        }
    }
}
