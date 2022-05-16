using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnaryTests
{

    [TestClass]
    public class UnitTest1
    {
        //String "C" input and converted form
        private static string CINPUT = "C";
        private static string CSOLUTION = "0 0 00 0000 0 00";

        //String "CC" input and converted form
        private static string CCINPUT = "CC";
        private static string CCSOLUTION = "0 0 00 0000 0 000 00 0000 0 00";

        //String "%" input and converted form
        private static string PERCENTINPUT = "%";
        private static string PERCENTSOLUTION = "00 0 0 0 00 00 0 0 00 0 0 0";

        //String "Chuck Norris' keyboard has 2 keys: 0 and white space." input and converted form
        private static string MESSAGEINPUT = "Chuck Norris' keyboard has 2 keys: 0 and white space.";
        private static string MESSAGESOLUTION = "0 0 00 0000 0 0000 00 0 0 0 00 ...0 000 00 000 0 0000 00 00 0 0 00 0 0 0 00 0 0 0 00 0 0 000 00 0";

        [TestMethod]
        public void TestC()
        {
            Assert.AreEqual(CSOLUTION, Unary.Solution.ConvertStringToUnary(CINPUT));
        }

        [TestMethod]
        public void TestCC()
        {
            Assert.AreEqual(CCSOLUTION, Unary.Solution.ConvertStringToUnary(CCINPUT));
        }

        [TestMethod]
        public void TestPercent()
        {
            Assert.AreEqual(PERCENTSOLUTION, Unary.Solution.ConvertStringToUnary(PERCENTINPUT));
        }

        [TestMethod]
        public void TestMessage()
        {
            Assert.AreEqual(MESSAGESOLUTION, Unary.Solution.ConvertStringToUnary(MESSAGEINPUT));
        }
    }
}
