using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_FileParser.Presentation
{
    static class ArgumentsAnalyzer
    {
        public static Feature ParseArgs(string[] args, out string path, out string pattern, out string newValue, out bool ignoreCase)
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

            if (args.Length < 2)
            {
                throw new ArgumentException("Missing required arguments");
            }

            path = args[0];
            pattern = args[1];

            if (args.Length == 3)
            {
                selectedFeature = Feature.Find;
                newValue = string.Empty;

                if (args[2].Equals("-i", StringComparison.CurrentCultureIgnoreCase))
                {
                    ignoreCase = true;
                }
                else if (args[2].Equals("-n", StringComparison.CurrentCultureIgnoreCase))
                {
                    ignoreCase = false;
                }
                else
                {
                    throw new ArgumentException("Invalid key: " + args[2]);
                }
            }
            else if (args.Length == 4)
            {
                selectedFeature = Feature.Replace;
                newValue = args[2];

                if (args[3].Equals("-i", StringComparison.CurrentCultureIgnoreCase))
                {
                    ignoreCase = true;
                }
                else if (args[3].Equals("-n", StringComparison.CurrentCultureIgnoreCase))
                {
                    ignoreCase = false;
                }
                else
                {
                    throw new ArgumentException("Invalid key: " + args[3]);
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
