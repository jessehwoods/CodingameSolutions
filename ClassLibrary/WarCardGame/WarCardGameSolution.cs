﻿
namespace WarCardGame
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Text;

    /**
     * Solution for the puzzle at https://www.codingame.com/training/medium/winamax-battle
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

            Console.WriteLine(solver.solve());
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
                // Don't care about the suit, so stripping off the last character
                string value = valueAndSuit.Substring(0, valueAndSuit.Length - 2);
                if (int.TryParse(value, out int x)) // Value is a a number
                {
                    player1Deck.Enqueue(x);
                }
                else if (FACE_CARDS.TryGetValue(value[0], out x))// Value is a face card
                {
                    player2Deck.Enqueue(x);
                }
            }

            /**
             * Compares cards until there is a winner or pat, 
             * If there's a winner then it returns a string in the format "{0} {1}", player_number, turns.
             * If a player runs out of cards during a war, returns the appropriate string for pat.
             */
            internal string Solve()
            {
                //TODO

            }

            public override string ToString()
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append("Player 1 deck: ");
                foreach (var card in player1Deck)
                {
                    stringBuilder.Append(card + ",");
                }
                stringBuilder.Append("Player 2 deck: ");
                foreach (var card in player2Deck)
                {
                    stringBuilder.Append(card + ",");
                }
                return stringBuilder.ToString();
            }
        }
    }
}
