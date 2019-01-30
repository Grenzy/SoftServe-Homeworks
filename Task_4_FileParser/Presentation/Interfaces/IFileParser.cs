using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_4_FileParser.BL.Interfaces;
using Task_4_FileParser.Presentation.Models;

namespace Task_4_FileParser.Presentation.Interfaces
{
    public interface IFileParser
    {
        SearchedItemsCollectionModel Find(string path, string pattern,
          bool ignoreCase, IFileReader fileReader, IFileWriter fileWriter);
        ReplacedItemsCollectionModel Replace(string path,
            string pattern, string newValue, bool ignoreCase,
            IFileReader fileReader, IFileWriter fileWriter);
    }
}
