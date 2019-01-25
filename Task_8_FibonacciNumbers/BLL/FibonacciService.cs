using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8_FibonacciNumbers.Interfaces;

namespace Task_8_FibonacciNumbers.BL
{
    public class FibonacciService : IRange
    {

        public int[] GetRange(int lowerBound, int upperBound)
        {
            FibonacciNumbers fibonacci = new FibonacciNumbers(lowerBound);
            List<int> numbers = new List<int>();
            int number;
            while (true)
            {
                try
                {
                    number = fibonacci.GetNext();
                }
                catch
                {
                    break;
                }
                if (number > upperBound)
                {
                    break;
                }
                numbers.Add(number);
            }
            return numbers.ToArray();
        }
    }
}
