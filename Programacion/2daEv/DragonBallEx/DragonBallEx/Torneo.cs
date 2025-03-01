using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallEx
{
    class Torneo : ITorneo
    {
        public delegate void VisitAction(Persona participante);

        private readonly List<Persona>? _participantes;

        public Torneo()
        {
            _participantes = new List<Persona>();
        }
           
        public void Init()
        {
            if (_participantes == null)
                return;

            for (int i = 0; i <= 16; i++)
            {
                _participantes.Add(CreateParticipantes(i));
                

            }
        }

        private Persona CreateParticipantes(int index)
        {
            string n = string.Empty;
            double randomType = Utils.GetRandom(0, 1);
            if (randomType < 0.25)
            {
                return new Humano(n);
            }
            else if (randomType < 0.50 && randomType >= 0.25)
            {
                return new GuerreroEspacio(n);
            }
            else if (randomType < 0.75 && randomType >= 0.50)
            {
                return new Supersaiyajin(n);
            }
            else
                return new Namekiano(n);
        }

        public List<string> Execute()
        {
            throw new NotImplementedException();
        }

        public void Visit(VisitAction action)
        {
            if (_participantes == null)
                return;

            foreach(var participante in _participantes)
            {
                action(participante);
            }
        }
        
    }
}
