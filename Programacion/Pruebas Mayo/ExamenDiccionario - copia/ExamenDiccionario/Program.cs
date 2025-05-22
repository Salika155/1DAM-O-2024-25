using System;

namespace ExamenDiccionario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            ExDictionary<int, string> dic = new();
            dic.Add(1, "Uno");
            dic.Add(4, "Cuatro");
            dic.Add(2, "Dos");
            dic.Add(1, "UnoUno");

            Console.WriteLine(dic);
            {
                string val;
                if (dic.TryGetValue(1, out val))
                    Console.WriteLine($"El valor 1 existe y vale {val}");
                else
                    Console.WriteLine($"El valor 1 existe y vale {val}");
            }

            {
                string val;
                if (dic.TryGetValue(1, out var val))
                    Console.WriteLine($"El valor 1 existe y vale {val}");
                else
                    Console.WriteLine($"El valor 1 existe y vale {val}");
            }

            dic.ForEach((k, v) => Console.WriteLine($"Console"));
        }
    }
}
