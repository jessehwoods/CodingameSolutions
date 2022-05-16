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

        private static string Input1 = "3\n3\nhtml text/html\npng image/png\ngif image/gif\nanimated.gif\nportrait.png\nindex.html";
        private static string Output1 = "image/gif\nimage/png\ntext/html";

        private static string Input2 = "3\n4\ntxt text/plain\nxml text/xml\nflv video/x-flv\nimage.png\nanimated.gif\nscript.js\nsource.cpp";
        private static string Output2 = "";

        private static string Input3 = "3\n11\nwav audio/x-wav\nmp3 audio/mpeg\npdf application/pdf\na\na.wav\nb.wav.tmp\ntest.vmp3\npdf\n.pdf\nmp3\nreport..pdf\ndefaultwav\n.mp3.\nfinal.";
        private static string Output3 = "";

        private static string Input4 = "4\n7\npng image/png\nTIFF image/TIFF\ncss text/css\nTXT text/plain\nexample.TXT\nreferecnce.txt\nstrangename.tiff\nresolv.CSS\nmatrix.TiFF\nlanDsCape.Png\nextract.cSs";
        private static string Output4 = "";


        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
