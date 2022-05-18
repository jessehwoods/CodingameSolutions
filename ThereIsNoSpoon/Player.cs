using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ThereIsNoSpoonEpisode1Tests")]

namespace ThereIsNoSpoonEpisode1
{
    /**
     * This is a solution to the puzzle at https://www.codingame.com/training/medium/there-is-no-spoon-episode-1
     **/
    internal class Player
    {

        private static char NODE = '0'; // Character used to indicate the presence of a node

        static void Main(string[] args)
        {
            Console.ReadLine(); // This is the number of cells on the X axis, but I'm not using it
            int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis

            GameGraph gameGraph = new GameGraph(height);

            // Read the input into the graph and read the nodes into the nodesList
            for (int i = 0; i < height; i++)
            {
                gameGraph.AddLine(i, Console.ReadLine());
            }

            // Output the nodes
            Console.Write(gameGraph.ToString());
            
        }

        /**
         * Holds the graph representing the location of nodes, and maintains a list of nodes with their neighboring nodes.
         */ 
        internal class GameGraph
        {
            private string[] graph; //Graph of height length to hold the graph
            private IDictionary<Tuple<int, int>, Node> nodesDictionary;

            public GameGraph(int height)
            {
                graph = new string[height];
                nodesDictionary = new Dictionary<Tuple<int, int>, Node>();
            }

            /**
             * Adds a line to the graph and updates the nodes. 
             * 
             * Assumes that lines will be added in ascending order. Adding lines in a different order will not update nodes correctly.
             */
            internal void AddLine(int yAxis, string s)
            {
                graph[yAxis] = s;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == NODE)
                    {
                        Node toModify = null;
                        nodesDictionary.Add(new Tuple<int, int>(i, yAxis), new Node(i, yAxis));
                        // Check for a node at (x-1, y)
                        if (i > 0 &&  s[i-1].Equals(NODE) && nodesDictionary.TryGetValue(new Tuple<int, int>(i - 1, yAxis), out toModify))
                        {
                            toModify.setXY2(i, yAxis);
                        }
                        // Check for a node at (x, y-1)
                        if (yAxis > 0 && i <= graph[yAxis - 1].Length && graph[yAxis - 1][i].Equals(NODE) && nodesDictionary.TryGetValue(new Tuple<int, int>(i, yAxis - 1), out toModify))
                        {
                            toModify.setXY3(i, yAxis);
                        }
                    }
                }
             }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                foreach (var keyValuePair in nodesDictionary)
                {
                    sb.Append(keyValuePair.Value.ToString() + "\n");
                }
                return sb.ToString();
            }

            /**
            * Holds data of a node to read out later.
            */
            private class Node
            {
                private int x1; // Holds x value for this node
                private int y1; // Holds y value for this node
                private int x2; // Holds x value for (x+1, y) node or -1
                private int y2; // Holds y value for (x+1, y) node or -1
                private int x3; // Holds x value for (x, y+1) node or -1
                private int y3; // Holds y value for (x, y+1) node or -1

                public Node(int x1, int y1)
                {
                    this.x1 = x1;
                    this.y1 = y1;
                    x2 = -1;
                    y2 = -1;
                    x3 = -1;
                    y3 = -1;
                }

                internal string GetXY1()
                {
                    return x1 + " " + y1;
                }

                internal void setXY2(int x2, int y2)
                {
                    this.x2 = x2;
                    this.y2 = y2;
                }

                internal void setXY3(int x3, int y3)
                {
                    this.x3 = x3;
                    this.y3 = y3;
                }

                public override string ToString()
                {
                    return x1 + " " + y1 + " " + x2 + " " + y2 + " " + x3 + " " + y3;
                }
            }
        }
    }
}
