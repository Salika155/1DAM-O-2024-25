using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLista
{
    internal class Prueba
    {
        //Hacer una funcion que le paso una lista de enteros y los imprime por pantalla
        public static void WriteList(List<int> lista)
        {
            if (lista == null)
                return;

            for (int i = 0; i < lista.Count; i++) 
            {
                var item = lista[i];
                Console.WriteLine(item);
            }
        }
       
        //Hacer una funcion que le paso una lista de enteros y me devuelve la suma de todos esos numeros
        public static int SumaElementosLista(List<int> lista) 
        {
            if (lista == null)
                return 0;
            int result = 0;

            for (int i = 0; i < lista.Count; i++)
            {
                result += lista[i];
            }
            return result;
        }
        
        //Funcion que le paso una lista de enteros y devuelva la suma de todos sus numeros pares
        public static int SumaElementosParesLista(List<int> lista) 
        {
            if (lista == null)
                return 0;
            int result = 0;

            for (int i = 0; i < lista.Count ; i++)
            {
                int aux = lista[i];
                if (aux % 2 == 0)
                    result += aux;
            }
            return result;
        }

        //Hacer una funcion que le paso una lista de enteros y me devuelve una lista que sea una copia exacta que la lista que le he pasado
        public static List<int> CopiarLista(List<int> lista)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < lista.Count ; i++)
            {
                int aux = lista[i];
                result.Add(aux);
            }
            return result;
        }

        //Hacer una funcion que le paso una lista de enteros y devuelve una lista al reves
        public static List<int> CopiaListaAlReves(List<int> lista)
        {
            List<int> result = new List<int>();

            for (int i = lista.Count - 1; i >= 0; i--)
            {
                int aux = lista[i];
                result.Add(aux);
            }

            return result;
        }
        

        //Hacer una funcion que le paso una lista de enteros (no devuelve nada) y los invierte
        public static void InvertirLista(List<int> lista)
        {
            int count = lista.Count;
            int n = lista.Count >> 1;

            for(int i = 0; i < n; i++)
            {
                int otherIndex = count - 1 - i;
                int aux = lista[i];
                lista[i] = lista[otherIndex];
                lista[otherIndex] = aux;
            }
        }

        //Hacer una funcion que le paso una lista de enteros y me devuelve el numero mas grande que hay en la lista
        public static int DevolverMayorNumeroLista(List<int> lista) 
        {
            int max = lista[0];

            for (int i = 1; i < lista.Count; i++)
            {
                int aux = lista[i];
                if (aux > max)
                    max = aux;
            }
            return max;
        }
        

        //Hacer una funcion que le paso una lista de enteros y devuelvo la posicion donde se encuentra el menor
        public static int DevolverPosicionMenorEnLista(List<int> lista)
        {
            int min = lista[0];
            int minpos = 0;

            for (int i = 1; i < lista.Count;i++)
            {
                int aux = lista[i];
                if (aux < min)
                {
                    min = aux;
                    minpos = i;
                }
            }
            return minpos;
        }

        //Hacer una funcion que le paso una lista de enteros y borra de esa lista todos los numeros negativos
        public static void RemoveNegativosDeLista(List<int> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i] < 0)
                {
                    lista.RemoveAt(i);
                    i--;
                }
            }
        }

    }
}
