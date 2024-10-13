namespace Examen1raEv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ej 1

            int entero1 = 8; 
            int entero2 = 4;
            Console.WriteLine("primer parametro = " + Funciones.ex1(entero1, entero2));

            int a = 2;
            int b = 3;
            int c = 4;
            int d = 5;
            int e = 6;
            int x = 2;
            Console.WriteLine("Real " + Funciones.ex2(a, b, c, d, e, x));

            int n1 = -3;
            int n2 = 5;
            int n3 = 6;
            int n4 = -5;
            int n5 = 12;
            int n6 = 2;
            int n7 = -16;
            int n8 = 8; 
            int n9 = 9;
            int n10 = 10;
            Console.WriteLine(Funciones.ex3(n1, n2, n3, n4, n5, n6, n7, n8, n9, n10));

            int a1 = 3;
            int a2 = 1;
            int a3 = 7;
            Console.WriteLine(Funciones.Ex4(a1, a2, a3));

            int dec = 394975;
            Console.WriteLine(Funciones.GetDecimals(dec));

            int ex6 = 42;
            Console.WriteLine(Funciones.Ex6(ex6));

            string vocales = "vFSAsdvsagtuO";
            Console.WriteLine(Funciones.GetFirstVocal(vocales));

            int numprim = 17;
            Console.WriteLine(Funciones.GetPrimoPosition(numprim));

           
        }
    }
}