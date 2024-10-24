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
            Console.WriteLine();
            //control + d para poner la misma linea 
        }

        public static void PrintFigure(CardType kind)
        {
            if (kind == CardType.DIAMOND)
                Console.Write("♦");
            else if (kind == CardType.CLOVER)
                Console.Write("♣");
            else if (kind == CardType.HEARTS) 
                Console.Write("♥");
            else 
                Console.Write("♠");
            //control + d para poner la misma linea 
        }

        //hacer el print del deck ->ToString
        public static void PrintAllDeck(Deck deck)
        {
           for(int i = 0; i < deck.GetCardCount(); i++)
           {
                Print(deck.GetCardAt(i));
           }
        }

        //Funcion (posible en utils) que le paso un deck y un numero de cartas y me devuelve un deck con las cartas extraidas
        //de manera aleatoria ese numero
        public static Deck DrawRandomCards(Deck deck, int number)
        {
            Deck dw = new Deck();

            deck.Suffle();
            for(int i = 0; i < number; i++)
            {
                if(Utils.IsEmpty(deck))
                    return deck;
                int randomIndex = Utils.GetRandom(0, deck.GetCardCount() - 1);
                Card? card = deck.DrawCardAt(randomIndex);
                dw.Add(card);
                
            }
            return dw;
        }

        public static bool IsEmpty(Deck deck)
        {
            return deck.GetCardCount() == 0;
        }

        //Deck que le paso un numero y devuelve otro deck, cogiendo las 6 primeras cartas (DrawCard ya esta implementado)
        public static Deck DrawChainedCards(Deck deck, int number)
        {
            Deck dw = new Deck();

            for(int i = 0; i < number; i++)
            {
                if(Utils.IsEmpty(deck))
                    return dw;
                Card? c = deck.GetCardAt(number);
                dw.Add(c);
                
            }
            return dw;
        }

        //le paso dos deck y me devuelve un nuevo deck con todo lo que hay en los dos decks (Clone) crea una copia de todo
        //lo que hay en los dos decks

        public static Deck MergeDecks(Deck deck1, Deck deck2)
        {
            Deck dw = new Deck();

            Deck clone1 = CloneDeck(deck1);
            for(int i = 0; i < deck1.GetCardCount(); i++)
            {
                dw.Add(clone1.GetCardAt(i));
            }

            Deck clone2 = CloneDeck(deck2);
            for(int i = 0; i < deck2.GetCardCount(); i++)
            {
                dw.Add(clone2.GetCardAt(i));
            }
            return dw;
        }

        public static Deck CloneDeck(Deck deck)
        {
            Deck newDeck = new Deck();

            for (int i = 0; i < deck.GetCardCount(); i++)
            {
                Card c = deck.GetCardAt(i);
                if (c == null)
                    return newDeck;
                newDeck.Add(c);
            }
            return newDeck;
        }
    }
}

