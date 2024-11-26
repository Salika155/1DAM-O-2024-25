using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class FuncionesExamen
    {
        public static bool Infernal(int n)
        {
            if (n == 0)
                return false;

            string num = n.ToString();
            int aux = 6;
            int count = 0;

            if (num.Length == 0)
                return false;

            for(int i = 0, j = i + 1; i < num.Length; i++, j++)
            {
                for(int k = j + 1; k < num.Length; k++)
                {
                    char iaux = num[i];
                    char jaux = num[j];
                    char kaux = num[k];
                    if (iaux == aux)
                    {
                        if (jaux == aux)
                        {
                            if (kaux == aux)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
           
        }

        //public static int IndexOf

        public static bool AreEquals(char a, char b)
        {
            return (a == b) ? true : false;
        }

        //EJ 2
        public static int SumaNumerosPrimos(int n)
        {
            if (n <= 0)
                return 0;

            int aux = 0;
            int count = 0;

            while (count <= n)
            {
                for(int i = 0; i < n; i++)
                {
                    if (IsPrimo(i))
                    {
                        aux += i;
                        count++;
                    }
                }
            }
            return aux;

        }

        public static bool IsPrimo(int n)
        {
            if (n <= 1)
                return false;

            for (int i = 2; i <= n; i ++)
            {
                if (i % n == 0 || i % 2 != 0)
                    return true;
            }
            return false;
        }
    }
}
