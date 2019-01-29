using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_4_FileParser.Presentation.Models;

namespace Task_4_FileParser.Presentation.Interfaces
{
    interface IUserInterface
    {
        void ShowSearchedItems(IList<SearchedItemModel> searchedItems,
            int Count);
        void ShowReplacedItems(SearchedItemModel[] searchedItems,
            string newValue, int Count);
        void ShowHelp();
        void ShowError(string message);
    }
}
