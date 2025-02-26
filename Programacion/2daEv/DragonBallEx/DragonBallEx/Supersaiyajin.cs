using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallEx
{
    class Supersaiyajin : Persona
    {
        public Supersaiyajin(string name) : base(name, RazaType.SUPERSAIYAJIN)
        {
        }

        public override void Atacar(Persona persona)
        {
            throw new NotImplementedException();
        }

        public override double GetCapacidadParada()
        {
            throw new NotImplementedException();
        }

        public override double GetEsquivaCapacidad()
        {
            throw new NotImplementedException();
        }
    }
}
