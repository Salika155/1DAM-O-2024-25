using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExDragonBallBienHecho
{
    delegate bool FilterDelegate(Persona p);
    
    interface ITorneo
    {
        void Init();
        void AddParticipantes(Persona p);
        void ExecuteRound();
        List<Persona> FiltrarListaParticipantes(FilterDelegate filter);
        Persona GetWinner();
    }
}
