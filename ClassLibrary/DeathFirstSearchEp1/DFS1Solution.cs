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
        private HashSet<Tuple<int,int>>[] nodes;
        HashSet<int> gateways;
        public Solver(int nodes)
        {
            // Number of nodes in the graph
            this.nodes = new HashSet<Tuple<int, int>>[nodes];
            // Initialize the hashset of gateways
            gateways = new HashSet<int>();
            // Initialize the hashset of links
        }


        /**
         * Takes in two indexes and adds a link between them.
         */
        public void AddLink(int n1, int n2)
        {
            if (nodes[n1] == null)
            {
                nodes[n1] = new HashSet<Tuple<int, int>>();
            }
            if (nodes[n2] == null)
            {
                nodes[n2] = new HashSet<Tuple<int, int>>();
            }
            nodes[n1].Add(Tuple.Create<int, int>(n1, n2));
            nodes[n2].Add(Tuple.Create<int, int>(n2, n1));
        }

        /**
         * Takes a node index. That index will be a gateway node.
         */
        public void AddGateway(int idx)
        {
            gateways.Add(idx);
        }

        /**
         * Takes in an index, modifies the internal representation of the graph to remove the shortest path to a gateway, then returns
         * a string representation of the removed link in the form "x y".
         */
        public string Solve(int input)
        {
            return null;
        }

        /**
         * Returns a string with a separate line for each node and all links that include the node separated by commas. An asterisk * at
         * the beginning of the line will represent a gateway node.
         *  
         * So, a set of three nodes (0, 1, and *2) with two links ( (0,1) and (1,2) ) would return the following:
         * 0,(0,1)
         * 1,(0,1),(1,2)
         * *2,(1,2)
         * 
         */
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder(); // To return
            for (int i = 0; i < nodes.Length; i++)
            {
                // Print the node number, checking for gateways
                if (gateways.Contains(i))
                {
                    stringBuilder.Append('*');
                }
                stringBuilder.Append(i);
                // Add the links on each line
                for (int j = 0; j < nodes.Length; j++)
                {
                    Tuple<int,int> linkToCheck = Tuple.Create<int, int>(i, j);
                    if (nodes [i] != null && nodes[i].Contains(linkToCheck))
                    {
                        stringBuilder.Append(String.Format(",({0},{1})", Math.Min(i, j), Math.Max(i, j)));
                    }
                }
                // Add a newline character
                stringBuilder.Append('\n');
            }
            return stringBuilder.ToString();
        }
    }
}
