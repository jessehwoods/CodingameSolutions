using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnaryTests
{

    [TestClass]
    public class SolutionTests
    {
        //String "C" input and converted form
        private static string CINPUT = "C";
        private static string CBINARY = "1000011";
        private static string CSOLUTION = "0 0 00 0000 0 00";

        //String "CC" input and converted form
        private static string CCINPUT = "CC";
        private static string CCBINARY = "10000111000011";
        private static string CCSOLUTION = "0 0 00 0000 0 000 00 0000 0 00";

        //String "%" input and converted form
        private static string PERCENTINPUT = "%";
        private static string PERCENTBINARY = "0100101";
        private static string PERCENTSOLUTION = "00 0 0 0 00 00 0 0 00 0 0 0";

        //String "Chuck Norris' keyboard has 2 keys: 0 and white space." input and converted form
        private static string MESSAGEINPUT = "Chuck Norris' keyboard has 2 keys: 0 and white space.";
        private static string MESSAGESOLUTION = "0 0 00 0000 0 0000 00 0 0 0 00 000 0 000 00 0 0 0 00 0 0 000 00 000 0 0000 00 0 0 0 00 0 0 00 00 0 0 0 00 00000 0 0 00 00 0 000 00 0 0 00 00 0 0 0000000 00 00 0 0 00 0 0 000 00 00 0 0 00 0 0 00 00 0 0 0 00 00 0 0000 00 00 0 00 00 0 0 0 00 00 0 000 00 0 0 0 00 00000 0 00 00 0 0 0 00 0 0 0000 00 00 0 0 00 0 0 00000 00 00 0 000 00 000 0 0 00 0 0 00 00 0 0 000000 00 0000 0 0000 00 00 0 0 00 0 0 00 00 00 0 0 00 000 0 0 00 00000 0 00 00 0 0 0 00 000 0 00 00 0000 0 0000 00 00 0 00 00 0 0 0 00 000000 0 00 00 00 0 0 00 00 0 0 00 00000 0 00 00 0 0 0 00 0 0 0000 00 00 0 0 00 0 0 00000 00 00 0 0000 00 00 0 00 00 0 0 000 00 0 0 0 00 00 0 0 00 000000 0 00 00 00000 0 0 00 00000 0 00 00 0000 0 000 00 0 0 000 00 0 0 00 00 00 0 0 00 000 0 0 00 00000 0 000 00 0 0 00000 00 0 0 0 00 000 0 00 00 0 0 0 00 00 0 0000 00 0 0 0 00 00 0 00 00 00 0 0 00 0 0 0 00 0 0 0 00 00000 0 000 00 00 0 00000 00 0000 0 00 00 0000 0 000 00 000 0 0000 00 00 0 0 00 0 0 0 00 0 0 0 00 0 0 000 00 0";

        [TestMethod]
        public void TestCToBinary()
        {
            Assert.AreEqual(CBINARY, Unary.Solution.GetBinaryVersionOfString(CINPUT));
        }

        [TestMethod]
        public void TestCCToBinary()
        {
            Assert.AreEqual(CCBINARY, Unary.Solution.GetBinaryVersionOfString(CCINPUT));
        }

        [TestMethod]
        public void TestPercentToBinary()
        {
            Assert.AreEqual(PERCENTBINARY, Unary.Solution.GetBinaryVersionOfString(PERCENTINPUT));
        }

        [TestMethod]
        public void TestCBinaryToUnary()
        {
            Assert.AreEqual(CSOLUTION, Unary.Solution.BinaryToUnary(CBINARY));
        }

        [TestMethod]
        public void TestCCBinaryToUnary()
        {
            Assert.AreEqual(CCSOLUTION, Unary.Solution.BinaryToUnary(CCBINARY));
        }

        [TestMethod]
        public void TestPercentBinaryToUnary()
        {
            Assert.AreEqual(PERCENTSOLUTION, Unary.Solution.BinaryToUnary(PERCENTBINARY));
        }

        [TestMethod]
        public void TestCToUnary()
        {
            Assert.AreEqual(CSOLUTION, Unary.Solution.ConvertStringToUnary(CINPUT));
        }

        [TestMethod]
        public void TestCCToUnary()
        {
            Assert.AreEqual(CCSOLUTION, Unary.Solution.ConvertStringToUnary(CCINPUT));
        }

        [TestMethod]
        public void TestPercentToUnary()
        {
            Assert.AreEqual(PERCENTSOLUTION, Unary.Solution.ConvertStringToUnary(PERCENTINPUT));
        }

        [TestMethod]
        public void TestMessageToUnary()
        {
            Assert.AreEqual(MESSAGESOLUTION, Unary.Solution.ConvertStringToUnary(MESSAGEINPUT));
        }
    }
}
