

namespace PokerGame
{
    public class Deck
    {
        private readonly List<Card> _cardList = new List<Card>();
        //cardlist no va a apuntar a otra lista.

        //que cosas quiero hacer con una baraja
        //en depuracion esto repite palos
        public void Add(Card? card) //si pongo aqui el interrogante, te puedes ahorrar la comprobacion en el otro metodo Add del null
        {
            if (card == null)
                return;
            if (!card.IsValid())
                return;
            if (Contains(card))
                return;
            _cardList.Add(card);
            //Console.WriteLine($"Carta añadida: {card.GetNumber()} de {card.GetKind()}"); // Mensaje de depuración
        }

        public void Add(int number, CardType kind)
        {
            Card? newCard = Card.Create(number, kind);

            //if (newCard == null)
            //    return;
            Add(newCard);
        }

        public Card? DrawCard() //si le pongo el ? me ahorraria la comprobacion de si la lista esta vacia
        {
            //if (_cardList.Count == 0)
            //    throw new Exception("No hay cartas");
            //if (_cardList.Count == 0)
            //    return null;
            //int index = _cardList.Count - 1;
            //forma 1 java
            //var card = GetCardAt(GetCardCount() - 1);
            //RemoveAt(GetCardCount() - 1);
            //var card = _cardList[index];
            //_cardList.RemoveAt(index);
            //return card;
            return DrawCardAt(GetCardCount() - 1);
        }

        public Card? DrawCardAt(int index)
        {
            //if (_cardList.Count == 0)
            //    throw new Exception("No hay cartas");
            //if (_cardList.Count == 0)
            //    return null;

            //forma 1 java
            var card = GetCardAt(index);
            if (card != null)
                RemoveAt(index);
            return card;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= GetCardCount())
                return;
            _cardList.RemoveAt(index);
        }

        public void Remove(Card card)
        {
            //if(!card.IsValid())
            //    return;
            //int index = IndexOf(card);
            //if (index >= 0)
            //    RemoveAt(index);
            //for(int i = 0; i < _cardList.Count; i++)
            //    if (_cardList[i].Number == card.Number && _cardList[i].Kind == card.Kind)
            //        _cardList.RemoveAt(i);
            //Forma correcta corta:
            RemoveAt(IndexOf(card));

        }

        public void Remove(int number, CardType kind)
        {
            int index = IndexOf(number, kind);
            RemoveAt(index);

            //for (int i = 0; i < _cardList.Count; i++)
            //    if (index >= 0)
            //        _cardList.RemoveAt(i);
        }

        public void Suffle()
        {
            int n = GetCardCount() - 1;
            for (int i = 0; i < 1000; i++)
            {
                int n1 = Utils.GetRandom(0, n);
                int n2 = Utils.GetRandom(0, n);

                Card aux = _cardList[n1];
                _cardList[n1] = _cardList[n2];
                _cardList[n2] = aux;
            }
        }

        public bool Contains(int number, CardType kind)
        {
            //foreach(Card card in _cardList)
            //{
            //    if(card.GetNumber() == number && card.GetKind() == kind)
            //        return true;
            //}
            //return false;
            return IndexOf(number, kind) >= 0;
        }

        //esto he tenido que cambiarlo
        public bool Contains(Card card)
        {
            //foreach(Card c in _cardList)
            //{
            //    if (c.GetNumber() ==  card.GetNumber() && c.GetKind() == card.Kind) 
            //        return true;
            //}
            //return false;
            if (card == null)
                return false;
            foreach (var c in _cardList)
            {
                if (Card.AreEquals(c, card)) // Usar AreEquals para comparar cartas
                    return true;
            }
            //return Contains(card.GetNumber(), card.GetKind());
            return false;
        }

        public int IndexOf(int number, CardType kind)
        {
            int n = GetCardCount();
            for (int i = 0; i < n; i++)
            {
                Card card = _cardList[i];
                if (card.GetNumber() == number && card.GetKind() == kind)
                    //if (_cardList[i] == c)
                    return i;
                //posible solucion
                if (Card.AreEquals(_cardList[i], card))
                    return i;
            }

            return -1;
        }

        public int IndexOf(Card? card)
        {
            if (card == null)
                return -1;
            return IndexOf(card.GetNumber(), card.GetKind());
        }

        public int GetCardCount()
        {
            return _cardList.Count;
        }

        //si quiero lanzar excepcion se pondria ?, si no, y solo es un null se deja igual y se retorna null
        public Card GetCardAt(int index)
        {
            if (index < 0 || index >= GetCardCount())
                throw new IndexOutOfRangeException("Posicion invalida");
            //opcion 1 -> return excepcion;
            return _cardList[index];
            //opcion 2 -> return null con el ?;

        }

        public void Init()
        {
            _cardList.Clear();
            //Add(Card.Create(1, CardType.HEARTS));
            InitFigure(CardType.CLOVER);
            InitFigure(CardType.DIAMOND);
            InitFigure(CardType.HEARTS);
            InitFigure(CardType.SPADES);
        }


        private void InitFigure(CardType type)
        {
            for (int i = 1; i <= 13; i++)
            {
                Add(Card.Create(i, type));
                //Console.WriteLine($"Creando carta: {i} de {type}"); // En InitFigure
            }
        }

        public Deck Clone() //no tiene sentido la ? porque se va a clonar algo que existe ya
        {
            Deck result = new Deck();
            for(int i = 0; i < GetCardCount(); i++)
            {
                //puede ser Add(c.Clone()); o como esta
                Card c = GetCardAt(i);
                result.Add(c);
            }
            return result;
        }
    }
    
}
