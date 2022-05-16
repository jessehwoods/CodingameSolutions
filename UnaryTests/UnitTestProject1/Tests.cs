using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnaryTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("blah", Unary.Solution);
        }
    }
}
