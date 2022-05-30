using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static ShadowOfTheKnightEp1.Player;

namespace ShadowOfTheKnightEp1Tests
{

    [TestClass]
    public class ShadowOfTheKnightEp1Tests
    {
        
        private int[] TESTGRID_PROPERTIES = {8, 8, 4, 4}; //Properties are in the format width, height, x position, y position
        private int[] TESTGRID_INCREASING_VALUES = {6, 7, 8};
        private int[] TESTGRID_DECREASING_VALUES = {2, 1, 0};
        private Solver TESTSOLVER;

        // U
        private string TESTGRID_U_DIRECTION = "U"; // Direction to input if final position (4, 8)

        // UR
        private string TESTGRID_UR_DIRECTION = "UR"; // Directions to input if final position (8, 8)

        // R
        private string TESTGRID_R_DIRECTION = "R"; // Directions to input if final position (8, 4)

        // DR
        private string TESTGRID_DR_DIRECTION = "DR"; // Directions to input if final position (8, 0)

        // D
        private string TESTGRID_D_DIRECTION = "D"; // Directions to input if final position (4, 0)

        // DL
        private string TESTGRID_DL_DIRECTION = "DL"; // Directions to input if final position (0, 0)

        // L
        private string TESTGRID_L_DIRECTION = "L"; // Directions to input if final position (0, 4)

        // UL
        private string TESTGRID_UL_DIRECTION = "UL"; // Directions to input if final position (4, 0)

        [TestInitialize]
        public void TestInitialize()
        {
            TESTSOLVER = new Solver(TESTGRID_PROPERTIES[0], TESTGRID_PROPERTIES[1], TESTGRID_PROPERTIES[2], TESTGRID_PROPERTIES[3]);
        }

        [TestMethod]
        public void InvalidSolverConstructor()
        {
            Solver solver = null;
            // Bad width
            try
            {
                solver = new Solver(0, 1, 0, 0);
            } catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
            }
            // Bad height
            try
            {
                solver = new Solver(1, 0, 0, 0);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
            }
            // Bad x position, too high
            try
            {
                solver = new Solver(1, 1, 2, 0);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
            }
            // Bad x position, too low
            try
            {
                solver = new Solver(0, 1, -1, 1);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
            }
            // Bad y position, too high
            try
            {
                solver = new Solver(0, 1, 0, 2);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
            }
            //Bad y position, too low
            try
            {
                solver = new Solver(0, 1, 0, -1);
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

        }

        [TestMethod]
        public void TestGridUR()
        {

        }

        [TestMethod]
        public void TestGridR()
        {

        }

        [TestMethod]
        public void TestGridDR()
        {

        }

        [TestMethod]
        public void TestGridD()
        {

        }

        [TestMethod]
        public void TestGridDL()
        {

        }

        [TestMethod]
        public void TestGridL()
        {

        }

        [TestMethod]
        public void TestGridUL()
        {

        }
    }
}
