

namespace PokerGame
{
    internal class Card
    {
        private int _number;
        public CardType _kind;
        public ColorType _color;
        
        public Card()
        {

        }

        public Card(int number, ColorType color , CardType kind)
        {
            //this.Number = number;
            //this.Color = color;
            //this.Kind = kind;
            _number = number;
            _color = color;
            _kind = kind;
            //this. hace referencia al mas cercano, en este caso la variable number que esta en Card por parametro()
        }

        public Card(ColorType color, CardType kind, int number)
        {

        }

        //setter siempre con value de nombre
        public void SetNumber(int value)
        {
            if (value > 13 || value < 1)
                return;
            _number = value;
        }

        public int GetNumber()
        {
            return this._number;
        }

        public void SetColor(ColorType value)
        {
            _color = value;
        }
    }
}
