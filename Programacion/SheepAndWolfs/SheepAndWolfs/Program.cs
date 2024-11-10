namespace SheepAndWolfs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mundo mundo = new Mundo();
            Utils.GenerateRandomWorld(mundo);
        }
    }
}
