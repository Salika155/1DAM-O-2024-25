using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDomino
{
    class Conservador : Participante
    {
        public Conservador(List<Ficha> manoJugador, string name) : base(manoJugador, name)
        {

        }

        public override int PuntuajeFicha(Ficha ficha)
        {
            return ficha.PuntuajeFicha(ficha.NumArriba, ficha.NumAbajo);
        }

        public override Ficha TirarFicha()
        {
            throw new NotImplementedException();
        }
    }
}
