using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    internal class Class1
    {
        private List<Animal> _animalList = new();

        public bool ContainsWolf(string name)
        {
            foreach (Animal animal in _animalList)
            {
                if (animal.Name == name && animal is Lobo)
                    return true;
            }
            return false;
        }

        public bool ContainsWolfWithHowl(double value)
        {
            foreach (Animal animal in _animalList)
            {
                if (animal is Lobo lobo && lobo.PotenciaAullido == value)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
