using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1
{
    internal class Pruebas
    {
        public static List<int> GetFibonacci(int n)
        {

            List<int> fibonacci = new List<int>();

            
            for (int i = 0; i < n; i++)
            {
                int f0 = 0;
                int f1 = 1;
                int aux = 0;

                fibonacci.Add(f0);
                  
            }
            return fibonacci;

        }
    }
}
