using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Ejercicios
    {
        //Funcion que me diga si un numero es par o no

        public static bool IsEven(int numero)
        {
            if (numero % 2 == 0)
                return true;
            return false;
            //return numero % 2 == 0;
        }
    }
}
