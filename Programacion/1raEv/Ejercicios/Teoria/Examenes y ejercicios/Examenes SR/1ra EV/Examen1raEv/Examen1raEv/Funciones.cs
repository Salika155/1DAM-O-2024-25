using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Examen1raEv
{
    public enum MachineState
    {
        PREPARADA,
        PROCESANDO,
        EJECUTANDO,
        TERMINANDO
    }
    internal class Funciones
    {

        #region Funciones
        //1. (0,5) Crea una funcion que reciba como parametro 2 enteros y devuelva un real que sea el primer
        //parametro mas 1, todo ello entre el segundo.


        public static double ex1(int a, int b)
        {
            return (a + 1.0) / b;
        }

        //2. (0,5) Crea una funcion que se le pasen 5 reales(a, b, c, d y e) mas otro real que se llama x.La
        //funcion devuelve un real representado por el siguiente polinomio:

        public static double ex2(int a, int b, int c, int d, int e, int x)
        {
            double resultado = (a * Math.Pow(x, 2)) + (b * Math.Pow(x, 3)) + (c * Math.Pow(x, 4)) + (d * x) + e;
            return resultado;
        }

        //3. (1) Crea una funcion que se le pasen 10 enteros y devuelva el menor de ellos.
        public static int ex3(int n1, int n2, int n3, int n4, int n5, int n6, int n7, int n8, int n9, int n10)
        {
            int min = n1;

            if (n2 < n1)
                min = n2;
            if (n3 < n2) min = n3;
            if (n4 < n3) min = n4;
            if (n5 < n4) min = n5;
            if (n6 < n5) min = n6;
            if (n7 < n6) min = n7;
            if (n8 < n7) min = n8;
            if (n9 < n8) min = n9;
            if (n10 < n9) min = n10;

            return min;

        }


        //4. (1) Crea una funcion que se le pasen 3 enteros(no ordenados), y devuelva la distancia maxima
        //entre el numero que tiene el valor central, con respecto al minimo y al maximo de los otros dos.
        //Por ejemplo, si se le pasa(3, 1, 7) devolvera un 4, ya que la distancia de 3 y 1 es 2 y la distancia de
        //3 y 7 es 4.
        //distancia media

        public static int Ex4(int a, int b, int c)
        {
            int min = GetMinor(a, b, c);
            int max = GetMax(a, b, c);
            int mid = a + b + c - min - max;

            int distance1 = GetDistance(mid, max);
            int distance2 = GetDistance(mid, min);

            return Math.Max(distance1, distance2);

        }

        public static int GetMinor(int a, int b, int c)
        {
            if (a < b && a < c) return a;
            if (b < c && b < a) return b;
            else return c;
        }

        public static int GetMax(int a, int b, int c)
        {
            if (a > b && a > c) return a;
            if (b > c && b > a) return b;
            else return c;
        }

        public static int GetDistance(int a, int b)
        {
            return (Math.Abs(a - b));
        }

        //5. (0,5) Crea una funcion que devuelva el numero de digitos de un numero entero.Para hacer esta
        //funcion no se pueden usar strings.
        // Por ejemplo, el numero de digitos del 154 es 3, el de 75366 es 5. Para ello, puedes ir dividiendo el
        // numero por 10 hasta que…

        public static int GetDecimals(int n)
        {
            int digitos = 1;

            while (n / 10 > 0)
            {
                n /= 10;
                digitos++;
            }
            return digitos;
        }

        //6. (1) Realiza una funcion recursiva que, dado un numero n, devuelva:
        //1² + 2² + 3² + 4² +5² … n²

        public static int Ex6(int n)
        {
            if (n == 1)
                return 1;
            else
                return (n - 1 + (n + n));
        }

        //7. (1) Crea una funcion que reciba como parametro un texto, y devuelva la posicion de la primera
        //vocal que encuentre(sea mayuscula o minuscula) y de la ultima vocal que encuentre.


        public static string GetFirstVocal(string s)
        {
            string vocales = "vFSAsdvsagtuO";
            int VocalprimeraPos = -1;
            int vocalfinalPos = -1;

            for (int i = 0; i < s.Length; i++)
            {
                if (EsVocal(s[i]))
                {
                    if (VocalprimeraPos == -1)
                    {
                        VocalprimeraPos = i;
                    }
                    vocalfinalPos = i;
                }
            }

            if (VocalprimeraPos != -1)
            {
                return $"Primera vocal en la posición: {VocalprimeraPos}, Última vocal en la posición: {vocalfinalPos}";
            }
            else
            {
                return "No hay vocales";
            }
        }

        public static bool EsVocal(char caracter)
        {
            char[] vocales = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            for (int i = 0; i < vocales.Length; i++)
            {
                if (caracter == vocales[i])
                {
                    return true;
                }
            }
            return false;
        }

        //public static bool esVocal(string s)
        //{
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        if (s[i] == 'a' || s[i] == 'e' || s[i] == 'i' || s[i] == 'o'
        //            || s[i] == 'u' || s[i] == 'A' || s[i] == 'E' || s[i] == 'I'
        //            || s[i] == 'O' || s[i] == 'U')
        //            return true;
        //    }
        //    return false;
        //}

        //    int getminvowelposition(string s)
        //    {
        //        for (int i = 0; i < s.Length - 1; i++)
        //        {
        //            (int i = 0; i < s.Length 1; i++)
        //                {

        //        }
        //        if (IsVowel(s[i]))
        //            return i;

        //    }

        //        return -1;
        //    }
        //int min = getminorvowelposition(s)
        //    int max = getminvowelposition(s)



        //8. (1) Crea una funcion que reciba como parametro un numero y devuelva la posicion de ese
        //numero dentro de los numeros primos.Si el numero no es primo, devolvera un -1.
        //Por ejemplo, sabemos que los numeros primos son: 2, 3, 5, 7, 11, 13, … Si a esta funcion se le pasa
        //un 7 devolvera un 4, ya que 7 es el cuarto numero primo.Si a esta funcion se le pasa un 6,
        //devolvera un -1, ya que este no es primo.

        public static int GetPrimoPosition(int n)
        {
            if (n < 2)
                return -1;

            int position = 1;
            int numero = 2;

            while (position < n)
            {
                numero++;

                if (isprime(numero))
                {
                    position++;
                }
            }
            return numero;
        }


        public static bool isprime(int number)
        {
            for (int i = 2; i <= number; i++)
            {
                if ((number % i) == 0)
                    return false;
            }
            return true;
        }


        //public static int getprimeposiition(int n)
        //{
        //    //internal cont = 0;

        //    //if (isprimer(n) == false)
        //    //{

        //    //    return -1;


        //    //    for (int i = 2; i <= n; i++)
        //    //    {        
        //    //        if (isprime(i))
        //    //        cont++;
        //    //    }
        //    //}
        //    //return Cont;
        //}




        //9. (1) Haz una funcion que se le pasen como parametros un enum y un booleano.El enum es el
        //estado de una maquina (PREPARADA, PROCESANDO, EJECUTANDO, TERMINANDO). Si el
        //booleano que se le pasa es false, devolvera justamente el enum que se le pasa como parametro, si es
        //true, devolvera el siguiente estado de la maquina.
        //Por ejemplo, si se le pasa PROCESANDO y un true, devolvera EJECUTANDO. Si se le pasa
        //TERMINANDO y un false, devolvera TERMINANDO.

        public static MachineState GetMachineState(MachineState estado, bool funcionando)
        {
            if (!funcionando)
            {
                return estado;
            }

            if (estado == MachineState.PREPARADA) 
            {
                return MachineState.PROCESANDO;
            }
            if (estado == MachineState.PROCESANDO)
            {
                return MachineState.EJECUTANDO;
            }
            if (estado == MachineState.EJECUTANDO)
            {
                return MachineState.TERMINANDO;
            }
            if (estado == MachineState.TERMINANDO) 
            {
                return MachineState.PREPARADA;
            }
            return estado;
        }

        
        //10. (1) Crea una funcion que se le pase un numero y devuelva la suma de todos sus divisores desde
        //1 hasta ese numero(sin contar ese numero)

        public static int GetSumaDivisoresNumero(int numero)
        {
            int result = 0;

            for (int i = 1; i <= numero; i++)
            {
                if (numero % i == 0)
                {
                    result += i;
                } 

            }
            return result;
        }


        //    int sumdivisors(int n)
        //    {
        //    int result = 0;

        //    for (int i = 1; i < n; i++)
        //        {
        //        if (n % i == 0)
        //            result += i;
        //        }

        //    return result;
        //    }


        //public static double getmax(double a, double b, double c, double d, double e, 
        //    double Xmin, double Xmax, double dt)

        //{

        //    double result = Ej2(a, b, c, d, e, xmin);   //double.minvalue

        //    for (double x = Xmin; x <= Xmax; x += dt)
        //    {
        //        double value = ejercicio2(a, b, c, d, e, x);
        //        if (Value > result)
        //            result = Value;
        //    }
        //    return result;
        //}


        //11. (1.5) Crea una funcion que reciba como parametros los siguientes datos:
        //a.Los coeficientes a, b, c, d, y e de un polinomio del tipo
        //a.x⁴ + b.x³ + c.x² + d.x¹ + e
        //b. Un intervalo de muestreo xmin, xmax
        //c. Un periodo de muestreo de Lambda x = 0,1
        //d.La funcion debe devolver el valor maximo que toma ese polinomio en el intervalo dado y dado el
        //tamaño del sampler.

        public static double CalculatePolinomio(double a, double b, double c, double d, double e, double x)
        {
            return a + Math.Pow(x, 4) + b * Math.Pow(x, 3) + c * Math.Pow(x, 2) + d * Math.Pow(x, 1) + e;
        }

        public static double FindMaxValue(double a, double b, double c, double d, double e,
            double xmin, double xmax, double lambda)
        {
            double valorMax = 0;

            for (double x = xmin; x <= xmax; x += lambda)
            {
                double valoractual = CalculatePolinomio(a, b, c, d, e, x);
                if (valoractual > valorMax)
                    valorMax= valoractual;
            }
            return valorMax;
        }
        #endregion
    }
}

    

