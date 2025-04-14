using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExDragonBallBienHecho
{
    class Torneo : ITorneo
    {
        private List<Persona> _participantesTorneo = new();
        public void AddParticipantes(Persona p)
        {
            if (p == null)
                return;
            _participantesTorneo.Add(p);
        }

        public void ExecuteRound()
        {
            List<Persona> _ganadoresRonda = new();

            while(_participantesTorneo.Count > 1)
            {
                var p1 = _participantesTorneo[0];
                var p2 = _participantesTorneo[1];

                var ganador = Combatir(p1, p2);
                _ganadoresRonda.Add(ganador);

                _participantesTorneo.RemoveAt(0);
                _participantesTorneo.RemoveAt(1);
            }
            _participantesTorneo = _ganadoresRonda;
        }

        public Persona Combatir(Persona p1, Persona p2)
        {
            while(p1.Energia > 0 && p2.Energia > 0)
            {
                p1.Atacar(p2);
                if (p2.Energia <= 0)
                    return p1;
                p2.Atacar(p1);
                if (p1.Energia <= 0)
                    return p2;
            }
            throw new Exception();
        }

        public List<Persona> FiltrarListaParticipantes(FilterDelegate filter)
        {
            List<Persona> filtrados = new();

            foreach(var c in _participantesTorneo)
            {
                
            }
            return filtrados;
        }

        public Persona GetWinner()
        {
            return _participantesTorneo.Count == 1 ? _participantesTorneo[0] : throw new Exception();
        }

        public void Init()
        {
            while (_participantesTorneo.Count < 1)
            {
                ExecuteRound();
            }
            GetWinner();
        }
    }
}
