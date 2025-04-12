using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallEx
{
    class Namekiano : Persona
    {
        private double _ataqueConRayo;
        private double _ataqueConGolpes;
        private double _capacidadDeEsquivar;
        private double _capacidadDeParar;

        public Namekiano(string name) : base(name, RazaType.NAMEKIANO)
        {
            _ataqueConRayo = Utils.GetRandom(0.1, 0.4);
            _ataqueConGolpes = Utils.GetRandom(0.3, 0.8);
            _capacidadDeEsquivar = Utils.GetRandom(0.5, 0.7);
            _capacidadDeParar = Utils.GetRandom(0.3, 0.6);
        }

        public override void Atacar(Persona objetivo)
        {
            // Decide aleatoriamente si ataca con golpes o con rayo
            if (Utils.GetRandom(0, 1) <= 0.6) // 60% de probabilidad de atacar con golpes
            {
                // Ataca con golpes
                if (Utils.GetRandom(0, 1) <= _ataqueConGolpes) // Verifica si el ataque tiene éxito
                {
                    QuitarEnergia(10); // Gasta 10 puntos de energía
                    objetivo.RecibirAtaque(7, 19); // Daño reducido (7) o completo (19)
                }
                else
                {
                    Console.WriteLine($"{Name} falló el ataque con golpes contra {objetivo.Name}.");
                }
            }
            else // 40% de probabilidad de atacar con rayo
            {
                // Ataca con rayo
                if (Utils.GetRandom(0, 1) <= _ataqueConRayo) // Verifica si el ataque tiene éxito
                {
                    QuitarEnergia(50); // Gasta 50 puntos de energía
                    objetivo.RecibirAtaque(20, 100); // Daño reducido (20) o completo (100)
                }
                else
                {
                    Console.WriteLine($"{Name} falló el ataque con rayo contra {objetivo.Name}.");
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
