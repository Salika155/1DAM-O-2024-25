using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2
{
    internal class Pruebas
    {
        public static int[] Merge(int[] a, int[] b)
        {
            int[] result = new int[a.Length + b.Length];


            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] < b[i])
                {
                    result[i] = a[i];
                    result[i]++;
                }
                else
                {
                    result[i] = b[i];
                    result[i]++;
                }
            }
            return result;
        }
    }
}
