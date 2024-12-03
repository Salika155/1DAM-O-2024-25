namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int numeroInfernal = 666;
            bool isNumeroInfernal = FuncionesExamen.Infernal(numeroInfernal);
            Console.WriteLine(isNumeroInfernal);
            int numeroInfernal2 = 4447666;
            bool isNumeroInfernal2 = FuncionesExamen.Infernal(numeroInfernal);
            Console.WriteLine(isNumeroInfernal);
            int numeroInfernal3 = 74643;
            bool isNumeroInfernal3 = FuncionesExamen.Infernal(numeroInfernal);
            Console.WriteLine(isNumeroInfernal);


            int primo = 5;
            bool esprimo = FuncionesExamen.IsPrimo(primo);
            int seriePrimos = FuncionesExamen.SumaNumerosPrimos(primo);
            Console.WriteLine(seriePrimos);
        }
    }
}
