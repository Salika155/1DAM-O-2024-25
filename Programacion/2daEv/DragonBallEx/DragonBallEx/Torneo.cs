using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallEx
{
    class Torneo : ITorneo
    {
        private readonly List<Persona>? _participantes;


        public void Init()
        {
            List<Persona> _participantes = new List<Persona>();
            for(int i = 0; i < 16; i++)
            {
                //CreatePersona()

            }
        }

        public List<string> Execute()
        {
            throw new NotImplementedException();
        }

        
    }
}
