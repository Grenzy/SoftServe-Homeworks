using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8_FibonacciNumbers.UI;

namespace Task_8_FibonacciNumbers.UI
{
    class Application
    {
        public void Start(string[] args)
        {
            int lowerBound = 0;
            int upperBound = 0;
            try
            {
                ArgumentsAnalyzer.Parse(args, out lowerBound, out upperBound);
            }
            catch(ArgumentOutOfRangeException e)
            {
                ConsoleUI.ShowError(e.Message);
                ConsoleUI.ShowHelp();
            }
            catch(ArgumentException e)
            {
                ConsoleUI.ShowError(e.Message);
                ConsoleUI.ShowHelp();
            }
            catch(FormatException e)
            {
                ConsoleUI.ShowError(e.Message);
                ConsoleUI.ShowHelp();
            }
            catch(OverflowException e)
            {
                ConsoleUI.ShowError(e.Message);
                ConsoleUI.ShowHelp();
            }

            FibonacciNumbers fibonacciNumbers = new FibonacciNumbers(lowerBound);
            int[] numbers = fibonacciNumbers.GetRange(upperBound);

            if (numbers.Any())
            {
                ConsoleUI.ShowRange(numbers);
            }
            else
            {
                ConsoleUI.ShowNumbersNotFoundMessage();
            }
         
        }
    }
}
