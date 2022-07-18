
namespace DeathFirstSearchEp2Tests
{

    using DeathFirstSearchEp2;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using static DeathFirstSearchEp2.Player;

    [TestClass]
    public class DFS2Tests
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

        private Player.Solver testSolver;

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
        public void TestSolveDoubleGate()
        {
            testSolver = new Solver(7);
            testSolver.AddLink(0, 1);
            testSolver.AddLink(0, 2);
            testSolver.AddLink(0, 3);
            testSolver.AddLink(2, 4);
            testSolver.AddLink(2, 5);
            testSolver.AddLink(3, 5);
            testSolver.AddLink(4, 5);
            testSolver.AddLink(5, 6);
            testSolver.AddGateway(1);
            testSolver.AddGateway(3);
            testSolver.AddGateway(6);
            Assert.AreEqual("3 5", testSolver.Solve(4));
            Assert.AreEqual("0 1", testSolver.Solve(2));
        }

        /*
         * Has a gate with a single link that is far away. Checks that this doesn't time out the program.
         */
        [TestMethod]
        public void TestSolveFarGate()
        {
            testSolver = new Solver(7);
            testSolver.AddLink(0, 1);
            testSolver.AddLink(0, 2);
            testSolver.AddLink(0, 3);
            testSolver.AddLink(2, 4);
            testSolver.AddLink(2, 5);
            testSolver.AddLink(3, 5);
            testSolver.AddLink(4, 5);
            testSolver.AddLink(5, 6);
            testSolver.AddGateway(6);
            Assert.AreEqual("5 6", testSolver.Solve(0));
            Assert.AreEqual("No gateway found", testSolver.Solve(2));
        }

        /*
        * Big graph that has been failing on the site. Should initially cut a connection with node 27.
        */
        [TestMethod]
        public void TestSolveBigGraph()
        {
            testSolver = new Solver(37);

            //Add links: 0
            testSolver.AddLink(0, 1);
            testSolver.AddLink(0, 6);
            testSolver.AddLink(0, 7);
            testSolver.AddLink(0, 9);
            testSolver.AddLink(0, 10);
            testSolver.AddLink(0, 11);

            //Add links: 1
            testSolver.AddLink(1, 2);
            testSolver.AddLink(1, 3);
            testSolver.AddLink(1, 4);
            testSolver.AddLink(1, 6);
            testSolver.AddLink(1, 7);

            //Add links: 2
            testSolver.AddLink(2, 3);
            testSolver.AddLink(2, 4);
            testSolver.AddLink(2, 5);
            testSolver.AddLink(2, 33);
            testSolver.AddLink(2, 34);
            testSolver.AddLink(2, 35);

            //Add links: 3
            testSolver.AddLink(3, 8);
            testSolver.AddLink(3, 19);
            testSolver.AddLink(3, 20);
            testSolver.AddLink(3, 33);

            //Add links: 4
            testSolver.AddLink(4, 5);
            testSolver.AddLink(4, 6);

            //Add links: 5
            testSolver.AddLink(5, 35);

            //Add links: 6
            testSolver.AddLink(6, 11);
            testSolver.AddLink(6, 12);

            //Add links: 7
            testSolver.AddLink(7, 9);
            testSolver.AddLink(7, 13);
            testSolver.AddLink(7, 36);

            //Add links: 8
            testSolver.AddLink(8, 16);
            testSolver.AddLink(8, 17);
            testSolver.AddLink(8, 19);
            testSolver.AddLink(8, 36);

            //Add links: 9
            testSolver.AddLink(9, 10);
            testSolver.AddLink(9, 13);
            testSolver.AddLink(9, 14);

            //Add links: 10
            testSolver.AddLink(10, 11);
            testSolver.AddLink(10, 14);

            //Add links: 11
            testSolver.AddLink(11, 12);

            //Add links 12

            //Add links 13
            testSolver.AddLink(13, 14);
            testSolver.AddLink(13, 15);
            testSolver.AddLink(13, 16);
            testSolver.AddLink(13, 36);

            //Add links 14
            testSolver.AddLink(14, 15);

            //Add links 15
            testSolver.AddLink(15, 16);
            testSolver.AddLink(15, 23);
            testSolver.AddLink(15, 24);

            //Add links 16
            testSolver.AddLink(16, 17);
            testSolver.AddLink(16, 23);
            testSolver.AddLink(16, 27);
            testSolver.AddLink(16, 30);

            //Add links 17
            testSolver.AddLink(17, 18);
            testSolver.AddLink(17, 19);
            testSolver.AddLink(17, 31);
            testSolver.AddLink(17, 32);

            //Add links 18
            testSolver.AddLink(18, 19);
            testSolver.AddLink(18, 22);
            testSolver.AddLink(18, 32);

            //Add links 19
            testSolver.AddLink(19, 20);
            testSolver.AddLink(19, 21);
            testSolver.AddLink(19, 22);

            //Add links 20
            testSolver.AddLink(20, 21);

            //Add links 21
            testSolver.AddLink(21, 32);

            //Add links 22
            testSolver.AddLink(22, 32);

            //Add links 23
            testSolver.AddLink(23, 24);
            testSolver.AddLink(23, 25);
            testSolver.AddLink(23, 27);

            //Add links 24
            testSolver.AddLink(24, 25);

            //Add links 25
            testSolver.AddLink(25, 26);
            testSolver.AddLink(25, 27);

            //Add links 26
            testSolver.AddLink(26, 27);
            testSolver.AddLink(26, 28);

            //Add links 27
            testSolver.AddLink(27, 28);
            testSolver.AddLink(27, 29);
            testSolver.AddLink(27, 30);

            //Add links 28
            testSolver.AddLink(28, 29);

            //Add links 29
            testSolver.AddLink(29, 30);

            //Add links 30

            //Add links 31
            testSolver.AddLink(31, 32);

            //Add links 32

            //Add links 33
            testSolver.AddLink(33, 34);

            //Add links 34
            testSolver.AddLink(34, 35);

            //Add links 35

            //Add links 36

            // Add gateways
            testSolver.AddGateway(0);
            testSolver.AddGateway(16);
            testSolver.AddGateway(18);
            testSolver.AddGateway(26);

            String toCheck = testSolver.Solve(2);
            Assert.IsTrue(toCheck.Equals("16 27") || toCheck.Equals("26 27"));
        }
    }
}

