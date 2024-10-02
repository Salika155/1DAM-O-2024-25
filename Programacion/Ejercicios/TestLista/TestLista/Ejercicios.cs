

namespace test_list
{
    internal class Ejercicios
    {
        //Hacer una funcion que le paso una lista de enteros y los imprime por pantalla

        public static void PrintNumbers(List<int> l) 
        {
            if (l == null)
            Console.WriteLine("La lista tiene " + l.Count + " elementos.");

            for (int i = 0; i < l.Count; i++)
            {
                var element = l[i];
                Console.WriteLine(element);
            }
        }

        //Hacer una funcion que le paso una lista de enteros y me devuelve la suma de todos esos numeros

        public static int SumaElementosLista(List<int> l)
        {
            if (l == null)
                return 0;
            int result = 0;
            
            for (int i = 0; i < l.Count; i++)
            {
                //int element = l[i];
                //result += element;
                result += l[i];
            }
            return result;
        }

        //Funcion que le paso una lista de enteros y devuelva la suma de todos sus numeros pares

        public static int SumaElementosParesLista(List<int> l)
        {
            if (l == null)
                return 0;
            int result = 0;

            for (int i = 0; i < l.Count; i++)
            {
                int element = l[i];
                if (element % 2 == 0) //mejor usar la funcion
                    result += element;
            }
            return result;
        }

        //Hacer una funcion que le paso una lista de enteros y me devuelve una lista que sea una copia exacta que la lista que le he pasado

        public static List<int> CopiarLista(List<int> l)
        {
            List<int> l1 = new List<int>();
            if (l == null)
                return l;
            
            for (int i = 0; i < l.Count; i++)
            {
                int element = l[i];
                l1.Add(element);
            }
            return l1;
        }

        //Hacer una funcion que le paso una lista de enteros y devuelve una lista al reves

        public static List<int> CopiarListaInversa(List<int> l)
        {
            List<int> lcopia = new();

            for(int i = l.Count - 1; i >= 0; i--)
            {
                int element = l[i];
                lcopia.Add(element);
                //result.Insert(0, element);

                //int index = l.Count - i - 1;
                //int element = l[index];
                //result.Add(element);
            }
            return lcopia;
        }

        //Hacer una funcion que le paso una lista de enteros (no devuelve nada) y los invierte
    }
}
