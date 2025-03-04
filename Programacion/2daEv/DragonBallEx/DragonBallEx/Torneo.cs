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

        private readonly List<Persona> _participantes = new List<Persona>();
        private static int _participantCounter = 1;


        public Torneo()
        {
            _participantes = new List<Persona>();
        }

        public void Init()
        {
            if (_participantes == null)
                return;

            for (int i = 0; i < 16; i++)
            {
                _participantes.Add(CreateParticipante());
            }
        }


        //public static void CreateParticipantes(int numParticipantes)
        //{
        //    for (int i = 0; i <= numParticipantes; i++)
        //    {
        //        CreateParticipante();
        //    }
        //}

        //mejor un createParticipante y el Participantes puede ser practicamente el init no?

        public static Persona CreateParticipante()
        {
            string n = $"Persona{_participantCounter++}";
            double randomType = Utils.GetRandom(0, 1);
            if (randomType < 0.25)
                return new Humano(n);
            else if (randomType < 0.50)
                return new GuerreroEspacio(n);
            else if (randomType < 0.75)
                return new Supersaiyajin(n);
            else
                return new Namekiano(n);
        }

        public List<string> Execute()
        {
            if (_participantes == null || _participantes.Count != 16)
                throw new InvalidOperationException("Torneo Invalido");

            List<string> resultados = new List<string>();
            List<Persona> participantesActivos = new List<Persona>(_participantes);

            while(participantesActivos.Count > 1)
            {
                List<Persona> ganadoresRonda = new List<Persona>();
                for(int i = 0; i < participantesActivos.Count; i += 2)
                {
                    Persona participante1 = participantesActivos[i];
                    Persona participante2 = participantesActivos[i + 1];

                    string? resultadoCombate = SimularCombate(participante1, participante2);
                    if (resultadoCombate == null)
                        return resultados;
                    resultados.Add(resultadoCombate);

                    Persona ganador = participante1.Energia > 0 ? participante1 : participante2;
                    ganadoresRonda.Add(ganador);
                }
                participantesActivos = ganadoresRonda;
            }
            resultados.Add($"{participantesActivos[0].Name} es el ganador del torneo!");
            return resultados;
        }

        private string SimularCombate(Persona participante1, Persona participante2)
        {
            while (participante1.Energia > 0 && participante2.Energia > 0)
            {
                participante1.Atacar(participante2);
                if (participante2.Energia > 0)
                {
                    participante2.Atacar(participante1);
                }
            }

            string? nombreGanador = participante1.Energia > 0 ? participante1.Name : participante2.Name;
            string? nombrePerdedor = participante1.Energia > 0 ? participante2.Name : participante1.Name;

            Console.WriteLine($"{nombrePerdedor} ha sido eliminado.");
            return $"{participante1.Name} vs {participante2.Name} -> Ganador: {nombreGanador}";
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
