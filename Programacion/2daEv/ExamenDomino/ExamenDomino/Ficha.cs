using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDomino
{
    class Ficha
    {
        private int _numArriba;
        private int _numAbajo;

        public int NumArriba { get => _numArriba; }
        public int NumAbajo { get => _numAbajo; }

        public Ficha(int numArriba, int numAbajo)
        {
            _numArriba = numArriba;
            _numAbajo = numAbajo;
        }

        public static bool EsDoble(int numArriba, int numAbajo)
        {
            return numArriba == numAbajo;
        }

        public int PuntuajeFicha(int numArriba, int numAbajo)
        {
            int puntuacionTotal = NumArriba + NumAbajo;
            if (EsDoble(NumArriba, NumAbajo))
                puntuacionTotal = puntuacionTotal * 2;
            return puntuacionTotal;
        }
        
    }
}
