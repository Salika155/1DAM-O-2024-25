using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExDragonBallBienHecho
{
    class Utils
    {
        Random r = new Random();

        public static int GetRandom(int a, int b)
        {
            return a * b;
        }

        internal static double GetRandomDouble(double v1, double v2)
        {
            throw new NotImplementedException();
        }
    }
}
