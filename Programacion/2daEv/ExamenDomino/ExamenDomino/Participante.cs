using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDomino
{
    abstract class Participante
    {
        private List<Ficha> _manoJugador;
        private string _name = string.Empty;

        public string Name { get => _name; }
        public List<Ficha> ManoJugador { get => _manoJugador; }
        public Participante(List<Ficha> manoJugador, string name)
        {
            _manoJugador = manoJugador;
            _name = name;
        }

        public abstract Ficha? TirarFicha();

        public void RobarFicha(Ficha ficha)
        {
            while (_manoJugador.Count < 7)
                _manoJugador.Add(ficha);
        }

        public abstract int PuntuajeFicha(Ficha ficha);
        
    }
}
