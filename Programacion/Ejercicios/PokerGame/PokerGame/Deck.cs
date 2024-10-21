

namespace PokerGame
{
    public class Deck
    {
        private readonly List<Card> _cardList = new List<Card>();
        //cardlist no va a apuntar a otra lista.

        //que cosas quiero hacer con una baraja
        public void Add(Card card)
        {
            if (card == null)
                return;
            if (card.IsValid() == false)
                return;
            if (Contains(card))
                return;
            _cardList.Add(card);
        }

        public void Add(int number, CardType kind)
        {
            Card? newCard = Card.Create(number, kind);

            if (newCard == null || Contains(newCard))
                return;
            _cardList.Add(newCard);
        }

        public Card DrawCard()
        {
            if (_cardList.Count == 0)
                throw new Exception("No hay cartas");
            Card card = _cardList[_cardList.Count - 1];
            _cardList.RemoveAt(_cardList.Count - 1);
            return card;

        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _cardList.Count)
                return;
            _cardList.RemoveAt(index);
        }

        public void Remove(Card card)
        {
            if(!card.IsValid())
                return;

            for(int i = 0; i < _cardList.Count; i++)
                if (_cardList[i].Number == card.Number && _cardList[i].Kind == card.Kind)
                    _cardList.RemoveAt(i);

        }

        public void Remove(int number, CardType kind)
        {
            for (int i = 0; i < _cardList.Count; i++)
                if (_cardList[i].Number == number && _cardList[i].Kind == kind)
                    _cardList.RemoveAt(i);
        }

        public void Suffle()
        {
            Random random = new Random();

            for(int i = 0; i < _cardList.Count ; i++)
            {
                int randomIndex = random.Next(i, _cardList.Count);

                Card aux = _cardList[i];
                _cardList[i] = _cardList[randomIndex];
                _cardList[randomIndex] = aux;
            }
        }

        public bool Contains(int number, CardType kind)
        {
            foreach(Card card in _cardList)
            {
                if(card.GetNumber() == number && card.GetKind() == kind)
                    return true;
            }
            return false;
        }

        public bool Contains(Card card)
        {
            foreach(Card c in _cardList)
            {
                if (c.GetNumber() ==  card.GetNumber() && c.GetKind() == card.Kind) 
                    return true;
            }
            return false;
        }

        public int IndexOf(int number, CardType kind)
        {
            for(int i = 0; i < _cardList.Count; i++) 
            {
                Card card = _cardList[i];
                if (card.GetNumber() == number && card.GetKind() == kind)
                    return i;
            }
            return -1;
        }

        public int GetCardCount()
        {
            return _cardList.Count;
        }

        //si quiero lanzar excepcion se pondria ?, si no, y solo es un null se deja igual y se retorna null
        public Card GetCardAt(int index)
        {
            if(index < 0 || index >= GetCardCount())
                throw new IndexOutOfRangeException("Posicion invalida");
            //opcion 1 -> return excepcion;
            return _cardList[index];
            //opcion 2 -> return null con el ?;

        }

        public void Init()
        {
            Add(Card.Create(1, CardType.HEARTS));
        }
    }
}
