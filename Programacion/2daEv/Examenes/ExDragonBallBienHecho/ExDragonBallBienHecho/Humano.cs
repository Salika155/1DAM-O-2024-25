namespace ExDragonBallBienHecho
{
    internal class Humano : Persona
    {
        private string name;

        public Humano(string name, double energia, double deseoEsquivar)
        {
            this.name = name;
            Energia = energia;
            DeseoEsquivar = deseoEsquivar;
        }
    }
}