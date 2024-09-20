namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            bool esPar = Ejercicios.IsEven(5);
            Console.WriteLine(esPar);

            bool result = Ejercicios.IsOdd(2);
            Console.WriteLine(result);

            double ecua = Ejercicios.SolveSecondGradeEquation(1, -4, 3);
            Console.WriteLine(ecua);

            Ejercicios.MovimientoSexy(5);

            bool esdivisible = Ejercicios.IsDivisible(0, 5);
            Console.WriteLine(esdivisible);

        }
    }
}
