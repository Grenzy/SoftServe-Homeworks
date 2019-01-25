using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_7_NumberSequence.Interfaces;

namespace Task_7_NumberSequence.BL
{
    public class LessThenSquareSequence : ISequence<int>
    {
        public int[] GetSequence(int upperBound)
        {
            if (upperBound < 2)
            {
                return new int[0];
            }
            int upperBoundSqrt = (int)Math.Sqrt(upperBound);

            if ((upperBound - upperBoundSqrt * upperBoundSqrt) <= double.Epsilon)
            {
                upperBoundSqrt--;
            }

            return Enumerable.Range(1, upperBoundSqrt).ToArray();
        }
    }
}
