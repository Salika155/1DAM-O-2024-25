using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallEx
{
    public enum RazaType
    {
        HUMANO,
        SUPERSAIYAJIN,
        GUEREROESPACIO,
        NAMEKIANO
    }
    public abstract class Persona
    {
        private string? _name;
        private RazaType _raza;
        private double _energia;
        private double _deseoEsquivar;

        
        public string? Name { get => _name; }
        public RazaType Raza { get => _raza; }
        public double Energia { get => _energia; }
        public double Esquiva { get => _deseoEsquivar; }

        public Persona(string name, RazaType raza)
        {
            _name = name;
            _raza = raza;
            _energia = Utils.GetRandom(1000, 2000);
            _deseoEsquivar = Utils.GetRandom(0.1, 0.9);
        }

        public void QuitarEnergia(double cantidad)
        {
             _energia = _energia - cantidad;
            if (_energia < 0) 
                _energia = 0;
        }

        public abstract void Atacar(Persona persona);
        public abstract double GetEsquivaCapacidad();
        public abstract double GetCapacidadParada();
        public bool QuiereEsquivar() 
        {
            double random = Utils.GetRandom(0, 1);
               return random < _deseoEsquivar;
        }
    }
}
