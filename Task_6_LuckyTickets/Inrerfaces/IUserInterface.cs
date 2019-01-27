using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8_LuckyTickets.Inrerfaces
{
    public interface IUserInterface
    {
        void ShowError(string message);
        void ShowHelp();

        void ShowTickets(IEnumerable<int[]> tickets);
        void ShowTotal(int total);
        string GetPath();
    }
}
