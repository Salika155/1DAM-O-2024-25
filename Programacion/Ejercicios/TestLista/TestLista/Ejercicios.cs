

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
                return -1;

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
            if (l == null)
                return;
            for (int i = l.Count - 1; i >= 0; i--)
            {
                if (l[i] < 0)
                {
                    l.RemoveAt(i);
                }
            }
        }

        public static void RemoveNegativeFromList1(List<int> l)
        {
            if (l == null)
                return;
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i] < 0)
                {
                    l.RemoveAt(i);
                    i--;
                } 
            }
        }

        //Le paso una lista de enteros y me devuelve una lista con las posiciones donde se encuentra el numero menor

        public static List<int> PosicionDelMenorValor(List<int> l)
        {
            List<int> listaresult = new List<int>();
            if (l == null || l.Count == 0)
                return listaresult;
            
            int menorpos = GetLowerValue(l);

            for(int i = 0; i < l.Count; i++)
            {
                int element = l[i];
                if (element == menorpos)
                    listaresult.Add(i);
            }
            return listaresult;
        }

        public static int GetLowerValue(List<int> l)
        {
            if (l == null || l.Count == 0)
                return -1;
            List<int> listresult = new List<int>();
            int aux = 0;

            for(int i = 0; i < l.Count; i++)
            {
                if (aux > l[i])
                    aux = l[i];
            }
            return aux;
        }

        //interpolacion = b * u + a (1 - u)
        public static double GetInterpolacionLineal(double a, double b, double u)
        {
            double part2 = a * (1 - u);
            double part1 = b * u;
            double interpolation = part1 + part2;

            return interpolation;
        }

        //calcula la saturacion con respecto a dos numeros
        //si el valor es menor a los limites inferiores o superiores que lo ajuste al mas cercano
        public static double GetSaturate(double limInf, double limSup, double value)
        {
            if (value < limInf)
                value = limInf;
            else if (value > limSup)
                value = limSup;
            return value;
        }
        //le paso una lista de strings y un string, borra de la lista todos los string que coincidan con el string
        //al pasarle string hay que comprobar si el mismo string es null
        public static void DeleteStringFromList(List<string> slist, string s)
        {
            if (slist == null || s == null)
                return;
            
            for (int i = 0; i < slist.Count; i++)
            {
                string element = slist[i];
                if (element != null && element == s)
                {
                    slist.RemoveAt(i);
                    i--;
                }
            }
        }
        public static void DeleteStringFromList1(List<string> slist, string s)
        {
            for (int i = 0; i < slist.Count; i++)
            {
                if (AreStringEquals(slist[i], s))
                {
                    slist.RemoveAt(i);
                    i--;
                }    
            }
        }

        public static bool AreStringEquals(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                    return false;
            }
            return true;
        }
        //funcion lerp interpolacion lineal

        //hacer una funcion que le paso una lista de string y un valor, y em devuelve la primera posicion donde se encuentra ese valor en la lista

        public static int IndexOfList(List<string> l, string n)
        {
            if (l == null || n == null)
                return -1;
            string result = "";

            for (int i = 0; i < l.Count; i++)
            {
                result = l[i];
                if (result != null && result == n)
                    return i;
            }
            return -1;
        }

        //hacer una funcion que me diga si un valor se encuentra en una lista de strings o no

        public static bool Contains(List<string> ls, string s)
        {
            //esto esta mal
            //if (ls == null || s == null)
            //    return false;

            //for(int i = 0; i < ls.Count; i++)
            //{
            //    if (ls == null && ls[i] != s)
            //        return false;
            //}
            //return true;

            return IndexOfList(ls, s) >= 0;
        }
        //binary search

        public static int BinarySearch(List<double> list, double value)
        {
            int min = 0;
            int max = list.Count - 1;
            //int position = 0;

            while (min <= max)
            {
                int mid = (max + min) / 2;

                if (list[mid] == value)
                    return mid;
                else if (list[mid] > value) 
                    max = mid - 1;
                else
                    min = mid + 1;
            }
            return -1;
        }

        //me van a dar una lista de enteros, y puedo modificarla a mi antojo, pero tengo que devolver una lista de enteros con todos los valores que tenga ahi pero ordenados
        //hacer una funcion que le paso una lista de enteros (que se puede modificar) y devuelvo otra lista nueva con los mismos numeros de la original pero ordenados de menor a mayor

        public static List<int> OrdenarLista(List<int> l)
        {
            List<int> newList = new();

            if (l == null)
                return newList;

            int aux = l[0];

            while (l.Count > 0)
            {
                int minIndex = IndexOfMenor(l);
                int element = l[minIndex];
                
                newList.Add(element);
                l.RemoveAt(minIndex);
            }
            return newList;
            #region
            //for(int i = 0; i < l.Count; i++)
            //{

            //    //while (aux < l[i])
            //    //{
            //    //    IndexOfMenor(l);
            //    //    i++;
            //    //}
            //    //newList.Add(l[i]);
            //}
            #endregion
        }

        public static void OrdenarListaWithForDouble(List<int> l)
        {
            if (l == null)
                return;

            for (int i = 0; i < l.Count; i++)
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

        //hacer una funcion que le paso una lista de enteros y me devuelve la mediana (numero que esta en la propia lista, la mitad de los valores estan por debajo y la otra por encima
    }
}
