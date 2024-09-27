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

            Ejercicios.WriteHello10Times();
            Ejercicios.WriteHello10Times1();
            Ejercicios.WriteHello10Times2();
            Ejercicios.WriteHello10Times3(8.0);
            
            bool esPrimo = Ejercicios.IsEven(311);
            Console.WriteLine(esPrimo);

            string result1 = Ejercicios.Serie1(6);
            Console.WriteLine(result1);
            string result2 = Ejercicios.Serie2(6);
            Console.WriteLine(result2);
            string result3 = Ejercicios.Serie3(16);
            Console.WriteLine(result3);
            string result4 = Ejercicios.Serie4(6);
            Console.WriteLine(result4);
            string result5 = Ejercicios.Serie5(1000);
            Console.WriteLine(result5);

            string result6 = Ejercicios.Serie6(30);
            Console.WriteLine(result6);

            Console.WriteLine("Serie7: ");
            int result7 = Ejercicios.Serie7(20);
            Console.WriteLine(result7);

            Console.WriteLine("Serie8: ");
            int result8 = Ejercicios.Serie8(5);
            Console.WriteLine(result8);

            Console.WriteLine("Serie9: ");
            int result9 = Ejercicios.Serie9(6);
            Console.WriteLine(result9);

            Console.WriteLine("Serie10: ");
            int result10 = Ejercicios.Serie10(5);
            Console.WriteLine(result10);
        }
    }
}
