using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4.BLL
{
    class SearchService
    {
        public static IList<int> GetAllIndexes(string str, string pattern, bool IgnoreCase)
        {
            StringComparison comparison;
            if (IgnoreCase)
            {
                comparison = StringComparison.InvariantCultureIgnoreCase;
            }
            else
            {
                comparison = StringComparison.InvariantCulture;
            }

            List<int> indexes = new List<int>();
            int index;
            for (int i = 0; i < str.Length; i++)
            {
                index = str.IndexOf(pattern, i, comparison);
                if (index >= 0)
                {
                    indexes.Add(index);
                }
            }
            return indexes;
        }
        public static IList<RightLeftPart> GetRightAndLeftParts(string str, IEnumerable<int> indexes, int length)
        {

        }
    }
}
