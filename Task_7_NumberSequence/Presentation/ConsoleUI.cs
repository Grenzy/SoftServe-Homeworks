using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_7_NumberSequence.Interfaces;

namespace Task_7_NumberSequence.Presentation
{
    class ConsoleUI : IUserInterface
    {
        public void ShowError(string error)
        {
            string message = $"Error: {error}";
            Console.WriteLine(message);
        }
        public void ShowHelp()
        {
            string message = "Command line format:" +
                Environment.NewLine +
                "<int>" +
                Environment.NewLine +
                "Where <int> - upper bound";

            Console.WriteLine(message);
        }
        public void ShowRange(int[] range)
        {
            string numbers = string.Join(", ", range);
            Console.WriteLine(numbers);
        }
        public void ShowNumbersNotFoundMessage()
        {
            string message = "There are no sequance numbers in this interval.";
            Console.WriteLine(message);
        }

    }
}
