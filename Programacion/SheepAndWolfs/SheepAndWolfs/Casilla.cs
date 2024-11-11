using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepAndWolfs
{
    public enum TerritorioType
    {
        AGUA,
        HIERBA,
        VACIO
    }
    public class Casilla
    {
        public TerritorioType type;
        public double regeneration;
        public readonly Coordenada coordenada;

        
        
    }
}
