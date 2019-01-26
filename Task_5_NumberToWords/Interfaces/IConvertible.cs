using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5_NumberToWords.Interfaces
{
    public interface IConvertible
    {
        string NumberToWords(long number, CultureInfo cultureInfo);
    }
}
