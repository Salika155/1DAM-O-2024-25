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
        public double regeneration;
        public readonly Coordenada coordenada;

        public Casilla(Coordenada coordenada)
        {
            
            //this.regeneration = regeneration;
            this.coordenada = coordenada;
        }
    }
}
