namespace ExamenT2D1
{
    public class Program
    {
        static void Main(string[] args)
        {
            ExList<int> lista1 = new();
            lista1.Add(4);
            lista1.Add(8);
            lista1.Add(12);
            lista1.Add(1);
            int value1 = lista1.First;
            int value2 = lista1.Last;
            ExList<int> lista2 = lista1.Reversed();
            lista1.IndexOf((n1) => n1 == 8);
            lista1.Contains((n1) => n1 == 12);
            lista1.Visit((n1) => Console.WriteLine(n1));
            lista1.Sort((n1, n2) => n1 > n2);
            ExList<int> lista3 = lista1.Filter((n1) => n1 % 2 == 0);
            lista1.Insert(2, 9);
            lista1.IndexOf(14);
            lista1.Contains(8);
            lista1.RemoveAt(5);
            lista1.Reverse();
            int result4 = lista1[2];
            lista1[2] = 4;
            ExList<int> result = lista1.Reversed();
            lista1.Clear();
            lista1.Add(22);
            int capacity = lista1.Capacity;
            lista1.Clone();
            ExList<int> result3 = lista1.Reversed();
            int result2 = lista1[5];
            int count = lista1.Count;
        }
    }
}
