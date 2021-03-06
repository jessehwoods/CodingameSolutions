

/**
 * Tests for a solution to the puzzle at https://www.codingame.com/training/medium/death-first-search-episode-1
 */

namespace DeathFirstSearchEp1Tests
{

    using DeathFirstSearchEp1;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class DFS1Tests
    {
        private int NUMBER_OF_NODES = 3;
        private int GATEWAY_NODE = 2;
        private int SOLVE_NODE = 1;
        private int[] FIRST_LINK = { 0, 1 };
        private int[] SECOND_LINK = { 1, 2 };
        //String representation of an Solver object with no links added
        private string EMPTY_SOLVER_STRING = "0\n1\n2\n";
        //String representation of a Solver object with a gateway and no links
        private string GATEWAY_STRING = "0\n1\n*2\n";
        //String representation of a Solver object with links but no gateway
        private string LINKS_STRING = "0,(0,1)\n1,(0,1),(1,2)\n2,(1,2)\n";
        //String representation of a Solver object with all the above information successfully added.
        private string TEST_STRING = "0,(0,1)\n1,(0,1),(1,2)\n*2,(1,2)\n";
        //String representation of a Solver object that has called the Solve(SOLVE_NODE) method. 
        private string SOLVED_TEST_RETURN = "1 2";
        private string SOLVED_TEST_STRING = "0,(0,1)\n1,(0,1)\n*2\n";

        private Solver testSolver;

        [TestInitialize]
        public void Setup()
        {
            testSolver = new Solver(NUMBER_OF_NODES);
        }

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(EMPTY_SOLVER_STRING, testSolver.ToString());
        }

        [TestMethod]
        public void TestAddLink()
        {
            testSolver.AddLink(FIRST_LINK[0], FIRST_LINK[1]);
            testSolver.AddLink(SECOND_LINK[0], SECOND_LINK[1]);
            Assert.AreEqual(LINKS_STRING, testSolver.ToString());
        }

        [TestMethod]
        public void TestAddGateway()
        {
            testSolver.AddGateway(GATEWAY_NODE);
            Assert.AreEqual(GATEWAY_STRING, testSolver.ToString());
        }

        [TestMethod]
        public void TestSolve()
        {
            testSolver.AddLink(FIRST_LINK[0], FIRST_LINK[1]);
            testSolver.AddLink(SECOND_LINK[0], SECOND_LINK[1]);
            testSolver.AddGateway(GATEWAY_NODE);
            Assert.AreEqual(TEST_STRING, testSolver.ToString());
            Assert.AreEqual(SOLVED_TEST_RETURN, testSolver.Solve(SOLVE_NODE));
            Assert.AreEqual(SOLVED_TEST_STRING, testSolver.ToString());
        }

        [TestMethod]
        public void TestSolveBigger()
        {
            testSolver = new Solver(4);
            testSolver.AddLink(0, 1);
            testSolver.AddLink(0, 2);
            testSolver.AddLink(1, 3);
            testSolver.AddLink(2, 3);
            testSolver.AddGateway(3);
            Assert.AreEqual("1 3", testSolver.Solve(0));
            Assert.AreEqual("2 3", testSolver.Solve(1));
        }
    }
}
