using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepAndWolfs
{  
    public class Casilla
    {
        public TerritorioType Type;
        //private double _regeneration;
        public readonly Coordenada Coord;
        public int ValorHierba;

        //TODO: esto funciona
        public Casilla(Coordenada coordenada)
        {
            //this.regeneration = regeneration;
            this.Coord = coordenada;
            this.ValorHierba = 25;
            //this._regeneration = 5;
        }

        public int GetValorHierba()
        {
            return ValorHierba;
        }
    }
}
