using System;
using System.Collections.Generic;
using Task_4_FileParser.BL.Interfaces;

namespace Task_4_FileParser.BL
{
    public class SearchService: ISearchable
    {
        public int[] GetIndexes(string source, string pattern, bool IgnoreCase)
        {
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
