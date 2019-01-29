using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_4_FileParser.BL;
using Task_4_FileParser.Presentation.Models;
using Task_4_FileParser.BL.Interfaces;
using Task_4_FileParser.Presentation.Interfaces;

namespace Task_4_FileParser.Presentation
{
    public class Application
    {
        public void Start(params string[] args)
        {
            IUserInterface UI = new ConsoleUI();

            Feature selectedFeature;
            string path;
            string pattern;
            string newValue;
            bool ignoreCase;

            try
            {
                selectedFeature = ArgumentsAnalyzer.ParseArgs(args, out path,
                    out pattern, out newValue, out ignoreCase);
            }
            catch (ArgumentException ex)
            {
                UI.ShowError(ex.Message);
                UI.ShowHelp();
                return;
            }

            switch (selectedFeature)
            {
                case Feature.Help:
                    UI.ShowHelp();
                    break;
                case Feature.Find:
                    SearchedItemsCollectionModel searchedItemsCollection =
                        Find(path, pattern, ignoreCase);
                    UI.ShowSearchedItems(searchedItemsCollection.SearchedItems,
                        searchedItemsCollection.Count);
                    break;
                case Feature.Replace:
                    ReplacedItemsCollectionModel replacedItems =
                        Replace(path, pattern, newValue, ignoreCase);
                    UI.ShowReplacedItems(replacedItems.SearchedItems,
                        replacedItems.NewValue, replacedItems.Count);
                    break;
            }
        }

        private SearchedItemsCollectionModel Find(string path,
            string pattern, bool ignoreCase)
        {
            IFileReader fileReader = new FileReader(path);
            IStringSplitter stringSplitter = new StringSplitter();
            ISearchable searchService = new SearchService();
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

                int[] indexes = searchService.GetIndexes(currentLine,
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

        private ReplacedItemsCollectionModel Replace(string path, 
            string pattern, string newValue, bool ignoreCase)
        {
            IFileReader fileReader = new FileReader(path);
            IFileWriter fileWriter = new FileWriter(path);
            ISearchable searchService = new SearchService();
            IStringSplitter stringSplitter = new StringSplitter();
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
                int[] indexes = searchService.GetIndexes(currentLine,
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

        private static string GetCurrentLine(IFileReader fileReader, string nextLine)
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