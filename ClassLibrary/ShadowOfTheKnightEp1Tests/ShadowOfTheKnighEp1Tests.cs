using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static ShadowOfTheKnightEp1.Player;

namespace ShadowOfTheKnightEp1Tests
{

    [TestClass]
    public class ShadowOfTheKnightEp1Tests
    {

        private readonly int TESTGRID_STARTING_VALUE = 4; //Starting value for x and y values
        private readonly int[] TESTGRID_PROPERTIES = {9, 4}; //Properties are in the format width, height, x position, y position
        private readonly int[] TESTGRID_INCREASING_VALUES = {6, 7, 8};
        private readonly int[] TESTGRID_DECREASING_VALUES = {2, 1, 0};
        private Solver TestSolver;

        private readonly string TESTGRID_U_DIRECTION = "U"; // Direction to input if final position (4, 8)

        private readonly string TESTGRID_UR_DIRECTION = "UR"; // Directions to input if final position (8, 8)

        private readonly string TESTGRID_R_DIRECTION = "R"; // Directions to input if final position (8, 4)

        private readonly string TESTGRID_DR_DIRECTION = "DR"; // Directions to input if final position (8, 0)

        private readonly string TESTGRID_D_DIRECTION = "D"; // Directions to input if final position (4, 0)

        private readonly string TESTGRID_DL_DIRECTION = "DL"; // Directions to input if final position (0, 0)

        private readonly string TESTGRID_L_DIRECTION = "L"; // Directions to input if final position (0, 4)

        private readonly string TESTGRID_UL_DIRECTION = "UL"; // Directions to input if final position (4, 0)

        [TestInitialize]
        public void TestInitialize()
        {
            TestSolver = new Solver(TESTGRID_PROPERTIES[0], TESTGRID_PROPERTIES[0], TESTGRID_PROPERTIES[1], TESTGRID_PROPERTIES[1]);
        }

        [TestMethod]
        public void InvalidSolverConstructor()
        {
            Solver solver = null;
            // Bad width
            try
            {
                solver = new Solver(0, 1, 0, 0);
                Assert.Fail();
            } catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
            }
            // Bad height
            try
            {
                solver = new Solver(1, 0, 0, 0);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
                Assert.Fail();
            }
            // Bad x position, too high
            try
            {
                solver = new Solver(1, 1, 2, 0);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
            }
            // Bad x position, too low
            try
            {
                solver = new Solver(1, 1, -1, 1);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
            }
            // Bad y position, too high
            try
            {
                solver = new Solver(1, 1, 0, 2);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
            }
            //Bad y position, too low
            try
            {
                solver = new Solver(1, 1, 0, -1);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
            }

        }

        [TestMethod]
        public void ValidSolverConstructor()
        {
            Solver solver = new Solver(1, 1, 0, 0);
            Assert.IsTrue(solver is Solver);
        }

        [TestMethod]
        public void TestGridU()
        {
            //U means that the x will be unchanged and y will be increasing
            string[] results = TestSolver.nextMove(TESTGRID_U_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_STARTING_VALUE, int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[0], int.Parse(results[1]));
            results = TestSolver.nextMove(TESTGRID_U_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_STARTING_VALUE, int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[1], int.Parse(results[1]));
            results = TestSolver.nextMove(TESTGRID_U_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_STARTING_VALUE, int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[2], int.Parse(results[1]));
        }

        [TestMethod]
        public void TestGridUR()
        {
            //UR means that the x will be increasing and y will be increasing
            string[] results = TestSolver.nextMove(TESTGRID_UR_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[0], int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[0], int.Parse(results[1]));
            results = TestSolver.nextMove(TESTGRID_UR_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[1], int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[1], int.Parse(results[1]));
            results = TestSolver.nextMove(TESTGRID_UR_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[2], int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[2], int.Parse(results[1]));
        }

        [TestMethod]
        public void TestGridR()
        {
            //R means that the x will be increasing and y be unchanged
            string[] results = TestSolver.nextMove(TESTGRID_R_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[0], int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_STARTING_VALUE, int.Parse(results[1]));
            results = TestSolver.nextMove(TESTGRID_R_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[1], int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_STARTING_VALUE, int.Parse(results[1]));
            results = TestSolver.nextMove(TESTGRID_R_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[2], int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_STARTING_VALUE, int.Parse(results[1]));
        }

        [TestMethod]
        public void TestGridDR()
        {
            //DR means that the x will be increasing and y be decreasing
            string[] results = TestSolver.nextMove(TESTGRID_DR_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[0], int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[0], int.Parse(results[1]));
            results = TestSolver.nextMove(TESTGRID_DR_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[1], int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[1], int.Parse(results[1]));
            results = TestSolver.nextMove(TESTGRID_DR_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[2], int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[2], int.Parse(results[1]));
        }

        [TestMethod]
        public void TestGridD()
        {
            //D means that the x will not change and y will be decreasing
            string[] results = TestSolver.nextMove(TESTGRID_D_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_STARTING_VALUE, int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[0], int.Parse(results[1]));
            results = TestSolver.nextMove(TESTGRID_D_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_STARTING_VALUE, int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[1], int.Parse(results[1]));
            results = TestSolver.nextMove(TESTGRID_D_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_STARTING_VALUE, int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[2], int.Parse(results[1]));
        }

        [TestMethod]
        public void TestGridDL()
        {
            //DL means that the x will be decreasing and y be decreasing
            string[] results = TestSolver.nextMove(TESTGRID_DL_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[0], int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[0], int.Parse(results[1]));
            results = TestSolver.nextMove(TESTGRID_DL_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[1], int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[1], int.Parse(results[1]));
            results = TestSolver.nextMove(TESTGRID_DL_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[2], int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[2], int.Parse(results[1]));
        }

        [TestMethod]
        public void TestGridL()
        {
            //L means that the x will be decreasing and y be unchanged
            string[] results = TestSolver.nextMove(TESTGRID_L_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[0], int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_STARTING_VALUE, int.Parse(results[1]));
            results = TestSolver.nextMove(TESTGRID_L_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[1], int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_STARTING_VALUE, int.Parse(results[1]));
            results = TestSolver.nextMove(TESTGRID_L_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[2], int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_STARTING_VALUE, int.Parse(results[1]));
        }

        [TestMethod]
        public void TestGridUL()
        {
            //UL means that the x will be decreasing and y will be increasing
            string[] results = TestSolver.nextMove(TESTGRID_UL_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[0], int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[0], int.Parse(results[1]));
            results = TestSolver.nextMove(TESTGRID_UL_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[1], int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[1], int.Parse(results[1]));
            results = TestSolver.nextMove(TESTGRID_UL_DIRECTION).Split(' ');
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[2], int.Parse(results[0]));
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[2], int.Parse(results[1]));
        }
    }
}
