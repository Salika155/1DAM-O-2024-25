namespace ExamenListaArray
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //EX1

            int[] arrayNumeros = new int[] { 3, 1, 5, 4, 2};
            int[] array2 = new int[] { 40, 10, 50, 20, 30 };


            double numeromedio = Funciones.GetNumNearMidValor(arrayNumeros);
            Console.Write(numeromedio);

            double numeromedio2 = Funciones.GetNumNearMidValor(array2);
            Console.Write(numeromedio2);


            //EX2
            List<string> listaCompra = new List<string>();
            
            string s = "manzana";
            listaCompra.Add(s);
            string s2 = "banana";
            listaCompra.Add(s2);
            string s3 = "cereza";
            listaCompra.Add(s3);
            string s4 = "durazno";
            listaCompra.Add(s4);

            List<string> listaFiltro = new List<string>();

            listaFiltro.Add(s2);
            listaFiltro.Add(s4);

            Funciones.RemoveRepeatedValors(listaCompra, listaFiltro);
            Console.Write(listaCompra);


        }
    }
}
