using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenListaArray
{
    internal class Correccion
    {
        public class Funciones
        {
            // Encuentra y devuelve el número dentro del array que más se acerque al valor promedio
            public static int GetNumNearMidValor(int[] array)
            {
                if (array == null || array.Length == 0)
                    return -1;

                // Calculamos el promedio de los valores
                double average = 0;
                for (int i = 0; i < array.Length; i++)
                    average += array[i];
                average /= array.Length;

                // Buscamos el número más cercano al promedio
                int closest = array[0];
                double minDistance = Math.Abs(average - closest);

                for (int i = 1; i < array.Length; i++)
                {
                    double distance = Math.Abs(average - array[i]);
                    if (distance < minDistance)
                    {
                        closest = array[i];
                        minDistance = distance;
                    }
                }

                return closest;
            }

            // Encuentra el valor mínimo del array
            public static int GetMinValorOfArray(int[] array)
            {
                if (array == null || array.Length == 0)
                    return -1;

                int minor = array[0];
                for (int i = 1; i < array.Length; i++) // Comenzar desde el índice 1
                {
                    if (array[i] < minor)
                    {
                        minor = array[i];
                    }
                }
                return minor;
            }

            // Encuentra el valor máximo del array
            public static int GetMaxValorOfArray(int[] array)
            {
                if (array == null || array.Length == 0)
                    return -1;

                int biggest = array[0];
                for (int i = 1; i < array.Length; i++) // Comenzar desde el índice 1
                {
                    if (array[i] > biggest)
                    {
                        biggest = array[i];
                    }
                }
                return biggest;
            }

            // Ordena un array de forma ascendente (Bubble Sort)
            public static void SortArray(int[] array)
            {
                if (array == null || array.Length == 0)
                    return;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j] > array[j + 1])
                        {
                            int temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            public static bool IsPair(int n) => (n % 2 == 0);

            // Calcula la distancia entre dos números
            public static double GetDistance(int a, int b) => Math.Abs(b - a);

            // Elimina valores repetidos de una lista basándose en un filtro (sin Contains)
            public static int RemoveRepeatedValors(List<string> list, List<string> filtro)
            {
                if (list == null || filtro == null)
                    return 0;

                int count = 0;

                for (int i = 0; i < list.Count; i++)
                {
                    if (IsInList(list[i], filtro))
                    {
                        list.RemoveAt(i);
                        count++;
                        i--; // Ajustamos el índice tras eliminar un elemento
                    }
                }

                return count;
            }

            // Verifica manualmente si un elemento está en la lista filtro (sin usar Contains)
            public static bool IsInList(string value, List<string> list)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (StringEquals(value, list[i]))
                        return true;
                }
                return false;
            }

            // Compara si dos cadenas son iguales
            public static bool StringEquals(string a, string b) => (a == b);
        }
    }
}


