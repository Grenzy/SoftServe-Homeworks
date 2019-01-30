using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Task_4_FileParser.BL;

namespace Task_4_FileParser.Tests
{
    [TestFixture]
    class StringSplitterTests
    {
        [TestCase("anababebaer", new int[] { 3, 7 }, 2, new string[] { "ana", "ba", "be", "ba", "er" })]
        public void SplitByIndexes_ValidParams_ReturnValidResult(string source,
            int[] indexes, int length, string[] expected)
        {
            StringSplitter stringSplitter = new StringSplitter();

            string[] result = stringSplitter.SplitByIndexes(source, indexes, length);

            CollectionAssert.AreEqual(result, expected);
        }
    }
}
