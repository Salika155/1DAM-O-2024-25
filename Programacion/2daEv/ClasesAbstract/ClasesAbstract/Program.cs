namespace ClasesAbstract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayUtils.Filter(array, (value)) => value.Contains('a'));
            int[] array = { 1, 5, 7, 3, -1 };
            //var filterArray = ArrayUtils.Filter(array, (int value) =>
            //{
            //    return value >= 0;
            //});
            var filterArray = ArrayUtils.Filter(array, value => value < 0);


            int[] numeros = { 1, 2, 3, 4, 5, 6 };
            var filterarray2 = ArrayUtils.Filter(array, value => )
            

            // Mostrar el resultado
            Console.WriteLine("Números pares: " + string.Join(", ", ));
        }
    }
}
