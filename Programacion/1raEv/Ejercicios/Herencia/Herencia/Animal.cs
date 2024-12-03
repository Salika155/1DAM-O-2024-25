using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    public class Animal
    {
        public string Name;
        public int Age;
        public double Life;
        private int _hungry;
        protected readonly List<Animal> _children = new();
        //protected => variables que solo puedo ver yo animal, o las clases que hereden de animal

        public Animal(string name)
        {
            Name = name;
        }

        //cualquiera de mis clases hijas puede sobreescribirla y ser de otra manera
        public virtual void ExecuteTurn()
        {

        }
    }

    public class Lobo : Animal
    {
        public double PotenciaAullido;

        public Lobo(string name) : base(name)
        {
        }

        public int GetChildCount()
        {
            return _children.Count;
        }

        public override void EjecutarTurno()
        {
            foreach (Animal animal in _animalList)
            {
                animal.ExecuteTurn();
            }
        }

    }

    public class World
    {
        public void EjecutarTurno()
        {
            foreach (Animal animal in _animalList)
            {
                animal.ExecuteTurn();
            }
        }
    }

    public class Oveja : Animal
    {
        public Oveja(string name) : base(name)
        {
        }
    }
}
