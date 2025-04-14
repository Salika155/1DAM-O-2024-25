namespace ExDragonBallBienHecho
{
    public class Humano : Persona
    {
        #region comentarios
        //● Tiene los siguientes atributos privados
        //○ Ataque con golpes → Con una efectividad entre 0.1 y 0.8
        //○ Capacidad de esquivar → Con una efectividad entre 0.4 y 0.6
        //○ Capacidad de parar → Con una efectividad entre 0.7 y 0.9
        #endregion
        private double _ataqueConGolpe;
        private double _capacidadEsquiva;
        private double _capacidadParar;

        public double AtaqueConGolpe { get => _ataqueConGolpe; }
        public double CapacidadEsquiva { get => _capacidadEsquiva; }
        public double CapacidadParar { get => _capacidadParar; }
        public Humano(string name, double energia, double deseoEsquivar, double ataqueGolpe, double capacidadEsquiva, double capacidadParar)
    : base(name, energia, deseoEsquivar, RazaType.HUMANO)
        {
            _ataqueConGolpe = ataqueGolpe;
            _capacidadEsquiva = capacidadEsquiva;
            _capacidadParar = capacidadParar;
        }

        public static Humano CrearHumano(string name, double energia, double deseoEsquivar)
        {
            double ataqueGolpe = Utils.GetRandomDouble(0.1, 0.8);
            double capacidadEsquiva = Utils.GetRandomDouble(0.4, 0.6);
            double capacidadParar = Utils.GetRandomDouble(0.7, 0.9);

            return new Humano(name, energia, deseoEsquivar, ataqueGolpe, capacidadEsquiva, capacidadParar);
        }
        /*● Sólo ataca con golpes.
          ● Cuando ataca, gasta 1 punto de energía. Si el contrincante:
            ○ lo esquiva, no le hará nada
            ○ lo para, le quitará 0.5 puntos de energía
            ○ si le da, le quitará 5 puntos de energía
         * */
        public override void Atacar(Persona p)
        {
            Energia -= 1; // El atacante gasta 1 punto de energía al atacar.

            // Genera una probabilidad aleatoria entre 0 y 1 para ver si se esquiva el golpe.
            double probEsquiva = Utils.GetRandomDouble(0, 1);

            // Si la probabilidad aleatoria es menor que la capacidad de esquiva del rival, se esquiva el golpe.
            if (probEsquiva < p.ObtenerCapacidadEsquiva())
            {
                p.QuitarEnergia(0); // No pasa nada si el golpe es esquivado
                return; // Sale de la función porque ya no hace falta seguir procesando
            }

            // Si el golpe no se esquiva, verifica si el golpe es parado.
            double probParada = Utils.GetRandomDouble(0, 1);
            if (probParada < p.ObtenerCapacidadParada())
            {
                p.QuitarEnergia(0.5); // Si el golpe es parado, quita 0.5 puntos de energía.
            }
            else
            {
                p.QuitarEnergia(5); // Si no se esquiva ni se para, el golpe da y quita 5 puntos de energía.
            }
        }

        public override RazaType GetRaza()
        {
            return RazaType.HUMANO;
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
}