using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallEx
{
    class Humano : Persona
    {
        private double _ataqueConGolpes;
        private double _capacidadDeEsquivar;
        private double _capacidadDeParar;

        //getters
        public double AtaqueConGolpe { get => _ataqueConGolpes; }
        public double CapacidadEsquiva { get => _capacidadDeEsquivar; }
        public double CapacidadParar { get => _capacidadDeParar; }

        public Humano(string name) 
            : base(name, RazaType.HUMANO)
        {
            _ataqueConGolpes = Utils.GetRandom(0.1, 0.8);
            _capacidadDeEsquivar = Utils.GetRandom(0.4, 0.6);
            _capacidadDeParar = Utils.GetRandom(0.7, 0.9);
        }

        #region comentado
        //public bool IntentarParar(Persona persona)
        //{
        //    if(Utils.GetRandom(0, 1) < persona.GetCapacidadParada())
        //    {
        //        Console.WriteLine($"{persona.Name} paró el ataque de {Name}.");
        //        persona.QuitarEnergia(0.5); // Pierde 0.5 de energía al parar
        //        return true; // El ataque fue parado
        //    }
        //    return false;
        //}

        //public bool IntentarEsquivar(Persona persona)
        //{
        //    if (persona.QuiereEsquivar() && Utils.GetRandom(0, 1) < persona.GetEsquivaCapacidad())
        //    {
        //        Console.WriteLine($"{persona.Name} esquivó el ataque de {Name}.");
        //        return true;
        //    }
        //    return false;
        //}
        #endregion

        public override double GetCapacidadParada()
        {
            return _capacidadDeParar;
        }

        public override double GetEsquivaCapacidad()
        {
            return _capacidadDeEsquivar;
        }

        public override void Atacar(Persona persona)
        {
            QuitarEnergia(1);
            #region comentado
            //if (Utils.GetRandom(0, 1) < AtaqueConGolpe)
            //{
            //    if(!IntentarEsquivar(persona) && !IntentarParar(persona))
            //    {
            //        // Si no esquiva ni para, recibe el ataque completo
            //        Console.WriteLine($"{Name} atacó a {persona.Name} y le quitó 3 puntos de energía.");
            //        persona.QuitarEnergia(3);
            //    }
            //}
            //else
            //{ 
            //    Console.WriteLine($"{Name} falló el ataque contra {persona.Name}."); 
            //}

            //if (persona.QuiereEsquivar() && Utils.GetRandom(0, 1) < persona.GetEsquivaCapacidad())
            //{
            //    Console.WriteLine($"{persona.Name} esquivó el ataque de {Name}.");
            //    QuitarEnergia(0);
            //}
            //else if (!persona.QuiereEsquivar() && Utils.GetRandom(0, 1) < persona.GetCapacidadParada())
            //{
            //    Console.WriteLine($"{persona.Name} paró el ataque de {Name}.");
            //    QuitarEnergia(0.5);
            //}
            //else
            //{
            //    persona.QuiereEsquivar() && Utils.GetRandom(0, 1) >= persona.GetEsquivaCapacidad() = QuitarEnergia(3);

            //}
            #endregion
            if (Utils.GetRandom(0, 1) > _ataqueConGolpes)
                persona.RecibirAtaque(0.5, 3);

        }
    }
}
