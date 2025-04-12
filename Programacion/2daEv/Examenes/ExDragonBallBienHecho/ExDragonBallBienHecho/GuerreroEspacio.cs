namespace ExDragonBallBienHecho
{
    internal class GuerreroEspacio : Persona
    {
        private string name;

        public GuerreroEspacio(string name, double energia, double deseoEsquivar)
        {
            this.name = name;
            Energia = energia;
            DeseoEsquivar = deseoEsquivar;
        }
    }
}