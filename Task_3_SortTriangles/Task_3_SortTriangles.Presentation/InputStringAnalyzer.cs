using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_SortTriangles.Presentation
{
    internal class InputStringAnalyzer
    {
        public static void ParseTriangleParameters(string inputString, out string name, out double sideA, out double sideB, out double sideC)
        {
            string[] values = inputString.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (values.Length != 4)
            {
                throw new ArgumentException("Arguments should be 4");
            }
            name = values[0];
            sideA = double.Parse(values[1]);
            sideB = double.Parse(values[2]);
            sideC = double.Parse(values[3]);
        }
        public static bool ParseDoesNeedNext(string inputString)
        {
            return inputString.Equals("Y", StringComparison.CurrentCultureIgnoreCase)
               || (inputString.Equals("YES", StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
