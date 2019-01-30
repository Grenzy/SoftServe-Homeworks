using System.Collections.Generic;
using Task_8_FibonacciNumbers.BL.Interfaces;

namespace Task_8_FibonacciNumbers.BL
{
    public class FibonacciRange : IRange
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
