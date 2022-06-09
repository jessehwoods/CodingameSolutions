using Microsoft.VisualStudio.TestTools.UnitTesting;
using static WarCardGame.Solution;

namespace WarCardGameTests
{
    [TestClass]
    public class WarCardGameTests
    {
        private Solver testSolver;
        private string[] PLAYER1_CARDS1 = { "10D", "9S", "8D", "KH", "7D", "5H", "6S" };
        private string[] PLAYER2_CARDS1 = { "10H", "7H", "5C", "QC", "2C", "4H", "6D" };
        private string SOLVER_STRING_FILLED1 = "Player 1: 10 9 8 13 7 5 6\nPlayer 2: 10 7 5 12 2 4 6";
        private string SOLVER_STRING_FILLED1_WAR = "Player 1: 5 6 10 9 8 13 7 10 7 5 12 2\nPlayer 2: 4 6";

        private string[] PLAYER1_CARDS2 = { "9S", "8D", "KH", "7D", "5H", "6S" };
        private string[] PLAYER2_CARDS2 = { "7H", "5C", "QC", "2C", "4H", "6D" };
        private string SOLVER_STRING_FILLED2 = "Player 1: 9 8 13 7 5 6\nPlayer 2: 7 5 12 2 4 6";
        private string SOLVER_STRING_NONWAR = "Player 1: 8 13 7 5 6 9 7\nPlayer 2: 5 12 2 4 6";


        [TestInitialize]
        public void Setup()
        {
            testSolver = new Solver();
        }

        [TestMethod]
        public void TestAdd()
        {
            for(int i = 0; i < PLAYER1_CARDS1.Length; i++)
            {
                testSolver.AddCard(1, PLAYER1_CARDS1[i]);
            }
            for (int i = 0; i < PLAYER2_CARDS1.Length; i++)
            {
                testSolver.AddCard(2, PLAYER2_CARDS1[i]);
            }
            Assert.AreEqual(SOLVER_STRING_FILLED1, testSolver.ToString());
        }

        /**
         * Test of a move that doesn't require war.
         */
        [TestMethod]
        public void TestMove()
        {
            for (int i = 0; i < PLAYER1_CARDS2.Length; i++)
            {
                testSolver.AddCard(1, PLAYER1_CARDS2[i]);
            }
            for (int i = 0; i < PLAYER2_CARDS2.Length; i++)
            {
                testSolver.AddCard(2, PLAYER2_CARDS2[i]);
            }
            Assert.AreEqual(SOLVER_STRING_FILLED2, testSolver.ToString());
            testSolver.Move();
            Assert.AreEqual(SOLVER_STRING_NONWAR, testSolver.ToString());
        }

        /**
         * Test of a move that requires one instance of war.
         */
        [TestMethod]
        public void TestWar()
        {
            for (int i = 0; i < PLAYER1_CARDS1.Length; i++)
            {
                testSolver.AddCard(1, PLAYER1_CARDS1[i]);
            }
            for (int i = 0; i < PLAYER2_CARDS1.Length; i++)
            {
                testSolver.AddCard(2, PLAYER2_CARDS1[i]);
            }
            Assert.AreEqual(SOLVER_STRING_FILLED1, testSolver.ToString());
            testSolver.Move();
            Assert.AreEqual(SOLVER_STRING_FILLED1_WAR, testSolver.ToString());
        }

        [TestMethod]
        public void TestSolve()
        {
            Assert.Fail();
        }


    }
}
