using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4.BLL.DTO
{
    public class SearchedItemDTO
    {
        public string Pattern { get; set; }
        public string RightPart { get; set; }
        public string LeftPart { get; set; }
        public int PatternStringNumber { get; set; }
        public string PriviousLine { get; set; }
        public string NextLine { get; set; }
    }
}
