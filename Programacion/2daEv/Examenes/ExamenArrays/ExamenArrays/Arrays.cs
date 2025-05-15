using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;

namespace ExamenArrays
{
    class Arrays
    {

        //(2 punto) Implementa una función que, dado un array de enteros, devuelva el valor más
        //alto.
        public static int ValorMasAlto(int[] array)
        {
            if (array == null || array.Length == 0)
                return -1;
            int valor = array[0];
            for(int i = 1; i < array.Length; i++)
            {
                if (array[i] > valor)
                    valor = array[i];
            }
            return valor;
        }

        //(3 punto) Implementa una función que borre de un array de doubles, todas las ocurrencias
        //de un double en concreto.Importante, deberás inferir qué devuelve este array, porque en
        //esencia no se pueden borrar cosas de un array.
        public static int[] BorrarOcurrencia(int[] array, int valoreliminar)
        {
            if (array == null)
                return null;

            // Paso 1: Contar cuántos elementos no deben eliminarse
            int contador = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != valoreliminar)
                    contador++;
            }

            // Paso 2: Crear nuevo array con el tamaño adecuado
            int[] result = new int[contador];

            // Paso 3: Copiar solo los elementos que no coincidan
            int j = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != valoreliminar)
                {
                    result[j] = array[i];
                    j++;
                }
            }
            return result;
        }


        //(3 punto) Implementa una función que, dado un array de strings, lo ordene de alguna
        //manera.

        public static void StringOrdenado(string[] array)
        {
            if (array == null)
                return;

            for(int i = 0; i < array.Length; i++)
            {
                for(int j = 0; j < array.Length - i - 1; j++)
                {
                    if (EsMayor(array[j], array[j + 1]))
                    {
                        string temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        private static bool EsMayor(string a, string b)
        {
            int minLen = Math.Min(a.Length, b.Length);
            for (int i = 0; i < minLen; i++)
            {
                if (a[i] > b[i]) return true;
                if (a[i] < b[i]) return false;
                // Si son iguales, seguimos comparando
            }
            // Si son iguales hasta el más corto, el más largo es mayor
            return a.Length > b.Length;
        }

        //(2 punto) Implementa una función que, dado un array de strings, devuelva la posición
        //donde se encuentra el string con longitud más grande.

        public static int IndiceStringMasLargo(string[] array)
        {
            if (array == null || array.Length == 0)
                return -1;

            int maxindex = 0;
            int maxLength = array[0].Length;

            for(int i = 1; i < array.Length; i++)
            {
                if (array[i].Length > maxLength)
                {
                    maxLength = array[i].Length;
                    maxindex = i;
                }
            }
            return maxindex;
        }

        //(2 puntos) (Nota mínima 7) Implementa la siguiente función.
        //Una función llamada Merge, que reciba dos arrays de enteros que están ordenados y devuelva un
        //array ordenado con el contenido de los dos arrays de entrada.Prohibido usar algoritmos de
        //ordenación, ni de C#, ni tuyos. El algoritmo se explicará en la pizarra.

        public static int[] Merge(int[] arr1, int[] arr2)
        {
            if (arr1 == null)
                arr1 = new int[0];
            if (arr2 == null)
                arr2 = new int[0];

            int[] resultado = new int[arr1.Length + arr2.Length];
            int i = 0, j = 0, k = 0;
            while(i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i] < arr2[i])
                {
                    resultado[k] = arr1[i];
                    i++;
                }
                else
                {
                    resultado[k] = arr2[j];
                    j++;
                }
                k++;   
            }
            while(i < arr1.Length)
            {
                resultado[k] = arr1[i];
                i++;
                k++;
            }
            while(j < arr2.Length)
            {
                resultado[k] = arr2[j];
                j++;
                k++;
            }
            return resultado;
        }

        //(2 puntos) (nota mínima 3) Implementa la siguiente clase, pon los atributos, constructores y
        //métodos que veas necesarios.La clase que hay que implementar es un pool de objetos que
        //implementa una interfaz, es decir hay que hacer una interfaz y la clase.Entre el código a
        //desarrollar que tienes que hacer: ToArray, Clone y Count.Es posible que tengas que usar “where
        //T : class”. El constructor de la clase será privado, si no, no se corregirá el ejercicio, y en la
        //interfaz habrá una función de clase (estática) llamada CreatePool que creará un pool.


    }
}
