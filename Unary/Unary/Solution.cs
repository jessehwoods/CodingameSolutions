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
            Console.WriteLine(SayBlah());
        }

        internal static string SayBlah()
        {
            return "blah";
        }
    }

}
