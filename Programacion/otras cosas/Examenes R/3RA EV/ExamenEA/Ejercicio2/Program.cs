namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new();
            list.Add(2);
            list.Add(4);
            list.Add(3);
            list.Add(5);
            list.Add(7);
            list.Add(8);
            list.Add(9);

            int n = 10;

            //FuncEj2.ParesQueSuman(list, n);
            Console.WriteLine(FuncEj2.ParesQueSuman(list, n));
            Console.WriteLine(FuncEj2.SumarElementos(list, n));
             
        }
    }
}