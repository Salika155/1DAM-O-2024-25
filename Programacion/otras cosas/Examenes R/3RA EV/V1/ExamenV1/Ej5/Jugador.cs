using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{
    abstract class Jugador
    {
        private string _name;
        private Dado dado;

        public Jugador(string name, Dado dado)
        {
            _name = name;
            this.dado = dado;
        }

    }
}
