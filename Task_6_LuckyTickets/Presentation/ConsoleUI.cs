using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8_LuckyTickets.Presentation.Inrerfaces;

namespace Task_8_LuckyTickets.Presentation
{
    public class ConsoleUI : IUserInterface
    {
        public void ShowError(string message)
        {
            Console.WriteLine("Error:" + message);
        }
        public void ShowHelp()
        {
            string message = "USAGE" + Environment.NewLine +
                "The first line in the file should contain the " +
                "name of the counting method: Moskow or Piter" +
                Environment.NewLine +
                "The remaining lines must contain 6-digit ticket numbers."
                + Environment.NewLine;
            Console.WriteLine(message);
        }

        public void ShowTickets(IEnumerable<int[]> tickets)
        {
            string message = "Lycky tickets: ";
            Console.WriteLine(message);
            foreach (var p in tickets)
            {
                Console.WriteLine(string.Join(null, p));
            }
        }

        public void ShowTotal(int total)
        {
            string message = "Total count: {0}";
            Console.WriteLine(message, total);
        }

        public string GetPath()
        {
            Console.WriteLine("Enter the file path:");
            string path = Console.ReadLine();
            return path;
        }

    }
}
