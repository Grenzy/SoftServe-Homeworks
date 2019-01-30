using System;
using Task_8_FibonacciNumbers.Presentation.Interfaces;

namespace Task_8_FibonacciNumbers.Presentation
{
    public class ConsoleUI : IUserInterface
    {
        private const string HELP_MESSAGE =
@"USAGE
    lower_bound upper_bound
WHERE
    lower_bound - integer
    upper_bound - integer";
        private const string ERROR_MESSAGE = "Error: {0}";
        private const string COMMA_SEPARATOR = ", ";
        private const string NOT_FOUND_MESSAGE = "There are no Fibonacci " +
            "numbers in this interval";

        public void ShowError(string error)
        {
            Console.WriteLine(ERROR_MESSAGE, error);
        }
        public void ShowHelp()
        {
            Console.WriteLine(HELP_MESSAGE);
        }
        public void ShowRange(int[] range)
        {
            string numbers = string.Join(COMMA_SEPARATOR, range);
            Console.WriteLine(numbers);
        }
        public void ShowNumbersNotFoundMessage()
        {
            Console.WriteLine(NOT_FOUND_MESSAGE);
        }

    }
}
