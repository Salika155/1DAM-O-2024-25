using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExDragonBall
{
    internal class GuerreroEspacio : Persona
    {
        private double _ataqueRayo;
        private double _ataqueGolpe;
        private double _capacidadEsquivar;
        private double _capacidadParar;

        public double AtaqueRayo
        {
            get => _ataqueRayo;
            set => Utils.GetRandomDouble(0.3, 0.6);
        }

        public double AtaqueGolpe
        {
            get => _ataqueGolpe;
            set => Utils.GetRandomDouble(0.1, 0.8);
        }

        public double CapacidadEsquivar
        {
            get => _capacidadEsquivar;
            set => _capacidadEsquivar = value;
        }

        public double CapacidadParar
        {
            get => _capacidadParar;
            set => _capacidadParar = value;
        }

        public GuerreroEspacio(double energia, double deseoEsquivar, double ataqueRayo, double ataqueGolpe, double capacidadEsquivar, double capacidadParar) : base("GuerreroEspacial", energia, deseoEsquivar, RazaType.GUERREROESPACIO)
        {
            _ataqueRayo = ataqueRayo;
            _ataqueGolpe =ataqueGolpe;
            _capacidadEsquivar =capacidadEsquivar;
            _capacidadParar =capacidadParar;
        }

        public override void Atacar(Persona p)
        {
            var ataque = DecidirAtaque();

            switch(ataque)
            {
                
            }
        }

        public override double ObtenerCapacidadEsquiva()
        {
            return _capacidadEsquivar = Utils.GetRandomDouble(0.2, 0.4);
        }

        public override double ObtenerCapacidadParada()
        {
            return _capacidadParar = Utils.GetRandomDouble(0.4, 0.9);
        }

        public int DecidirAtaque()
        {
            int ataque = Utils.GetRandom(0, 1);
            return ataque;
        }
    }
}
