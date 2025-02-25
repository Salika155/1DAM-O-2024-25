using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallEx
{
    class Humano : Persona
    {
        private double _ataqueConGolpes;
        private double _capacidadDeEsquivar;
        private double _capacidadDeParar;

        //getters

        public Humano(string name, RazaType raza, double energia, double deseoEsquivar, double ataqueConGolpes, double capacidadDeEsquivar, double capacidadDeParar) : base(name, raza, energia, deseoEsquivar)
        {
            _ataqueConGolpes = Utils.GetRandom(0.1, 0.8);
            _capacidadDeEsquivar = Utils.GetRandom(0.4, 0.6);
            _capacidadDeParar = Utils.GetRandom(0.7, 0.9);
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
