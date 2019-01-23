using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_Envelopes.Presentation
{
    class InputStringAnalyzer
    {
        public static void ParseEnvelopeParameters(string inputString, out double width, out double height)
        {
            string[] values = inputString.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (values.Length != 2)
            {
                throw new ArgumentException("Arguments should be 2");
            }
            width = double.Parse(values[0]);
            height = double.Parse(values[1]);
        }
        public static bool AnalyzeAnswer(string answer)
        {
            return answer.Equals("Y", StringComparison.CurrentCultureIgnoreCase)
               || (answer.Equals("YES", StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
