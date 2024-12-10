namespace CorreccionExamenV1nov24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numeroInfernal = 666;
            bool isNumeroInfernal = Funciones.Infernal(numeroInfernal);
            Console.WriteLine(isNumeroInfernal);
            int numeroInfernal2 = 4447666;
            bool isNumeroInfernal2 = Funciones.Infernal(numeroInfernal);
            Console.WriteLine(isNumeroInfernal);
            int numeroInfernal3 = 74643;
            bool isNumeroInfernal3 = Funciones.Infernal(numeroInfernal);
            Console.WriteLine(isNumeroInfernal);


            int primo = 5;
            bool esprimo = Funciones.IsPrimo(primo);
            int seriePrimos = Funciones.SumaNumerosPrimos(primo);
            Console.WriteLine(seriePrimos);
        }
    }
}
