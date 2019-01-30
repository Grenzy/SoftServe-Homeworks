using System;
using System.Linq;
using Task_8_FibonacciNumbers.BL;
using Task_8_FibonacciNumbers.BL.Interfaces;
using Task_8_FibonacciNumbers.Presentation.Interfaces;

namespace Task_8_FibonacciNumbers.Presentation
{
    class Application
    {
        public void Start(string[] args)
        {
            int lowerBound = 0;
            int upperBound = 0;
            IUserInterface UI = new ConsoleUI();

            try
            {
                CommandLinesAnalyzer.Parse(args, out lowerBound, out upperBound);
            }
            catch (ArgumentException e)
            {
                UI.ShowError(e.Message);
                UI.ShowHelp();
            }       
            catch(FormatException e)
            {
                UI.ShowError(e.Message);
                UI.ShowHelp();
            }
            catch(OverflowException e)
            {
                UI.ShowError(e.Message);
                UI.ShowHelp();
            }

            IRange fibonacciRange = new FibonacciRange();
            int[] numbers = fibonacciRange.GetRange(lowerBound, upperBound);

            if (numbers.Any())
            {
                UI.ShowRange(numbers);
            }
            else
            {
                UI.ShowNumbersNotFoundMessage();
            }
         
        }
    }
}
