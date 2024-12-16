using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstract
{
    public abstract class Animal
    {
        private string? _name;
        private int _edad;
        private int _velocidad;

        public string? Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public int Edad
        {
            get
            {
                return _edad;
            }
            set
            {
                _edad = value;
            }
        }

        public int Velocidad
        {
            get
            {
                return _velocidad;
            }
            set
            {
                _velocidad = value;
            }
        }

        public Animal(string? name, int edad, int velocidad)
        {
            Name = name;
            Edad = edad;
            Velocidad = velocidad;
        }

        public abstract void AccionDeSonido();
        public abstract void AccionDeMover();
        public void Comer()
        {
            Console.WriteLine("El animal ${Name} esta comiendo");
        }

        // Método virtual (puede ser sobrescrito por las clases derivadas)
        public virtual void CorrerAnimal()
        {
            Console.WriteLine($"El animal {Name} está corriendo a una velocidad de {Velocidad} km/h.");
        }


    }
}
