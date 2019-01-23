using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8_FibonacciNumbers.Interfaces
{
    public interface IRange
    {
        int[] GetRange(int lowerBound, int upperBound);
    }
}
