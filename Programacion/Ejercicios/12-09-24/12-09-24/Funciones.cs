using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_09_24
{
    public class Funciones
    {
        public static double GetAreaRectangulo(double w, double h)
        {
            return w * h;
        }

        //perimetro de un rectangulo
        public static double GetPerimetroRectangulo(double w, double h)
        {
            return 2 * (w + h);
        }  
        //calcula area de un circulo
        public static double GetAreaCirculo(double r)
        {
            return Math.PI * (r * r);
            //return Power2(diameter / 2) * Math.PI;
            //return Power2(diameter * 0.5) * Math.PI;
        }

        //funcion que le paso un entero si ese numero es mayor que 0 me devuelve un 1, si es menor o igual un 0
        public static int GetSign(int num)
        {
            int result;
            //if (num > 0)
            //    {
            //        result = 1;
            //    }
            //else
            //result = 0;
            //return result;

            result = 0;
            if (num > 0)
            {
                result = 1;
            }
            return result;
            //return num > 0 ? 1 : 0;
        }

        //funcion que me devuelva el valor absoluto de un numero entero
        //funcion que te diga si un numero es positivo o no.

        public static int GetAbsValor(int num)
        {
            if (num >= 0)
            {
                return num;
            }
            else
            {
                return -num;
            }
        }

        public static bool IsPositive(double num)//mejor value
        {
            //if (num >= 0.0)
            //    return true;
            //return false;
            return (num >= 0.0) ? true : false;
        }

        //hacer funcion pase dos numeros enteros y devuelva el mayor
        public static int GetGreather(int num1, int num2)
        {
            if (num1 >= num2)
                return num1;
            return num2;
        }

        //funcion que devuelva el mayor de 3 enteros
        public static int GetGreatherOfThree(int num1, int num2, int num3)
        {
            return GetGreather(GetGreather(num1, num2), num3);
        }

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
