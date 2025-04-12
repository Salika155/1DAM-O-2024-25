using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallCorregido
{
    class GuerreroEspacio : Persona
    {
        public GuerreroEspacio(string name) : base(name)
        {
        }

        public override void Atacar(Persona p)
        {
            throw new NotImplementedException();
        }

        public override Raza GetRaza()
        {
            throw new NotImplementedException();
        }

        public override double ObtenerCapacidadEsquiva()
        {
            throw new NotImplementedException();
        }

        public override double ObtenerCapacidadParada()
        {
            throw new NotImplementedException();
        }
    }
}
