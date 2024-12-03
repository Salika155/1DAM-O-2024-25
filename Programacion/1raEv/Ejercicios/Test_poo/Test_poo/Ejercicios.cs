using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_poo
{
    internal class Ejercicios
    {
        //funcion interpolacion Lerp

        public static double GetInterpolacionLineal(double a, double b, double u)
        {
            double part2 = a * (1 - u);
            double part1 = b * u;
            double interpolation = part1 + part2;

            return interpolation;
        }

        //calcula la saturacion con respecto a dos numeros
        //si el valor es menor a los limites inferiores o superiores que lo ajuste al mas cercano
        public static double GetSaturate(double limInf, double limSup, double value)
        {
            if (value < limInf)
                value = limInf;
            else if (value > limSup)
                value = limSup;
            return value;
        }

        //Lerp
        public static Colour Lerp(Colour c1, Colour c2, double u)
        {
            Colour color = new();

            if (c1 == null || c2 == null)
                return color;

            color.r = GetInterpolacionLineal(c1.r, c2.r, u);
            color.g = GetInterpolacionLineal(c1.g, c2.g, u);
            color.b = GetInterpolacionLineal(c1.b, c2.b, u);
            color.a = GetInterpolacionLineal(c1.a, c2.a, u);

            return color;

        }

        public static void PrintColours(Colour colour)
        {
            Console.WriteLine(colour.r);
            Console.WriteLine(colour.g);
            Console.WriteLine(colour.b);
            Console.WriteLine(colour.a);
        }

        //le paso dos vectores2d (tiene dos elementos double x e y) y me calcula la interpolacion lineal de esos dos vectores
        //
        public static Vector2D Lerp(Vector2D c1, Vector2D c2, double u)
        {
            //if ()
            Vector2D result = new();

            if (c1 == null || c2 == null)
                return result;

            result.x = GetInterpolacionLineal(c1.x, c2.x, u);
            result.y = GetInterpolacionLineal(c1.x, c2.y, u);

            return result;
        }

        //funcion que le paso un vector2d y me devuelve su modulo (lo que mide) -> hipotenusa = raizacuadrada cateto^2 + cateto^2
        public static double GetModule(Vector2D v1)
        {
            //comprobar que no de null
            if (v1 == null)
                return 0.0;

            double modX = v1.x * v1.x;
            double modY = v1.y * v1.y;
            double modS = modX + modY;
            double mod = Math.Sqrt(modS);

            return mod;
        }

        
    }
}
