using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenListaArray
{
    public class Funciones
    {
        //dado un array de enteros, encuentre y devuelva el numero dentro del array que mas se
        //acerque al valor medio de todos los numeros contenidos en el
        public static double GetNumNearMidValor(int[] array)
        {
            if (array == null || array.Length == 0)
                return -1;

            //ordenar array??
            SortArray(array);
            int min = GetMinValorOfArray(array);
            int max = GetMaxValorOfArray(array);

            int medInt = (min + max) / 2;
            double med = (min * 1.0 + max * 1.0) / 2.0;
            int arrayLength = array.Length;
            
            //restar dos numeros y 

            
            for (int i = 0; i < arrayLength / 2; i++)
            {
                if (IsPair(arrayLength))
                {
                    med = array[medInt] - array[medInt - 1];
                }
                else
                {
                    med = array[medInt];
                }
            }
            med = medInt;
            return med;

        }

        public static int GetMinValorOfArray(int[] array)
        {
            if (array == null || array.Length == 0)
                return -1;

            //comprobaciones
            int minor = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < array[0])
                {
                    minor = array[i];
                }
            }
            return minor;
        }

        public static int GetMaxValorOfArray(int[] array)
        {
            if (array == null || array.Length == 0)
                return -1;

            int biggest = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > biggest)
                {
                    biggest = array[i];
                }
            }
            return biggest;
        }

        public static void SortArray(int[] array)
        {
            if (array == null || array.Length == 0)
                return;

            for(int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    int auxI = array[i];
                    int auxJ = array[j];

                    if (auxJ < auxI)
                    {
                        int aux = auxI;
                        auxI = auxJ;
                        auxJ = aux;
                    }
                }
            }
        }

        public static bool IsPair(int n) => (n % 2 == 0);

        public static double GetDistance(int a, int b) => b - a;

        //Ex2
        public static int RemoveRepeatedValors(List<string> list, List<string> filtro)
        {
            int count = 0;

            for (int i = 0, j = 0; i < list.Count && j < /*filtro.Count*/ list.Count; i++, j++)
            {

                if (StringEquals(list[i], filtro[j]))
                {
                    list.RemoveAt(i);
                    count++;
                    i--;
                }
            }
            return count;
        }

        public static bool StringEquals(string a, string b) => (a == b);

    }
}
