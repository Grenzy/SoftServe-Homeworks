using Homework_4.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4.BLL
{
    class SearchService
    {
        public static List<KeyValuePair<int, int>> GetAllIndexes(IList<string> file, string pattern, bool IgnoreCase)
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
            var indexes = new List<KeyValuePair<int, int>>();
            int index;
            for (int i = 0; i < file.Count; i++)
            {
                index = -1;
                do
                {
                    index++;
                    index = file[i].IndexOf(pattern, index, comparison);
                    if (index >= 0)
                    {
                        indexes.Add(new KeyValuePair<int, int>(i, index));

                    }
                } while (index >= 0);
            }
            return indexes;
        }

        public static void SetPartsOfLine(IList<string> file, IList<SearchedItemDTO> searcheditems, IList<KeyValuePair<int, int>> indexes, string pattern)
        {
            for (int i = 0; i < indexes.Count; i++)
            {
                searcheditems.Add(new SearchedItemDTO());
                var partsOfLine = GetPartOfLines(file[indexes[i].Key], pattern, indexes[i].Value);
                var searchedItem = searcheditems.Last();
                searchedItem.RightPart = partsOfLine.Right;
                searchedItem.Pattern = partsOfLine.Pattern;
                searchedItem.LeftPart = partsOfLine.Left;
            }
        }
        private static PartsOfLine GetPartOfLines(string source, string pattern, int index)
        {
            var partsOfLine = new PartsOfLine();
            partsOfLine.Right = source.Substring(0, index);
            partsOfLine.Pattern = source.Substring(index, pattern.Length);
            partsOfLine.Left = source.Substring(index + pattern.Length);
            return partsOfLine;
        }
        public static void SetPriviousAndNextLines(IList<string> file, IList<SearchedItemDTO> searcheditems, IList<KeyValuePair<int, int>> indexes)
        {
            for (int i = 0; i < indexes.Count; i++)
            {
                int currentIndex = indexes[i].Key;
                if (currentIndex > 0)
                {
                    searcheditems[i].PriviousLine = file[currentIndex - 1];
                }
                if (currentIndex + 1 < file.Count)
                {
                    searcheditems[i].NextLine = file[currentIndex + 1];
                }
                searcheditems[i].PatternStringNumber = currentIndex + 1;
            }
        }
    }
}
