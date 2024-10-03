

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
        public static void InvertirLista(List<int> l) 
        {
            if (l == null)
                return;
            int count = l.Count;
            int n = l.Count >> 1; // / 2

            for (int i = 0; i < n / 2; i++)
            {
                int otherIndex = count - 1 - i;
                int temp = l[i];
                l[i] = l[otherIndex];
                l[otherIndex] = temp;

                //l.Insert(i, 1[l.Count - 1);
                //l.RemoveAt(l.Count - 1);

                //int element = l[i];
                //l.RemoveAt(i);
                //l.Add(element);
            }
        }

        //Hacer una funcion que le paso una lista de enteros y me devuelve el numero mas grande que hay en la lista

        public static int DevolverMayorValorEnLista(List<int> l)
        {
            if (l == null || l.Count == 0)
                return int.MinValue;
            
            int result = l[0];
            for (int i = 1; i < l.Count; i++)
            {
                int element = l[i];
                if (element > result)
                    result = element;
            }
            return result;
        }

        //Hacer una funcion que le paso una lista de enteros y devuelvo la posicion donde se encuentra el menor
        public static int IndexOfMenor(List<int> l)
        {
            if (l == null || l.Count == 0)
                return int.MinValue;

            int menor = l[0];
            int index = 0;

            for(int i = 1; i < l.Count; i++)
            {
                int aux = l[i];
                if (aux < menor)
                {
                    menor = aux;
                    index = i;
                }
            }
            return index;
        }

        //Hacer una funcion que le paso una lista de enteros y borra de esa lista todos los numeros negativos
        public static void RemoveNegativeFromList(List<int> l)
        {
            if (l == null || l.Count == 0)
                return;
            for (int i = l.Count - 1; i > 0; i--)
            {
                if (l[i] < 0)
                    l.RemoveAt(l[i]);
            }
        }
    }
}
