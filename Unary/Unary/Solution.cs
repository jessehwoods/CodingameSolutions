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
        //To be used for zero
        private static char ZERO = '0';

        //To be used for whitespace
        private static char WHITESPACE = (char) 32;

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
            //Convert the string to a string of '1' and '0' chars based on the binary
            string BinaryVersion = GetBinaryVersionOfString(StringToConvert);

            //Convert the binary to unary
            string UnaryVersion = GetUnaryVersionOfBinary(BinaryVersion);

            return UnaryVersion;
        }

        /**
         * Converts a string to a binary version of the string as a series of '1' and '0' characters with no whitespace.
         */
        internal static string GetBinaryVersionOfString(string CharStringToConvert)
        {
            StringBuilder BinaryVersion = new StringBuilder();

            foreach (char c in CharStringToConvert)
            {
                BinaryVersion.Append(Convert.ToString((int)c, 2));
            }

            return BinaryVersion.ToString();
        }

        /**
        * Converts a string to a unary version of the string as a series of '0' and whitespace characters.
         */
        internal static string GetUnaryVersionOfBinary(string BinaryStringToConvert)
        {
            StringBuilder UnaryVersion = new StringBuilder();

            //Handle the first character by adding the first part of the unary expression
            char CurrentChar = BinaryStringToConvert[0];
            UnaryVersion.Append(LeadCharacter(CurrentChar));

            //Convert the binary to an unary representation. Include the first character, because it needs to be counted for the second part of the
            //unary expression.
            foreach (char c in BinaryStringToConvert)
            {
                if (!c.Equals(CurrentChar))
                {
                    //If it's a new character, need to add the first part
                    UnaryVersion.Append(WHITESPACE);
                    UnaryVersion.Append(LeadCharacter(c));
                }
                //Always add a zero for each character to the second part.
                UnaryVersion.Append(ZERO);
            }

            return UnaryVersion.ToString();
        }

        /**
         * Gives you the correct firts part of an unary expression for the input character.
         */
        private static string LeadCharacter(char InputChar)
        {
            StringBuilder sb = new StringBuilder(3);
            sb.Append(ZERO);
            if (InputChar.Equals(ZERO))
            {
                sb.Append(ZERO);
            }
            sb.Append(WHITESPACE);

            return sb.ToString();
        }
    }

}
