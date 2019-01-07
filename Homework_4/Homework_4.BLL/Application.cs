using Homework_4.BLL.DTO;
using Homework_4.CUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4.BLL
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
            bool ignoreCase = true;

            if (args.Length == 3)
            {
                FindAndShow(path, pattern, ignoreCase);
            }
  
  

        }

        private static void FindAndShow(string path, string pattern, bool ignoreCase)
        {
            var file = File.ReadAllLines(path);
            var indexes = SearchService.GetAllIndexes(file, pattern, ignoreCase);
            var searchedItems = new List<SearchedItemDTO>();
            SearchService.SetPartsOfLine(file, searchedItems, indexes, pattern);
            SearchService.SetPriviousAndNextLines(file, searchedItems, indexes);
            ConsoleUI.ShowSearchedItems(searchedItems);
        }
        private static void RepleceAndShow(string path, string pattern, bool ignoreCase)
        {
            var file = File.ReadAllLines(path);
            var indexes = SearchService.GetAllIndexes(file, pattern, ignoreCase);
            var searchedItems = new List<SearchedItemDTO>();
            SearchService.SetPartsOfLine(file, searchedItems, indexes, pattern);
            SearchService.SetPriviousAndNextLines(file, searchedItems, indexes);
            ConsoleUI.ShowSearchedItems(searchedItems);
        }

    }
    
}
