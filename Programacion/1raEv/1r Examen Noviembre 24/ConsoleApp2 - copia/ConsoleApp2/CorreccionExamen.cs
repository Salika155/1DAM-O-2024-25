using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class CorreccionExamen
    {
        public static bool IsInfernal(int n)
        {
            #region comentado
            //if (n == 0)
            //    return false;

            //n = Math.Abs(n);
            //int count6numbers = 0;

            //while (n > 0)
            //{
            //    if (n % 10 == 6)
            //    {
            //        count6numbers++;
            //        if (count6numbers == 3)
            //            return true;
            //    }
            //    else
            //        count6numbers = 0;
            //    n /= 10;
            //}
            //return false;
            #endregion
            if (n == 0)
                return false;

            int countNumInf = 0;
            n = Math.Abs(n);

            while (n > 0)
            {
                if (n % 10 == 6)
                {
                    countNumInf++;
                    if (countNumInf == 3)
                        return true;
                }
                else
                    countNumInf = 0;
                n /= 10; 
            }
            return false;
        }

        public static int SumaNumerosPrimos(int n)
        {
            #region comentado
            //if (n <= 0)
            //    return 0;

            //int suma = 0;
            //int count = 0;
            //int numPrimo = 2;

            //while (count < n)
            //{
            //    if (IsPrime(numPrimo))
            //    {
            //        suma += numPrimo;
            //        count++;
            //    }
            //    numPrimo++;
            //}
            //return suma;
            #endregion
            if (n <= 0)
                return 0;

            int sumaNum = 0;
            int countNum = 0;
            int PrimoNum = 2;

            while (countNum < n)
            {
                if (IsPrime(PrimoNum))
                {
                    sumaNum += PrimoNum;
                    countNum++;
                }
                PrimoNum++;
            }
            return sumaNum;
        }

        public static bool IsPrime(int n)
        {
            #region comentado
            //if (n <= 1)
            //    return false;

            //for (int i = 2; i < n; i++)
            //{
            //    if (n % i == 0)
            //        return false;
            //}
            //return true;
            #endregion
            if (n <= 1)
                return false;

            for (int i = 2; i < n; i++)
            {
                if (n % 2 == 0)
                    return false;
            }
            return true;
        }
    }
}

