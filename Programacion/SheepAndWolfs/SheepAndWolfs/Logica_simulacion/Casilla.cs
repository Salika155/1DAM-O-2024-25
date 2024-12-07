using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepAndWolfs
{  
    public class Casilla
    {
        public TerritorioType type;
        private double regeneration;
        public readonly Coordenada coordenada;
        public int _valorHierba;

        //TODO: esto funciona
        public Casilla(Coordenada coordenada)
        {
            //this.regeneration = regeneration;
            this.coordenada = coordenada;
            this._valorHierba = 25;
        }

        public int GetValorHierba()
        {
            return _valorHierba;
        }
    }
}
