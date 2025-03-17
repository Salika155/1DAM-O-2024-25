using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallCorregido
{
    public class Torneo : ITorneo
    {
        List<Persona> personas = new();
        public void Add(Persona p)
        {
            throw new NotImplementedException();
        }

        public void ExecuteRound()
        {
            List<Persona> ganadores = new();
            while(personas.Count > 1)
            {
                var guerrero0 = personas[0];
                var guerrero1 = personas[1];

                var ganador = Combatir(guerrero0, guerrero1);

                personas.RemoveAt(0);
                personas.RemoveAt(1);
            }

            personas = ganadores;
        }

        private object Combatir(Persona guerrero0, Persona guerrero1)
        {
            throw new NotImplementedException();
        }

        public List<Persona> Filter(FilterDelegate filter)
        {
            throw new NotImplementedException();
        }

        public Persona GetWinner()
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            throw new NotImplementedException();
        }
    }
}
