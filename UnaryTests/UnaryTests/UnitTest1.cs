using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnaryTests
{

    [TestClass]
    public class UnitTest1
    {
        // Unary equivalent of the string "C"
        private static string CSOLUTION = "0 0 00 0000 0 00";

        // Unary equivalent of the string "CC"
        private static string CCSOLUTION = "0 0 00 0000 0 000 00 0000 0 00";

        // Unary equivalent of the string "%"
        private static string PERCENTSOLUTION = "00 0 0 0 00 00 0 0 00 0 0 0";

        // Unary equivalent of the string "Chuck Norris' keyboard has 2 keys: 0 and white space."
        private static string MESSAGESOLUTION = "0 0 00 0000 0 0000 00 0 0 0 00 ...0 000 00 000 0 0000 00 00 0 0 00 0 0 0 00 0 0 0 00 0 0 000 00 0";

        [TestMethod]
        public void TestC()
        {
            Assert.AreEqual(CSOLUTION, Unary.Solution.SayBlah());
        }

        [TestMethod]
        public void TestCC()
        {
            Assert.AreEqual(CCSOLUTION, Unary.Solution.SayBlah());
        }

        [TestMethod]
        public void TestPercent()
        {
            Assert.AreEqual(PERCENTSOLUTION, Unary.Solution.SayBlah());
        }

        [TestMethod]
        public void TestMessage()
        {
            Assert.AreEqual(MESSAGESOLUTION, Unary.Solution.SayBlah());
        }
    }
}
