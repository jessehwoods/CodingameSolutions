[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("DeathFirstSearchEp2Tests")]

namespace DeathFirstSearchEp2
{

    /**
     * This is a solution to the puzzle at https://www.codingame.com/training/hard/death-first-search-episode-2
     */

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
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
                solver.AddLink(N1, N2);
            }
            for (int i = 0; i < E; i++)
            {
                int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
                solver.AddGateway(EI);
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

        /**
         * Internal class that takes in the information about the graph and can then be used to solve it.
         * 
         */
        internal class Solver
        {
            // Each cell of the array contains a node with the links to neighboring nodes and the number of connected gateways
            private LinkStore[] nodes;

            // Holds the indexes of any nodes that are gateways.
            HashSet<int> gateways;

            public Solver(int nodes)
            {
                this.nodes = new LinkStore[nodes];
                // Initialize the hashset of gateways
                gateways = new HashSet<int>();
            }


            /**
             * Takes in two indexes and adds a link between them.
             */
            public void AddLink(int n1, int n2)
            {
                if (gateways.Count != 0)
                {
                    throw new InvalidOperationException("Cannot add links after gateways have been added.");
                }
                // Handle the case of an empty cell
                if (nodes[n1] == null)
                {
                    nodes[n1] = new LinkStore();
                }
                if (nodes[n2] == null)
                {
                    nodes[n2] = new LinkStore();
                }
                nodes[n1].StoreLink(n1, n2);
                nodes[n2].StoreLink(n2, n1);
            }

            /**
             * Takes a node index. That index will be a gateway node.
             * Assumed be done after all nodes and links are created, so that adding gateways can update neighboring nodes
             */
            public void AddGateway(int idx)
            {
                gateways.Add(idx);
                // Update all connected nodes to reflect that they are connected to a gateway
                if (nodes[idx] != null)
                {
                    foreach (Tuple<int, int> link in nodes[idx])
                    {
                        nodes[link.Item2].IncreaseLinkedGateways();
                    }
                }
            }

            /**
             * Takes in an index, modifies the internal representation of the graph to remove the shortest path to a gateway, then returns
             * a string representation of the removed link in the form "x y".
             */
            public string Solve(int input)
            {
                Tuple<int, int> linkToSever = ProcessLinks(true, false, input); // Try it first looking for big ones.
                if (linkToSever == null)
                {
                    linkToSever = ProcessLinks(false, true, input); // Didn't find any big ones, so just go for something close.
                }
                if (linkToSever == null)
                {
                    return "No gateway found"; // Didn't find anything. That's weird.
                }
                return RemoveLinks(linkToSever);
            }

            /**
             * Takes a link and finds links to gateways.
             * The bool bigcheck tells us, if true, we only want links that 1) are immediately next to the input index, 
             * or 2) particularly large. 
             * If false: just sever the nearest.
             * 
             * This is on the theory that a node connected to only one gateway is only a threat if it is immediately next to the input
             * index, so we might want to focus on just cutting up the nearest node that connects to multiple gateways.
             * 
             * Returns null if no matching link is found.
             */
            private Tuple<int, int> ProcessLinks(bool bigcheck, bool takeAnything, int input)
            {
                Tuple<int, int> toReturn = null;
                bool firstPass = true; // Tracking element to tell us if we're still on the first set of links
                var toProcess = new Queue<Tuple<int, int>>(); // This will be loaded with links to check for a gateway
                var visited = new HashSet<int>(); // Tracks indexes that have been visited already
                var staging = new Queue<Tuple<int, int>>(); // This will be loaded with links to have their sub-links checked
                foreach (Tuple<int, int> t in nodes[input]) // Load the initial group to process
                {
                    toProcess.Enqueue(t);
                }
                while (toProcess.Count > 0)
                {
                    visited.Add(toProcess.Peek().Item1);
                    while (toProcess.Count > 0)
                    {
                        var t = toProcess.Dequeue();
                        if ( gateways.Contains(t.Item2) && ((firstPass || !bigcheck) || nodes[t.Item1].GetLinkedGateways() > 1)) // Only want single links if they are 1) in the first set, or 2) bigcheck is false
                        {
                            // We found one that meets our requirements, so return it
                            return t;
                        }
                        // Also add it to have its sub-links examined, if it hasn't been visited yet
                        if (!visited.Contains(t.Item2)) {
                            staging.Enqueue(t);
                        }
                    }
                    while (staging.Count > 0) // Didn't find a link to a gateway, so we'll load up sub-links to examine
                    {
                        var t = staging.Dequeue();
                        foreach (Tuple<int, int> x in nodes[t.Item2])
                        {
                            if (nodes[x.Item1].GetLinkedGateways() != 0 || takeAnything) {
                                toProcess.Enqueue(x);
                            }
                        }
                    }
                    firstPass = false; // Done with first pass.
                }
                return toReturn;
            }

            private string RemoveLinks(Tuple<int, int> linkToSever)
            {
                // Remove links
                nodes[linkToSever.Item1].Remove(linkToSever);
                nodes[linkToSever.Item2].Remove(new Tuple<int, int>(linkToSever.Item2, linkToSever.Item1));
                //Reduce the gateway links if necessary
                if (gateways.Contains(linkToSever.Item2))
                {
                    nodes[linkToSever.Item1].DecreaseLinkedGateways();
                }
                else if (gateways.Contains(linkToSever.Item1))
                {
                    nodes[linkToSever.Item2].DecreaseLinkedGateways();
                }

                // Return string
                return String.Format("{0} {1}", Math.Min(linkToSever.Item1, linkToSever.Item2), Math.Max(linkToSever.Item1, linkToSever.Item2));
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
                        Tuple<int, int> linkToCheck = Tuple.Create<int, int>(i, j);
                        if (nodes[i] != null && nodes[i].Contains(linkToCheck))
                        {
                            stringBuilder.Append(String.Format(",({0},{1})", Math.Min(i, j), Math.Max(i, j)));
                        }
                    }
                    // Add a newline character
                    stringBuilder.Append('\n');
                }
                return stringBuilder.ToString();
            }

            internal class LinkStore : IEnumerable<Tuple<int, int>>
            {
                private HashSet<Tuple<int, int>> links;
                private int linkedGateways;

                internal LinkStore()
                {
                    this.links = new HashSet<Tuple<int, int>>();
                    linkedGateways = 0;
                }

                public IEnumerator<Tuple<int, int>> GetEnumerator()
                {
                    return ((IEnumerable<Tuple<int, int>>)links).GetEnumerator();
                }

                internal bool Contains(Tuple<int, int> linkToCheck)
                {
                    return links.Contains(linkToCheck);
                }

                internal void IncreaseLinkedGateways()
                {
                    linkedGateways++;
                }

                internal void DecreaseLinkedGateways()
                {
                    linkedGateways--;
                }

                internal void Remove(Tuple<int, int> t)
                {
                    links.Remove(t);
                }

                internal void StoreLink(int n1, int n2)
                {
                    links.Add(Tuple.Create<int, int>(n1, n2));
                }

                IEnumerator IEnumerable.GetEnumerator()
                {
                    return ((IEnumerable)links).GetEnumerator();
                }

                internal int GetLinkedGateways()
                {
                    return linkedGateways;
                }
            }
        }
    }
}
