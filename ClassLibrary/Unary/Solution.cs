using System;
using System.Text;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnaryTests")]

/**
 * This is a solution to the puzzle at https://www.codingame.com/training/easy/unary
 * Solution successful as of 5/17/2022
 */
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
         * Converts a string of arbitrary characters to unary based on the binary of ASCII 7-bit characters.
         * 
         * Unary is based on the binary represenation of the binary represenation of the character, and is "0" for a block of 1s or "00" for a 
         * block of 0s, followed by a space and a number of 0s equal to the characters in the block. 
         */
        internal static string ConvertStringToUnary(string StringToConvert)
        {

            //Convert the string to a string of '1' and '0' chars based on the binary of ASCII 7-bit encoding.
            string BinaryVersion = GetBinaryVersionOfString(StringToConvert);

            //Convert the binary to unary
            string UnaryVersion = BinaryToUnary(BinaryVersion);

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
                BinaryVersion.Append( Convert.ToString(System.Convert.ToInt32(c), 2).PadLeft(7, ZERO));
            }

            return BinaryVersion.ToString();
        }

        /**
        * Converts a string to a unary version of the string as a series of '0' and whitespace characters.
         */
        internal static string BinaryToUnary(string BinaryStringToConvert)
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
                    //If it's a different character, need to add the first part of the unary expression
                    UnaryVersion.Append(WHITESPACE);
                    UnaryVersion.Append(LeadCharacter(c));
                    CurrentChar = c;
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
