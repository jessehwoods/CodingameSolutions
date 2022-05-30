using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static ShadowOfTheKnightEp1.Player;

namespace ShadowOfTheKnightEp1Tests
{



    [TestClass]
    public class ShadowOfTheKnightEp1Tests
    {
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
        public void TestGrid1()
        {

        }

        [TestMethod]
        public void TestGrid2()
        {

        }

    }
}
