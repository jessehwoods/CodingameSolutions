using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

/**
 * Tests for a solution to the puzzle at https://www.codingame.com/training/easy/mime-type
 */
namespace MimeTypeTests
{
    [TestClass]
    public class MimeTypeTests
    {

        private MimeType.Solution.Classifier classifier;

        private static string OUTPUTUNKNOWN = "UNKNOWN";

        private static string MINPUT1 = "html text/html";
        private static string MINPUT2 = "png image/png";
        private static string MINPUT3 = "gif image/gif";
        private static string MINPUT4 = "txt text/plain";
        private static string MINPUT5 = "css text/css";

        private static string MOUTPUT1 = "text/html";
        private static string MOUTPUT2 = "image/png";
        private static string MOUTPUT3 = "image/gif";
        private static string MOUTPUT4 = "text/plain";
        private static string MOUTPUT5 = "text/css";

        private static string FNAME1 = "a.b.html";
        private static string FNAME2 = "picture..png";
        private static string FNAME3 = "animated.gif";
        private static string FNAME4 = "name.tXt";
        private static string FNAME5 = "resolv.CSS";

        private string FNAMEUNKOWN1 = "a.html.b";
        private string FNAMEUNKOWN2 = "picture.png.";
        private string FNAMEUNKOWN3 = "gif";
        private string FNAMEUNKOWN4 = "name...";
        private string FNAMEUNKOWN5 = "resolv.cSv";

        [TestInitialize]
        public void TestInitialize()
        {
            classifier = new MimeType.Solution.Classifier();
        }

        // Check an empty classifier will return "UNKNOWN" to everything.
        [TestMethod]
        public void TestEmpty()
        {
            Assert.AreEqual(OUTPUTUNKNOWN, classifier.ClassifyFilename(FNAME1));
            Assert.AreEqual(OUTPUTUNKNOWN, classifier.ClassifyFilename(FNAME2));
            Assert.AreEqual(OUTPUTUNKNOWN, classifier.ClassifyFilename(FNAME3));
            Assert.AreEqual(OUTPUTUNKNOWN, classifier.ClassifyFilename(FNAME4));
            Assert.AreEqual(OUTPUTUNKNOWN, classifier.ClassifyFilename(FNAME5));

            Assert.AreEqual(OUTPUTUNKNOWN, classifier.ClassifyFilename(FNAMEUNKOWN1));
            Assert.AreEqual(OUTPUTUNKNOWN, classifier.ClassifyFilename(FNAMEUNKOWN2));
            Assert.AreEqual(OUTPUTUNKNOWN, classifier.ClassifyFilename(FNAMEUNKOWN3));
            Assert.AreEqual(OUTPUTUNKNOWN, classifier.ClassifyFilename(FNAMEUNKOWN4));
            Assert.AreEqual(OUTPUTUNKNOWN, classifier.ClassifyFilename(FNAMEUNKOWN5));
        }

        // Check a classifier with MIME types loaded, should give expected output to the name types and unknown to the unkown types.
        [TestMethod]
        public void TestMimeTypesAdded()
        {
            classifier.AddMimeType(MINPUT1);
            classifier.AddMimeType(MINPUT2);
            classifier.AddMimeType(MINPUT3);
            classifier.AddMimeType(MINPUT4);
            classifier.AddMimeType(MINPUT5);

            Assert.AreEqual(MOUTPUT1, classifier.ClassifyFilename(FNAME1));
            Assert.AreEqual(MOUTPUT2, classifier.ClassifyFilename(FNAME2));
            Assert.AreEqual(MOUTPUT3, classifier.ClassifyFilename(FNAME3));
            Assert.AreEqual(MOUTPUT4, classifier.ClassifyFilename(FNAME4));
            Assert.AreEqual(MOUTPUT5, classifier.ClassifyFilename(FNAME5));

            Assert.AreEqual(OUTPUTUNKNOWN, classifier.ClassifyFilename(FNAMEUNKOWN1));
            Assert.AreEqual(OUTPUTUNKNOWN, classifier.ClassifyFilename(FNAMEUNKOWN2));
            Assert.AreEqual(OUTPUTUNKNOWN, classifier.ClassifyFilename(FNAMEUNKOWN3));
            Assert.AreEqual(OUTPUTUNKNOWN, classifier.ClassifyFilename(FNAMEUNKOWN4));
            Assert.AreEqual(OUTPUTUNKNOWN, classifier.ClassifyFilename(FNAMEUNKOWN5));
        }

    }
}
