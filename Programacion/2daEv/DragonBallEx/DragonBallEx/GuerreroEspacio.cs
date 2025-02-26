using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallEx
{
    class GuerreroEspacio : Persona
    {
        private double _ataqueConRayo;
        private double _ataqueConGolpes;
        private double _capacidadDeEsquivar;
        private double _capacidadDeParar;

//○ Ataque con rayo → Es un real entre 0.3 y 0.6
//○ Ataque con golpes → Es un real entre 0.1 y 0.8
//○ Capacidad de esquivar → Es un real entre 0.2 y 0.4
//○ Capacidad de parar → Es un real entre 0.4 y 0.9
        public GuerreroEspacio(string name) : base(name, RazaType.GUEREROESPACIO)
        {
            _ataqueConRayo = Utils.GetRandom(0.3, 0.6);
            _ataqueConGolpes = Utils.GetRandom(0.1, 0.8);
            _capacidadDeEsquivar = Utils.GetRandom(0.2, 0.4);
            _capacidadDeParar = Utils.GetRandom(0.4, 0.9);
        }

        public override void Atacar(Persona persona)
        {
            throw new NotImplementedException();
        }

        public override double GetCapacidadParada()
        {
            return _capacidadDeParar;
        }

        public override double GetEsquivaCapacidad()
        {
            return _capacidadDeEsquivar;
        }
    }
}
