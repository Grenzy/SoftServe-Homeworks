using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_4.BLL.DTO;
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
                    Console.WriteLine($"{si[i].PatternStringNumber - 1}. {si[i].PriviousLine}");
                }
                Console.Write($"{si[i].PatternStringNumber}. {si[i].RightPart}");
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write($"{si[i].Pattern}");
                Console.ResetColor();
                Console.WriteLine($"{si[i].LeftPart}");
                if (si[i].NextLine != null)
                {
                    Console.WriteLine($"{si[i].PatternStringNumber + 1}. {si[i].NextLine}");
                }

            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Number of line entries in a text file: {si.Count}");
        }
    }
}
