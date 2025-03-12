using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExDragonBall
{
    public class Torneo : ITorneo
    {
        public delegate void VisitParticipantes(List<Persona> pl);

        private readonly List<Persona> _participantes = new List<Persona>();
        private int _participantesCount;

        public int Count => _participantes.Count;

        public Torneo(List<Persona> participantes)
        {
            _participantes = participantes;
        }

        public void AddParticipantes(Persona p)
        {
            if (p == null)
                return;
            _participantes.Add(p);
        }

        public List<Persona> DevolverGanador()
        {
            List<Persona> ganador = new List<Persona>();
            if (_participantes.Count == 1)
                ganador = DevolverGanador();
            return ganador;
        }

        public List<Persona> DevolverParticipantes()
        {
            List<Persona> p = new List<Persona>();
            for (int i = 0; i < _participantes.Count; i++)
            {
                var persona = _participantes[i];
                p.Add(persona);
            }
            return p;
        }

        public void ExecuteRound()
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            
        }

        public void CreateParticipantes()
        {
            if (_participantesCount <= 0)
                return; 

            for (int i = 0; i < _participantesCount; i++)
            {
               
            }
        }

        public void Visit(VisitParticipantes pl) 
        {
            foreach (var p in _participantes)
            {
                
            }
        }
    }
}
