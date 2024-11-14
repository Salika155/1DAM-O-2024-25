namespace SheepAndWolfs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mundo mundo = new(40, 30);
            Utils.GenerateRandomWorld(mundo);

            Lobo lobo = new Lobo("lobo1");
            Oveja oveja = new Oveja();

            Animal l = oveja;
        }
    }
}
