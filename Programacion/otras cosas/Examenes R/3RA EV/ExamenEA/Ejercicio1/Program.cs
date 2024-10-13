namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 8, 74, 67, 2, 19, 25, 37 };

            FuncEj1.GetMinMaxAndAvgArrayValors(array);
            Console.WriteLine(FuncEj1.GetMinMaxAndAvgArrayValors(array));
            //2, 8, 19, 25, 37, 67, 74, 
        }
    }
}