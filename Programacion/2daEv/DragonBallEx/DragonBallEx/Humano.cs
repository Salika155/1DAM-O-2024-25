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
        public double AtaqueConGolpe { get => _ataqueConGolpes; }
        public double CapacidadEsquiva { get => _capacidadDeEsquivar; }
        public double CapacidadParar { get => _capacidadDeParar; }

        public Humano(string name) 
            : base(name, RazaType.HUMANO)
        {
            _ataqueConGolpes = Utils.GetRandom(0.1, 0.8);
            _capacidadDeEsquivar = Utils.GetRandom(0.4, 0.6);
            _capacidadDeParar = Utils.GetRandom(0.7, 0.9);
        }

        public override double GetCapacidadParada()
        {
            return _capacidadDeParar;
        }

        public override double GetEsquivaCapacidad()
        {
            return _capacidadDeEsquivar;
        }

        public override void Atacar(Persona persona)
        {
            QuitarEnergia(1);
            if (Utils.GetRandom(0, 1) > _ataqueConGolpes)
                persona.RecibirAtaque(0.5, 3);
            else
            {
                Console.WriteLine($"{Name} intentó atacar a {persona.Name}, pero falló.");
            }
        }
    }
}
