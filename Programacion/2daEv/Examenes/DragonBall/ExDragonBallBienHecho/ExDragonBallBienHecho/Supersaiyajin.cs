namespace ExDragonBallBienHecho
{
    public class Supersaiyajin : GuerreroEspacio
    {
        public Supersaiyajin(string name, double energia, double deseoEsquivar,
            double ataqueRayo, double ataqueGolpe, double capacidadEsquiva,
            double capacidadParar) : base(name, energia, deseoEsquivar, ataqueRayo, ataqueGolpe,
                capacidadEsquiva, capacidadParar)
        {

        }
        public static Supersaiyajin CreateSuperSaiyajin(string name, double energia, double deseoEsquivar)
        {
            double ataqueRayo = Utils.GetRandomDouble(0.3, 0.6);
            double ataqueGolpe = Utils.GetRandomDouble(0.1, 0.8);
            double capacidadEsquiva = Utils.GetRandomDouble(0.2, 0.4);
            double capacidadParar = Utils.GetRandomDouble(0.4, 0.9);

            return new Supersaiyajin(name, energia, deseoEsquivar, ataqueRayo, ataqueGolpe, capacidadEsquiva, capacidadParar);
        }
        public override void Atacar(Persona p)
        {
            int acciones = Utils.GetRandom(1, 3);

            for (int i = 0; i < acciones; i++)
            {
                int decisionataque = Utils.GetRandom(0, 2);
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
                        p.QuitarEnergia(25 * 2);
                    }
                    else
                    {
                        p.QuitarEnergia(300 * 2);
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
                        p.QuitarEnergia(2 * 2);
                    }
                    else
                    {
                        p.QuitarEnergia(7 * 2);
                    }
                }
            }

        }
        public override RazaType GetRaza()
        {
            return RazaType.SUPERSAIYAJIN;
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