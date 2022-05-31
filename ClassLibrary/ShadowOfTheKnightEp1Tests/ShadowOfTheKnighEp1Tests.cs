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
            // Bad width
            try
            {
                var solver = new Solver(0, 1, 0, 0);
                Assert.Fail();
            } catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
            }
            // Bad height
            try
            {
                var solver = new Solver(1, 0, 0, 0);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
            }
            // Bad x position, too high
            try
            {
                var solver = new Solver(1, 1, 2, 0);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
            }
            // Bad x position, too low
            try
            {
                var solver = new Solver(1, 1, -1, 1);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
            }
            // Bad y position, too high
            try
            {
                var solver = new Solver(1, 1, 0, 2);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
            }
            //Bad y position, too low
            try
            {
                var solver = new Solver(1, 1, 0, -1);
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
            var solver = new Solver(1, 1, 0, 1);
            Assert.IsTrue(solver is Solver);
            Assert.AreEqual(0, solver.getX());
            Assert.AreEqual(1, solver.getY());
        }

        [TestMethod]
        public void TestGridD()
        {
            //D means that the x will be unchanged and y will be increasing
            TestSolver.NextMove(TESTGRID_D_DIRECTION);
            Assert.AreEqual(TESTGRID_STARTING_VALUE, TestSolver.getX());
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[0], TestSolver.getY());
            
            TestSolver.NextMove(TESTGRID_D_DIRECTION);
            Assert.AreEqual(TESTGRID_STARTING_VALUE, TestSolver.getX());
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[1], TestSolver.getY());
            
            TestSolver.NextMove(TESTGRID_D_DIRECTION);
            Assert.AreEqual(TESTGRID_STARTING_VALUE, TestSolver.getX());
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[2], TestSolver.getY());
        }

        [TestMethod]
        public void TestGridDL()
        {
            //DL means that the x will be increasing and y will be increasing
            TestSolver.NextMove(TESTGRID_DL_DIRECTION);
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[0], TestSolver.getX());
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[0], TestSolver.getY());
            
            TestSolver.NextMove(TESTGRID_DL_DIRECTION);
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[1], TestSolver.getX());
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[1], TestSolver.getY());
            
            TestSolver.NextMove(TESTGRID_DL_DIRECTION);
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[2], TestSolver.getX());
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[2], TestSolver.getY());
        }

        [TestMethod]
        public void TestGridL()
        {
            //R means that the x will be decreasing and y be unchanged
            TestSolver.NextMove(TESTGRID_L_DIRECTION);
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[0], TestSolver.getX());
            Assert.AreEqual(TESTGRID_STARTING_VALUE, TestSolver.getY());
            
            TestSolver.NextMove(TESTGRID_L_DIRECTION);
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[1], TestSolver.getX());
            Assert.AreEqual(TESTGRID_STARTING_VALUE, TestSolver.getY());
            
            TestSolver.NextMove(TESTGRID_L_DIRECTION);
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[2], TestSolver.getX());
            Assert.AreEqual(TESTGRID_STARTING_VALUE, TestSolver.getY());
        }

        [TestMethod]
        public void TestGridUL()
        {
            //UL means that the x will be decreasing and y be decreasing
            TestSolver.NextMove(TESTGRID_UL_DIRECTION);
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[0], TestSolver.getX());
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[0], TestSolver.getY());
            
            TestSolver.NextMove(TESTGRID_UL_DIRECTION);
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[1], TestSolver.getX());
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[1], TestSolver.getY());
            
            TestSolver.NextMove(TESTGRID_UL_DIRECTION);
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[2], TestSolver.getX());
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[2], TestSolver.getY());
        }

        [TestMethod]
        public void TestGridU()
        {
            //D means that the x will not change and y will be decreasing
            TestSolver.NextMove(TESTGRID_U_DIRECTION);
            Assert.AreEqual(TESTGRID_STARTING_VALUE, TestSolver.getX());
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[0], TestSolver.getY());
            
            TestSolver.NextMove(TESTGRID_U_DIRECTION);
            Assert.AreEqual(TESTGRID_STARTING_VALUE, TestSolver.getX());
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[1], TestSolver.getY());
            
            TestSolver.NextMove(TESTGRID_U_DIRECTION);
            Assert.AreEqual(TESTGRID_STARTING_VALUE, TestSolver.getX());
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[2], TestSolver.getY());
        }

        [TestMethod]
        public void TestGridUR()
        {
            //UR means that the x will be increasing and y be decreasing
            TestSolver.NextMove(TESTGRID_UR_DIRECTION);
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[0], TestSolver.getX());
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[0], TestSolver.getY());
            
            TestSolver.NextMove(TESTGRID_UR_DIRECTION);
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[1], TestSolver.getX());
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[1], TestSolver.getY());
            
            TestSolver.NextMove(TESTGRID_UR_DIRECTION);
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[2], TestSolver.getX());
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[2], TestSolver.getY());
        }

        [TestMethod]
        public void TestGridR()
        {
            //L means that the x will be increasing and y be unchanged
            TestSolver.NextMove(TESTGRID_R_DIRECTION);
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[0], TestSolver.getX());
            Assert.AreEqual(TESTGRID_STARTING_VALUE, TestSolver.getY());
            
            TestSolver.NextMove(TESTGRID_R_DIRECTION);
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[1], TestSolver.getX());
            Assert.AreEqual(TESTGRID_STARTING_VALUE, TestSolver.getY());
            
            TestSolver.NextMove(TESTGRID_R_DIRECTION);
            Assert.AreEqual(TESTGRID_INCREASING_VALUES[2], TestSolver.getX());
            Assert.AreEqual(TESTGRID_STARTING_VALUE, TestSolver.getY());
        }

        [TestMethod]
        public void TestGridDR()
        {
            //UL means that the x will be decreasing and y will be decreasing
            TestSolver.NextMove(TESTGRID_UL_DIRECTION);
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[0], TestSolver.getX());
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[0], TestSolver.getY());
            
            TestSolver.NextMove(TESTGRID_UL_DIRECTION);
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[1], TestSolver.getX());
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[1], TestSolver.getY());
            
            TestSolver.NextMove(TESTGRID_UL_DIRECTION);
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[2], TestSolver.getX());
            Assert.AreEqual(TESTGRID_DECREASING_VALUES[2], TestSolver.getY());
        }

        [TestMethod]
        public void TestProvidedExample()
        {
            // This is a series of moves offered as an example on the site
            TestSolver = new Solver(4, 8, 2, 3); // Starting at (2, 3)
            // Final is at (3, 7)
            TestSolver.NextMove(TESTGRID_DR_DIRECTION);
            Assert.AreEqual(3, TestSolver.getX());
            Assert.AreEqual(5, TestSolver.getY());

            TestSolver.NextMove(TESTGRID_D_DIRECTION);
            Assert.AreEqual(3, TestSolver.getX());
            Assert.AreEqual(6, TestSolver.getY());

            TestSolver.NextMove(TESTGRID_D_DIRECTION);
            Assert.AreEqual(3, TestSolver.getX());
            Assert.AreEqual(7, TestSolver.getY());
        }

    }
}
