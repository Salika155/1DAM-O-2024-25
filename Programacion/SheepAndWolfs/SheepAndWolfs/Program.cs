namespace SheepAndWolfs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mundo mundo = new(40, 30);
            Utils.GenerateRandomWorld(mundo);


            mundo.CreateWolfs(5);
            mundo.CreateSheeps(5);
            //Lobo lobo = new Lobo("lobo1");
            //Oveja oveja = new Oveja();

            //Animal l = oveja;
        }
    }
}
