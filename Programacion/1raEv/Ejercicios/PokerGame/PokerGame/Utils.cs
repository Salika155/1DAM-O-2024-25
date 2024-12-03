using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            if (card.GetColor() == ColorType.RED)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write(card.GetNumber());
            Console.Write("-");
            //Console.Write(card.GetKind());
            PrintFigure(card.GetKind());
            Console.WriteLine();
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
            if (kind == CardType.SPADES)
                Console.Write("♠");
            //control + d para poner la misma linea 
        }

        //hacer el print del deck ->ToString
        public static void PrintAllDeck(Deck deck)
        {
            for (int i = 0; i < deck.GetCardCount(); i++)
            {
                Print(deck.GetCardAt(i));
            }
        }

        //Funcion (posible en utils) que le paso un deck y un numero de cartas y me devuelve un deck con las cartas extraidas
        //de manera aleatoria ese numero
        /// <summary>
        /// Esta funcion sirve para robar cartas...
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        /// //Si se tiran excepciones se indica el caso en que salga esa excepcion
        public static Deck DrawRandomCards(Deck deck, int number)
        {
            Deck dw = new Deck();

            //deck.Suffle();
            for (int i = 0; i < number && deck.GetCardCount() > 0; i++) //comprobacion extra
            {
                if (Utils.IsEmpty(deck))
                    break;//romper el bucle
                int randomIndex = Utils.GetRandom(0, deck.GetCardCount() - 1);
                Card card = deck.DrawCardAt(randomIndex)!;
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

            for (int i = 0; i < number; i++)
            {
                if (Utils.IsEmpty(deck))
                    return dw;
                Card? c = deck.DrawCard()!;
                dw.Add(c);

            }
            return dw;
        }

        //le paso dos deck y me devuelve un nuevo deck con todo lo que hay en los dos decks (Clone) crea una copia de todo
        //lo que hay en los dos decks

        public static Deck MergeDecks(Deck? deck1, Deck? deck2)
        {
            Deck dw = new Deck();
            if (deck1 == null && deck2 == null)
                return dw;
            if (deck1 == null)
                return deck2!.Clone();
            if (deck2 is null)
                return deck1!.Clone();

            //Deck clone1 = CloneDeck(deck1);
            for (int i = 0; i < deck1.GetCardCount(); i++)
            {
                dw.Add(deck1.GetCardAt(i));
            }

            //Deck clone2 = CloneDeck(deck2);
            for (int i = 0; i < deck2.GetCardCount(); i++)
            {
                dw.Add(deck2.GetCardAt(i));
            }
            return dw;

            //Hacer un gestor de Aulas, las aulas tienen estudiantes, y los estudiantes tienen notas de asignaturas. Las clases tienen nombre y lista de alumnos
            //cada estudiante tiene nombre, sexo, edad, lista de notas. Son un enum las asignaturas -> cada asignatura tiene su lista de notas
            //OP1: student tiene instancias de Notes por cada asignatura
            //OP2: student tiene un array de notas 
            //truco enum: poner las asignaturas y poner una ultima con Count, asi siempre tienens el numero de elementos
            //_notes = new Notes[Subject.Count] -> Subject el nombre del enum
            //OP3: Una lista de Notas inicializada a 0
            //OP4: En vez de Listas puedes hacer un Enum y un doble con la nota
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

//        /*
//Welcome to JDoodle!

//You can execute code here in 88 languages. Right now you’re in the Java IDE.

//  1. Click the orange Execute button ▶ to execute the sample code below and see how it works.

//  2. Want help writing or debugging code? Type a query into JDroid on the right hand side ---------------->

//  3.Try the menu buttons on the left. Save your file, share code with friends and open saved projects.

//Want to change languages? Try the search bar up the top.
//*/

//        public class MyClass
//        {

//            public static int sumarNumero(int a, int b) throws Exception
//            {
//        if(a<b)
//            throw new Exception("tonto");
//        return a + b;
//    }
//        public static void main(String args[])
//        {
//            try
//            {
//                int sum = sumarNumero(1, 2);
//                System.out.println("Hola Mundo" + sum);
//            }
//            catch (Exception ex)
//    System.err.println("me cago en javi");
//            }
//        }
//    }
}

