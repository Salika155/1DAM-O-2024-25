using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallCorregido
{
    public class Humano : Persona
    {
        private double _ataqueGolpe;
        private double _capacidadEsquiva;
        private double _capacidadParar;

        public Humano(string name) : base(name)
        {
        }

        public override void Atacar(Persona p)
        {
            QuitarEnergia(1);
            if (Utils.GetRandom() < _ataqueGolpe)
            {
                bool quiereEsquivar = p.QuiereEsquivar();
                if (quiereEsquivar)
                {
                    if (Utils.GetRandom() > p.ObtenerCapacidadEsquiva())
                        p.QuitarEnergia(5);
                }
                else
                {
                    if (Utils.GetRandom() < p.ObtenerCapacidadEsquiva())
                        p.QuitarEnergia(0.5);
                    else
                        p.QuitarEnergia(5);
                }
            }
        }

        public override Raza GetRaza()
        {
            return Raza.Persona;
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
