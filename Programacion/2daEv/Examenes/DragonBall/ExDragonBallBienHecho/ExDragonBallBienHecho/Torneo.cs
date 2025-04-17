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

            while (_participantesTorneo.Count > 1)
            {
                var p1 = _participantesTorneo[0];
                var p2 = _participantesTorneo[1];

                var ganador = Combatir(p1, p2);
                _ganadoresRonda.Add(ganador);

                // Primero eliminamos el segundo elemento (índice 1)
                _participantesTorneo.RemoveAt(1);
                // Luego eliminamos el primer elemento (índice 0)
                _participantesTorneo.RemoveAt(0);
            }
            _participantesTorneo = _ganadoresRonda;
        }

        public Persona? Combatir(Persona p1, Persona p2)
        {
            while (p1.Energia > 0 && p2.Energia > 0)
            {
                // P1 ataca a P2
                p1.Atacar(p2);
                if (p2.Energia <= 0)
                    return p1;  // Si P2 se queda sin energía, P1 gana

                // P2 ataca a P1
                p2.Atacar(p1);
                if (p1.Energia <= 0)
                    return p2;  // Si P1 se queda sin energía, P2 gana
            }

            // Si ambos se quedan sin energía al mismo tiempo
            if (p1.Energia == 0 && p2.Energia == 0)
            {
                return null;  // Empate
            }

            // Si alguno de los dos tiene energía (esto debería estar cubierto por las condiciones previas)
            return p1.Energia > 0 ? p1 : p2;  // Retorna al ganador si alguien sobrevive
        }

        public List<Persona> FiltrarListaParticipantes(FilterDelegate filter)
        {
            List<Persona> filtrados = new();

            foreach(var c in _participantesTorneo)
            {
                if (filter(c))
                    filtrados.Add(c);
            }
            return filtrados;
        }

        public Persona GetWinner()
        {
            return _participantesTorneo.Count == 1 ? _participantesTorneo[0] : throw new Exception();
        }

        public void Init()
        {
            while (_participantesTorneo.Count > 1)
            {
                ExecuteRound();
            }
            GetWinner();
        }
    }
}
