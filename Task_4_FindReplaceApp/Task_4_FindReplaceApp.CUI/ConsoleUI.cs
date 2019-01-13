using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_4_FindReplaceApp.DTO;
namespace Task_4_FindReplaceApp.CUI
{
    public class ConsoleUI
    {
        private const int CONSOLE_LENGTH = 120;
        private static readonly string separator = new String('-', CONSOLE_LENGTH);
        public static void ShowSearchedItems(IList<SearchedItemDTO> searchedItems)
        {
            for (int i = 0; i < searchedItems.Count; i++)
            {
                if (searchedItems[i].PriviousLine != null)
                {
                    ColorWrite($"{searchedItems[i].PatternStringNumber - 1}.", ConsoleColor.Black, ConsoleColor.DarkYellow);
                    Console.WriteLine($"{searchedItems[i].PriviousLine}");
                }

                ColorWrite($"{searchedItems[i].PatternStringNumber}. ", ConsoleColor.Black, ConsoleColor.DarkYellow);
                Console.Write($"{searchedItems[i].RightPart}");
                ColorWrite($"{searchedItems[i].Pattern}", ConsoleColor.DarkGreen, ConsoleColor.White);
                Console.WriteLine($"{searchedItems[i].LeftPart}");

                if (searchedItems[i].NextLine != null)
                {
                    ColorWrite($"{searchedItems[i].PatternStringNumber + 1}. ", ConsoleColor.Black, ConsoleColor.DarkYellow);
                    Console.WriteLine($"{searchedItems[i].NextLine}");
                }
                Console.WriteLine(separator);
            }

            string numberOfEntries = $"{Environment.NewLine}Number of line entries in a text file: {searchedItems.Count}";

            Console.WriteLine(numberOfEntries);
        }
        public static void ShowReplacedItems(IList<ReplacedItemDTO> replacedItems)
        {
            for (int i = 0; i < replacedItems.Count; i++)
            {
                if (replacedItems[i].PriviousLine != null)
                {
                    ColorWrite($"{replacedItems[i].PatternStringNumber - 1}.", ConsoleColor.Black, ConsoleColor.DarkYellow);
                    Console.WriteLine($"{replacedItems[i].PriviousLine}");
                }

                ColorWrite($"{replacedItems[i].PatternStringNumber}. ", ConsoleColor.Black, ConsoleColor.DarkYellow);
                ColorWrite($"{replacedItems[i].RightPart}", ConsoleColor.Red, ConsoleColor.White);
                ColorWrite($"{replacedItems[i].OldValue}", ConsoleColor.DarkMagenta, ConsoleColor.White);
                ColorWriteLine($"{replacedItems[i].LeftPart}", ConsoleColor.Red, ConsoleColor.White);

                ColorWrite($"{replacedItems[i].PatternStringNumber}. ", ConsoleColor.Black, ConsoleColor.DarkYellow);
                ColorWrite($"{replacedItems[i].RightPart}", ConsoleColor.DarkGreen, ConsoleColor.White);
                ColorWrite($"{replacedItems[i].NewValue}", ConsoleColor.DarkMagenta, ConsoleColor.White);
                ColorWriteLine($"{replacedItems[i].LeftPart}", ConsoleColor.DarkGreen, ConsoleColor.White);

                if (replacedItems[i].NextLine != null)
                {
                    ColorWrite($"{replacedItems[i].PatternStringNumber + 1}. ", ConsoleColor.Black, ConsoleColor.DarkYellow);
                    Console.WriteLine($"{replacedItems[i].NextLine}");
                }
                Console.WriteLine(separator);
            }

            string NumberOfReplacements = $"{Environment.NewLine}Number of replacements: {replacedItems.Count}";

            Console.WriteLine(NumberOfReplacements);
        }
        public static void ShowHelp()
        {
            Console.WriteLine("help");
        }
        private static void ColorWriteLine(string text, ConsoleColor backgraubdColor, ConsoleColor foregroundColor)
        {
            Console.BackgroundColor = backgraubdColor;
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        private static void ColorWrite(string text, ConsoleColor backgraubdColor, ConsoleColor foregroundColor)
        {
            Console.BackgroundColor = backgraubdColor;
            Console.ForegroundColor = foregroundColor;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
