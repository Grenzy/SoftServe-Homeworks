using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5_NumberToWords.Interfaces
{
    public interface IUserInterface
    {
        void ShowError(string Message);
        void ShowNumber(string number);
        void ShowHelp();
    }
}
