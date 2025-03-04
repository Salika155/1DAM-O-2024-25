using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDomino
{
    class Impulsivo : Participante
    {
        public Impulsivo(List<Ficha> manoJugador, string name) : base(manoJugador, name)
        {
            
        }

        public override int PuntuajeFicha(Ficha ficha)
        {
            throw new NotImplementedException();
        }

        public override Ficha? TirarFicha()
        {
            // Comprobamos si la mano está vacía
            if (ManoJugador.Count == 0)
                return null;

            // Primero buscamos fichas dobles
            for (int i = 0; i < ManoJugador.Count; i++)
            {
                var pArriba = ManoJugador[i].NumArriba == ManoJugador[i].NumAbajo;
                if (pArriba) // Si la ficha es doble (mismo número arriba y abajo)
                {
                    Ficha? fichaSeleccionada = ManoJugador[i];
                    ManoJugador.RemoveAt(i); // Se elimina la ficha de la mano
                    return fichaSeleccionada;
                }
            }

            // Si no hay fichas dobles, juega la primera ficha disponible
            Ficha? fichaNormal = ManoJugador[0];
            ManoJugador.RemoveAt(0); // Se elimina la ficha de la mano
            return fichaNormal;
        }
    }
}
