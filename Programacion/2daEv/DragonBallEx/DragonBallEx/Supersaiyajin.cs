using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallEx
{
    class Supersaiyajin : GuerreroEspacio
    {
        private double _ataqueConRayo;
        private double _ataqueConGolpes;
        private double _capacidadDeEsquivar;
        private double _capacidadDeParar;
        public Supersaiyajin(string name) : base(name, RazaType.SUPERSAIYAJIN)
        {
            _ataqueConRayo = Utils.GetRandom(0.3, 0.6);
            _ataqueConGolpes = Utils.GetRandom(0.1, 0.8);
            _capacidadDeEsquivar = Utils.GetRandom(0.2, 0.4);
            _capacidadDeParar = Utils.GetRandom(0.4, 0.9);
        }

        public override void Atacar(Persona persona)
        {
            // Decide cuántas acciones de ataque realizar (entre 1 y 3)
            int acciones = (int)Utils.GetRandom(1, 4); // Número aleatorio entre 1 y 3

            for (int i = 0; i < acciones; i++)
            {
                // Decide aleatoriamente si ataca con golpes o con rayo
                double randomAttack = Utils.GetRandom(0, 1);

                if (randomAttack < 0.5) // 50% de probabilidad de atacar con golpes
                {
                    // Ataca con golpes
                    if (Utils.GetRandom(0, 1) < _ataqueConGolpes) // Verifica si el ataque tiene éxito
                    {
                        QuitarEnergia(5); // Gasta 5 puntos de energía
                        persona.RecibirAtaque(4, 14); // Daño reducido (4) o completo (14)
                    }
                    else
                    {
                        Console.WriteLine($"{Name} falló el ataque con golpes contra {persona.Name}.");
                    }
                }
                else // 50% de probabilidad de atacar con rayo
                {
                    // Ataca con rayo
                    if (Utils.GetRandom(0, 1) < _ataqueConRayo) // Verifica si el ataque tiene éxito
                    {
                        QuitarEnergia(100); // Gasta 100 puntos de energía
                        persona.RecibirAtaque(50, 600); // Daño reducido (50) o completo (600)
                    }
                    else
                    {
                        Console.WriteLine($"{Name} falló el ataque con rayo contra {persona.Name}.");
                    }
                }
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
