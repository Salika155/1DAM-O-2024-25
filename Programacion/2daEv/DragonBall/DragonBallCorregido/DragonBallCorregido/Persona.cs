using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallCorregido
{
    public enum Raza
    {

    }

    public abstract class Persona
    {
        private readonly string? _name;
        public readonly Raza Raza => GetRaza();
        private double _deseoEsquivar;



        public abstract Raza GetRaza();
        

        public string? Name => _name;
        public Persona(string name)
        {
            _name = name;
        }
        public void QuitarEnergia(double energia)
        {
            return Utils.GetRandom() < _deseoEsquivar;
        }

        public bool QuiereEsquivar()
        {
            return true;
        }
        public abstract void Atacar(Persona p);
        public abstract double ObtenerCapacidadEsquiva();
        public abstract double ObtenerCapacidadParada();
    }
}
