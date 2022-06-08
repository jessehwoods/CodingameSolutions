using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("DeathFirstSearchEp1Tests")]

namespace DeathFirstSearchEp1
{

    /**
     * This is a solution to the puzzle at https://www.codingame.com/training/medium/death-first-search-episode-1
     */

    class Player
    {
        static void Main(string[] args)
        {

            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
            int L = int.Parse(inputs[1]); // the number of links
            int E = int.Parse(inputs[2]); // the number of exit gateways

            var solver = new Solver(N);

            for (int i = 0; i < L; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
                int N2 = int.Parse(inputs[1]);
            }
            for (int i = 0; i < E; i++)
            {
                int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            }

            // game loop
            while (true)
            {
                int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Bobnet agent is positioned this turn

                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");


                // Example: 0 1 are the indices of the nodes you wish to sever the link between
                Console.WriteLine(solver.Solve(SI));
            }
        }
    }

    /**
     * Internal class that takes in the information about the graph and can then be used to solve it.
     * 
     */
    internal class Solver
    {
        private int nodes;

        public Solver(int nodes)
        {
            this.nodes = nodes;
        }

        public void AddLink(int n1, int n2)
        {

        }

        public void AddGateway(int idx)
        {

        }

        /**
         * Takes in an index, modifies the internal representation of the graph to remove the shortest path to a gateway, then returns
         * a string representation of the removed link.
         */
        public string Solve(int input)
        {
            return null;
        }

        /**
         * Returns a string with a separate line for each node and all links that include the node separated by commas.
         * 
         * So, a set of three nodes (0, 1, and 2) with two links ( (0,1) and (1,2) ) would return the following:
         * 0,(0,1)
         * 1,(0,1),(1,2)
         * 2,(1,2)
         * 
         */
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
