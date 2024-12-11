using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ExamenListaArray
{
    public class Correccion
    {
        //Ejercicio 1
        public static int GetNumMidValor(int[] array)
        {
            if (array == null || array.Length == 0)
                return -1;

            int valorMedio = 0;

            for (int i = 0; i < array.Length; i++)
            {
                valorMedio += array[i];
            }
            valorMedio /= array.Length;
            return valorMedio;
        }

        public static int GetDistanciaAbsoluta(int a, int b)
        {
            return Math.Abs(b - a);
        }

        public static int GetNumInArrayNearPromedio(int[] array)
        {
            if (array == null || array.Length == 0)
                return -1;

            int numMidValor = GetNumMidValor(array);
            int minDistancia = int.MaxValue;
            int numCercano = -1;

            for (int i = 0; i < array.Length; i++)
            {
                int numI = array[i];
                int distanciaAbsoluta = GetDistanciaAbsoluta(numI, numMidValor);
                if (distanciaAbsoluta < minDistancia)
                {
                    minDistancia = distanciaAbsoluta;
                    numCercano = numI;
                }
            }
            return numCercano;
        }

        //Ejercicio2

        public static int EliminarElementosCoincidentesEnLista(List<string> listaCompra, List<string> listFiltro)
        {
            if (listaCompra == null || listaCompra.Count == 0 || listFiltro == null || listFiltro.Count == 0)
                return 0;

            int elemEliminados = 0;

            for (int i = 0; i < listaCompra.Count; i++)
            {
                for (int j = 0; j < listFiltro.Count; j++)
                {
                    if (listaCompra[i] == listFiltro[j])
                    {
                        RemoveAtList(i, listaCompra);
                        i--;
                        elemEliminados++;
                        break;
                    }
                }
            }
            return elemEliminados;
        }

        public static int RemoveAtList(int index, List<string> compraList)
        {
            if (compraList == null || index < 0 || index >= compraList.Count)
                return -1;

            // Mover los elementos a la izquierda desde el índice
            for (int i = index; i < compraList.Count - 1; i++)
            {
                compraList[i] = compraList[i + 1]; // Sobrescribir el elemento actual
            }
            compraList.RemoveAt(compraList.Count - 1);

            return index; 
        }
    }
}


