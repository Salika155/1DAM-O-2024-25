using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExDragonBall
{
    public enum RazaType
    {
        HUMANO,
        GUERREROESPACIO,
        SUPERSAIYAJIN
    }

    public abstract class Persona
    {
        private string? _nombre = string.Empty;
        private RazaType _raza;
        private double _energia;
        private double _deseoEsquivar;
        private double _capacidadEsquivar;
        public bool _quiereEsquivar;

        public string? Nombre
        {
            get => _nombre;
            
        }

        public double Energia
        {
            get => Utils.GetRandom(1000, 2000);
            set => _energia = value;
        }

        public double DeseoEsquivar
        {
            get => Utils.GetRandomDouble(0.1, 0.9);
            set => _deseoEsquivar = value;
        }
        

        public Persona(string nombre, double energia, double deseoEsquivar, RazaType raza)
        {
            _nombre = nombre;
            _energia = energia;
            _deseoEsquivar = deseoEsquivar;
            _raza = raza;
        }

        public RazaType GetRazaType()
        {
            return _raza;
        }

        public void QuitarEnergia(double energia)
        {
            if (energia == 0)
                return;
            Energia = Energia - energia;
        }

        public abstract void Atacar(Persona p);
        public abstract double ObtenerCapacidadEsquiva();
        public abstract double ObtenerCapacidadParada();
        public bool QuiereEsquivar()
        {
            _capacidadEsquivar = Utils.GetRandomDouble(0, 1);
            if (_deseoEsquivar <= _capacidadEsquivar)
                _quiereEsquivar = false;
            else if (_deseoEsquivar > _capacidadEsquivar)
                _quiereEsquivar = true;
            return _quiereEsquivar;
        }

    }
}
