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

        private static int HEIGHT = 2;
        private static string INPUTLINE0 = "00";
        private static string INPUTLINE1 = "0.";
        private static string OUTPUT = "0 0 1 0 0 1\n1 0 -1 -1 -1 -1\n0 1 -1 -1 -1 -1\n";


        [TestMethod]
        public void TestGameGraph()
        {
            ThereIsNoSpoonEpisode1.Player.GameGraph gameGraph = new ThereIsNoSpoonEpisode1.Player.GameGraph(HEIGHT);
            gameGraph.AddLine(0, INPUTLINE0);
            gameGraph.AddLine(1, INPUTLINE1);
            Assert.AreEqual(OUTPUT, gameGraph.ToString());
        }
    }
}
