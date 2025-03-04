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

        public override Ficha? TirarFicha()
        {
            if (ManoJugador.Count == 0)
                return null; // No hay fichas para jugar.

            Ficha fichaMayor = ManoJugador[0]; // Suponemos que la primera es la mayor.
            int indiceMayor = 0; // Guardamos el índice para eliminarla después.

            // Recorremos la lista para encontrar la ficha con mayor puntuación.
            for (int i = 1; i < ManoJugador.Count; i++)
            {
                if (ManoJugador[i].PuntuajeFicha(ManoJugador[i].NumArriba, ManoJugador[i].NumAbajo) >
                    fichaMayor.PuntuajeFicha(fichaMayor.NumArriba, fichaMayor.NumAbajo))
                {
                    fichaMayor = ManoJugador[i];
                    indiceMayor = i;
                }
            }

            // Eliminamos la ficha seleccionada de la mano.
            ManoJugador.RemoveAt(indiceMayor);

            return fichaMayor; // Retornamos la ficha con mayor puntuación.
        }

    }
}
