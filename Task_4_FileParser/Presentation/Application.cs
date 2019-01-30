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
                selectedFeature = CommandLinesAnalyzer.ParseArgs(args, out path,
                    out pattern, out newValue, out ignoreCase);
            }
            catch (ArgumentException ex)
            {
                UI.ShowError(ex.Message);
                UI.ShowHelp();
                return;
            }
            if (!File.Exists(path))
            {
                UI.ShowError("File is not exist");
                return;
            }

            IFileParser fileParser = new FileParser(new IndexFinder(),
                new StringSplitter());

            switch (selectedFeature)
            {
                case Feature.Help:
                    UI.ShowHelp();
                    break;
                case Feature.Find:
                    Find(UI, path, pattern, ignoreCase, fileParser);
                    break;
                case Feature.Replace:
                    Replace(UI, path, pattern, newValue, ignoreCase, fileParser);
                    break;
            }
        }

        private void Find(IUserInterface UI, string path, string pattern,
            bool ignoreCase, IFileParser fileParser)
        {
            SearchedItemsCollectionModel searchedItemsCollection;
            try
            {
                searchedItemsCollection =
                fileParser.Find(path, pattern, ignoreCase, new FileReader(path),
                new FileWriter(path));
            }
            catch (IOException ex)
            {
                UI.ShowError(ex.Message);
                return;
            }

            UI.ShowSearchedItems(searchedItemsCollection.SearchedItems,
                searchedItemsCollection.Count);
        }

        private void Replace(IUserInterface UI, string path, string pattern,
            string newValue, bool ignoreCase, IFileParser fileParser)
        {
            ReplacedItemsCollectionModel replacedItems;
            try
            {
                replacedItems = fileParser.Replace(path, pattern, newValue,
                    ignoreCase, new FileReader(path), new FileWriter(path));
            }
            catch (IOException ex)
            {
                UI.ShowError(ex.Message);
                return;
            }

            UI.ShowReplacedItems(replacedItems.SearchedItems,
                replacedItems.NewValue, replacedItems.Count);
        }
    }
}