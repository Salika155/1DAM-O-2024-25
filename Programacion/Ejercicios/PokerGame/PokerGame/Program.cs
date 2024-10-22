using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;

namespace PokerGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Card c1 = new Card();
            //c1.GetNumber();
            //c1.SetNumber(3);
            //int n = c1.GetNumber();

            //este es uno de las mejores maneras para meterselo ya que no depende del orden de introducir elementos
            //Card c2 = new Card()
            //{
            //    Number = 5,
            //    Color = ColorType.BLACK,
            //    Kind = CardType.CLOVER
            //};
            //c2.SetNumber(10);
            //int n2 = c2.GetNumber();

            //Card c3 = new Card(10, ColorType.BLACK, CardType.CLOVER);
            //Card c32 = new Card(ColorType.BLACK, CardType.CLOVER, 10);
            //int n3 = c3.GetNumber();

            //Card c4 = new Card();
            //int n4 = c4.GetNumber();

            // al ser creado por la funcion create, no necesito el new delante del card a la hora de  crearlo
            //Card c5 = Card.Create(10, ColorType.BLACK, CardType.DIAMOND);

            Deck deck = new Deck();
            deck.Init();
            deck.Add(1, CardType.HEARTS);
            deck.Add(5, CardType.SPADES);
            deck.Add(8, CardType.CLOVER);
            deck.Add(10, CardType.DIAMOND);
            deck.Add(12, CardType.CLOVER);
            deck.Add(15, CardType.CLOVER);
            deck.Add(75, CardType.CLOVER);

            deck.Suffle();

            deck.GetCardCount();

            deck.Contains(1, CardType.HEARTS);

            deck.RemoveAt(0);

            deck.IndexOf(8, CardType.SPADES);
            deck.IndexOf(10, CardType.DIAMOND);

            deck.GetCardAt(3);



            //para quitar warning en init de constructor si devuelve null se pone ! al final
        }
    }
}
