using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExDragonBall
{
    interface ITorneo
    {
        void Init();
        void AddParticipantes(Persona p);
        void ExecuteRound();
        List<Persona> DevolverParticipantes();
        Persona DevolverGanador();
    }
}
