using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5_NumberToWords.Presentation
{
    public class CommandLinesAnalyzer
    {
        public static void Parse(string[] args, out long number, out string language)
        {
            if (args.Length > 2)
            {
                throw new ArgumentOutOfRangeException("Number of arguments exceeded");
            }

            number = long.Parse(args[0]);

            if ((number > 999999999999) || (number < -999999999999))
            {
                throw new NotImplementedException("Out of range");
            }

            if (args.Length == 2)
            {
                if (args[1] == "-ru")
                {
                    language = "ru-RU";
                }
                else if (args[1] == "-en")
                {
                    language = "en-US";
                }
                else
                {
                    throw new ArgumentException($"Invalid key {args[1]}");
                }
            }
            else if (args.Length == 1)
            {
                language = "en-US";
            }
            else
            {
                throw new ArgumentNullException(typeof(string[]).ToString());
            }
        }
    }
}
