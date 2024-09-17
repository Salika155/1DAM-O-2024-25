using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Funciones
    {
        public static int GetGreather3(int a, int b, int c)
        {
            int result = a;
            if (b > result)
            {
                result = b;
            }
            if (c > result)
            {
                result = c;
            }
            return result;
        }

        
    }
}
