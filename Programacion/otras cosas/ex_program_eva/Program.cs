using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace ex_program_eva
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("El área del círculo es = ");
            Console.WriteLine(Exercises_ex.GetAreaCirc(1));
            Console.WriteLine("El volumen del cilindro es = ");
            Console.WriteLine(Exercises_ex.GetCylindreVolume(2, 4));


            Console.WriteLine("El resultado de la jugada es ");
            Console.WriteLine(Exercises_ex.GetResultGame(PlayType.PAPER, PlayType.PAPER));

            Console.WriteLine("X vale = ");
            Console.WriteLine(Exercises_ex.EcuationSolution(20, 5));

            Console.WriteLine("Los resultados de la ecuación de 2º grado son = ");
            Console.WriteLine(Exercises_ex.EcuationSolution2Grade(2, 2, 4));

            Console.WriteLine("El triangulo es ");
            Console.WriteLine(Exercises_ex.TriangleType(106, 106, 106));

            Console.WriteLine("El máximo común divisor de los dos números es ");
            Console.WriteLine(Exercises_ex.GetMCD(16, 212));


            Console.WriteLine("El mínimo común multiplo de los dos números es ");
            Console.WriteLine(Exercises_ex.GetMCM(20, 15));

            string result3dices = Exercises_ex.SixFacesDice(1, 1, 1);
            Console.WriteLine("Todas la combinaciones de tiradas de dados:");
            Console.WriteLine(result3dices);

            string resultnatnum = Exercises_ex.GetNatNum(15);
            Console.WriteLine("Numeros naturales menores o iguales que n que no sean multiplos de 3 y 7:");
            Console.WriteLine(resultnatnum);

            Console.WriteLine("Multiplicación rusa:");
            Console.WriteLine(Exercises_ex.RussMultiply(51, 15));

            Console.WriteLine("El factorial del numero pasado es ");
            Console.WriteLine(Exercises_ex.GetFactorial(5));

            Console.WriteLine("El factorial en recursiva del numero pasado es ");
            Console.WriteLine(Exercises_ex.GetFactorialRecursive(5));

            Console.WriteLine("El sumatorio del numero pasado es ");
            Console.WriteLine(Exercises_ex.GetSum(5));

            Console.WriteLine("El sumatorio en recursiva del numero pasado es ");
            Console.WriteLine(Exercises_ex.GetSumatoryRec(5));

            //Console.WriteLine("Hola me llamo Carlos");
            //Console.WriteLine(Exercises_ex.QuitSpaces(char));

            Console.WriteLine("Las combinaciones del cubo para llegar al 100:");
            Console.WriteLine(Exercises_ex.GetCubeCombination());

            Console.WriteLine("El factorial del numero es ");
            Console.WriteLine(Exercises_ex.GetFactorial(5));

            



        }

    }
}        