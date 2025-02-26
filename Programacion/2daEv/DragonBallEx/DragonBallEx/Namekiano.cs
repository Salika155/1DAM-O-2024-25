using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallEx
{
    class Namekiano : Persona
    {
        public Namekiano(string name) : base(name, RazaType.NAMEKIANO)
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
