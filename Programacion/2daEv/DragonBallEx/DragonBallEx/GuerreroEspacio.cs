using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallEx
{
    class GuerreroEspacio : Persona
    {
        public GuerreroEspacio(string name, RazaType raza, double energia, double deseoEsquivar) : base(name, raza, energia, deseoEsquivar)
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
