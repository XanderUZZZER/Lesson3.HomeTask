using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3.HomeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tricks with cards\n");

            Card[] Deck = new Card[52];
            //creating a new sorted deck            
            for (int rankVal = 1; rankVal < 14; rankVal++)
            {
                for (int suitVal = 0; suitVal < 4; suitVal++)
                {
                    Deck[suitVal * 13 + rankVal - 1] = new Card() { suit = (Suit)suitVal, rank = (Rank)rankVal };
                }
            }

            Console.WriteLine("\tSorted deck\n----------------------------------------------");
            int counter = 0;
            for (int i = 0; i < 13; i++)
            {                
                for (int j = 0; j < 4; j++)
                {
                    string cardName = Deck[counter].rank + " of " + Deck[counter].suit;
                    Console.Write(" {1} {0,-19}\t",cardName, (counter +1 ));
                    counter++;
                }
                Console.WriteLine();
            }
                

            //shuffled deck
            Card tempCard;
            int n = 52;
            Random randomCard = new Random();
            while (n > 1)
            {
                int tempIndex = randomCard.Next(n--);
                tempCard = Deck[n];
                Deck[n] = Deck[tempIndex];
                Deck[tempIndex] = tempCard;
            }
            Console.WriteLine("\n\tShuffled deck\n----------------------------------------------");
            counter = 0;
            for (int i = 0; i < 13; i++)
            {                
                for (int j = 0; j < 4; j++)
                {
                    string cardName = Deck[counter].rank + " of " + Deck[counter].suit;
                    Console.Write(" {1} {0,-19}\t", cardName, (counter + 1));
                    counter++;
                }
                Console.WriteLine();
            }

            //Find the positions of all the aces in the deck
            Console.WriteLine("\n\tAces positions\n----------------------------------------------");
            for (int i = 0; i < 52; i++)
            {
                if (Deck[i].rank == Rank.Ace)
                    Console.WriteLine("The position of Ace of " + Deck[i].suit + " is #" + (i+1));
            }

            //Move all the Spades cards to the beginning of the deck
            for (int i = 0; i < 13; i++)
            {
                for (int j = 51; j >= 0; j--)
                {
                    if (Deck[j].suit == Suit.Spades)
                    {
                        tempCard = Deck[j];
                        Deck[j] = Deck[i];
                        Deck[i] = tempCard;
                    }
                }
            }

            Console.WriteLine("\n\tSprades sorted deck\n----------------------------------------------");
            counter = 0;
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    string cardName = Deck[counter].rank + " of " + Deck[counter].suit;
                    Console.Write(" {1} {0,-19}\t", cardName, (counter + 1));
                    counter++;
                }
                Console.WriteLine();
            }

            Console.ReadLine();

        }

        enum Suit
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades
        }
        enum Rank
        {
            Ace = 1,
            Deuce,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
        }
        struct Card
        {
            public Suit suit;
            public Rank rank;
        }
    }
}
