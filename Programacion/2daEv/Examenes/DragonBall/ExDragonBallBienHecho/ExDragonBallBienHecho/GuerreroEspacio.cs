using System;

namespace ExDragonBallBienHecho
{
    public class GuerreroEspacio : Persona
    {
        private double _ataqueConRayo;
        private double _ataqueConGolpe;
        protected double _capacidadEsquiva;
        protected double _capacidadParar;
        
        public double AtaqueConRayo { get => _ataqueConRayo; }
        public double AtaqueConGolpe { get => _ataqueConGolpe; }
        public double CapacidadEsquiva { get => _capacidadEsquiva; }
        public double CapacidadParar { get => _capacidadParar; }
        public GuerreroEspacio(string name, double energia, double deseoEsquivar, 
        double ataqueRayo, double ataqueGolpe, double capacidadEsquiva, double capacidadParar) 
        : base(name, energia, deseoEsquivar, RazaType.GUERREROESPACIO)
        {
            _ataqueConRayo = ataqueRayo;
            _ataqueConGolpe = ataqueGolpe;
            _capacidadEsquiva = capacidadEsquiva;
            _capacidadParar = capacidadParar;
        }

        public static GuerreroEspacio CreateGuerreroEspacio(string name, double energia, double deseoEsquivar)
        {
            double ataqueRayo = Utils.GetRandomDouble(0.3, 0.6);
            double ataqueGolpe = Utils.GetRandomDouble(0.1, 0.8);
            double capacidadEsquiva = Utils.GetRandomDouble(0.2, 0.4);
            double capacidadParar = Utils.GetRandomDouble(0.4, 0.9);

            return new GuerreroEspacio(name, energia, deseoEsquivar, ataqueRayo, ataqueGolpe, capacidadEsquiva, capacidadParar);
        }
        public override void Atacar(Persona p)
        {
            int decisionataque = Utils.GetRandom(0, 1);
            double prob = Utils.GetRandomDouble(0, 1);
            double probPar = Utils.GetRandomDouble(0, 1);

            if (decisionataque == 0) // Ataque con rayo
            {
                if (Energia < 100) return;
                QuitarEnergia(100);

                if (prob < p.ObtenerCapacidadEsquiva())
                {
                    // Esquiva exitosa
                    p.QuitarEnergia(0);
                }
                else if (probPar < p.ObtenerCapacidadParada())
                {
                    p.QuitarEnergia(25);
                }
                else
                {
                    p.QuitarEnergia(300);
                }
            }
            else // Ataque con golpe
            {
                if (Energia < 5) return;
                QuitarEnergia(5);

                if (prob < p.ObtenerCapacidadEsquiva())
                {
                    // Esquiva exitosa
                    p.QuitarEnergia(0);
                }
                else if (probPar < p.ObtenerCapacidadParada())
                {
                    p.QuitarEnergia(2);
                }
                else
                {
                    p.QuitarEnergia(7);
                }
            }
        }
        public override RazaType GetRaza()
        {
            return RazaType.GUERREROESPACIO;
        }

        public override double ObtenerCapacidadEsquiva()
        {
            return _capacidadEsquiva;
        }

        public override double ObtenerCapacidadParada()
        {
            return _capacidadParar;
        }
    }

# region comentarios
//Guerrero del espacio
    //● Hereda de Persona
    //● Tiene los siguientes atributos privados
        //○ Ataque con rayo → Con una efectividad entre 0.3 y 0.6
        //○ Ataque con golpes → Con una efectividad entre 0.1 y 0.8
        //○ Capacidad de esquivar → Con una efectividad entre 0.2 y 0.4
        //○ Capacidad de parar → Con una efectividad entre 0.4 y 0.9
    //● Cuando ataca, puede usar los rayos o los golpes(usar un
    //random como IA).
    //● Si ataca con rayo, el guerrero del espacio gasta 100 puntos
    // de energía.Si el contrincante:
        //○ lo esquiva, no le hará nada
        //○ lo para, le quitará 25 puntos de energía
        //○ si le da, le quitará 300 puntos de energía
    //● Si ataca con golpe, el guerrero del espacio gasta 5 puntos
    //de energía.Si el contrincante:
        //○ lo esquiva, no le hará nada
        //○ lo para, le quitará 2 puntos de energía
        //○ si le da, le quitará 7 puntos de energía
    #endregion
}