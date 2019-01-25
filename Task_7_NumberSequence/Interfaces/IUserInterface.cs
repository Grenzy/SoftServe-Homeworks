using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7_NumberSequence.Interfaces
{
    public interface IUserInterface
    {
        void ShowError(string error);
        void ShowHelp();
        void ShowRange(int[] range);
        void ShowNumbersNotFoundMessage();

    }
}
