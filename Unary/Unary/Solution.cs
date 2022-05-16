using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnaryTests")]

namespace Unary
{
    internal class Solution
    {
        static void Main(string[] args)
        {
            //Gets the string to be converted
            string MESSAGE = Console.ReadLine();

            //Returns the solution
            Console.WriteLine(ConvertStringToUnary(MESSAGE));
        }

        /**
         * Converts a string of arbitrary characters to unary.
         * 
         * Unary is based on the binary represenation of the binary represenation of the character, and is "0" for a block of 1s or "00" for a 
         * block of 0s, followed by a space and a number of 0s equal to the characters in the block. 
         */
        internal static string ConvertStringToUnary(string StringToConvert)
        {
            //Holds the binary representation of the string
            StringBuilder BinaryVersion = new StringBuilder();

            //Convert the string to a binary representation
            foreach (char c in StringToConvert)
            {
                BinaryVersion.Append(Convert.ToString((int) c, 2));
            }

            //Holds the string that will be returned
            StringBuilder ToReturn = new StringBuilder();

            //Convert the binary to unary

            return ToReturn.ToString();
        }

    }

}
