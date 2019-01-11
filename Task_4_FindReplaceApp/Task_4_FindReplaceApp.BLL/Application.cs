using Task_4_FindReplaceApp.DTO;
using Task_4_FindReplaceApp.CUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_FindReplaceApp.BLL
{
    public class Application
    {
        public void Start(params string[] args)
        {
            Feature selectedFeature;
            string path;
            string pattern;
            string newValue;
            bool ignoreCase;

            try
            {
                selectedFeature = ArgumentsAnalyzer.ParseArgs(args, out path, out pattern, out newValue, out ignoreCase);
            }
            catch (ArgumentException)
            {
                ConsoleUI.ShowHelp();
                return;
            }

            switch (selectedFeature)
            {
                case Feature.Help:
                    ConsoleUI.ShowHelp();
                    break;
                case Feature.Find:
                    List<SearchedItemDTO> searchedItems = Find(path, pattern, ignoreCase);
                    ConsoleUI.ShowSearchedItems(searchedItems);
                    break;
                case Feature.Replace:
                    List<ReplacedItemDTO> replacedItems = Replace(path, pattern, newValue, ignoreCase);
                    ConsoleUI.ShowReplacedItems(replacedItems);
                    break;
            }
        }

        private static List<SearchedItemDTO> Find(string path, string pattern, bool ignoreCase)
        {
            var file = File.ReadAllLines(path);
            var indexes = SearchService.GetAllIndexes(file, pattern, ignoreCase);
            var searchedItems = new List<SearchedItemDTO>();
            SearchService.SetPartsOfLineForSearchedDTO(file, searchedItems, indexes, pattern);
            SearchService.SetPriviousAndNextLines(file, searchedItems, indexes);
            return searchedItems;
        }

        private static List<ReplacedItemDTO> Replace(string path, string oldValue, string newValue, bool ignoreCase)
        {
            var file = File.ReadAllLines(path);
            var indexes = SearchService.GetAllIndexes(file, oldValue, ignoreCase);
            var replacedItems = new List<ReplacedItemDTO>();
            SearchService.SetPartsOfLineForReplacedDTO(file, replacedItems, indexes, oldValue);
            SearchService.SetPriviousAndNextLinesReplace(file, replacedItems, indexes);
            foreach (var p in replacedItems)
            {
                p.NewValue = newValue;
            }
            SearchService.Replace(file, indexes, oldValue, newValue);
            File.WriteAllLines(path, file);
            return replacedItems;
        }
    }
}
