using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Task_8_FibonacciNumbers.BL;

namespace Task_8_FibonacciNumbers.UnitTests
{
    [TestFixture]
    class FibonacciNumbersTests
    {
        [TestCase(-20, 1)]
        [TestCase(1, 1)]
        [TestCase(5, 5)]
        [TestCase(4, 5)]
        [TestCase(16, 21)]
        [TestCase(240, 377)]
        [TestCase(11111, 17711)]
        [TestCase(832040, 832040)]
        [TestCase(1836301421, 1836311903)]
        public void GetNext_WhenCalled_ReturnsValidNumber(int lowerBound,
            int expected)
        {
            FibonacciNumbers fibonacciNumbers = new FibonacciNumbers(lowerBound);

            int result = fibonacciNumbers.GetNext();

            Assert.AreEqual(expected, result);
        }

        [TestCase(1836311904)]
        [TestCase(1916345904)]
        [TestCase(2116354324)]
        [TestCase(2116354324)]
        [TestCase(2147483647)]
        public void GetNext_WhenCreated_ReturnsException(int lowerBound)
        {
            FibonacciNumbers fibonacciNumbers;
            Assert.Catch<OverflowException>(() => fibonacciNumbers =
                new FibonacciNumbers(lowerBound));
        }
    }
}
