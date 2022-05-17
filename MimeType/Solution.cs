﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("MimeTypeTests")]

/**
 * This is a solution to the puzzle at https://www.codingame.com/training/easy/mime-type
 */
namespace MimeType
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Text;
    using System.Collections;
    using System.Collections.Generic;

    /**
     * Auto-generated code below aims at helping you parse
     * the standard input according to the problem statement.
     **/
    internal class Solution
    {

        private static string UNKNOWN = "UNKNOWN";
        private static string WHITESPACE = " ";
        private static string NEWLINE = "\n";

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
            int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.

            Classifier classifier = new Classifier(); // Object to hold and determine file types

            //Add entries to the dictionary
            for (int i = 0; i < N; i++)
            {
                classifier.AddMimeType(Console.ReadLine());
            }

            //Process the file names
            for (int i = 0; i < Q; i++)
            {
                Console.WriteLine(classifier.ClassifyFilename(Console.ReadLine()));
            }

        }

        /**
         * An object that can be given file extensions and MIME types, as a string, and then return the appropriate MIME type or "UNKOWN" for
         * an input filename.
         */
        internal class Classifier
        {
            /**
             * Constructor that takes an expected number of entries to put in the dictionary.
             */
            private IDictionary<string, string> mimeTypes; // Holds the types to be recognized by this Classifier

            public Classifier()
            {
                // Set up the dictionary to be case insensitive
                StringComparer comparer = StringComparer.OrdinalIgnoreCase;
                this.mimeTypes = new Dictionary<string, string>(comparer);
            }

            /**
             * Takes in an extension and file type as a string in the form "Extension Type"
             */
            public void AddMimeType(string input)
            {
                string[] inputs = input.Split(' ');
                string EXT = inputs[0]; // file extension
                string MT = inputs[1]; // MIME type.
                this.mimeTypes.Add(EXT, MT);
            }

            public string ClassifyFilename(string input)
            {
                string FTYPE = null; // This will hold the MIME type, if a correct file extension is found
                string FEXT = null; //This will hold the extension, if it is found

                // Split on the '.' character
                string[] nameParts = input.Split('.');
                if (nameParts.Length > 1 && mimeTypes.TryGetValue(nameParts[nameParts.Length - 1], out FEXT) ) // This tells us if there was a '.' to split on and gets the last one.
                {
                    FTYPE = mimeTypes[FEXT];
                }
                // Do a null check on FEXT to see if we found a valid file extension
                if (FTYPE == null || FTYPE.Length == 0)
                {
                    FTYPE = UNKNOWN;
                }

                return FTYPE;
            }

        }

    }

}
