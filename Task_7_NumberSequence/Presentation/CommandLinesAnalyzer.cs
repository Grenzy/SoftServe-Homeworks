using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7_NumberSequence.Presentation
{
    public class CommandLinesAnalyzer
    {
        public static int Parse(string[] commandLines)
        {
            if (commandLines.Length != 1)
            {
                throw new ArgumentOutOfRangeException("The number of arguments must be 1");
            }
            int result = int.Parse(commandLines[0]);

            return result;
        }
    }
}
