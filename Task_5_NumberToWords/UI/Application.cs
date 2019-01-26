﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_5_NumberToWords.BL;
using Task_5_NumberToWords.Interfaces;

namespace Task_5_NumberToWords.UI
{
    class Application
    {
        public void Start(string[] args)
        {
            long number;
            string language;
            IUserInterface UI = new ConsoleUI();

            try
            {
                CommandLinesAnalyzer.Parse(args, out number, out language);
            }
            catch (ArgumentNullException ex)
            {
                UI.ShowError(ex.Message);
                return;
            }
            catch (Exception)
            {
                UI.ShowHelp();
                return;
            }
            Interfaces.IConvertible convertToWords = new ConvertToWords();
            
            string numberToWords = convertToWords.NumberToWords(number, new System.Globalization.CultureInfo(language));
            UI.ShowNumber(numberToWords);
        }
    }
}
