using System;
using System.Collections.Generic;
using System.Linq;
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



        //Funcion que le paso una lista de enteros y devuelva la suma de todos sus numeros pares



        //Hacer una funcion que le paso una lista de enteros y me devuelve una lista que sea una copia exacta que la lista que le he pasado



        //Hacer una funcion que le paso una lista de enteros y devuelve una lista al reves



        //Hacer una funcion que le paso una lista de enteros (no devuelve nada) y los invierte


        //Hacer una funcion que le paso una lista de enteros y me devuelve el numero mas grande que hay en la lista



        //Hacer una funcion que le paso una lista de enteros y devuelvo la posicion donde se encuentra el menor


        //Hacer una funcion que le paso una lista de enteros y borra de esa lista todos los numeros negativos




        //Le paso una lista de enteros y me devuelve una lista con las posiciones donde se encuentra el numero menor





        // haz una funcion que le paso tres dobles y me saque su interpolacion -> interpolacion = b * u + a (1 - u)


        //calcula la saturacion con respecto a dos numeros
        //si el valor es menor a los limites inferiores o superiores que lo ajuste al mas cercano

        //le paso una lista de strings y un string, borra de la lista todos los string que coincidan con el string
        //al pasarle string hay que comprobar si el mismo string es null


        //funcion lerp interpolacion lineal

        //hacer una funcion que le paso una lista de string y un valor, y em devuelve la primera posicion donde se encuentra ese valor en la lista



        //hacer una funcion que me diga si un valor se encuentra en una lista de strings o no


        //binary search



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
