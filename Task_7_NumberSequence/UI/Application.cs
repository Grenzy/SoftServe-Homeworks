using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_7_NumberSequence.BL;
using Task_7_NumberSequence.Interfaces;

namespace Task_7_NumberSequence.UI
{
    class Application
    {
        public void Start(string[] args)
        {
            IUserInterface UI = new ConsoleUI();
            ISequence<int> sequence = new LessThenSquareSequence();
            int upperBound = 0;
            try
            {
                upperBound = CommandLinesAnalyzer.Parse(args);
            }
            catch (Exception ex)
            {
                UI.ShowError(ex.Message);
                UI.ShowHelp();
                return;
            }
            int[] lessThenSqrtSequence = sequence.GetSequence(upperBound);
            if (lessThenSqrtSequence.Length > 0)
            {
                UI.ShowRange(lessThenSqrtSequence);
            }
            else
            {
                UI.ShowNumbersNotFoundMessage();
            }
        }
    }
}
