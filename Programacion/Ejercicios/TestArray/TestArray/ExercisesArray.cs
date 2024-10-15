using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestArray
{
    internal class ExercisesArray
    {
        //funcion que le paso un array y le añado un numero
        public static int[] Append(int[] array, int value)
        {
            if(array == null)
            {
                int[] aux = new int[1];
                aux[0] = value;
                return aux;
            }

            int lasPosit = array.Length;
            int[] result = new int[lasPosit + 1];

            for(int i = 0; i < lasPosit; i++)
            {
                result[i] = array[i];
            }
            result[lasPosit] = value;
            return result;
        }

        //RemoveAt -> quitar algo del array
        public static int[] Remove(int[] array, int index)
        {
            if (array == null)
            {
                int[] aux = new int[1];
                aux[0] = index;
                return array;
            }
            if (index < 0 || index >= array.Length)
                return array;

            int[] result = new int[array.Length - 1];
            //dos for: uno para copiar los bloques 

            for (int i = index + 1; i < ?; i++)
                result[i - 1] = array[i];

        }

    }
}
