using Task_4_FindReplaceApp.BLL.DTO;
using Task_4_FindReplaceApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_FindReplaceApp.BLL
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

        public static void SetPartsOfLineForSearchedDTO(IList<string> file, IList<SearchedItemDTO> searcheditems, IList<KeyValuePair<int, int>> indexes, string pattern)
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
        public static void SetPartsOfLineForReplacedDTO(IList<string> file, IList<ReplacedItemDTO> searcheditems, IList<KeyValuePair<int, int>> indexes, string pattern)
        {
            for (int i = 0; i < indexes.Count; i++)
            {
                searcheditems.Add(new ReplacedItemDTO());
                var partsOfLine = GetPartOfLines(file[indexes[i].Key], pattern, indexes[i].Value);
                var searchedItem = searcheditems.Last();
                searchedItem.RightPart = partsOfLine.Right;
                searchedItem.OldValue = partsOfLine.Pattern;
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
        public static void SetPriviousAndNextLinesReplace(IList<string> file, IList<ReplacedItemDTO> searcheditems, IList<KeyValuePair<int, int>> indexes)
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
        public static void Replace(string[] file, IList<KeyValuePair<int, int>> indexes, string oldValue, string newValue)
        {
            for (int i = 0; i < indexes.Count; i++)
            {
                file[indexes[i].Key] = Replace(file[indexes[i].Key], indexes[i].Value, oldValue, newValue);
                for (int j = i; j < indexes.Count; j++)
                {
                    if (indexes[j].Key == indexes[i].Key)
                    {
                       int newIndex = oldValue.Length > newValue.Length ? indexes[j].Value - (oldValue.Length - newValue.Length) : indexes[j].Value + (newValue.Length - oldValue.Length);
                        //int newIndex = indexes[j].Value;
                        indexes[j] = new KeyValuePair<int, int>(indexes[j].Key, newIndex);
                
                    }
                }
            }
        }
        private static string Replace(string source, int index, string oldValue, string newValue)
        {
            var partsOfLine = GetPartOfLines(source, oldValue, index);
            return partsOfLine.Right + newValue + partsOfLine.Left;
        }
    }
}
