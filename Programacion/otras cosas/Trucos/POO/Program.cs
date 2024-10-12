namespace POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game("A", 5)
            {
                Name = "SalikaGame",
                Prize = 1
            };
            var salikaGame2 = new Game("B", 3);
            salikaGame2.Name = "Trails";
            salikaGame2.Prize = 20;
        }
    }
}
