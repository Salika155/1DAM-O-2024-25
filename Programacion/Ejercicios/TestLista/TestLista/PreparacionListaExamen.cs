using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestLista
{
    internal class PreparacionListaExamen
    {
        //Hacer una funcion que le paso una lista de enteros y los imprime por pantalla
        public static void ImprimeLista(List<int> lista)
        {
            if (lista == null)
                return;
            
            for (int i = 0; i < lista.Count; i++)
            {
                var element = lista[i];
                Console.Write(element);
            }
        }

        //Hacer una funcion que le paso una lista de enteros y me devuelve la suma de todos esos numeros

        public static int SumaNumerosLista(List<int> lista)
        {
            if (lista == null || lista.Count == 0)
                return 0;

            int aux = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                aux += lista[i];
            }
            return aux;
        }


        //Funcion que le paso una lista de enteros y devuelva la suma de todos sus numeros pares

        public static int SumaPares(List<int> num)
        {
            if (num == null || num.Count == 0)
                return 0;
            int aux = 0;

            for (int i = 0; i < num.Count; i++)
            {
                if (num[i] % 2 == 0)
                {
                    aux += num[i];
                }
            }
            return aux;
        }

        //Hacer una funcion que le paso una lista de enteros y me devuelve una lista que sea una copia exacta que la lista que le he pasado
        public static List<int> CopiaLista(List<int> lis)
        {
            List<int> newl = new List<int>();

            if (lis == null || lis.Count == 0)
                return newl;

            for (int i = 0; i < lis.Count; i++)
            {
                int element = lis[i];
                newl.Add(element);
            }
            return newl;
        }


        //Hacer una funcion que le paso una lista de enteros y devuelve una lista al reves
        public static List<int> ReverseList(List<int> l)
        {
            List<int> reverse = new List<int>();

            if (l == null || l.Count == 0)
                return reverse;

            for (int i = l.Count - 1; i >= 0; i--)
            {
                int element = l[i];
                reverse.Add(element);
            }
            return reverse;
        }


        //Hacer una funcion que le paso una lista de enteros (no devuelve nada) y los invierte
        public static void InvierteLista(List<int> l)
        {
            if (l == null || l.Count == 0)
                return;

            for (int i = 0, j = l.Count - 1; i < l.Count / 2; i++, j--)
            {
                //int aux = l[i];
                //l[i] = l[j];
                //l[j] = aux;
                (l[j], l[i]) = (l[i], l[j]);
            }
        }

        //Hacer una funcion que le paso una lista de enteros y me devuelve el numero mas grande que hay en la lista
        public static int NumeroMasGrande(List<int> l)
        {
            if (l == null || l.Count == 0)
                return 0;
            int aux = int.MinValue;

            for (int i = 0; i < l.Count; i++)
            {
                if (EsMenor(aux, l[i]))
                    aux = l[i];
            }
            return aux;
        }

        public static bool EsMenor(int a, int b) => a < b;


        //Hacer una funcion que le paso una lista de enteros y devuelvo la posicion donde se encuentra el menor
        public static int PosicionDelMenor(List<int> l)
        //IndexOfMenor
        {
            if (l == null || l.Count == 0)
                return -1;

            int n = 0;

            for (int i = 1; i < l.Count; i++)
                if (l[i] < l[n])
                    n = i;
            return n;
        }

        public static int IndexOfMenor(List<int> l)
        {
            if (l == null || l.Count == 0)
                return -1;

            int menor = l[0];
            int index = 0;

            for(int i = 0; i < l.Count; i++)
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
        public static void BorrarDeListaNegativo(List<int> l)
        {
            if (l == null || l.Count == 0)
                return;

            for (int i = 0; i < l.Count; i++)
                if (IsNegative(l[i]))
                {
                    l.RemoveAt(i--);
                }
                    

        }

        public static bool IsNegative(int a) => (a) < 0; 


        //Le paso una lista de enteros y me devuelve una lista con las posiciones donde se encuentra el numero menor
        //se refiere a las veces que se repita el numero menor sus posiciones
        public static List<int> NumerosMenoresLista(List<int> l)
        {
            List<int> newl = new();

            if (l == null || l.Count == 0)
                return newl;

            int menor = IndexOfMenor(l);

            for (int i = 0; i < l.Count; i++)
            {
                if (l[i] == menor)
                    newl.Add(i);
            }
            return newl; 
        }

        // haz una funcion que le paso tres dobles y me saque su interpolacion -> interpolacion = b * u + a (1 - u)
        public static double Interpolacion(double a, double b, double u)
        {
            double interpol1 = b * u;
            double interpol2 = a * (1 - u);
            double result = interpol1 + interpol2;

            return result;
        }

        //calcula la saturacion con respecto a dos numeros
        //si el valor es menor a los limites inferiores o superiores que lo ajuste al mas cercano
        public static double GetSaturation(double inf, double sup, double value)
        {
            if (value < inf)
                value = inf;
            else if (value > sup)
                value = sup;
            return value;
        }

        //le paso una lista de strings y un string, borra de la lista todos los string que coincidan con el string
        //al pasarle string hay que comprobar si el mismo string es null
        public static void BorrarStrings(List<string> st, string estr)
        {
            if (st == null || st.Count == 0)
                return;

            for(int i = 0; i < st.Count; i++)
            {
                if (st[i] is not null || st[i] == estr)
                {
                    st.RemoveAt(i);
                    i--;
                }
            }
        }


        //funcion lerp interpolacion lineal

        //hacer una funcion que le paso una lista de string y un valor, y em devuelve la primera posicion donde se encuentra ese valor en la lista
        public static int IndexOfFirstValor(List<string> st, string a)
        {
            if (st == null || a == null)
                return -1;

            string index = "";

            for (int i = 0; i < st.Count; i++)
            {
                index = st[i];
                
                if (st[i] == a.ToString() && index != null)
                {
                    return i;
                }
            }
            return -1;
        }


        //hacer una funcion que me diga si un valor se encuentra en una lista de strings o no
        public static bool Contains (List<string> se, string s)
        {
            return IndexOfFirstValor(se, s) >= 0;
        }

        //binary search

        public static 

        //me van a dar una lista de enteros, y puedo modificarla a mi antojo, pero tengo que devolver una lista de enteros con todos los valores que tenga ahi pero ordenados
        //hacer una funcion que le paso una lista de enteros (que se puede modificar) y devuelvo otra lista nueva con los mismos numeros de la original pero ordenados de menor a mayor



        //hacer una funcion que le paso una lista de enteros y me devuelve la mediana (numero que esta en la propia lista, la mitad de los valores estan por debajo y la otra por encima



    }

    internal class PreparacionArrayExamen
    {
        public static bool IsCapicua(string cadena)
        {
            int n = cadena.Length / 2;
            for (int i = 0, j = cadena.Length - 1; i < n; i++, j--)
            //for (int i = 0, j = (cadena.Length - 1) / 2; i < j; i++, j--)
            //for (int i = 0, j = cadena.Length - 1; i < j; i++, j--)
            {
                if (cadena[i] != cadena[j])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
