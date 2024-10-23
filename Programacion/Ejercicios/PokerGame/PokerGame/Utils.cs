using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    public class Utils
    {
        private static readonly Random _random = new Random();
        public static int GetRandom(int min, int max)
        {
            return _random.Next(min, max + 1);
        }

        public static void Print(Card card)
        {
            if (card == null)
                return;
            if(card.GetColor() == ColorType.RED)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write(card.GetNumber());
            Console.Write("-");
            PrintFigure(card.GetKind());
            //control + d para poner la misma linea 
        }

        public static void PrintFigure(CardType kind)
        {

            if (kind == CardType.DIAMOND)
                Console.Write("♦");
            if (kind == CardType.CLOVER)
                Console.Write("♣");
            if (kind == CardType.HEARTS) 
            Console.Write("♥");
            else
                Console.Write("♠");
            //control + d para poner la misma linea 
        }
    }
}
