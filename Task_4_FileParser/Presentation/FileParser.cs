using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_4_FileParser.BL;
using Task_4_FileParser.BL.Interfaces;
using Task_4_FileParser.Presentation.Interfaces;
using Task_4_FileParser.Presentation.Models;

namespace Task_4_FileParser.Presentation
{
    public class FileParser : IFileParser
    {
        private IFinder indexFinder;
        private IStringSplitter stringSplitter;

        public FileParser(IFinder indexFinder, IStringSplitter stringSplitter)
        {
            this.indexFinder = indexFinder;
            this.stringSplitter = stringSplitter;
        }
        public SearchedItemsCollectionModel Find(string path, string pattern,
            bool ignoreCase, IFileReader fileReader, IFileWriter fileWriter)
        {
            List<SearchedItemModel> searchedItems =
                new List<SearchedItemModel>();
            SearchedItemModel searchedItem = null;
            string previousLine = null;
            string currentLine = null;
            string nextLine = null;
            int lineNumber = 0;
            int countOfEntries = 0;
            do
            {
                lineNumber++;
                currentLine = GetCurrentLine(fileReader, nextLine);
                int[] indexes = indexFinder.GetIndexes(currentLine,
                    pattern, ignoreCase);
                nextLine = fileReader.ReadLine();

                if (indexes.Length != 0)
                {
                    countOfEntries += indexes.Length;
                    string[] partsOfLine = stringSplitter.SplitByIndexes(
                        currentLine, indexes, pattern.Length);
                    searchedItem = new SearchedItemModel(partsOfLine,
                        lineNumber, previousLine, nextLine);
                    searchedItems.Add(searchedItem);
                }
                previousLine = currentLine;

            } while (nextLine != null);

            return new SearchedItemsCollectionModel(searchedItems.ToArray(),
                countOfEntries);
        }

        public ReplacedItemsCollectionModel Replace(string path,
            string pattern, string newValue, bool ignoreCase,
            IFileReader fileReader, IFileWriter fileWriter)
        {
            List<SearchedItemModel> searchedItems =
                new List<SearchedItemModel>();
            SearchedItemModel searchedItem = null;
            string previousLine = null;
            string currentLine = null;
            string nextLine = null;
            int lineNumber = 0;
            int countOfEntries = 0;
            do
            {
                lineNumber++;
                currentLine = GetCurrentLine(fileReader, nextLine);
                int[] indexes = indexFinder.GetIndexes(currentLine,
                    pattern, ignoreCase);
                nextLine = fileReader.ReadLine();

                if (indexes.Length != 0)
                {
                    countOfEntries += indexes.Length;
                    string[] partsOfLine = stringSplitter.SplitByIndexes(
                        currentLine, indexes, pattern.Length);
                    searchedItem = new SearchedItemModel(partsOfLine,
                        lineNumber, previousLine, nextLine);
                    searchedItems.Add(searchedItem);
                    string replacedLine = CreateReplacedLine(partsOfLine,
                        newValue);
                    fileWriter.WriteTemporary(replacedLine);
                }
                else
                {
                    fileWriter.WriteTemporary(currentLine);
                }

                previousLine = currentLine;

            } while (nextLine != null);
            fileReader.Close();
            fileWriter.Close();
            return new ReplacedItemsCollectionModel(searchedItems.ToArray(),
                countOfEntries, newValue);
        }

        private string CreateReplacedLine(string[] parts, string newValue)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < parts.Length; index++)
            {
                if (index % 2 == 0)
                {
                    stringBuilder.Append(parts[index]);
                }
                else
                {
                    stringBuilder.Append(newValue);
                }
            }
            return stringBuilder.ToString();
        }

        private string GetCurrentLine(IFileReader fileReader, string nextLine)
        {
            string currentLine;
            if (nextLine == null)
            {
                currentLine = fileReader.ReadLine();
            }
            else
            {
                currentLine = nextLine;
            }

            return currentLine;
        }
    }
}
