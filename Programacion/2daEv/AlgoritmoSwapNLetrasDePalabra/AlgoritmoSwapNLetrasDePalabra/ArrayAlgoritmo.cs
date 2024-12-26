using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoSwapNLetrasDePalabra
{
    internal class ArrayAlgoritmo
    {
        //cambiar la posicion de dos letras seguidas en una palabra, o mas
        //sin hacer un nuevo array

        public static void E1(string[] array, int n)
        {
            if (array == null || n <= 0)
                return;

            int lenght = array.Length;

            for(int i = 0; i < lenght - (lenght - i); i++)
            {
                if (array.Length % 2 == 0)
                {
                    string aux1 = array[lenght - (lenght - i)];
                    string auxarray0 = array[0 + lenght - i];
                    string swapvar = aux1;
                    aux1 = auxarray0;
                    auxarray0 = swapvar;
                    swapvar = aux1;
                }
                else
                {

                }
            }
        }
    }

    public static void E2(string[] array, int n)
    {
        int inicio = 0;
        int fin = array.Length - 1;

        while(inicio < fin)
        {
            string aux = array[inicio];
            array[inicio] = array[fin];
            array[fin] = aux;
            inicio++;
            fin--;
        }

        //aqui rotarias todo el array
        //ahora falta rotar sof otra vez e ia otra vez
        inicio = 0;
        fin = n - 1;
        while (inicio < fin)
        {
            string aux = array[inicio];
            array[inicio] = array[fin];
            array[fin] = aux;
            inicio++;
            fin--;
        }
        // con esto se resuelve
        inicio = n;
        fin = array.Length - 1;
        while(inicio < fin)
        {
            string aux = array[inicio];
            array[inicio] = array[fin];
            array[fin] = aux;
            inicio++;
            fin--;
        }
    }
}
