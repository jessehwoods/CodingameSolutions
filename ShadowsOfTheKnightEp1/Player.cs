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
            Solver solver = new Solver(W, H, X0, Y0);

            // game loop
            while (true)
            {
                string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)

                //  Get the next move from the Solver object
                string returnString = solver.NextMove(bombDir);

                // Return the next move 
                Console.WriteLine(returnString);
            }
        }

        /**
         * Used to get the solution to the problem by applying binary search.
         * Initialized to a grid and then given directions, it will apply binary search and update its' state whenever
         * a new move is requested.
         */
        internal class Solver
        {
            private int width; // Width of the grid
            private int height; // Height of the grid
            private int xPosition; // X position of most recently checked node
            private int yPosition; // Y position of most recently checked node

            public Solver(int width, int height, int x0, int y0)
            {
                if (width <= 0 || height <= 0 || x0 > width || x0 < 0 || y0 > height || y0 < 0)
                {
                    throw new ArgumentException("Invalid game setup.");
                }
                this.width = width;
                this.height = height;
                this.xPosition = x0;
                this.yPosition = y0;
            }

            /**
            * This takes in a string representing the direction to the next solution. 
            * It will calculate the next place to check, using a binary search algorithm, and then
            * update the state of the Solver object to reflect the returned value as the current position on the grid.
            * 
            * Valid direction strings are U, UR, R, DR, D, DL, L or UL.
            * 
            * Returns the coordinate of the next place to search as a string coordinate in the form "x y".
            */
            internal string NextMove(string bombDir)
            {
                

                return String.Format("{0} {1}", xPosition, yPosition);
            }

        }
    }
}
