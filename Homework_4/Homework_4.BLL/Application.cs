using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4.BLL
{
    public class Application
    {
        public void Start(params string[] args)
        {
            string str = args[0];
            string pattern = args[1];
            bool ignoreCase = args[2] == "-i";
            var indexes = SearchService.GetAllIndexes(str, pattern, ignoreCase);

        }
    }
}
