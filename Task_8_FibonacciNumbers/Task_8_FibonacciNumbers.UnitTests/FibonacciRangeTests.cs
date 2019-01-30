using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Task_8_FibonacciNumbers.BL;

namespace Task_8_FibonacciNumbers.UnitTests
{
    [TestFixture]
    class FibonacciRangeTests
    {
        [TestCase(200000, 300000, new int[] { })]
        [TestCase(-5, 5, new int[] { 1, 1, 2, 3, 5 })]
        [TestCase(80, 121393, new int[] { 89, 144, 233, 377, 610, 987,
            1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393})]
        [TestCase(39088123, 267914309, new int[] { 39088169, 63245986,
            102334155, 165580141, 267914296 })]
        
        public void GetRange_ValidBounds_ReturnValidRange(int lowerBound,
            int upperBound, int[] expected)
        {
            FibonacciRange fibonacciRange = new FibonacciRange();

            int[] result = fibonacciRange.GetRange(lowerBound, upperBound);

            CollectionAssert.AreEqual(result, expected);
        }

    }
}
