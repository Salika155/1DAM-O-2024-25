using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoExamen
{
    public class Practica
    {
        //Escribir una función que calcule el área de un círculo y otra que calcule el volumen de un cilindro
        //usando la primera función.
        public static double GetAreaCirculo(double r)
        {
            double r2 = r * r;
            double pi = Math.PI;
            double result = pi * r2;
            return result;
        }

        //(obligatorio) Realiza una función que se le pase dos jugadas de “Piedra, papel, tijera, lagarto o
        //Spock” y devuelva quién gana de los dos.Si gana el primer jugador, devuelve un -1, si gana el
        //segundo devuelve un 1, si quedan empates, un 0. Se tiene que usar un enum.

        //Desarrolla una función que devuelva el resultado de una ecuación de primer grado.

        //(obligatorio) Desarrolla una función que devuelva el resultado de una ecuación de segundo grado.

        //Los tres lados a, b y c de un triángulo deben satisfacer la desigualdad triangular: cada uno de los
        //lados no puede ser más largo que la suma de los otros dos.Escribe un programa que reciba como
        //entrada los tres lados de un triángulo (son reales), e indique: si acaso el triángulo es inválido; y si
        //no lo es, qué tipo de triángulo es(un enum).

        //Escribir una función que calcule el máximo común divisor de dos números.

        //Escribir una función que calcule el mínimo común múltiplo de dos números.

        //Escriba un programa que devuelva un string con los números naturales menores o iguales que un
        //número n determinado y que no sean múltiplos ni de 3 ni de 7.

        //(obligatorio) Escriba un programa que devuelva un string con todas las combinaciones posibles
        //al momento de lanzar tres dados de 6 caras. (1, 1, 1) (1, 1, 2) (1, 1, 3), …

        //Escribe una función que se le pase un número y devuelve un string con ese mismo número
        //separado por guiones.Por ejemplo 234 → “2-3-4”

        //(obligatorio) Es posible expresar 100 como la suma de tres cubos, cada uno de los cuales puede
        //ser negativo o positivo. Sólo se conocen tres maneras de hacerlo.Una de ellas es la siguiente: 1870^3 − 1797^3 − 903^3 = 100
        //Desarrolla un programa que busque las 1870 otras combinaciones para llegar al 100.

        //(obligatorio) Multiplicación rusa.El método de multiplicación rusa consiste en multiplicar
        //sucesivamente por 2 el multiplicando y dividir por 2 el multiplicador hasta que el multiplicador tome
        //el valor 1. Luego, se suman todos los multiplicandos correspondientes a los multiplicadores impares.
        //Dicha suma es el producto de los dos números. La siguiente tabla muestra el cálculo realizado
        //para multiplicar 37 por 12, cuyo resultado final es 12 + 48 + 384 = 444.

        //Crea una función, que reciba como parámetro un texto y lo escriba centrado en pantalla
        //(suponiendo una anchura de 80 columnas; pista: deberás escribir 40 - longitud/2 espacios antes
        //del texto). Además subraya el mensaje utilizando el carácter =.

        //(obligatorio) Crea una función que quite los espacios por delante y por detrás de un string. Se
        //considera un espacio: un espacio, un tabulador, un salto de línea y retorno de carro.La función
        //recibe un string y dos booleanos.

        //(obligatorio) Crea un programa que calcula una aproximación de PI mediante la expresión:
        //pi/4 = 1/1 - 1/3 + 1/5 - 1/7 + 1/9 - 1/11 + 1/13 (...) A esta función se le pasará un entero con el
        //número de iteraciones a realizar.Por ejemplo, si se le pasa un 4, el programa calculará:
        //p = 4 * (1/1 - 1/3 + 1/5 - 1/7)

        //Escribir una función que reciba un número entero positivo y devuelva su factorial.Hay que hacer
        //esta función de 2 formas, una iterativa y otra recursiva.

        //Escribir una función que reciba un número entero positivo y devuelva su sumatorio.Hay que hacer
        //esta función de 2 formas, una iterativa y otra recursiva.

        //(obligatorio) Según Sheldon, el mejor número es el 73.
        //73 es el 21er número primo.Su espejo, 37, es el 12mo número primo. 21 es el producto de
        //multiplicar 7 por 3. En binario, 73 es un palíndromo: 1001001.

        //Escriba programas que le permitan responder las siguientes preguntas:
        //¿Existen otros valores p que sean el n-ésimo primo, tales que espejo(p) es el espejo(n)-ésimo primo?
        //¿Existen otros valores p que sean el n-ésimo primo, tales que n es el producto de los dígitos de p?
        //¿Cuáles son los primeros diez números primos cuya representación binaria es un palíndromo?
    }
}
