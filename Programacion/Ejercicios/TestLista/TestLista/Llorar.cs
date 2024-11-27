using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TestLista
{
    internal class Llorar
    {
            //Hacer una funcion que le paso una lista de enteros y los imprime por pantalla
        public static void ImprimeLista(List<int> l)
        {
            if (l == null || l.Count == 0)
                return;
            
            for (int i = 0; i < l.Count; i++)
            {
                int aux = l[i];
                Console.WriteLine(aux);
            }
        }
      
            //Hacer una funcion que le paso una lista de enteros y me devuelve la suma de todos esos numeros
        public static int SumaValoresLista(List<int> l)
        {
            if (l == null || l.Count == 0)
                return 0;
            int aux = 0;

            for (int i = 0; i < l.Count; i++)
            {
                aux += l[i];
            }
            return aux;
        }
            

            //Funcion que le paso una lista de enteros y devuelva la suma de todos sus numeros pares
        public static int SumaNumerosParesLista(List<int> l)
        {
            if (l == null || l.Count == 0)
                return 0;

            int result = 0;
            for (int i = 0; i < l.Count; i++)
            {
                int aux = l[i];
                if (IsPair(aux))
                    result += aux;
            }
            return result;
        }

        public static bool IsPair(int n) => n % 2 == 0;
        
        //Hacer una funcion que le paso una lista de enteros y me devuelve una lista que sea una copia exacta que la lista que le he pasado
        public static List<int> CopyList(List<int> l)
        {
            List<int> newList = new();

            if (l == null || l.Count == 0)
                return newList;
            int aux = 0;

            for (int i = 0; i < l.Count; i++)
            {
                aux = l[i];
                newList.Add(aux);
            }
            return newList;
        }
            

        //Hacer una funcion que le paso una lista de enteros y devuelve una lista al reves
        public static List<int> ListaAlReves(List<int> l)
        {
            List<int> newList = new();

            if (l == null || l.Count == 0)
                return newList;
            int aux = 0;

            for (int i = l.Count - 1; i >= 0; i--)
            {
                aux = l[i];
                newList.Add(aux);
            }
            return newList;
        }
            

        //Hacer una funcion que le paso una lista de enteros (no devuelve nada) y los invierte
        public static void InvertirLista(List<int> l)
        {
            if (l == null || l.Count == 0)
                return;
            int n = l.Count;
            

            for (int i = 0; i < n / 2; i++)
            {
                int temp = l[i];
                l[i] = l[n - i - 1];
                l[n - i - 1] = temp;
            }
        }

        //Hacer una funcion que le paso una lista de enteros y me devuelve el numero mas grande que hay en la lista
        public static int MayorDeLaLista(List<int> l)
        {
            if (l == null || l.Count == 0)
                return 0;
            int mayor = l[0];

            for (int i = 0; i < l.Count; i++)
            {
                if (l[i] > mayor)
                    mayor = l[i];
            }
            return mayor;
        }

        public static bool EsMayor(int a, int b) => (a > b) ? true : false;

        //Hacer una funcion que le paso una lista de enteros y devuelvo la posicion donde se encuentra el menor
        public static int IndexOfMenor(List<int> l)
        {
            int index = 0;
            int menor = l[0];
            for (int i = 1; i < l.Count; i++)
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
        public static void BorrarNegativosDeLista(List<int> l)
        {
            if (l == null || l.Count == 0)
                return;

            for (int i = l.Count - 1; i > 0; i--)
            {
                if (l[i] > 0)
                    l.RemoveAt(i);
            }
        }

        //Le paso una lista de enteros y me devuelve una lista con las posiciones donde se encuentra el numero menor
        public static List<int> IndexOfMenorLista(List<int> l)
        {
            List<int> positionNegat = new();

            if (l == null || l.Count == 0)
                return positionNegat;

            int menor = IndexOfMenor(l);

            for (int i = 1; i < l.Count; i++)
            {
                if (l[i] == menor)
                    positionNegat.Add(i);
            }
            return positionNegat;
        }


            //interpolacion = b * u + a (1 - u)
            //calcula la saturacion con respecto a dos numeros
            //si el valor es menor a los limites inferiores o superiores que lo ajuste al mas cercano


            //le paso una lista de strings y un string, borra de la lista todos los string que coincidan con el string
            //al pasarle string hay que comprobar si el mismo string es null
        public static void BorrarStringEnLista(List<string> st, string s)
        {
            for (int i = 0; i < st.Count; i++)
            {
                if (st[i] == s && st[i] != null)
                {
                    st.RemoveAt(i);
                    i--;
                }
            }
        }

            //funcion lerp interpolacion lineal

        //hacer una funcion que le paso una lista de string y un valor, y em devuelve la primera posicion donde se encuentra ese valor en la lista
        public static int IndexOfStrings(List<string> st, string s)
        {
            if (st == null || st.Count == 0 || s == null)
                return -1;
           
            for(int i = 1; i < st.Count; i++)
            {
                string element = st[i];
                if (element == s)
                    return i;
            }
            return -1;
        }

            //hacer una funcion que me diga si un valor se encuentra en una lista de strings o no
        public static bool Contains(List<string> st, string s)
        {
            return IndexOfStrings(st, s) >= 0;
        }


        //binary search, Lista de doubles y un valor double, tiene que buscar el valor
        public static int BinarySearch(List<double> l, double d)
        {
            int min = 0;
            int max = l.Count - 1;

            while (min <= max)
            {
                int mid = (max + min) / 2;

                if (l[mid] == d)
                    return mid;
                else if (l[mid] > d)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }


        //me van a dar una lista de enteros, y puedo modificarla a mi antojo, pero tengo que devolver una lista de enteros con todos los valores que tenga ahi pero ordenados
        public static void SortList(List<int> l)
        {
            if (l == null || l.Count == 0)
                return;

            for (int i = 0; i < l.Count - 1; i++)
            {
                for (int j = i + 1; j < l.Count; j++)
                {
                    if (l[j] < l[i])
                    {
                        int aux = l[i];
                        l[i] = l[j];
                        l[j] = aux;
                    }
                }
            }
        }

            //hacer una funcion que le paso una lista de enteros (que se puede modificar) y devuelvo otra lista nueva con los mismos numeros de la original pero ordenados de menor a mayor
        public static List<int> SortList2(List<int> l)
        {
            List<int> newl = new(l);

            if (l == null || l.Count == 0)
                return newl;

            for (int i = 0; i < newl.Count - 1; i++)
            {
                for (int j = i + 1; j < newl.Count; j++)
                {
                    if (l[j] < l[i])
                    {
                        int aux = l[i];
                        l[i] = l[j];
                        l[j] = aux;
                        newl.Add(aux);
                    }
                }
            }
            return newl;
        }




            //hacer una funcion que le paso una lista de enteros y me devuelve la mediana (numero que esta en la propia lista, la mitad de los valores estan por debajo y la otra por encima

        
    }
}
