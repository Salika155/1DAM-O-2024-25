
namespace ExDragonBallBienHecho
{
    public enum RazaType
    {
        HUMANO,
        GUERREROESPACIO,
        SUPERSAIYAJIN
    }
    public abstract class Persona
    {
        private readonly string? _name = string.Empty;
        private readonly RazaType _raza;
        private double _energy;
        private double _deseoEsquivar;

        public string? Name { get => _name; }
        public RazaType Raza { get => GetRaza(); }

        public double Energia { get => _energy; set => _energy = value; }
        public double DeseoEsquivar { get => _deseoEsquivar; set => _deseoEsquivar = value; }

        public Persona(string? name, double energy, double deseoEsquivar, RazaType raza)
        {
            _name = name;
            _raza = raza;
            _energy = energy;
            _deseoEsquivar = deseoEsquivar;
        }

        public void QuitarEnergia(double energia)
        {
            if (energia <= 0)
                return;
            Energia -= energia;
        }

        public abstract void Atacar(Persona p);
        public abstract double ObtenerCapacidadEsquiva();
        public abstract double ObtenerCapacidadParada();
        public bool QuiereEsquivar()
        {
            double esquivar = Utils.GetRandomDouble(0, 1);
            if (esquivar > _deseoEsquivar)
                return true;
            return false;
        }

        public static Persona CrearPersona(string name, RazaType raza)
        {
            double energia = Utils.GetRandomDouble(1000, 2000);
            double deseoEsquivar = Utils.GetRandomDouble(0.1, 0.9);

            switch(raza)
            {
                case RazaType.HUMANO:
                    return new Humano(name, energia, deseoEsquivar);
                case RazaType.GUERREROESPACIO:
                    return new GuerreroEspacio(name, energia, deseoEsquivar);
                case RazaType.SUPERSAIYAJIN:
                    return new Supersaiyajin(name, energia, deseoEsquivar);
                default:
                    throw new ArgumentException("Raza desconocida");
            }
        }

        public abstract RazaType GetRaza();
        

    }
}