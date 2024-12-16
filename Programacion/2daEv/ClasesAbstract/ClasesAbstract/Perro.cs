using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstract
{
    public class Perro : Animal
    {
        public Perro(string? name, int edad, int velocidad) : base(name, edad, velocidad)
        {

        }

        public override void AccionDeMover()
        {
            Console.WriteLine($"El perro {Name} está dando un paseo.");
        }

        public override void AccionDeSonido()
        {
            Console.WriteLine($"El perro {Name} ladra");
        }

        public override void CorrerAnimal()
        {
            Console.WriteLine($"{Name} corre rápidamente a " + Velocidad + 5 + " cuando recoge el palo.");
        }
    }
}
