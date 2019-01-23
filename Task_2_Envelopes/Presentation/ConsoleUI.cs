using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_Envelopes.Presentation.Interfaces;
using Task_2_Envelopes.Presentation.Models;

namespace Task_2_Envelopes.Presentation
{
    class ConsoleUI : IUserInterface
    {
        public void DisplayError(string message)
        {
            Console.WriteLine("Error: " + message);
        }
        public EnvelopeModel GetEnvelopeParameters(string name)
        {
            string suggestionForInput = "Enter the parameters of the {0} envelope";
            Console.WriteLine(suggestionForInput, name);
            Console.WriteLine("<width> <height>");
            string parameters = Console.ReadLine();
            double width;
            double height;
            InputStringAnalyzer.ParseEnvelopeParameters(parameters, out width, out height);

            return new EnvelopeModel(width, height);
        }
        public void DisplayResult(int result)
        {
            if (result == 1)
            {
                Console.WriteLine("The second envelope can be put in the first");
            }
            else if (result == -1)
            {
                Console.WriteLine("The first envelope can be put in the second");
            }
            else
            {
                Console.WriteLine("Envelopes cannot be nested inside each other");
            }
        }
        public bool DoesStartOver()
        {
            Console.WriteLine("Start over? y/yes");
            string answer = Console.ReadLine();

            return InputStringAnalyzer.AnalyzeAnswer(answer);
        }


    }
}
