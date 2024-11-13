using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepAndWolfs
{
    public class Animal
    {
        public readonly string? Nombre = "";
        public int Vida;

        public Animal(string name, int n)
        {
            Nombre = name;
            Vida = n;
        }
    }
}
