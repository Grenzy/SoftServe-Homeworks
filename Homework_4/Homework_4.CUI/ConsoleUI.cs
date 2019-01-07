using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_4.DTO;
namespace Homework_4.CUI
{
    public class ConsoleUI
    {
        public static void ShowSearchedItems(IList<SearchedItemDTO> si)
        {
            for (int i = 0; i < si.Count; i++)
            {
                Console.WriteLine(new String('-', 120));
                if (si[i].PriviousLine != null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"{si[i].PatternStringNumber - 1}.");
                    Console.ResetColor();
                    Console.WriteLine($"{si[i].PriviousLine}");
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{si[i].PatternStringNumber}. ");
                Console.ResetColor();
                Console.Write($"{si[i].RightPart}");
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write($"{si[i].Pattern}");
                Console.ResetColor();
                Console.WriteLine($"{si[i].LeftPart}");
                if (si[i].NextLine != null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"{si[i].PatternStringNumber + 1}. ");
                    Console.ResetColor();
                    Console.WriteLine($"{si[i].NextLine}");
                }

            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Number of line entries in a text file: {si.Count}");
        }
        public static void ShowReplacedItems(IList<ReplacedItemDTO> ri)
        {
            for (int i = 0; i < ri.Count; i++)
            {
                Console.WriteLine(new String('-', 120));
                if (ri[i].PriviousLine != null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"{ri[i].PatternStringNumber - 1}.");
                    Console.ResetColor();
                    Console.WriteLine($"{ri[i].PriviousLine}");
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{ri[i].PatternStringNumber}. ");
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write($"{ri[i].RightPart}");
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"{ri[i].OldValue}");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ri[i].LeftPart}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{ri[i].PatternStringNumber}. ");
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write($"{ri[i].RightPart}");
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"{ri[i].NewValue}");
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{ri[i].LeftPart}");
                Console.ResetColor();
                if (ri[i].NextLine != null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"{ri[i].PatternStringNumber + 1}. ");
                    Console.ResetColor();
                    Console.WriteLine($"{ri[i].NextLine}");
                }

            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Number of replacements: {ri.Count}");
        }
    }
}
