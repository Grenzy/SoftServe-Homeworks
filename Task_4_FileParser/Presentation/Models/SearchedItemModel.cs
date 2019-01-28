using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_FileParser.Presentation.Models
{
    public class SearchedItemModel
    {
        public SearchedItemModel(string[] partsOfLine, int patternStringNumber, string priviousLine, string nextLine)
        {
            PartsOfLine = partsOfLine;
            PatternStringNumber = patternStringNumber;
            PriviousLine = priviousLine;
            NextLine = nextLine;
        }
        public string[] PartsOfLine { get; set; }
        public int PatternStringNumber { get; set; }
        public string PriviousLine { get; set; }
        public string NextLine { get; set; }
    }
}
