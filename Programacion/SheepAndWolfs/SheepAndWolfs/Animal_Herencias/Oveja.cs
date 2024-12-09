using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SheepAndWolfs
{
    //TODO: esto funciona
    public class Oveja : Animal
    {
        public Oveja(int food, int water, int stamina, int sleep, AnimalType type, string name, int velocidad) : base(food, water, stamina, sleep, AnimalType.OVEJA, name, velocidad)
        {
            
        }

        //si los metodos vienen de la clase padre animal, habra que sobreescribirlos aqui.
        public override int GetVelocidad()
        {
            return base.GetVelocidad() - 2;  // las ovejas tienen 2 menos de velocidad.
        }

        // Seria para hacer un movimiento diferente por clases, pero no termino de ver como aplicarlo.
        public override void Mover()
        {
            Console.WriteLine($"{GetNombre()} la oveja se mueve a una velocidad de {GetVelocidad()}.");
        }
    }
}
