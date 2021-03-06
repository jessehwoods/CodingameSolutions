using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("ShadowOfTheKnightEp1Tests")]

namespace ShadowOfTheKnightEp1
{
    /**
     * This is a solution to the puzzle at https://www.codingame.com/training/medium/shadows-of-the-knight-episode-1
     * Solution correct as of 5/31/2022
     **/
    class Player
    {

        static void Main(string[] args)
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int W = int.Parse(inputs[0]); // width of the building.
            int H = int.Parse(inputs[1]); // height of the building.
            Console.ReadLine(); // maximum number of turns before game over. Not needed, so not saving.
            inputs = Console.ReadLine().Split(' ');
            int X0 = int.Parse(inputs[0]);
            int Y0 = int.Parse(inputs[1]);

            //Solver object to hold the data and get a solution.
            var solver = new Solver(W, H, X0, Y0);

            // game loop
            while (true)
            {
                string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)

                //  Put the next move from the Solver object
                solver.NextMove(bombDir);

                // Return the next move 
                Console.WriteLine(solver.ToString());
            }
        }

        /**
         * Used to get the solution to the problem by applying binary search.
         * Initialized to a grid and then given directions, it will apply binary search and update its' state whenever
         * a new move is requested.
         */
        internal class Solver
        {
            private int max_width; // Highest width value to use
            private int max_height; // Highest height value to use
            private int min_width; // Lowest width value to use
            private int min_height; //Lowest height value to use
            private int xPosition; // X position of most recently checked node
            private int yPosition; // Y position of most recently checked node

            enum directionInput // Valid directions that can be included in input
            {
                U,
                R,
                D,
                L,
            }

            public override string ToString()
            {
                return String.Format("{0} {1}", xPosition, yPosition);
            }

            public Solver(int width, int height, int x0, int y0)
            {
                if (width <= 0 || height <= 0 || x0 > width || x0 < 0 || y0 > height || y0 < 0)
                {
                    throw new ArgumentException("Invalid game setup.");
                }
                this.max_width = width;
                this.max_height = height;
                this.min_width = 0;
                this.min_height = 0;
                this.xPosition = x0;
                this.yPosition = y0;
            }

            internal int getX()
            {
                return xPosition;
            }

            internal int getY()
            {
                return yPosition;
            }

            /**
            * This takes in a string representing the direction to the next solution. 
            * It will calculate the next place to check, using a binary search algorithm, and then
            * updates the state of the Solver object to reflect the next move in the binary search.
            * 
            * Valid direction input strings are U, UR, R, DR, D, DL, L or UL.
            * 
            * Returns the coordinate of the next place to search as a string coordinate in the form "x y".
            */
            internal void NextMove(string bombDir)
            {
                //Make sure it's a valid size
                if (bombDir.Length < 1 || bombDir.Length > 2)
                {
                    throw new ArgumentException("Input string must be one or two characters");
                }
                // Make the move for the first one
                MakeMove(bombDir[0], bombDir.Length == 2, false);
                // Make the move the second one, if applicable
                if (bombDir.Length == 2)
                {
                    MakeMove(bombDir[1], true, true);
                }
            }

            /**
             * Helper class to interpret the direction and update the state of the Solver object.
             * twoPart tells you if there are two letters in the input string
             * second tells you if this is the second letter in the input string
             */
            private void MakeMove(char dir, Boolean twoPart, Boolean second)
            {
                directionInput direction;
                if (Enum.TryParse(dir.ToString(), out direction))
                {
                    switch (direction)
                    {
                        case directionInput.U when (!second): // Can never be second
                            max_height = yPosition; // Can't be any farther down than this.
                            yPosition = ReduceDistance(min_height, yPosition); // Decrease y value
                            break;

                        case directionInput.R when (!twoPart ^ second): // Can only be second if there are two
                            min_width = xPosition; // Can't be any farther left than this
                            xPosition = ReduceDistance(xPosition, max_width); // Increase x value
                            break;

                        case directionInput.D when (!second): // Can never be second
                            min_height = yPosition; // Can't be less than this
                            yPosition = ReduceDistance(yPosition, max_height); //Increase y value
                            break;

                        case directionInput.L when (!twoPart ^ second): // Can only be second if there are two
                            max_width = xPosition; // Can't be any farther right than this
                            xPosition = ReduceDistance(min_width, xPosition); // Decrease x value
                            break;
                        default:
                            throw new ArgumentException("Improperly formatted input direction.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("That input direction was not recognized.");
                }
            }

            // Takes two numbers, gives back the ceiling
            private int ReduceDistance(int low, int high)
            { 
               int toReturn = low + ((high - low) / 2);
               return toReturn;
            }
        }
    }
}
