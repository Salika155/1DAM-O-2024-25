using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExDragonBall
{
    public class Humano : Persona
    {
        #region atributos
        private double _ataqueConGolpe;
        private double _capacidadEsquiva;
        private double _capacidadParar;
        #endregion
        #region properties
        public double AtaqueGolpe
        {
            get => _ataqueConGolpe;
            set => _ataqueConGolpe = value;
        }

        public double CapacidadEsquiva
        {
            get => _capacidadEsquiva;
            set => _capacidadEsquiva = value;
        }

        public double CapacidadParar
        {
            get => _capacidadParar;
            set => _capacidadParar = value;
        }
        #endregion

        public Humano(int energia, double deseoEsquivar, double ataqueGolpe, double capacidadEsquiva, double capacidadParar) 
            : base("Humano", energia, deseoEsquivar, RazaType.HUMANO)
        {
            _ataqueConGolpe = ataqueGolpe;
            _capacidadEsquiva = capacidadEsquiva;
            _capacidadParar = capacidadParar;
        }

        public override void Atacar(Persona p)
        {
            if (p.QuiereEsquivar())
            {
                if (p.DeseoEsquivar > AtaqueGolpe)
                    p.Energia -= 0;
                else if (p.ObtenerCapacidadParada() >= AtaqueGolpe)
                    p.Energia -= 0.5;
                else if
                    (p.ObtenerCapacidadParada() < _ataqueConGolpe)
                        p.Energia -= 5;
            }
        }

        public override double ObtenerCapacidadEsquiva()
        {
            return Utils.GetRandomDouble(0.4, 0.6);
        }

        public override double ObtenerCapacidadParada()
        {
            return Utils.GetRandomDouble(0.7, 0.9);
        }
    }
}
