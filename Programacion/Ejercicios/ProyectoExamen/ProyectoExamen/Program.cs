namespace ProyectoExamen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //Funciones.GetPrimoNumbers();
            int[] array = new int[] { 1, 5, 8, 3, 6 };
            Funciones.GetMayorValorInArray(array);

            //ESTO ES OTRA COSA
            List<int> numeros = new List<int> { 2, 4, 3, 5, 7, 8, 9 };
            int objetivo = 10;
            var resultado = ExamenJulioCO24.GetParesSumables(numeros, objetivo);
        }
    }
}
