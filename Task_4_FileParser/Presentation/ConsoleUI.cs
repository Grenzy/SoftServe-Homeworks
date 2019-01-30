using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_4_FileParser.Presentation.Interfaces;
using Task_4_FileParser.Presentation.Models;

namespace Task_4_FileParser.Presentation
{
    public class ConsoleUI : IUserInterface
    {
        private const string HELP_MESSAGE =
@"USAGE: 
Search option: 
    path pattern -n|-i
WHERE
    path - path to file
    pattern - pattern for search
    -n - not ignore case option
    -i - ignore case option

Replace option:
    path pattern newValue -n|-i
WHERE
    path - path to file
    pattern - pattern for search
    newValue - value for replacement
    -n - not ignore case option
    -i - ignore case option

IMPORTANT: 
    All arguments are requred";
        private const string NUMBER_OF_ENTRIES = "{0}Number of line entries " +
            "in a text file: {1}";
        private const string NUMBER_OF_REPLACEMENTS = "{0}Number of " +
            "replacements: {1}";
        private const string ERROR_MESSAGE = "Error: ";
        private const int CONSOLE_LENGTH = 120;
        private static readonly string separator =
            new String('*', CONSOLE_LENGTH);

        public void ShowSearchedItems(IList<SearchedItemModel> searchedItems,
            int Count)
        {
            for (int i = 0; i < searchedItems.Count; i++)
            {
                if (searchedItems[i].PriviousLine != null)
                {
                    ColorWrite($"{searchedItems[i].PatternStringNumber - 1}. ",
                        ConsoleColor.Black, ConsoleColor.DarkYellow);
                    ColorWriteLine(searchedItems[i].PriviousLine, 
                        ConsoleColor.Black, ConsoleColor.DarkGray);
                }

                ColorWrite($"{searchedItems[i].PatternStringNumber}. ",
                    ConsoleColor.Black, ConsoleColor.DarkYellow);

                for (int j = 0; j < searchedItems[i].PartsOfLine.Length; j++)
                {
                    if (j % 2 == 1)
                    {
                        ColorWrite(searchedItems[i].PartsOfLine[j],
                            ConsoleColor.Black, ConsoleColor.Red);
                    }
                    else
                    {
                        Console.Write(searchedItems[i].PartsOfLine[j]);
                    }
                }
                Console.WriteLine();
                if (searchedItems[i].NextLine != null)
                {
                    ColorWrite($"{searchedItems[i].PatternStringNumber + 1}. ",
                        ConsoleColor.Black, ConsoleColor.DarkYellow);
                    ColorWriteLine(searchedItems[i].NextLine,
                        ConsoleColor.Black, ConsoleColor.DarkGray);
                }
                Console.Write(separator);
            }



            Console.WriteLine(NUMBER_OF_ENTRIES, Environment.NewLine, Count);
        }
        public void ShowReplacedItems(SearchedItemModel[] searchedItems,
            string newValue, int Count)
        {
            for (int i = 0; i < searchedItems.Length; i++)
            {
                if (searchedItems[i].PriviousLine != null)
                {
                    ColorWrite($"{searchedItems[i].PatternStringNumber - 1}. ",
                        ConsoleColor.Black, ConsoleColor.DarkYellow);
                    ColorWriteLine(searchedItems[i].PriviousLine,
              ConsoleColor.Black, ConsoleColor.DarkGray);
                }

                ColorWrite($"{searchedItems[i].PatternStringNumber}. ",
                    ConsoleColor.Black, ConsoleColor.DarkYellow);

                for (int j = 0; j < searchedItems[i].PartsOfLine.Length; j++)
                {
                    if (j % 2 == 1)
                    {
                        ColorWrite(searchedItems[i].PartsOfLine[j],
                            ConsoleColor.Red, ConsoleColor.White);
                    }
                    else
                    {
                        ColorWrite(searchedItems[i].PartsOfLine[j],
                            ConsoleColor.Red, ConsoleColor.DarkGray);
                    }
                }

                Console.WriteLine();
                ColorWrite($"{searchedItems[i].PatternStringNumber}. ",
                    ConsoleColor.Black, ConsoleColor.DarkYellow);
                for (int j = 0; j < searchedItems[i].PartsOfLine.Length; j++)
                {
                    if (j % 2 == 1)
                    {
                        ColorWrite(newValue, ConsoleColor.Green,
                            ConsoleColor.White);
                    }
                    else
                    {
                        ColorWrite(searchedItems[i].PartsOfLine[j],
                            ConsoleColor.Green, ConsoleColor.DarkGray);
                    }
                }

                Console.WriteLine();

                if (searchedItems[i].NextLine != null)
                {
                    ColorWrite($"{searchedItems[i].PatternStringNumber + 1}. ",
                        ConsoleColor.Black, ConsoleColor.DarkYellow);
                    ColorWriteLine(searchedItems[i].NextLine,
                ConsoleColor.Black, ConsoleColor.DarkGray);
                }
                Console.Write(separator);
            }

            Console.WriteLine(NUMBER_OF_REPLACEMENTS,
                Environment.NewLine, Count);
        }
        public void ShowHelp()
        {


            Console.WriteLine(HELP_MESSAGE);
        }
        public void ShowError(string message)
        {
            Console.WriteLine(ERROR_MESSAGE + message);
        }
        private static void ColorWriteLine(string text,
            ConsoleColor backgraubdColor, ConsoleColor foregroundColor)
        {
            Console.BackgroundColor = backgraubdColor;
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        private static void ColorWrite(string text,
            ConsoleColor backgraubdColor, ConsoleColor foregroundColor)
        {
            Console.BackgroundColor = backgraubdColor;
            Console.ForegroundColor = foregroundColor;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
