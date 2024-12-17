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
            #region codigo
            if (lista == null)
                return;
            
            for (int i = 0; i < lista.Count; i++)
            {
                var element = lista[i];
                Console.Write(element);
            }
            #endregion
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
            #region codigo
            if (lista == null || lista.Count == 0)
                return 0;

            int aux = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                aux += lista[i];
            }
            return aux;
            #endregion
            if (lista == null || lista.Count == 0)
                return 0;
            aux = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                aux += lista[i];
            }
            return aux;
        }


        //Funcion que le paso una lista de enteros y devuelva la suma de todos sus numeros pares

        public static int SumaPares(List<int> num)
        {
            #region codigo
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
            #endregion
            int sum = 0;
            for (int i = 0; i < num.Count; i++)
            {
                if (num[i] % 2 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }

        //Hacer una funcion que le paso una lista de enteros y me devuelve una lista que sea una copia exacta que la lista que le he pasado
        public static List<int> CopiaLista(List<int> lis)
        {
            #region codigo
            List<int> newl = new List<int>();

            if (lis == null || lis.Count == 0)
                return newl;

            for (int i = 0; i < lis.Count; i++)
            {
                int element = lis[i];
                newl.Add(element);
            }
            return newl;
            #endregion

            List<int> copia = new List<int>();
            for (int i = 0; i < lis.Count; i++)
            {
                int element = lis[i];
                copia.Add(element);
            }
            return copia;
        }


        //Hacer una funcion que le paso una lista de enteros y devuelve una lista al reves
        public static List<int> ReverseList(List<int> l)
        {
            #region codigo
            List<int> reverse = new List<int>();

            if (l == null || l.Count == 0)
                return reverse;

            for (int i = l.Count - 1; i >= 0; i--)
            {
                int element = l[i];
                reverse.Add(element);
            }
            return reverse;
            #endregion
            List<int> reverselist = new List<int>();
            if (l == null || l.Count == 0)
                return reverselist;
            for (int i = l.Count - 1; i >= 0; i--)
            {
                int element = l[i];
                reverselist.Add(element);
            }
            return reverselist;
        }


        //Hacer una funcion que le paso una lista de enteros (no devuelve nada) y los invierte
        public static void InvierteLista(List<int> l)
        {
            #region codigo
            if (l == null || l.Count == 0)
                return;

            for (int i = 0, j = l.Count - 1; i < l.Count / 2; i++, j--)
            {
                //int aux = l[i];
                //l[i] = l[j];
                //l[j] = aux;
                (l[j], l[i]) = (l[i], l[j]);
            }
            #endregion
            List<int> newList = new List<int>();
            for (int i = l.Count - 1; i >= 0; i--)
            {
                int element = l[i];
                newList.Add(element);
            }
        }

        //Hacer una funcion que le paso una lista de enteros y me devuelve el numero mas grande que hay en la lista
        public static int NumeroMasGrande(List<int> l)
        {
            #region codigo
            if (l == null || l.Count == 0)
                return 0;
            int aux = int.MinValue;

            for (int i = 0; i < l.Count; i++)
            {
                if (EsMenor(aux, l[i]))
                    aux = l[i];
            }
            return aux;
            #endregion
            int mayor = l[0];
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i] > mayor)
                {
                    mayor = l[i];
                }
            }
            return mayor;
        }

        public static bool EsMenor(int a, int b) => a < b;


        //Hacer una funcion que le paso una lista de enteros y devuelvo la posicion donde se encuentra el menor
        public static int PosicionDelMenor(List<int> l)
        //IndexOfMenor
        {
            #region codigo
            if (l == null || l.Count == 0)
                return -1;

            int n = 0;

            for (int i = 1; i < l.Count; i++)
                if (l[i] < l[n])
                    n = i;
            return n;
            #endregion

            int menor = l[0];
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i] < menor)
                    menor = i;
            }
            return menor;
        }

        public static int IndexOfMenor(List<int> l)
        {
            #region codigo
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
            #endregion
        }

        //Hacer una funcion que le paso una lista de enteros y borra de esa lista todos los numeros negativos
        public static void BorrarDeListaNegativo(List<int> l)
        {
            #region codigo
            if (l == null || l.Count == 0)
                return;

            for (int i = 0; i < l.Count; i++)
                if (IsNegative(l[i]))
                {
                    l.RemoveAt(i--);
                }
            #endregion
        }

        public static bool IsNegative(int a) => (a) < 0; 


        //Le paso una lista de enteros y me devuelve una lista con las posiciones donde se encuentra el numero menor
        //se refiere a las veces que se repita el numero menor sus posiciones
        public static List<int> NumerosMenoresLista(List<int> l)
        {
            #region codigo
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
            #endregion
        }

        // haz una funcion que le paso tres dobles y me saque su interpolacion -> interpolacion = b * u + a (1 - u)
        public static double Interpolacion(double a, double b, double u)
        {
            #region codigo
            double interpol1 = b * u;
            double interpol2 = a * (1 - u);
            double result = interpol1 + interpol2;

            return result;
            #endregion
        }

        //calcula la saturacion con respecto a dos numeros
        //si el valor es menor a los limites inferiores o superiores que lo ajuste al mas cercano
        public static double GetSaturation(double inf, double sup, double value)
        {
            #region codigo
            if (value < inf)
                value = inf;
            else if (value > sup)
                value = sup;
            return value;
            #endregion
        }

        //le paso una lista de strings y un string, borra de la lista todos los string que coincidan con el string
        //al pasarle string hay que comprobar si el mismo string es null
        public static void BorrarStrings(List<string> st, string estr)
        {
            #region codigo
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
            #endregion
        }


        //funcion lerp interpolacion lineal

        //hacer una funcion que le paso una lista de string y un valor, y em devuelve la primera posicion donde se encuentra ese valor en la lista
        public static int IndexOfFirstValor(List<string> st, string a)
        {
            #region codigo
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
            #endregion
        }


        //hacer una funcion que me diga si un valor se encuentra en una lista de strings o no
        public static bool Contains (List<string> se, string s)
        {
            #region codigo
            return IndexOfFirstValor(se, s) >= 0;
            #endregion
        }

        //binary search

        public static int BinarySearch(List<int> l, double value)
        {
            #region codigo
            if (l == null || l.Count == 0)
                return -1;

            int min = 0;
            int max = l.Count - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;

                if (l[mid] == value)
                    return mid;
                else if (l[mid] < value)
                {
                    max = mid + 1;
                }
                else if (l[mid] > value)
                {
                    min = mid - 1; 
                }
            }
            return -1;
            #endregion
        }

        //me van a dar una lista de enteros, y puedo modificarla a mi antojo, pero tengo que devolver una lista de enteros con todos los valores que tenga ahi pero ordenados
        //hacer una funcion que le paso una lista de enteros (que se puede modificar) y devuelvo otra lista nueva con los mismos numeros de la original pero ordenados de menor a mayor

        public static List<int> SortList(List<int> list)
        {
            #region codigo
            List<int> result = new List<int>();
 
            while (list.Count > 0)
            {
                int menor = IndexOfMenor(list);
                int element = list[menor];

                result.Add(element);
                list.RemoveAt(menor);
            }
            return result;
            #endregion
        }


        //hacer una funcion que le paso una lista de enteros y me devuelve la mediana (numero que esta en la propia lista, la mitad de los valores estan por debajo y la otra por encima
        public static int GetMedianaFromList(List<int> l)
        {
            #region codigo
            OrdenarListaConFor(l);
            int result = 0;

            if (l.Count % 2 == 0)
            {
                int mid = l[l.Count / 2];
                int min = l[(l.Count / 2) - 1];
                result = (min + min) / 2;
            }
            else
                result = l[l.Count / 2];
            return result;
            #endregion
        }

        public static void OrdenarListaConFor(List<int> l)
        {
            #region codigo
            for (int i = 0; i < l.Count; i++)
            {
                for(int j = i + 1; j < l.Count; j++)
                {
                    if (l[j] < l[i])
                    {
                        int aux = l[i];
                        l[i] = l[j];
                        l[j] = aux;
                    }
                }
            }
            #endregion
        }


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
