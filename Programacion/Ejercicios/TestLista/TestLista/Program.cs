namespace test_list
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new();
            List<int> list1 = new List<int>();

            list.Add(7);
            list.Add(-1);
            list.Add(0);
            list.Add(3);

            int n = list.Count();
            list.Add(5);
            n = list.Count();

            //Ejercicios.PrintNumbers(list);

            //int suma = Ejercicios.SumaElementosLista(list);
            //Console.WriteLine(suma);

            //int sumaPar = Ejercicios.SumaElementosParesLista(list);
            //Console.WriteLine(sumaPar);

            //List<int> l2 = Ejercicios.CopiarLista(list);

            //Ejercicios.CopiarLista(list);

            //Ejercicios.CopiarListaInversa(list);

            //Ejercicios.InvertirLista(list);

            //Ejercicios.DevolverMayorValorEnLista(list);

            //int menor = Ejercicios.IndexOfMenor(list);
            //Console.WriteLine(menor);

            Ejercicios.RemoveNegativeFromList(list);
            Ejercicios.RemoveNegativeFromList1(list);
            //Remove en lista es suspenso, se usa RemoveAt

            List<int> listanueva = new List<int>();
            listanueva.Add(8);
            listanueva.Add(4);
            listanueva.Add(3);
            listanueva.Add(-1);
            listanueva.Add(-5);
            listanueva.Add(8);
            listanueva.Add(-5);


            List<int> lis = Ejercicios.PosicionDelMenorValor(listanueva);

            double interpolation = Ejercicios.GetInterpolacionLineal(10, 100, 0.5);
            Console.WriteLine(interpolation);

            List<string> strings = new List<string>();
            string s = "0";
            string t = "r52435";
            strings.Add(s);
            strings.Add(t);
            Ejercicios.DeleteStringFromList(strings, s);




        }
    }
}
