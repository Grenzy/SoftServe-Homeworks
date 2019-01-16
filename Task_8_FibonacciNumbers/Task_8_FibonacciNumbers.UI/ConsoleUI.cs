using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8_FibonacciNumbers.UI
{
    public class ConsoleUI
    {
        public static void ShowError(string error)
        {
            string message = $"Error: {error}";
            Console.WriteLine(message);
        }
        public static void ShowHelp()
        {
            string message = "<int> <int>" 
                + Environment.NewLine + "First argument - lower bound"
                + Environment.NewLine + "Second argument - upper bound";
            Console.WriteLine(message);
        }
        public static void ShowRange(int[] range)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (int number in range)
            {
                stringBuilder.Append(number + " ");
            }
            Console.WriteLine(stringBuilder);
        }
        public static void ShowNumbersNotFoundMessage()
        {
            string message = "There are no Fibonacci numbers in this interval.";
            Console.WriteLine(message);
        }

    }
}
