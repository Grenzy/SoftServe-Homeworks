using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_5_NumberToWords.Interfaces;

namespace Task_5_NumberToWords.UI
{
    public class ConsoleUI: IUserInterface
    {
        public void ShowError(string Message)
        {
            Console.WriteLine("Error: " + Message);
        }
        public void ShowNumber(string number)
        {
            Console.WriteLine(number);
        }
        public void ShowHelp()
        {
            string message = "USAGE:" +
                Environment.NewLine +
                "number [-en]|[-ru]" +
                Environment.NewLine +
                "Where: number is number between -999999999999 and 999999999999" +
                Environment.NewLine +
                "Optiions:" +
                Environment.NewLine +
                "-en (default)" +
                Environment.NewLine +
                "-ru";
            Console.WriteLine(message);
        }
    }
}
