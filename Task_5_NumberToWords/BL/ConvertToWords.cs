using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

namespace Task_5_NumberToWords.BL
{
    public class ConvertToWords:Task_5_NumberToWords.Interfaces.IConvertible
    {
        public string NumberToWords(long number, CultureInfo cultureInfo)
        {
            if(cultureInfo == null)
            {
                cultureInfo = CultureInfo.CurrentCulture;
            }
            string result = number.ToWords(cultureInfo);
            return result;
        }
    }
}
