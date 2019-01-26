using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_5_NumberToWords.BL;
using Humanizer;

namespace Task_5_NumberToWords.UI
{
    class Application
    {
        public void Start(string[] args)
        {
            
            long number;
            string language;
            ConsoleUI UI = new ConsoleUI();

            try
            {
                CommandLinesAnalyzer.Parse(args, out number, out language);
            }
            catch (ArgumentNullException ex)
            {
                UI.ShowError(ex.Message);
                return;
            }
            catch (Exception ex)
            {
                UI.ShowHelp();
                return;
            }

            string numberInWords = number.ToWords(new System.Globalization.CultureInfo(language));
            UI.ShowNumber(numberInWords);
        }
    }
}
