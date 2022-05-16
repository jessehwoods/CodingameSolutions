using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnaryTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("blah", Unary.Solution.SayBlah());
        }
    }
}
