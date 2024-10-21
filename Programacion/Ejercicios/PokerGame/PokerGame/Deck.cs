

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

        public void Add(int number, ColorType color, CardType kind)
        {

        }

        public Card DrawCard()
        {
            return null;
        }

        public void RemoveAt(int index)
        {


        }

        public void Remove(Card card)
        { 
        
        }

        public void Remove(int number, ColorType color, CardType kind)
        {

        }

        public void Suffle()
        {

        }

        public bool Contains(int index, ColorType color, CardType kind)
        {
            return false;
        }

        public bool Contains(Card card)
        {
            return true;
        }

        public int IndexOf(int index, ColorType color, CardType kind)
        {
            return 0;
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
