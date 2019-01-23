using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_Envelopes.Presentation.Models;

namespace Task_2_Envelopes.Presentation
{
    class ConsoleUI
    {
        public void DisplayError(string message)
        {
            Console.WriteLine("Error: " + message);
        }
        public EnvelopeModel GetEnvelopeParameters(string name)
        {
            string suggestionForInput = "Enter the parameters of the {0} envelope: ";
            Console.Write(suggestionForInput, name);
            string parameters = Console.ReadLine();
            double width;
            double height;
            InputStringAnalyze.ParseEnvelopeParameters(parameters, out width, out height);
            return new EnvelopeModel(width, height);
        }
        public void DisplayResult(bool isNested)
        {
            if (isNested)
            {

            }
        }
    }
}
