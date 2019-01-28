using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_FileParser.Presentation.Models
{
    public class ReplacedItemsCollectionModel
    {
        public SearchedItemModel[] SearchedItems { get; set; }
        public int Count { get; set; }
        public string NewValue { get; set; }

        public ReplacedItemsCollectionModel(SearchedItemModel[] searchedItems, int count, string newValue)
        {
            SearchedItems = searchedItems;
            Count = count;
            NewValue = newValue;
        }
    }
}
