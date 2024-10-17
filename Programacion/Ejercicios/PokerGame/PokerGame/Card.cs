using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    internal class Card
    {
        public int Number;
        public CardType Kind;
        public ColorType Color;
        
        public Card()
        {

        }

        public Card(int number, ColorType color , CardType kind)
        {
            this.Number = number;
            this.Color = color;
            this.Kind = kind;
        }

        public void SetNumber(int number)
        {
            this.Number = number;
        }
    }
}
