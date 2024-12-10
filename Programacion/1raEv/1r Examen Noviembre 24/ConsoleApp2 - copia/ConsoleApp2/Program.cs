using System.Threading.Channels;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //int numeroInfernal = 666;
            //bool isNumeroInfernal = FuncionesExamen.Infernal(numeroInfernal);
            //Console.WriteLine(isNumeroInfernal);
            //int numeroInfernal2 = 4447666;
            //bool isNumeroInfernal2 = FuncionesExamen.Infernal(numeroInfernal);
            //Console.WriteLine(isNumeroInfernal);
            //int numeroInfernal3 = 74643;
            //bool isNumeroInfernal3 = FuncionesExamen.Infernal(numeroInfernal);

            //int primo = 5;
            //bool esprimo = FuncionesExamen.IsPrimo(primo);
            //int seriePrimos = FuncionesExamen.SumaNumerosPrimos(primo);
            //Console.WriteLine(seriePrimos);

            //Clase Correcccion

            Console.WriteLine("Ejercicio 1");
            int numeroInfernalC = 666;
            bool isNumeroInfernalC = CorreccionExamen.IsInfernal(numeroInfernalC);
            Console.WriteLine(isNumeroInfernalC);
            int numeroInfernal2C = 4447666;
            bool isNumeroInfernal2C = CorreccionExamen.IsInfernal(numeroInfernal2C);
            Console.WriteLine(isNumeroInfernal2C);
            int numeroInfernal3C = 74643;
            bool isNumeroInfernal3C = CorreccionExamen.IsInfernal(numeroInfernal3C);
            Console.WriteLine(isNumeroInfernal3C);
            int numeroInfernal4C = 7466643;
            bool isNumeroInfernal4C = CorreccionExamen.IsInfernal(numeroInfernal4C);
            Console.WriteLine(isNumeroInfernal4C);

            Console.WriteLine("Ejercicio 2");
            int primoC = 5;
            bool esprimoC = CorreccionExamen.IsPrime(primoC);
            int sumaPrimosC = CorreccionExamen.SumaNumerosPrimos(primoC);
            //Console.WriteLine(sumaPrimosC);
            Console.WriteLine($"La suma de los primeros {primoC} números primos es: {sumaPrimosC}");

        }
    }
}
