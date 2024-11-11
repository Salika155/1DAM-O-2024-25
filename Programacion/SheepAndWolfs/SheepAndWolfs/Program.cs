namespace SheepAndWolfs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mundo mundo = new(40, 30);
            Utils.GenerateRandomWorld(mundo);
        }
    }
}
