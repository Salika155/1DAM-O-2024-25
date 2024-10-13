using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ex_program_eva
{
    public enum PlayType
    {
        ROCK,
        PAPER,
        SCISSORS,
        LIZARD,
        SPOCK,
    }

    public enum TriangleSIdes
    {
        EQUILATERAL,
        ISOSCELES,
        SCALENE,
        INVALID,
    }

    public class Exercises_ex
    {
        //Escribir una función que calcule el área de un círculo y otra que calcule el volumen de un
        //cilindro usando la primera función.
        // Nota: 4
        public static double GetAreaCirc(double radius)
        {
            return Math.PI * (radius * radius);
        }

        public static double GetCylindreVolume(double radius, double height)
        {
            return GetAreaCirc(radius) * height;
        }

        //(obligatorio) Realiza una función que se le pase dos jugadas de “Piedra, papel, tijera,
        //lagarto o Spock” y devuelva quién gana de los dos.Si gana el primer jugador, devuelve
        //un -1, si gana el segundo devuelve un 1, si quedan empates, un 0. Se tiene que usar un enum.
        // Nota: 4

        public static int GetResultGame(PlayType play1, PlayType play2)
        {
            
            if (play1 == PlayType.PAPER)
            {
                if (play2 == PlayType.ROCK || play2 == PlayType.SPOCK)
                    return 1;
                if (play2 == PlayType.SCISSORS || play2 == PlayType.LIZARD)
                    return -1;
                else if (play2 == PlayType.PAPER)
                    return 0;
            }
            if (play1 == PlayType.ROCK)
            {
                if (play2 == PlayType.LIZARD || play2 == PlayType.SCISSORS)
                    return 1;
                if (play2 == PlayType.SPOCK || play2 == PlayType.PAPER)
                    return -1;
                else if (play2 == PlayType.ROCK)
                    return 0;
            }
            if (play1 == PlayType.LIZARD)
            {
                if (play2 == PlayType.ROCK || play2 == PlayType.SCISSORS)
                    return -1;
                if (play2 == PlayType.SPOCK || play2 == PlayType.PAPER)
                    return 1;
                else if (play2 == PlayType.LIZARD)
                    return 0;
            }
            if (play1 == PlayType.SPOCK)
            {
                if (play2 == PlayType.LIZARD || play2 == PlayType.PAPER)
                    return -1;
                if (play2 == PlayType.ROCK || play2 == PlayType.SCISSORS)
                    return 1;
                else if (play2 == PlayType.SPOCK)
                    return 0;
            }
            if (play1 == PlayType.SCISSORS)
            {
                if (play2 == PlayType.SPOCK || play2 == PlayType.ROCK)
                    return -1;
                if (play2 == PlayType.LIZARD || play2 == PlayType.PAPER)
                    return 1;
                else if (play2 == PlayType.SCISSORS)
                    return 0;
            }
            return 1;
        }

        //Desarrolla una función que devuelva el resultado de una ecuación de primer grado.
        // Nota: 2, hay que comprobar que la a no sea cero
        public static double EcuationSolution(double a, double b)
        //ax + b = 0
        //ax = 0 - b
        //x = - b / a
        {
            double ecuation1 = (- b / a);
            return ecuation1;
        }


        //(obligatorio) Desarrolla una función que devuelva el resultado de una ecuación
        //de segundo grado.

        /*(-b +- (Square (b * b) - 4(a * c)/(2 * a)
         */
        // Nota: 0, está mal, tanto a nivel de comprobar posibles problemas como la resolución
        public static (double, double) EcuationSolution2Grade(double a, double b, double c)
        {
            double ecuation2 = (b * b) - (4 * (a * c) / (2 * a));
            if (ecuation2 == 0) 
                return (double.NaN, double.NaN);

            double square = Math.Sqrt(ecuation2);

            double positivEcuation = -b + (ecuation2);

            double negativEcuation = -b - (ecuation2);

            return (positivEcuation, negativEcuation);
        }

        //Los tres lados a, b y c de un triángulo deben satisfacer la desigualdad triangular: cada
        //uno de los lados no puede ser más largo que la suma de los otros dos.Escribe un programa
        //que reciba como entrada los tres lados de un triángulo(son reales), e indique: si acaso
        //el triángulo es inválido; y si no lo es, qué tipo de triángulo es(un enum).

        /* public static double TriangleType(double a, double b, double c)
         {
        ((a * a) = (b * b) + (c * c)) equilatero = (a = b = c), isosceles = (a = b) || (a = c) || (b = c), escaleno = ( a != b) || (b != c) || (a != c)
         }
        */

        // Nota: 1, no se hace con un while
        public static TriangleSIdes TriangleType(double a, double b, double c)
        {
            while (a + b > c && b + c > a && c + a > b)
            {  
             if ((a == b) && (c == a))
                 return TriangleSIdes.EQUILATERAL;

             else if ((a != b) && (b != c) && (c != a))
                 return TriangleSIdes.SCALENE;
                
                else 
                    return TriangleSIdes.ISOSCELES;
            }
               
            return TriangleSIdes.INVALID;
        }

        //Escribir una función que calcule el máximo común divisor de dos números.
        // Nota: 4
        public static int GetMCD(int a, int b)
        {
            int n = 0;

            for (int i = 1; i <= a; i++)
            {
                if ((a % i == 0) && (b % i == 0))
                    n = i;
            }
            return n;
        }

        //Escribir una función que calcule el mínimo común múltiplo de dos números.
        // Nota: 2, no hace lo que debe, no creo que la hayas probado
            public static int GetMCM(int a, int b)
            {
                int max;
                
                if (a > b)
                {
                    max = a;
                }
                else
                {
                    max = b;
                }

                for (int i = 2; i <= max; i++)
                {
                    if (i % a == 0 && i % b == 0)
                        return i;
                }
                return 1;
            }



                //Escriba un programa que devuelva un string con los números naturales menores o
                //iguales que un número n determinado y que no sean múltiplos ni de 3 ni de 7.
        // Nota: 4
       public static string GetNatNum(int num)
            //resultado del string para un for
            //luego si el resto de la division entre 3 y 7 del num es diferente de 0 devuelve string + num
       {
            string result = "";

            for (int i = 1; i <= num; i++)
            {
                if ((i % 3 != 0) && (i % 7 != 0))
                    result += i + ",";
                continue;
            }
            return result;
       }

        //(obligatorio) Escriba un programa que devuelva un string con todas las combinaciones
        //posibles al momento de lanzar tres dados de 6 caras. (1, 1, 1) (1, 1, 2)
        //(1, 1, 3), …

        //for para un dado con sus + caras, luego dentro de otro for con lo mismo y otro for para lo mismo
        //al final el result es la suma de todos esas posibilidades dentro del string resurlt "("posibilidades sumadas")"
        // Nota: 4
        public static string SixFacesDice(int a, int b, int c)
        {
            string result = "";
            for (int i= 1; i <= 6; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    for (int k = 1; k <= 6; k++)
                    {
                        result += "(" + i + "," + j + "," + k + ") ";
                    }
                }
            }
            return result;
        }


        //Escribe una función que se le pase un número y devuelve un string con ese mismo
        //número separado por guiones.Por ejemplo 234 → “2-3-4”

        //variable de string = "" + variable;

        //convertir numero a string separado por guiones




        //(obligatorio) Es posible expresar 100 como la suma de tres cubos, cada uno de
        //los cuales puede ser negativo o positivo.Sólo se conocen tres maneras de hacerlo.
        //Una de ellas es la siguiente: . Desarrolla un programa que busque las 1870 otras
        //combinaciones 3 − 1797 3 − 903 3 = 100 para llegar al 100.
        // Nota: 4
        public static string GetCubeCombination()
        {
            string result = "";
            for (double n = -10000; n <= 10000; n++)
            {
                for (double o = -10000; o <= 10000; o++)
                {
                    for (double p = -10000; p <= 10000; p++)
                    {
                        if ((n * n * n) + (o * o * o) + (p * p * p) == 100)
                        {
                            result += "(" + n + "," + o + "," + p + ") = 100";
                        }
                    }
                }
            }
            return result;
        }


        //(obligatorio) Multiplicación rusa. El método de multiplicación rusa consiste en
        //multiplicar sucesivamente por 2 el multiplicando y dividir por 2 el multiplicador
        //hasta que el multiplicador tome el valor 1. Luego, se suman todos los multiplicandos
        //correspondientes a los multiplicadores impares.
        //Dicha suma es el producto de los dos números.La siguiente tabla muestra el cálculo
        //realizado para multiplicar 37 por 12, cuyo resultado final es 12 + 48 + 384 = 444.
        // Nota: 2, esta función no debe devolver un string
        public static string RussMultiply(int a, int b)

        //multiplicador = a
        //multiplicando = b
        {
            int result = 0;
            string calculate = "";

            while (b >= 1)
            {
                if (calculate == "")
                {
                    calculate += a;
                    result += a;
                }
                else if (calculate != "" && b % 2 != 0)
                {
                    calculate += " + " + a;
                    result += a;
                }
                    
                a *= 2;
                b /= 2;
            }
            return calculate + " = " + result;

        }


        //Crea una función, que reciba como parámetro un texto y lo escriba centrado en pantalla
        //(suponiendo una anchura de 80 columnas; pista: deberás escribir 40 - longitud/2 espacios
        //antes del texto). Además subraya el mensaje utilizando el carácter =.



        //(obligatorio) Crea una función que quite los espacios por delante y por detrás de un string.
        //Se considera un espacio: un espacio, un tabulador, un salto de línea y retorno de carro.
        //La función recibe un string y dos booleanos.

        public static bool charsToTrim(char specialspace)
        {
            return specialspace == ' ' || specialspace== '\r' || specialspace == '\n' || specialspace == ' ';
        }

        
        
        


        //(obligatorio) Crea un programa que calcula una aproximación de PI mediante
        //la expresión: pi/4 = 1/1 - 1/3 + 1/5 - 1/7 + 1/9 - 1/11 + 1/13 (...)
        //A esta función se le pasará un entero con el número de iteraciones a realizar.
        //Por ejemplo, si se le pasa un 4, el programa calculará: p = 4 * (1/1 - 1/3 + 1/5 - 1/7)



        //Escribir una función que reciba un número entero positivo y devuelva su factorial.
        //Hay que hacer esta función de 2 formas, una iterativa y otra recursiva.
        // Nota: 4
         public static int GetFactorial(int n)
        {
            int result = 1;

            for (int i = n; i >= 1; i--)
            {
                result *= i;
            }
            return result;
        }

        public static int GetFactorialRecursive(int n)
        {
            if (n == 1)
                return 1;
            else
                return n * GetFactorialRecursive( n - 1 );
        }


        //Escribir una función que reciba un número entero positivo y devuelva su sumatorio.
        //Hay que hacer esta función de 2 formas, una iterativa y otra recursiva.

        // Nota: 4
        public static int GetSum(int n)
        {
            int number = 0;
            for (int i = 1; i <= n; i++)
            {
                number += i;
            }
            return number;
        }

        public static int GetSumatoryRec(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1) // No hace falta
                return 1;
            return n + GetSum(n - 1);
        }



        /*(obligatorio) Según Sheldon, el mejor número es el 73.
        73 es el 21er número primo.Su espejo, 37, es el 12mo número primo. 21 es el producto de 
        multiplicar 7 por 3. En binario, 73 es un palíndromo: 1001001.
        Escriba programas que le permitan responder las siguientes preguntas:
        ¿Existen otros valores p que sean el n-ésimo primo, tales que espejo(p) es el espejo(n)-ésimo 
        primo?
        ¿Existen otros valores p que sean el n-ésimo primo, tales que n es el producto de los dígitos 
        de p?
        ¿Cuáles son los primeros diez números primos cuya representación binaria es un palíndromo?*/




    }
}
