using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallEx
{
    class Utils
    {
        private static Random _r = new Random();
        //GetRandom(min: double, max: double) : double → Devuelve un número aleatorio
        //entre el mínimo y el máximo que se le pasan.
        public static double GetRandom(double min, double max)
        {
            if (min >= max)
                throw new Exception("No puede ser menor o mayor a los limites");
            return min + (_r.NextDouble() * (max - min));
        }
    }
}
