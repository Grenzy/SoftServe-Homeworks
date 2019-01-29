using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_4_FileParser.BL.Interfaces;

namespace Task_4_FileParser.BL
{
    public class StringSplitter : IStringSplitter
    {
        public string[] SplitByIndexes(string source, int[] indexes,
            int patternLength)
        {
            List<string> parts = new List<string>();
            int previousIndex = 0;
            string leftPart = null;
            string pattern = null;
            foreach (int index in indexes)
            {
                leftPart = source.Substring(previousIndex, 
                    index - previousIndex);
                parts.Add(leftPart);
                pattern = source.Substring(index, patternLength);
                parts.Add(pattern);
                previousIndex = index + patternLength;
            }

            if (previousIndex != patternLength - 1)
            {
                parts.Add(source.Substring(previousIndex));
            }

            return parts.ToArray();
        }
    }
}
