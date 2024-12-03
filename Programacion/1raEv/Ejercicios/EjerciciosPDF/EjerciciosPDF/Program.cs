namespace EjerciciosPDF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int real = Funciones.GetReal(-755);
            Console.WriteLine(real);

            bool pair = Funciones.IsPair(-754);
            Console.WriteLine(pair);

            bool notPair = Funciones.IsNotPair(-754);
            Console.WriteLine(notPair);

            bool parejos = Funciones.SonParejos(-754, 75);
            Console.WriteLine(parejos);

            string esParOImpar = Funciones.EsParOImpar(25, 34);
            Console.WriteLine(esParOImpar);

            string letra = "a";
            int number = 865;
            bool isNumber = Funciones.IsNumberOrNot(number);


        }
    }
}
