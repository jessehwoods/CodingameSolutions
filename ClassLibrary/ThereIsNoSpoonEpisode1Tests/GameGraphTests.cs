using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;


namespace ThereIsNoSpoonEpisode1Tests
{

    /**
     * These are tests for a solution to the puzzle at https://www.codingame.com/training/medium/there-is-no-spoon-episode-1
     */
    [TestClass]
    public class GameGraphTests
    {


        private static int EXAMPLE_HEIGHT = 2;
        private static string EXAMPLE_INPUTLINE0 = "00";
        private static string EXAMPLE_INPUTLINE1 = "0.";
        private static string EXAMPLE_OUTPUT = "0 0 1 0 0 1\n1 0 -1 -1 -1 -1\n0 1 -1 -1 -1 -1\n";

        private static int HORIZONTAL_HEIGHT = 1;
        private static string HORIZONTAL_INPUTLINE0 = "0.0.0";
        private static string HORIZONTAL_OUTPUT = "0 0 2 0 -1 -1\n2 0 4 0 -1 -1\n4 0 -1 -1 -1 -1\n";

        private static int VERTICAL_HEIGHT = 5;
        private static string VERTICAL_INPUTLINE0 = "0";
        private static string VERTICAL_INPUTLINE1 = ".";
        private static string VERTICAL_INPUTLINE2 = "0";
        private static string VERTICAL_INPUTLINE3 = ".";
        private static string VERTICAL_INPUTLINE4 = "0";
        private static string VERTICAL_OUTPUT = "0 0 -1 -1 0 2\n0 2 -1 -1 0 4\n0 4 -1 -1 -1 -1\n";

        [TestMethod]
        public void TestExample()
        {
            ThereIsNoSpoonEpisode1.Player.GameGraph gameGraph = new ThereIsNoSpoonEpisode1.Player.GameGraph(EXAMPLE_HEIGHT);
            gameGraph.AddLine(0, EXAMPLE_INPUTLINE0);
            gameGraph.AddLine(1, EXAMPLE_INPUTLINE1);
            Assert.AreEqual(EXAMPLE_OUTPUT, gameGraph.ToString());
        }

        [TestMethod]
        public void TestHorizontal()
        {
            ThereIsNoSpoonEpisode1.Player.GameGraph gameGraph = new ThereIsNoSpoonEpisode1.Player.GameGraph(HORIZONTAL_HEIGHT);
            gameGraph.AddLine(0, HORIZONTAL_INPUTLINE0);
            Assert.AreEqual(HORIZONTAL_OUTPUT, gameGraph.ToString());
        }

        [TestMethod]
        public void TestVertical()
        {
            ThereIsNoSpoonEpisode1.Player.GameGraph gameGraph = new ThereIsNoSpoonEpisode1.Player.GameGraph(VERTICAL_HEIGHT);
            gameGraph.AddLine(0, VERTICAL_INPUTLINE0);
            gameGraph.AddLine(1, VERTICAL_INPUTLINE1);
            gameGraph.AddLine(2, VERTICAL_INPUTLINE2);
            gameGraph.AddLine(3, VERTICAL_INPUTLINE3);
            gameGraph.AddLine(4, VERTICAL_INPUTLINE4);
            Assert.AreEqual(VERTICAL_OUTPUT, gameGraph.ToString());
        }
    }
}
