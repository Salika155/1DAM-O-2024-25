namespace PokerGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Card c1 = new Card();
            c1.Number = 1;
            c1.SetNumber(3);

            Card c2 = new Card()
            {
                Number = 5,
                Color = ColorType.BLACK,
                Kind = CardType.CLOVER
            };
            c2.SetNumber(10);

            Card c3 = new Card(10, ColorType.BLACK, CardType.CLOVER);
        }
    }
}
