using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_FindReplaceApp.DTO
{
    public class ReplacedItemDTO
    {
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string RightPart { get; set; }
        public string LeftPart { get; set; }
        public int PatternStringNumber { get; set; }
        public string PriviousLine { get; set; }
        public string NextLine { get; set; }
    }
}
