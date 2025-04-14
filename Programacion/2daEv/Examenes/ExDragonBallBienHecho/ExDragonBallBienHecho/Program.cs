namespace ExDragonBallBienHecho
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITorneo torneo = new Torneo(); // Cambiar a una clase concreta que implemente ITorneo
            torneo.Init();
        }
    }
}
