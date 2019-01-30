using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_FileParser.BL.Interfaces
{
    public interface IFinder
    {
        int[] GetIndexes(string source, string pattern, bool IgnoreCase);
    }
}
