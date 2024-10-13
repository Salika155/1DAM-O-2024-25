using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    internal class FuncEj2
    {
        public static List<int> ParesQueSuman(List<int> list, int n)
        {
            if (list == null || list.Count < 0)
                throw new Exception("list no puede ser nulo o menor de 0");

            List<int> suman = new List<int>();

            //foreach (int i in list)
            //{
            //    if (list[i] + list[i + 1] == n)
            //        suman.Add(i);
            //        suman.Add(i + 1);
            //}
            //return suman;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] + list[i + 1] == n)
                {
                    suman.Add(i);
                    suman.Add(i + 1);
                } 
            }
            return suman;
        }

        public static List<int> SumarElementos(List<int> list, int n) 
        {
            if (list == null || list.Count < 0)
                throw new Exception("list no puede ser nulo o menor de 0");

            List<int> suman = new List<int>();

            for (int i = 0; i < list.Count; i++) 
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    int aux = list[i] + list[j];
                    if (aux == n)
                    {
                        suman.Add(i);
                        suman.Add(j);
                    }
                }
            }
            return suman;
        }
    }
}
