using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_FindReplaceApp.BLL
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
            }
            if (args.Length < 2)
            {
                throw new ArgumentException("Invalid parameters");
            }

            path = args[0];
            pattern = args[1];

            if (args.Length == 3)
            {
                selectedFeature = Feature.Find;
                newValue = string.Empty;
                if (args[2] == "-i")
                {
                    ignoreCase = true;
                }
                else if (args[2] == "-n")
                {
                    ignoreCase = false;
                }
                else
                {
                    throw new ArgumentException("Invalid parameters");
                }
            }
            else
            {
                selectedFeature = Feature.Replace;
                newValue = args[2];

                if (args[3] == "-i")
                {
                    ignoreCase = true;
                }
                else if (args[3] == "-n")
                {
                    ignoreCase = false;
                }
                else
                {
                    throw new ArgumentException("Invalid parameters");
                }
            }
            return selectedFeature;
        }
    }
}
