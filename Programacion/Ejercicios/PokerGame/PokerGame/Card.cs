

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

        public int Number
        {
            get { return _number; }
            set { SetNumber(value); } 
        }

        public ColorType Color
        {
            get { return _color; }
            set { _color = value; } 
        }

        public CardType Kind
        {
            get { return _kind; }
            set { _kind = value; } 
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
            if (ColorType.RED == value)
                _color = ColorType.RED;
            else
                _color = ColorType.BLACK;
            //_color = value;
        }

        public ColorType GetColor(Card card) 
        {
           if(ColorType.RED == card._color)
                return ColorType.RED;
           else
                return ColorType.BLACK;
           //return _color;
        }
        public ColorType GetColor()
        {
            return _color;
        }

        public void SetKind(CardType kind) 
        {
            if (CardType.HEARTS == kind)
                _kind = CardType.HEARTS;
            if (CardType.CLOVER == kind)
                _kind = CardType.CLOVER;
            if (CardType.DIAMOND == kind)
                _kind = CardType.DIAMOND;
            if (CardType.SPADES == kind)
                _kind = CardType.SPADES;
            //_kind = kind;
        }

        public CardType GetKind(Card card) 
        {
            if (CardType.HEARTS == card._kind)
                return CardType.HEARTS;
            else if (CardType.CLOVER == card._kind)
                return CardType.CLOVER;
            else if (CardType.DIAMOND == card._kind)
                return CardType.DIAMOND;
            else
                return CardType.SPADES;
            //return _kind
        }
        public CardType GetKind()
        {
            return _kind;
        }
    }
}
