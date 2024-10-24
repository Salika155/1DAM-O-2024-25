

namespace PokerGame
{
    public class Card
    {
        private int _number;
        public CardType _kind;
        //public ColorType _color;
        

        //politica 1. Corregir valores. -> condicion if 
        //politica 2. Petar -> errores
        //politica 3. Deja constructor pro defecto, poner constructor en private
        private Card(int number, CardType kind)
        {
            if (number >= 1 && number <= 13)
                _number = number;
            else
                //_number = 0;
                throw new Exception("Te ha petao socio");
            //this.Number = number;
            //this.Color = color;
            //this.Kind = kind;
            
            //_color = color;
            _kind = kind;
            //this. hace referencia al mas cercano, en este caso la variable number que esta en Card por parametro()
        }

        //cuando el objeto pueda ser null, bien sea parametro de entrada o lo que devuelvas mejor poner "?"lñç

        public static Card? Create(int number, CardType kind)
        {
            if (number < 1)
                return null;
            if (number > 13)
                return null;
            return new Card(number, kind);
        }
        public bool IsValid()
        {
            if (_number <= 0)
                return false;
            return true;
            //return number > 0 
        }

        //public Card(CardType kind, int number)
        //{

        //}

        //public int Number
        //{
        //    get { return _number; }
        //    set { SetNumber(value); } 
        //}

        //public ColorType Color
        //{
        //    get { return _color; }
        //    set { _color = value; } 
        //}

        public CardType Kind
        {
            get { return _kind; }
            set { _kind = value; } 
        }


        //setter siempre con value de nombre
        //public void SetNumber(int value)
        //{
        //    if (value > 13 || value < 1)
        //        return;
        //    _number = value;
        //}

        public int GetNumber()
        {
            return _number;
        }

        //public void SetColor()
        //{
            
        //}

        //public ColorType GetColor(Card card) 
        //{
        //   if(ColorType.RED == card._color)
        //        return ColorType.RED;
        //   else
        //        return ColorType.BLACK;
        //   //return _color;
        //}
        public ColorType GetColor()
        {
            if (_kind == CardType.SPADES || _kind == CardType.CLOVER)
                return ColorType.BLACK;
            return ColorType.RED;
        }

        //public void SetKind(CardType kind) 
        //{
        //    if (CardType.HEARTS == kind)
        //        _kind = CardType.HEARTS;
        //    if (CardType.CLOVER == kind)
        //        _kind = CardType.CLOVER;
        //    if (CardType.DIAMOND == kind)
        //        _kind = CardType.DIAMOND;
        //    if (CardType.SPADES == kind)
        //        _kind = CardType.SPADES;
        //    //_kind = kind;
        //}

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

        public static bool AreEquals(Card a, Card b)
        {
            return a.GetNumber() == b.GetNumber() && a.GetKind() == b.GetKind();
        }

        //public static bool operator == (Card? a, Card? b)
        //{
        //    return a.GetNumber() == b.GetNumber() && a.GetKind() == b.GetKind();
        //}
        //public static bool operator != (Card? a, Card? b)
        //{
        //    return !(a == b);
        //}

        public Card Clone()
        {
            Card c = new Card(_number, _kind);
            return c;
        }
    }
}
