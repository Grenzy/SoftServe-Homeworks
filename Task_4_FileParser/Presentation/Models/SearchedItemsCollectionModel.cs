using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_FileParser.Presentation.Models
{
    class SearchedItemsCollectionModel
    {
        public SearchedItemModel[] SearchedItems { get; set; }
        public int Count { get; set; }
        public SearchedItemsCollectionModel(SearchedItemModel[] searchedItems, int count)
        {
            SearchedItems = searchedItems;
            Count = count;
        }
    }
}
