using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallCorregido
{
    class SuperSaiyajin : GuerreroEspacio
    {
        
        public SuperSaiyajin(string name) : base(name)
        {
        }

        public override void Atacar(Persona p)
        {
            int acciones = 2;
            for (int i = 0; i < acciones; i++)
            {
                base.Atacar(p);
            }
        }

        public override double GetEnergyDamageFactor()
        {
            return 2.0;
        }
    }
}
