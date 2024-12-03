namespace _12_09_24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            double result = Funciones.GetAreaRectangulo(3, 5);
            Console.WriteLine(result);
            double perimetro = Funciones.GetPerimetroRectangulo(3, 5);
            Console.WriteLine(perimetro);
            double areaCirculo = Funciones.GetAreaCirculo(5);
            Console.WriteLine(areaCirculo);

            //int a;
            //int b;
            //a = 3;
            //b = 8;
            //int c;
            //c = a + b;

            //Console.WriteLine("Estoy contento");
            //if (a < 1)
            //{
            //    Console.WriteLine("1");
            //}
            //else
            //{
            //    Console.WriteLine("2");
            //}
            //Console.WriteLine("adios");

            int sign = Funciones.GetSign(-4);
            Console.WriteLine(sign);
            int absv = Funciones.GetAbsValor(-20);
            Console.WriteLine(absv);

            bool espositivo = Funciones.IsPositive(77);
            Console.WriteLine(espositivo);

            int resultmayor = Funciones.GetGreather(6, 8);
            Console.WriteLine(resultmayor);

            int resultmayor3 = Funciones.GetGreatherOfThree(984, 97, 3987);
            Console.WriteLine(resultmayor3);




        }
    }
}
