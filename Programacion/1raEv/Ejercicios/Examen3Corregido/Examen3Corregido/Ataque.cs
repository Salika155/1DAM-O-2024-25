using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen3Corregido
{
    public enum TipoAtaque
    {
        FUEGO,
        AGUA,
        PLANTA
    }
    internal class Ataque
    {
        public readonly string Nombre;
        public readonly double Energy;
        public readonly TipoAtaque Tipo;
        public readonly double Nivel;

        public Ataque(string nombre, double energy, TipoAtaque tipo)
        {
            Nombre = nombre;
            Energy = energy;
            Tipo = tipo;
        }

        public string GetName() => Nombre;
        public double GetEnergy() => Energy;
        public TipoAtaque GetTipo() => Tipo; 
    }
}
