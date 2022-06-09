[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("WarCardGameTests")]

namespace WarCardGame
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /**
     * Solution for the puzzle at https://www.codingame.com/training/medium/winamax-battle
     * Successful as of 6/9/2022
     **/
    class Solution
    {
        static void Main(string[] args)
        {
            var solver = new Solver();

            int n = int.Parse(Console.ReadLine()); // the number of cards for player 1
            for (int i = 0; i < n; i++)
            {
                string cardp1 = Console.ReadLine(); // the n cards of player 1
                solver.AddCard(1, cardp1);
            }
            int m = int.Parse(Console.ReadLine()); // the number of cards for player 2
            for (int i = 0; i < m; i++)
            {
                string cardp2 = Console.ReadLine(); // the m cards of player 2
                solver.AddCard(2, cardp2);
            }

            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine(solver.Solve());
        }

        internal class Solver
        {
            private static string PAT = "PAT"; // Return in event of a tie
            private Queue<int> player1Deck;
            private Queue<int> player2Deck;
            private Dictionary<char, int> FACE_CARDS = new Dictionary<char, int>
            {
                {'J' , 11 },
                {'Q' , 12 },
                {'K' , 13 },
                {'A' , 14 }
            };

            public Solver()
            {
                player1Deck = new Queue<int>();
                player2Deck = new Queue<int>();
            }

            /**
             * Adds a card to the deck for a specified player.
             */
            internal void AddCard(int player, string valueAndSuit)
            {
                Queue<int> deckToUse = null;
                //Figure out which deck to use
                switch (player)
                {
                    case 1:
                        deckToUse = player1Deck;
                        break;
                    case 2:
                        deckToUse = player2Deck;
                        break;
                    default:
                        throw new ArgumentException("Player number not recognized.");
                }
                // Don't care about the suit, so stripping off the last character
                string value = valueAndSuit.Substring(0, valueAndSuit.Length - 1);
                if (int.TryParse(value, out int x)) // Value is a a number
                {
                    deckToUse.Enqueue(x);
                }
                else if (FACE_CARDS.TryGetValue(value[0], out x))// Value is a face card
                {
                    deckToUse.Enqueue(x);
                }
            }

            /**
             * Draws two cards and compares them. Gives the cards to the winner (first player card, then second player card)
             * If tied, draws three cards and adds them to the pot then compares again until no tie.
             */
            internal void Move()
            {
                // Get the cards ready
                var player1CardsToWin = new Queue<int>();
                var player2CardsToWin = new Queue<int>();

                var player1Card = player1Deck.Dequeue();
                player1CardsToWin.Enqueue(player1Card);

                var player2Card = player2Deck.Dequeue();
                player2CardsToWin.Enqueue(player2Card);

                var tied = player1Card == player2Card; // Used to check for tie and determine winner
                while (tied) // War happens here
                {
                    for(int i = 0; i < 3; i++) //Draw three cards
                    {
                        player1CardsToWin.Enqueue(player1Deck.Dequeue());
                        player2CardsToWin.Enqueue(player2Deck.Dequeue());
                    }
                    player1Card = player1Deck.Dequeue();
                    player1CardsToWin.Enqueue(player1Card);

                    player2Card = player2Deck.Dequeue();
                    player2CardsToWin.Enqueue(player2Card);

                    tied = player1Card == player2Card;
                }
                // Assert: the cards are not tied
                Queue<int> deckToAdd = null;
                switch (player1Card > player2Card)
                {
                    case true:
                        deckToAdd = player1Deck;
                        break;
                    case false:
                        deckToAdd = player2Deck;
                        break;
                }
                foreach (var card in player1CardsToWin)
                {
                    deckToAdd.Enqueue(card);
                }
                foreach (var card in player2CardsToWin)
                {
                    deckToAdd.Enqueue(card);
                }
            }

            /**
            * Compares cards until there is a winner or pat, 
            * If there's a winner then it returns a string in the format "{0} {1}", player_number, turns.
            * If a player runs out of cards during a war, returns the appropriate string for pat.
            */
            internal string Solve()
            {
                int rounds = 0;
                while(player1Deck.Count > 0 && player2Deck.Count > 0){
                    rounds++;
                    try
                    {
                        Move();
                    } catch (InvalidOperationException) {
                        return PAT;
                    }
                }
                int player = 0; // Default value to be replaced.
                switch (player1Deck.Count == 0)
                {
                    case true :
                        player = 2;
                        break;
                    case false:
                        player = 1;
                        break;
                }
                return String.Format("{0} {1}", player, rounds);
            }

            public override string ToString()
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append("Player 1:");
                foreach (var card in player1Deck)
                {
                    stringBuilder.Append(" " + card);
                }
                stringBuilder.Append("\nPlayer 2:");
                foreach (var card in player2Deck)
                {
                    stringBuilder.Append(" " + card);
                }
                return stringBuilder.ToString();
            }

        }
    }
}

