using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Task_8_FibonacciNumbers.Presentation;

namespace Task_8_FibonacciNumbers.UnitTests
{
    [TestFixture]
    class CommandLinesAnalyzerTests
    {
        [TestCase(new string[] { "5", "5" }, 5, 5)]
        [TestCase(new string[] { "100", "200" }, 100, 200)]
        [TestCase(new string[] { "25000", "1000000" }, 25000, 1000000)]
        public void Parse_ValidArgs_ReturnValidBounds(string[] commandLines,
            int expectedLowerBound, int expectedUpperBound)
        {
            int resultLowerBound;
            int resultUpperBound;

            CommandLinesAnalyzer.Parse(commandLines, out resultLowerBound,
                out resultUpperBound);

            Assert.AreEqual(expectedLowerBound, resultLowerBound);
            Assert.AreEqual(expectedUpperBound, resultUpperBound);
        }

        [Test]
        public void Parse_InvalidArgs_ReturnArgumentException()
        {
            string[] commandLines = { "200", "100" };
            int resultLowerBound;
            int resultUpperBound;

            Assert.Catch<ArgumentException>(() => CommandLinesAnalyzer.Parse(
                commandLines, out resultLowerBound, out resultUpperBound));
        }
        [Test]
        public void Parse_InvalidArgs_ReturnArgumentOutOfRangeException()
        {
            string[] commandLines = { "100" };
            int resultLowerBound;
            int resultUpperBound;

            Assert.Catch<ArgumentOutOfRangeException>(() =>
            CommandLinesAnalyzer.Parse(commandLines,
               out resultLowerBound, out resultUpperBound));
        }
        [Test]
        public void Parse_HugeNumber_ReturnOverflowException()
        {
            string[] commandLines = { "100", "10055532231" };
            int resultLowerBound;
            int resultUpperBound;

            Assert.Catch<OverflowException>(() =>
            CommandLinesAnalyzer.Parse(commandLines,
               out resultLowerBound, out resultUpperBound));
        }
        [Test]
        public void Parse_InvalidNumber_ReturnOverflowException()
        {
            string[] commandLines = { "100a", "100551" };
            int resultLowerBound;
            int resultUpperBound;

            Assert.Catch<FormatException>(() =>
            CommandLinesAnalyzer.Parse(commandLines,
               out resultLowerBound, out resultUpperBound));
        }
    }
}
