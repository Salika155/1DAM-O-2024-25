using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstract
{
    public class Gato : Animal
    {
        public Gato(string? name, int edad, int velocidad) : base(name, edad, velocidad)
        {

        }

        public override void AccionDeMover()
        {
            Console.WriteLine($"El gato {Name} está dando un paseo.");
        }

        public override void AccionDeSonido()
        {
            Console.WriteLine($"El gato {Name} maulla");
        }

        public override void CorrerAnimal()
        {
            Console.WriteLine($"{Name} no corre mucho, va a " + Velocidad + 5 + " cuando recorre el callejón.");
        }
    }
}
