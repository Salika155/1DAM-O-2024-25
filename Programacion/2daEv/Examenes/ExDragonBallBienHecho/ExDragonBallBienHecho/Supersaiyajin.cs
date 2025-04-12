namespace ExDragonBallBienHecho
{
    internal class Supersaiyajin : Persona
    {
        private string name;

        public Supersaiyajin(string name, double energia, double deseoEsquivar)
        {
            this.name = name;
            Energia = energia;
            DeseoEsquivar = deseoEsquivar;
        }
    }
}