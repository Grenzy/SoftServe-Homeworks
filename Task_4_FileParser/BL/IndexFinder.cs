using System;
using System.Collections.Generic;
using Task_4_FileParser.BL.Interfaces;

namespace Task_4_FileParser.BL
{
    public class IndexFinder: IFinder
    {
        public int[] GetIndexes(string source, string pattern, bool IgnoreCase)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if(pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }

            StringComparison comparison;
            if (IgnoreCase)
            {
                comparison = StringComparison.CurrentCultureIgnoreCase;
            }
            else
            {
                comparison = StringComparison.CurrentCulture;
            }

            var indexes = new List<int>();

            int index;

            index = -1;
            do
            {
                index++;
                index = source.IndexOf(pattern, index, comparison);
                if (index >= 0)
                {
                    indexes.Add(index);
                }

            } while (index >= 0);

            return indexes.ToArray();
        }

        
    }
}
