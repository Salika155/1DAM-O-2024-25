namespace test_list
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new();
            List<int> list1 = new List<int>();

            list.Add(7);
            list.Add(-1);
            list.Add(0);
            list.Add(3);

            int n = list.Count();
            list.Add(5);
            n = list.Count();

            Ejercicios.PrintNumbers(list);

            int suma = Ejercicios.SumaElementosLista(list);
            Console.WriteLine(suma);

            int sumaPar = Ejercicios.SumaElementosParesLista(list);
            Console.WriteLine(sumaPar);

            List<int> l2 = Ejercicios.CopiarLista(list);

            Ejercicios.CopiarLista(list);

            Ejercicios.CopiarListaInversa(list);

            Ejercicios.InvertirLista(list);

            Ejercicios.DevolverMayorValorEnLista(list);

            //Remove en lista es suspenso, se usa RemoveAt
        }
    }
}
