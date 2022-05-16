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
            Console.WriteLine(ConvertString(MESSAGE));
        }

        internal static string ConvertString(string ToConvert)
        {
            return "blah";
        }
    }

}
