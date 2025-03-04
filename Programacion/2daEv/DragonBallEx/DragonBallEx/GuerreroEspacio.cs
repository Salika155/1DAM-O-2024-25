using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallEx
{
    class GuerreroEspacio : Persona
    {
        private double _ataqueConRayo;
        private double _ataqueConGolpes;
        private double _capacidadDeEsquivar;
        private double _capacidadDeParar;

//○ Ataque con rayo → Es un real entre 0.3 y 0.6
//○ Ataque con golpes → Es un real entre 0.1 y 0.8
//○ Capacidad de esquivar → Es un real entre 0.2 y 0.4
//○ Capacidad de parar → Es un real entre 0.4 y 0.9
        public GuerreroEspacio(string name) : base(name, RazaType.GUEREROESPACIO)
        {
            _ataqueConRayo = Utils.GetRandom(0.3, 0.6);
            _ataqueConGolpes = Utils.GetRandom(0.1, 0.8);
            _capacidadDeEsquivar = Utils.GetRandom(0.2, 0.4);
            _capacidadDeParar = Utils.GetRandom(0.4, 0.9);
        }

        public GuerreroEspacio(string name, RazaType raza) : base(name, raza)
        {
            
        }

        public override void Atacar(Persona persona)
        {
            double randomAttack = Utils.GetRandom(0, 1); // Decide aleatoriamente si ataca con golpes o con rayo

            if (randomAttack < 0.5) // 50% de probabilidad de atacar con golpes
            {// Ataca con golpes
                if (Utils.GetRandom(0, 1) < _ataqueConGolpes) // Verifica si el ataque tiene éxito
                {
                    QuitarEnergia(5); // Gasta 5 puntos de energía
                    persona.RecibirAtaque(2, 7); // Daño reducido (2) o completo (7)
                }
                else
                    Console.WriteLine($"{Name} falló el ataque con golpes contra {persona.Name}.");
            }
            else // 50% de probabilidad de atacar con rayo
            {// Ataca con rayo
                if (Utils.GetRandom(0, 1) < _ataqueConRayo) // Verifica si el ataque tiene éxito
                {
                    QuitarEnergia(100); // Gasta 100 puntos de energía
                    persona.RecibirAtaque(25, 300); // Daño reducido (25) o completo (300)
                }
                else
                    Console.WriteLine($"{Name} falló el ataque con rayo contra {persona.Name}.");
            }
        }

        public override double GetCapacidadParada()
        {
            return _capacidadDeParar;
        }

        public override double GetEsquivaCapacidad()
        {
            return _capacidadDeEsquivar;
        }
    }
}
