namespace Test_poo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Colour col1 = new Colour(0.0, 0.0, 1.0, 50);
            Colour col2 = new Colour(0.0, 1.0, 1.0, 19);
            double u = 10.0;

            Colour col3 = Ejercicios.Lerp(col1, col2, u);
            Console.WriteLine(col3);

            
        }
    }
}
