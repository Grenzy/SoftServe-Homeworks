using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_FileParser.Presentation
{
    static class ArgumentsAnalyzer
    {
        private const int NUMBER_FOR_SEARCH = 3;
        private const int SEARCH_KEY_OPTION = 2;
        private const int NUMBER_FOR_REPLACE = 4;
        private const int REPLACE_KEY_OPTION = 3;
        private const int NEW_REPLACING_VALUE = 2;
        public static Feature ParseArgs(string[] args, out string path,
            out string pattern, out string newValue, out bool ignoreCase)
        {
            Feature selectedFeature;
            if (args.Length == 0)
            {
                selectedFeature = Feature.Help;
                path = string.Empty;
                pattern = string.Empty;
                newValue = string.Empty;
                ignoreCase = false;
                return selectedFeature;
            }

            if (args.Length < NUMBER_FOR_SEARCH)
            {
                throw new ArgumentException("Missing required arguments");
            }

            path = args[0];
            pattern = args[1];

            if (args.Length == NUMBER_FOR_SEARCH)
            {
                selectedFeature = Feature.Find;
                newValue = string.Empty;

                if (args[SEARCH_KEY_OPTION].Equals("-i", 
                    StringComparison.CurrentCultureIgnoreCase))
                {
                    ignoreCase = true;
                }
                else if (args[SEARCH_KEY_OPTION].Equals("-n", 
                    StringComparison.CurrentCultureIgnoreCase))
                {
                    ignoreCase = false;
                }
                else
                {
                    throw new ArgumentException("Invalid key: " + 
                        args[SEARCH_KEY_OPTION]);
                }
            }
            else if (args.Length == NUMBER_FOR_REPLACE)
            {
                selectedFeature = Feature.Replace;
                newValue = args[NEW_REPLACING_VALUE];

                if (args[REPLACE_KEY_OPTION].Equals("-i", 
                    StringComparison.CurrentCultureIgnoreCase))
                {
                    ignoreCase = true;
                }
                else if (args[REPLACE_KEY_OPTION].Equals("-n", 
                    StringComparison.CurrentCultureIgnoreCase))
                {
                    ignoreCase = false;
                }
                else
                {
                    throw new ArgumentException("Invalid key: " +
                        args[REPLACE_KEY_OPTION]);
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Extra arguments");
            }
            return selectedFeature;
        }
    }
}
