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
            if (args.Length == 0)
            {
                Console.WriteLine("help");
                return;
            }
            if (args.Length < 2)
            {
                Console.WriteLine("Ошибка");
                return;
            }
            string path = args[0];
            if (!File.Exists(path))
            {
                Console.WriteLine("Ошибка");
                return;
            }

            string pattern = args[1];
            bool ignoreCase;
            string newValue = args[2];
            if (args.Length == 3)
            {
                if (args[2] == "-i")
                {
                    ignoreCase = true;
                }
                else if (args[2] == "-n")
                {
                    ignoreCase = false;
                }
                else
                {
                    Console.WriteLine("Ошибка");
                    return;
                }
                FindAndShow(path, pattern, ignoreCase);
            }
            else
            {
                if (args[3] == "-i")
                {
                    ignoreCase = true;
                }
                else if (args[3] == "-n")
                {
                    ignoreCase = false;
                }
                else
                {
                    Console.WriteLine("Ошибка");
                    return;
                }
                ReplaceAndShow(path, pattern, newValue, ignoreCase);
            }
        }

        private static void FindAndShow(string path, string pattern, bool ignoreCase)
        {
            var file = File.ReadAllLines(path);
            var indexes = SearchService.GetAllIndexes(file, pattern, ignoreCase);
            var searchedItems = new List<SearchedItemDTO>();
            SearchService.SetPartsOfLineForSearchedDTO(file, searchedItems, indexes, pattern);
            SearchService.SetPriviousAndNextLines(file, searchedItems, indexes);
            ConsoleUI.ShowSearchedItems(searchedItems);
        }
        private static void ReplaceAndShow(string path, string oldValue, string newValue, bool ignoreCase)
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
            //File.WriteAllLines("2.txt", file);
            File.WriteAllLines(path, file);
            ConsoleUI.ShowReplacedItems(replacedItems);
        }

    }

}
