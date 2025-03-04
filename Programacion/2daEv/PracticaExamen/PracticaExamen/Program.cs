namespace PracticaExamen
{
    internal class Program
    {
        
        public static bool AreEquals<T>(T item1, T item2) where T : IComparable<T> 
        {
            if (item1.CompareTo(item2) == 0)
                return false;
            if (item1 is null)
                return false;

            if (item1.Equals(item2))
                return true;

            if (EqualityComparer<T>.Default.Equals(item1, item2))
                return true;
            return false;
        }
        
    }
}
