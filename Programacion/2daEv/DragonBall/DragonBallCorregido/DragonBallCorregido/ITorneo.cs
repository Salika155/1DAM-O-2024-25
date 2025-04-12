using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallCorregido
{
    public delegate bool FilterDelegate(Persona p);
    public interface ITorneo
    {
        void Init();
        void Add(Persona p);
        void ExecuteRound();
        List<Persona> Filter(FilterDelegate filter);
        Persona GetWinner();
    }
}
